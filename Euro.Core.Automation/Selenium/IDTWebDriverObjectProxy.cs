// <copyright file="IDTWebDriverObjectProxy.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    internal abstract class IDTWebDriverObjectProxy : RealProxy
    {
        private readonly IElementLocator locator;
        private readonly IEnumerable<By> bys;
        private readonly bool cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="IDTWebDriverObjectProxy"/> class.
        /// </summary>
        /// <param name="classToProxy">The <see cref="Type"/> of object for which to create a proxy.</param>
        /// <param name="locator">The <see cref="IElementLocator"/> implementation that
        /// determines how elements are located.</param>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <param name="cache"><see langword="true"/> to cache the lookup to the element; otherwise, <see langword="false"/>.</param>
        protected IDTWebDriverObjectProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys, bool cache)
            : base(classToProxy)
        {
            this.locator = locator;
            this.bys = bys;
            this.cache = cache;
        }

        /// <summary>
        /// Gets the <see cref="IElementLocator"/> implementation that determines how elements are located.
        /// </summary>
        protected IElementLocator Locator
        {
            get { return this.locator; }
        }

        /// <summary>
        /// Gets the list of methods by which to search for the elements.
        /// </summary>
        protected IEnumerable<By> Bys
        {
            get { return this.bys; }
        }

        /// <summary>
        /// Gets a value indicating whether element search results should be cached.
        /// </summary>
        protected bool Cache
        {
            get { return this.cache; }
        }

        /// <summary>
        /// Invokes a method on the object this proxy represents.
        /// </summary>
        /// <param name="msg">Message containing the parameters of the method being invoked.</param>
        /// <param name="representedValue">The object this proxy represents.</param>
        /// <returns>The <see cref="ReturnMessage"/> instance as a result of method invocation on the
        /// object which this proxy represents.</returns>
        protected static ReturnMessage InvokeMethod(IMethodCallMessage msg, object representedValue)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg", "The message containing invocation information cannot be null");
            }

            MethodInfo proxiedMethod = msg.MethodBase as MethodInfo;
            return new ReturnMessage(proxiedMethod.Invoke(representedValue, msg.Args), null, 0, msg.LogicalCallContext, msg);
        }
    }
}
