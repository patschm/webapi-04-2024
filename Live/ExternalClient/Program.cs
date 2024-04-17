using System.Net.Http.Headers;
using Microsoft.Identity.Client;

internal class Program
{
    private static string ServiceUrl = "https://localhost:7290/";
    private static async Task Main(string[] args)
    {
        //await DoTheCodeFlowAsync();
        await DoTheCredentialFlowAsync();
        
        Console.ReadLine();
    }

    private static async Task DoTheCodeFlowAsync()
    {
        // To make this work do the following:
        // 1) Create an application registration for platform Mobile and Desktop Application.
        //    This prepares Code Grant Flow
        // 2) Set Redirect Uri to http://localhost (must be http. Port is optional)
        var bld = PublicClientApplicationBuilder
            .Create("61039648-36d6-40d5-ae0b-294d4ad2211c")
            .WithAuthority(AzureCloudInstance.AzurePublic, "030b09d5-7f0f-40b0-8c01-03ac319b2d71")
            .WithRedirectUri("http://localhost:9898/");  // http scheme only!

        var app = bld.Build();
        // .AcquireTokenByUsernamePassword
        var response = await app.AcquireTokenInteractive(
            new string[] { "api://61039648-36d6-40d5-ae0b-294d4ad2211c/Leest" })
            .ExecuteAsync();

        Console.WriteLine(response.AccessToken);

        var client = new HttpClient();
        client.BaseAddress = new Uri(ServiceUrl);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", response.AccessToken);

        string data = await client.GetStringAsync("weatherforecast");
        Console.WriteLine(data);
    }
    private static async Task DoTheCredentialFlowAsync()
    {
        // To make this work do the following:
        // 1) On the application registration of the webapi define an App Role
        //    for Application. 
        // 2) Create a new Application Registration for the servie app.
        //    a) Certificates & secrets: Generate a new Client Secret
        //    b) API permissions: Add Permission -> My Apis -> Select your webapi registration.
        //    c) Select Application Permissions (if disabled you forgot or wrongly did step 1)
        //    d) Select the roles you defined in webapi registration
        //    e) Grant Admin consent on the newly created permission.
        var app = ConfidentialClientApplicationBuilder
            .Create("61039648-36d6-40d5-ae0b-294d4ad2211c")
            .WithTenantId("030b09d5-7f0f-40b0-8c01-03ac319b2d71")
            .WithClientSecret("Token hier");

        var token = await app.Build()
            .AcquireTokenForClient(
                new string[]{ "api://61039648-36d6-40d5-ae0b-294d4ad2211c/.default" }) // Api ID Uri from webapi regstration. Add /.default to it
            .ExecuteAsync();
        Console.WriteLine(token.AccessToken);

        var client = new HttpClient();
        client.BaseAddress = new Uri(ServiceUrl);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token.AccessToken);

        string data = await client.GetStringAsync("weatherforecast");
        Console.WriteLine(data);
    }
}