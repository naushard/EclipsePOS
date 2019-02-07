//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Globalization;
using Microsoft.Practices.Composite.Properties;

namespace Microsoft.Practices.Composite.Events
{
    /// <summary>
    /// Provides a way to retrieve a <see cref="Delegate"/> to execute an action dependending
    /// on the value of a second filter predicate that returns true if the action should execute.
    /// </summary>
    /// <typeparam name="TPayload">The type to use for the generic <see cref="System.Action{TPayload}"/> and <see cref="Predicate{TPayload}"/> types.</typeparam>
    public class EventSubscription<TPayload> : IEventSubscription
    {
        private readonly IDelegateReference _actionReference;
        private readonly IDelegateReference _filterReference;

        ///<summary>
        /// Creates a new instance of <see cref="EventSubscription{TPayload}"/>.
        ///</summary>
        ///<param name="actionReference">A reference to a delegate of type <see cref="System.Action{TPayload}"/>.</param>
        ///<param name="filterReference">A reference to a delegate of type <see cref="Predicate{TPayload}"/>.</param>
        ///<exception cref="ArgumentNullException">When <paramref name="actionReference"/> or <see paramref="filterReference"/> are <see langword="null" />.</exception>
        ///<exception cref="ArgumentException">When the target of <paramref name="actionReference"/> is not of type <see cref="System.Action{TPayload}"/>,
        ///or the target of <paramref name="filterReference"/> is not of type <see cref="Predicate{TPayload}"/>.</exception>
        public EventSubscription(IDelegateReference actionReference, IDelegateReference filterReference)
        {
            if (actionReference == null)
                throw new ArgumentNullException("actionReference");
            if (!(actionReference.Target is Action<TPayload>))
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidDelegateRerefenceTypeException, typeof(Action<TPayload>).FullName), "actionReference");

            if (filterReference == null)
                throw new ArgumentNullException("filterReference");
            if (!(filterReference.Target is Predicate<TPayload>))
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidDelegateRerefenceTypeException, typeof(Predicate<TPayload>).FullName), "filterReference");

            _actionReference = actionReference;
            _filterReference = filterReference;
        }

        /// <summary>
        /// Gets the target <see cref="System.Action{T}"/> that is referenced by the <see cref="IDelegateReference"/>.
        /// </summary>
        /// <value>An <see cref="System.Action{T}"/> or <see langword="null" /> if the referenced target is not alive.</value>
        public Action<TPayload> Action
        {
            get { return (Action<TPayload>)_actionReference.Target; }
        }

        /// <summary>
        /// Gets the target <see cref="Predicate{T}"/> that is referenced by the <see cref="IDelegateReference"/>.
        /// </summary>
        /// <value>An <see cref="Predicate{T}"/> or <see langword="null" /> if the referenced target is not alive.</value>
        public Predicate<TPayload> Filter
        {
            get { return (Predicate<TPayload>)_filterReference.Target; }
        }

        /// <summary>
        /// Gets or sets a <see cref="Microsoft.Practices.Composite.Events.SubscriptionToken"/> that identifies this <see cref="IEventSubscription"/>.
        /// </summary>
        /// <value>A token that identifies this <see cref="IEventSubscription"/>.</value>
        public SubscriptionToken SubscriptionToken { get; set; }

        /// <summary>
        /// Gets the execution strategy to publish this event.
        /// </summary>
        /// <returns>An <see cref="System.Action{T}"/> with the execution strategy, or <see langword="null" /> if the <see cref="IEventSubscription"/> is no longer valid.</returns>
        /// <remarks>
        /// If <see cref="Action"/> or <see cref="Filter"/> are no longer valid because they were
        /// garbage collected, this method will return <see langword="null" />.
        /// Otherwise it will return a delegate that evaluates the <see cref="Filter"/> and if it
        /// returns <see langword="true" /> will then call <see cref="InvokeAction"/>. The returned
        /// delegate holds hard references to the <see cref="Action"/> and <see cref="Filter"/> target
        /// <see cref="Delegate">delegates</see>. As long as the returned delegate is not garbage collected,
        /// the <see cref="Action"/> and <see cref="Filter"/> references delegates won't get collected either.
        /// </remarks>
        public virtual Action<object[]> GetExecutionStrategy()
        {
            Action<TPayload> action = this.Action;
            Predicate<TPayload> filter = this.Filter;
            if (action != null && filter != null)
            {
                return arguments =>
                           {
                               TPayload argument = default(TPayload);
                               if (arguments != null && arguments.Length > 0 && arguments[0] != null)
                               {
                                   argument = (TPayload)arguments[0];
                               }
                               if (filter(argument))
                               {
                                   InvokeAction(action, argument);
                               }
                           };
            }
            return null;
        }

        /// <summary>
        /// Invokes the specified <see cref="System.Action{TPayload}"/> synchronously when not overriden.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="argument">The payload to pass <paramref name="action"/> while invoking it.</param>
        public virtual void InvokeAction(Action<TPayload> action, TPayload argument)
        {
            action(argument);
        }
    }
}