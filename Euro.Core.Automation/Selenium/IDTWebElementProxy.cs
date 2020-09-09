// <copyright file="IDTWebElementProxy.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using OpenQA.Selenium.Support.PageObjects;

    internal class IDTWebElementProxy : IDTWebDriverObjectProxy, IWrapsElement
    {
        private IWebElement cachedElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="IDTWebElementProxy"/> class.
        /// </summary>
        /// <param name="classToProxy">The <see cref="Type"/> of object for which to create a proxy.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that determines
        /// how elements are located.</param>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <param name="cache"><see langword="true"/> to cache the lookup to the element; otherwise, <see langword="false"/>.</param>
        private IDTWebElementProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cache)
            : base(classToProxy, locator, bys, cache)
        {
        }

        /// <summary>
        /// Gets the <see cref="IWebElement"/> wrapped by this object.
        /// </summary>
        public IWebElement WrappedElement
        {
            get { return this.Element; }
        }

        /// <summary>
        /// Gets the IWebElement object this proxy represents, returning a cached one if requested.
        /// </summary>
        private IWebElement Element
        {
            get
            {
                if (!this.Cache || this.cachedElement == null)
                {
                    this.cachedElement = this.Locator.LocateElement(this.Bys);
                }

                return this.cachedElement;
            }
        }

        /// <summary>
        /// Creates an object used to proxy calls to properties and methods of an <see cref="IWebElement"/> object.
        /// </summary>
        /// <param name="classToProxy">The <see cref="Type"/> of object for which to create a proxy.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <param name="cacheLookups"><see langword="true"/> to cache the lookup to the element; otherwise, <see langword="false"/>.</param>
        /// <returns>An object used to proxy calls to properties and methods of the list of <see cref="IWebElement"/> objects.</returns>
        public static object CreateProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cacheLookups)
        {
            return new IDTWebElementProxy(classToProxy, locator, bys, cacheLookups).GetTransparentProxy();
        }

        /// <summary>
        /// Invokes the method that is specified in the provided <see cref="IMessage"/> on the
        /// object that is represented by the current instance.
        /// </summary>
        /// <param name="msg">An <see cref="IMessage"/> that contains a dictionary of
        /// information about the method call. </param>
        /// <returns>The message returned by the invoked method, containing the return value and any
        /// out or ref parameters.</returns>
        public override IMessage Invoke(IMessage msg)
        {
            var element = this.Element;
            IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;

            if (typeof(IWrapsElement).IsAssignableFrom((methodCallMessage.MethodBase as MethodInfo).DeclaringType))
            {
                return new ReturnMessage(element, null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
            }

            return IDTWebDriverObjectProxy.InvokeMethod(methodCallMessage, element);
        }
    }
}
