﻿// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites
{
    using System;
    using System.Collections.Generic;
    using Services.DeploymentEntities;
    using Services.WebEntities;

    public interface IWebsitesClient
    {
        /// <summary>
        /// Starts log streaming for the given website.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="path">The log path, by default root</param>
        /// <param name="message">The substring message</param>
        /// <param name="endStreaming">Predicate to end streaming</param>
        /// <param name="waitInternal">The fetch wait interval</param>
        /// <returns>The log line</returns>
        IEnumerable<string> StartLogStreaming(
            string name,
            string path,
            string message,
            Predicate<string> endStreaming,
            int waitInternal);

        /// <summary>
        /// List log paths for a given website.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<LogPath> ListLogPaths(string name);

        /// <summary>
        /// Gets the application diagnostics settings
        /// </summary>
        /// <param name="name">The website name</param>
        /// <returns>The website application diagnostics settings</returns>
        DiagnosticsSettings GetApplicationDiagnosticsSettings(string name);

        /// <summary>
        /// Restarts a website.
        /// </summary>
        /// <param name="name">The website name</param>
        void RestartWebsite(string name);

        /// <summary>
        /// Starts a website.
        /// </summary>
        /// <param name="name">The website name</param>
        void StartWebsite(string name);

        /// <summary>
        /// Stops a website.
        /// </summary>
        /// <param name="name">The website name</param>
        void StopWebsite(string name);

        /// <summary>
        /// Gets a website instance.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <returns>The website instance</returns>
        Site GetWebsite(string name);

        /// <summary>
        /// Create a new website in production.
        /// </summary>
        /// <param name="webspaceName">Web space to create site in.</param>
        /// <param name="disablesClone">Flag to control cloning the website configuration.</param>
        /// <param name="siteToCreate">Details about the site to create.</param>
        /// <returns>The created site object</returns>
        Site CreateWebsite(string webspaceName, SiteWithWebSpace siteToCreate);

        /// <summary>
        /// Create a new website in a given slot.
        /// </summary>
        /// <param name="webspaceName">Web space to create site in.</param>
        /// <param name="disablesClone">Flag to control cloning the website configuration.</param>
        /// <param name="siteToCreate">Details about the site to create.</param>
        /// <param name="slot">The slot name.</param>
        /// <returns>The created site object</returns>
        Site CreateWebsite(string webspaceName, SiteWithWebSpace siteToCreate, string slot);

        /// <summary>
        /// Update the set of host names for a website.
        /// </summary>
        /// <param name="site">The website name.</param>
        /// <param name="hostNames">The new host names.</param>
        void UpdateWebsiteHostNames(Site site, IEnumerable<string> hostNames);

        /// <summary>
        /// Update the set of host names for a website slot.
        /// </summary>
        /// <param name="site">The website name.</param>
        /// <param name="hostNames">The new host names.</param>
        /// <param name="slot">The website slot name.</param>
        void UpdateWebsiteHostNames(Site site, IEnumerable<string> hostNames, string slot);

        /// <summary>
        /// Gets the website configuration.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <returns>The website configuration object</returns>
        SiteConfig GetWebsiteConfiguration(string name);

        /// <summary>
        /// Create a git repository for the web site.
        /// </summary>
        /// <param name="webspaceName">Webspace that site is in.</param>
        /// <param name="websiteName">The site name.</param>
        void CreateWebsiteRepository(string webspaceName, string websiteName);

        /// <summary>
        /// Update the website configuration
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="newConfiguration">The website configuration object containing updates.</param>
        void UpdateWebsiteConfiguration(string name, SiteConfig newConfiguration);

        /// <summary>
        /// Update the website slot configuration
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="newConfiguration">The website configuration object containing updates.</param>
        /// <param name="slot">The website slot name</param>
        void UpdateWebsiteConfiguration(string name, SiteConfig newConfiguration, string slot);

        /// <summary>
        /// Delete a website.
        /// </summary>
        /// <param name="webspaceName">webspace the site is in.</param>
        /// <param name="websiteName">website name.</param>
        /// <param name="deleteMetrics"></param>
        /// <param name="deleteEmptyServerFarm"></param>
        void DeleteWebsite(string webspaceName, string websiteName, bool deleteMetrics = false, bool deleteEmptyServerFarm = false);

        /// <summary>
        /// Get the WebSpaces.
        /// </summary>
        /// <returns>Collection of WebSpace objects</returns>
        IList<WebSpace> ListWebSpaces();

        /// <summary>
        /// Get the sites in the given webspace
        /// </summary>
        /// <param name="spaceName">Name of webspace</param>
        /// <returns>The sites</returns>
        IList<Site> ListSitesInWebSpace(string spaceName);

        /// <summary>
        /// Get a list of the user names configured to publish to the space.
        /// </summary>
        /// <returns>The list of user names.</returns>
        IList<string> ListPublishingUserNames();

        /// <summary>
        /// Enables site diagnostic.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="webServerLogging">Flag for webServerLogging</param>
        /// <param name="detailedErrorMessages">Flag for detailedErrorMessages</param>
        /// <param name="failedRequestTracing">Flag for failedRequestTracing</param>
        void EnableSiteDiagnostic(
            string name,
            bool webServerLogging,
            bool detailedErrorMessages,
            bool failedRequestTracing);

        /// <summary>
        /// Disables site diagnostic.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="webServerLogging">Flag for webServerLogging</param>
        /// <param name="detailedErrorMessages">Flag for detailedErrorMessages</param>
        /// <param name="failedRequestTracing">Flag for failedRequestTracing</param>
        void DisableSiteDiagnostic(
            string name,
            bool webServerLogging,
            bool detailedErrorMessages,
            bool failedRequestTracing);

        /// <summary>
        /// Enables application diagnostic.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="output">The application log output, FileSystem or StorageTable</param>
        /// <param name="properties">The diagnostic setting properties</param>
        void EnableApplicationDiagnostic(
            string name,
            WebsiteDiagnosticOutput output,
            Dictionary<DiagnosticProperties, object> properties);

        /// <summary>
        /// Disables application diagnostic.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="output">The application log output, FileSystem or StorageTable</param>
        void DisableApplicationDiagnostic(string name, WebsiteDiagnosticOutput output);

        /// <summary>
        /// Sets an AppSetting of a website.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="key">The app setting name</param>
        /// <param name="value">The app setting value</param>
        void SetAppSetting(string name, string key, string value);

        /// <summary>
        /// Sets a connection string for a website.
        /// </summary>
        /// <param name="name">Name of the website.</param>
        /// <param name="key">Connection string key.</param>
        /// <param name="value">Value for the connection string.</param>
        /// <param name="connectionStringType">Type of connection string.</param>
        void SetConnectionString(string name, string key, string value, DatabaseType connectionStringType);

        /// <summary>
        /// Lists available website locations.
        /// </summary>
        /// <returns>List of location names</returns>
        List<string> ListAvailableLocations();

        /// <summary>
        /// Gets the default website DNS suffix for the current environment.
        /// </summary>
        /// <returns>The website DNS suffix</returns>
        string GetWebsiteDnsSuffix();

        /// <summary>
        /// Gets the default location for websites.
        /// </summary>
        /// <returns>The default location name.</returns>
        string GetDefaultLocation();

        /// <summary>
        /// Checks if a website exists.
        /// </summary>
        /// <param name="name">The website name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        bool WebsiteExists(string name);

        /// <summary>
        /// Checks if a website exists.
        /// </summary>
        /// <param name="name">The website name.</param>
        /// <param name="name">The website slot name.</param>
        /// <returns>True if exists, false otherwise.</returns>
        bool WebsiteExists(string name, string slot);

        /// <summary>
        /// Updates a website compute mode.
        /// </summary>
        /// <param name="websiteToUpdate">The website to update</param>
        void UpdateWebsiteComputeMode(Site websiteToUpdate);

        /// <summary>
        /// Gets a website slot DNS name.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="slot">The slot name</param>
        /// <returns>the slot DNS name</returns>
        string GetSlotDnsName(string name, string slot);

        /// <summary>
        /// Gets a website slot.
        /// </summary>
        /// <param name="Name">The website name</param>
        /// <param name="Slot">The website slot name</param>
        /// <returns>The website slot object</returns>
        Site GetWebsite(string name, string slot);

        /// <summary>
        /// Gets a website slot configuration
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="slot">The website slot name</param>
        /// <returns>The website cobfiguration object</returns>
        SiteConfig GetWebsiteConfiguration(string name, string slot);

        /// <summary>
        /// Enables application diagnostic on website slot.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="output">The application log output, FileSystem or StorageTable</param>
        /// <param name="properties">The diagnostic setting properties</param>
        /// <param name="slot">The website slot name</param>
        void EnableApplicationDiagnostic(
            string name,
            WebsiteDiagnosticOutput output,
            Dictionary<DiagnosticProperties, object> properties,
            string slot);

        /// <summary>
        /// Disables application diagnostic.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="output">The application log output, FileSystem or StorageTable</param>
        /// <param name="slot">The website slot name</param>
        void DisableApplicationDiagnostic(string name, WebsiteDiagnosticOutput output, string slot);

        /// <summary>
        /// Restarts a website.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="slot">The website slot name</param>
        void RestartWebsite(string name, string slot);

        /// <summary>
        /// Starts a website.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="slot">The website slot name</param>
        void StartWebsite(string name, string slot);

        /// <summary>
        /// Stops a website.
        /// </summary>
        /// <param name="name">The website name</param>
        /// <param name="slot">The website slot name</param>
        void StopWebsite(string name, string slot);
    }

    public enum WebsiteState
    {
        Running,
        Stopped
    }

    public enum WebsiteDiagnosticType
    {
        Site,
        Application
    }

    public enum WebsiteDiagnosticOutput
    {
        FileSystem,
        StorageTable
    }

    public enum DiagnosticProperties
    {
        StorageAccountName,
        LogLevel
    }
}
