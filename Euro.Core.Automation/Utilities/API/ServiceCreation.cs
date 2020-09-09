// <copyright file="ServiceCreation.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.API
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Threading;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Gmail.v1;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;

    /// <summary>
    /// The class is in charge to set and return a GmailService.
    /// </summary>
    public sealed class ServiceCreation
    {
        private const string JSONFILE = "client_secret.json";
        private const string CREDENTIALPATH = ".credentials/gmail-dotnet-quickstart.json";
        private static string[] Scopes = { GmailService.Scope.GmailReadonly };
        private static string ApplicationName = "Gmail API .NET";

        private static ServiceCreation instance;
        private static string emailAddress = ConfigurationManager.AppSettings["EMAIL_ADDRESS"];
        private GmailService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCreation"/> class.
        /// ServiceCreation Constructor.
        /// </summary>
        private ServiceCreation()
        {
            this.service = this.CreateGmailAPIService(this.Initialize());
        }

        /// <summary>
        /// Returns the instance of the ServiceCreation class.
        /// </summary>
        /// <returns>a ServiceCreation instance</returns>
        public static ServiceCreation GetInstance()
        {
            if (instance == null)
            {
                instance = new ServiceCreation();
            }

            return instance;
        }

        /// <summary>
        /// Return the UserId (user mail)
        /// </summary>
        /// <returns>userId as string</returns>
        public static string GetUserId()
        {
            return emailAddress;
        }

        /// <summary>
        /// Returns the actual value of the service attribute.
        /// </summary>
        /// <returns>a GmailService value.</returns>
        public GmailService GetService()
        {
            return this.service;
        }

        /// <summary>
        /// Initializes the credential attribute.
        /// </summary>
        /// <returns>a UserCredential value.</returns>
        private UserCredential Initialize()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(JSONFILE, FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, CREDENTIALPATH);

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }

        /// <summary>
        /// Creates Gmail API service.
        /// </summary>
        /// <param name="credential">The credential of the user.</param>
        /// <returns>a new GmailService.</returns>
        private GmailService CreateGmailAPIService(UserCredential credential)
        {
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
    }
}
