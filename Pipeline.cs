using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
class Pipeline {
    public IDataFactoryManagementClient client;
    //private string applicationId = "";
    //private string clientSecret = "";
    //private string subscriptionId = "";
    //private string tenantID = "";

    private string applicationId = "930fd88e-104b-4cf0-bf16-254de8dd41b2";
    private string clientSecret = "b6aa7658-ef42-4015-a929-d80ba8a7ae4b";
    private string subscriptionId = "47587519-96f3-4a80-90c6-e237a3df7233";
    private string tenantID = "ae65f568-0ceb-42c2-9dda-731b9c16e6b4";


    public void CreateAdfClient() {
        // Authenticate and create a data factory management client
        var context = new AuthenticationContext("https://login.windows.net/" + tenantID);
        var ClientCredential = new ClientCredential(applicationId, clientSecret);

        var result = context.AcquireTokenAsync(
            "https://management.azure.com/", ClientCredential).Result;

        var cred = new TokenCredentials(result.AccessToken);
        client = new DataFactoryManagementClient(cred) {
            SubscriptionId = subscriptionId
        };
    }

    public Pipeline() {
        CreateAdfClient();
    }

    public void StartPipeline(string resourceGroup, string dataFactoryName, string pipelineName) {
        Console.WriteLine("Creating pipeline run...");

        var runResponse = client.Pipelines.CreateRunWithHttpMessagesAsync(resourceGroup, dataFactoryName, pipelineName).Result.Body;

        Console.WriteLine("Pipeline run ID: " + runResponse.RunId);
    }
}