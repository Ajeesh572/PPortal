// <copyright file="GmailManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Google.Apis.Gmail.v1;
    using Google.Apis.Gmail.v1.Data;

    public class GmailManager
    {
        /// <summary>
        /// This query is used to filter the emails. e.g. "subject:MVNO", will filter all the emails with the subject MVNO.
        /// More information on: https://support.google.com/mail/answer/7190?hl=en
        /// </summary>
        private string query;

        private GmailService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GmailManager"/> class.
        /// GmailService Constructor.
        /// </summary>
        /// <param name="filterBy">Filter</param>
        /// <param name="parameter">Value of the filter</param>
        public GmailManager(string filterBy, string parameter)
        {
            this.query = $"{filterBy}:{parameter}";
            this.service = ServiceCreation.GetInstance().GetService();
        }

        /// <summary>
        /// The method allows to extract a portion of text from the last mail received
        /// </summary>
        /// <param name="regex">regex string (starts with @ i.e. '@"\b\d{4}\b"') will return a 4 digit number</param>
        /// <returns>The portion of the </returns>
        public string ExtractMessageByRegex(string regex)
        {
            Message firstMessage = this.ListMessages().FirstOrDefault();

            string snippetMessage = this.service.Users.Messages.Get(ServiceCreation.GetUserId(), firstMessage.Id).Execute().Snippet;

            return string.Join(string.Empty, Regex.Matches(snippetMessage, regex).OfType<Match>().Select(m => m.Value));
        }

        /// <summary>
        /// Generates a list of all received messages.
        /// </summary>
        /// <returns>a list of messages.</returns>
        private List<Message> ListMessages()
        {
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = this.service.Users.Messages.List(ServiceCreation.GetUserId());
            request.Q = this.query;
            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    throw new Exception("An error occurred: " + e.Message);
                }
            } while (!string.IsNullOrEmpty(request.PageToken));

            return result;
        }
    }
}
