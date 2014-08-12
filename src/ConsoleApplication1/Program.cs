using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salesforce.Force;

namespace ConsoleApplication1
{
    class Program
    {
        private static string _securityToken = Encoding.UTF8.GetString(Convert.FromBase64String("V1dnVGFiSEdETE5wV29SbERaYkpJOElyOQ=="));
        private static string _clientId = Encoding.UTF8.GetString(Convert.FromBase64String("M01WRzl4T0NYcTRJRDF1RUNwckh3OXlBMmVqbGE2OGI1MDk2a2hPQnFLZXdDeHVXZjNPOEJOYWc1eW0ycXJPTGxkQ2xQOFNwVTVwLkRhUmtRa19BQw=="));
        private static string _clientSecret = Encoding.UTF8.GetString(Convert.FromBase64String("NjQ3ODMyMDc4MjU1MDE1NTIwOA=="));
        private static string _username = "demo@appplat.com";
        private static string _password = Encoding.UTF8.GetString(Convert.FromBase64String("UGEkJHcwcmQh")) + _securityToken;

        static void Main(string[] args)
        {
            var auth = new AuthenticationClient();
            auth.UsernamePasswordAsync(_clientId, _clientSecret, _username, _password).Wait();

            var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
            var results =  client.QueryAsync<dynamic>("SELECT Id, Name, Description FROM Account");
            results.Wait();

            Console.WriteLine(results.Result.records.Count);
        }
    }
}
