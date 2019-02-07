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
using System.Threading;
using Microsoft.Practices.Composite.Properties;
using Microsoft.Practices.ServiceLocation;

namespace Microsoft.Practices.Composite.Regions
{
    /// <summary>
    /// Class that creates a fluent interface for the <see cref="IRegionManager"/> class, with respect to 
    /// adding views to regions (View Injection pattern), registering view types to regions (View Discovery pattern)
    /// </summary>
    public static class RegionManagerExtensions
    {
        /// <summary>
        ///     Add a view to the Views collection of a Region. Note that the region must already exist in this regionmanager. 
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to add a view to</param>
        /// <param name="view">The view to add to the views collection</param>
        /// <returns>The RegionManager, to easily add several views. </returns>
        public static IRegionManager AddToRegion(this IRegionManager regionManager, string regionName, object view)
        {
            if (!regionManager.Regions.ContainsRegionWithName(regionName))
            {
                throw new ArgumentException(
                    string.Format(Thread.CurrentThread.CurrentCulture, Resources.RegionNotFound, regionName), "regionName");
            }

            IRegion region = regionManager.Regions[regionName];

            return region.Add(view);
        }

        /// <summary>
        /// Associate a view with a region, by registering a type. When the region get's displayed
        /// this type will be resolved using the ServiceLocator into a concrete instance. The instance
        /// will be added to the Views collection of the region
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to associate the view with.</param>
        /// <param name="viewType">The type of the view to register with the </param>
        /// <returns>The regionmanager, for adding several views easily</returns>
        public static IRegionManager RegisterViewWithRegion(this IRegionManager regionManager, string regionName, Type viewType)
        {
            var regionViewRegistry = ServiceLocator.Current.GetInstance<IRegionViewRegistry>();

            regionViewRegistry.RegisterViewWithRegion(regionName, viewType);

            return regionManager;
        }

        /// <summary>
        /// Associate a view with a region, using a delegate to resolve a concreate instance of the view. 
        /// When the region get's displayed, this delelgate will be called and the result will be added to the
        /// views collection of the region. 
        /// </summary>
        /// <param name="regionManager">The regionmanager that this extension method effects.</param>
        /// <param name="regionName">The name of the region to associate the view with.</param>
        /// <param name="getContentDelegate">The delegate used to resolve a concreate instance of the view.</param>
        /// <returns>The regionmanager, for adding several views easily</returns>
        public static IRegionManager RegisterViewWithRegion(this IRegionManager regionManager, string regionName, Func<object> getContentDelegate)
        {
            var regionViewRegistry = ServiceLocator.Current.GetInstance<IRegionViewRegistry>();

            regionViewRegistry.RegisterViewWithRegion(regionName, getContentDelegate);

            return regionManager;
        }

        /// <summary>
        /// Adds a region to the regionmanager with the name received as argument.
        /// </summary>
        /// <param name="regionCollection">The regionmanager's collection of regions.</param>
        /// <param name="regionName">The name to be given to the region.</param>
        /// <param name="region">The region to be added to the regionmanager.</param>
        public static void Add(this IRegionCollection regionCollection, string regionName, IRegion region)
        {
            if (region.Name != null && region.Name != regionName)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.RegionManagerWithDifferentNameException, region.Name, regionName), "regionName");
            }

            if (region.Name == null)
            {
                region.Name = regionName;
            }

            regionCollection.Add(region);
        }
    }
}
