﻿// ----------------------------------------------------------------------------------
//
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



namespace Microsoft.WindowsAzure.Commands.TrafficManager.Profile
{
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Utilities.TrafficManager;
    using Microsoft.WindowsAzure.Commands.Utilities.TrafficManager.Models;

    [Cmdlet(VerbsCommon.New, "AzureTrafficManagerProfile"), OutputType(typeof(IProfileWithDefinition))]
    public class NewAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateSet("Performance", "Failover", "RoundRobin", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancingMethod { get; set; }

        [Parameter(Mandatory = true)]
        public System.Int32 MonitorPort { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string MonitorProtocol { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string MonitorRelativePath { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DomainName { get; set; }

        [Parameter(Mandatory = true)]
        public System.Int32 Ttl { get; set; }

        public override void ExecuteCmdlet()
        {
            var profile = TrafficManagerClient.NewAzureTrafficManagerProfile(
                Name,
                DomainName,
                LoadBalancingMethod,
                MonitorPort,
                MonitorProtocol,
                MonitorRelativePath,
                Ttl);

            WriteObject(profile);
        }
    }
}
