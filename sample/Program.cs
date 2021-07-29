using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace samples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string clientId = "e938ec06-1233-4fa4-9609-62e40712be13",  
                         clientSecret = "7-h3X.0_ecN2DPgGu9VD.jbCr.k54qXM22",
                         environment = "enabler.crm6";

            var connectionString = @$"Url=https://{environment}.dynamics.com;AuthType=ClientSecret;ClientId={clientId};ClientSecret={clientSecret};RequireNewInstance=true";

            using var serviceClient = new ServiceClient(connectionString);

            var contactCollection = await serviceClient.RetrieveMultipleAsync(new QueryExpression("contact")
            {
                ColumnSet = new ColumnSet("fullname"),
                TopCount = 5
            });
            Console.WriteLine(string.Join("\n",
                contactCollection.Entities
                    .Select(x => $"{x.GetAttributeValue<string>("fullname")}, {x.Id}")));
        }
    }
}