﻿// ----------------------------------------------------------------------------------
//
// Copyright 2011 Microsoft Corporation
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

namespace Microsoft.WindowsAzure.Management.Websites.Services.Github
{
    using Microsoft.WindowsAzure.Management.Websites.Services.Github.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using WebEntities;

    /// <summary>
    /// Provides the Github Api. 
    /// </summary>
    [ServiceContract]
    public interface IGithubServiceManagement
    {
        [Description("Gets the members for an organization")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/users/{user}/repos", ResponseFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetRepositoriesFromUser(string user, AsyncCallback callback, object state);
        IList<GithubRepository> EndGetRepositoriesFromUser(IAsyncResult asyncResult);
    }
}
