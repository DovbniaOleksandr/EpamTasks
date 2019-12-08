using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FilesInspector
{
    public static class OneDriveFiles 
    {
        public static async Task<Stream> GetFileFromOneDriveAsync()
        {
            IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
                        .Create("5cd44a93-b9bd-48cf-b99b-772cd08aa0e0")
                        .WithRedirectUri("http://localhost")
                        .Build();

            var authProvider = new InteractiveAuthenticationProvider(publicClientApplication, new[] { "Files.read" });

            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var stream = await graphClient.Me.Drive.Items["32079BA26B2E1768!685"].Content
                .Request()
                .GetAsync();

            return stream;
        }
    }
}
