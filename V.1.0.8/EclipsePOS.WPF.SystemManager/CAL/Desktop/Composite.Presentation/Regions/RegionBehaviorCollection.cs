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
using System.Collections;
using System.Collections.Generic;
using Microsoft.Practices.Composite.Regions;

namespace Microsoft.Practices.Composite.Presentation.Regions
{
    /// <summary>
    /// A collection of <see cref="IRegionBehavior"/> instances, that are stored and retrieved by Key.
    /// </summary>
    public class RegionBehaviorCollection : IRegionBehaviorCollection
    {
        private readonly IRegion region;
        private readonly Dictionary<string, IRegionBehavior> behaviors = new Dictionary<string, IRegionBehavior>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionBehaviorCollection"/> class and associates it with a region.
        /// </summary>
        /// <param name="region">The region to associate the behavior collection with.</param>
        public RegionBehaviorCollection(IRegion region)
        {
            this.region = region;
        }

        /// <summary>
        /// Gets the <see cref="Microsoft.Practices.Composite.Regions.IRegionBehavior"/> with the specified key.
        /// </summary>
        /// <value>The RegionBehavior that's registered with the key.</value>
        public IRegionBehavior this[string key]
        {
            get { return this.behaviors[key]; }
        }

        /// <summary>
        /// Adds a <see cref="IRegionBehavior"/> to the collection, using the specified key as an indexer.
        /// </summary>
        /// <param name="key">The key that specifies the type of <see cref="IRegionBehavior"/> that's added.</param>
        /// <param name="regionBehavior">The <see cref="IRegionBehavior"/> to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown is the <paramref name="key"/> parameter is Null, 
        /// or if the <paramref name="regionBehavior"/> parameter is Null.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if a behavior with the specified Key parameter already exists.</exception>
        public void Add(string key, IRegionBehavior regionBehavior)
        {
            if (key == null) 
                throw new ArgumentNullException("key");

            if (regionBehavior == null) 
                throw new ArgumentNullException("regionBehavior");

            if (this.behaviors.ContainsKey(key))
                throw new  ArgumentException("Could not add duplicate behavior with same key.", "key");

            this.behaviors.Add(key, regionBehavior);
            regionBehavior.Region = this.region;

            regionBehavior.Attach();
        }

        /// <summary>
        /// Checks if a <see cref="IRegionBehavior"/> with the specified key is already present.
        /// </summary>
        /// <param name="key">The key to use to find a particular <see cref="IRegionBehavior"/>.</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return this.behaviors.ContainsKey(key);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, IRegionBehavior>> GetEnumerator()
        {
            return behaviors.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return behaviors.GetEnumerator();
        }
    }
}
