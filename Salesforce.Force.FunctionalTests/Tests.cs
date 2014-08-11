using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Salesforce.Force.FunctionalTests
{

    [TestFixture]
    public class Tests
    {
        private static string _securityToken = Encoding.UTF8.GetString(Convert.FromBase64String("V1dnVGFiSEdETE5wV29SbERaYkpJOElyOQ=="));
        private static string _clientId = Encoding.UTF8.GetString(Convert.FromBase64String("M01WRzl4T0NYcTRJRDF1RUNwckh3OXlBMmVqbGE2OGI1MDk2a2hPQnFLZXdDeHVXZjNPOEJOYWc1eW0ycXJPTGxkQ2xQOFNwVTVwLkRhUmtRa19BQw=="));
        private static string _clientSecret = Encoding.UTF8.GetString(Convert.FromBase64String("NjQ3ODMyMDc4MjU1MDE1NTIwOA=="));
        private static string _username = "demo@appplat.com";
        private static string _password = Encoding.UTF8.GetString(Convert.FromBase64String("UGEkJHcwcmQh")) + _securityToken;

        [Test]
        public async Task Auth_UsernamePassword_HasToken()
        {
            var auth = new AuthenticationClient();
            await auth.UsernamePasswordAsync(_clientId, _clientSecret, _username, _password);

            Assert.IsNotNull(auth.AccessToken);
        }

        [Test]
        public async Task Query_Accounts_IsNotNull()
        {
            var auth = new AuthenticationClient();
            await auth.UsernamePasswordAsync(_clientId, _clientSecret, _username, _password);

            var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);
            var results = await client.QueryAsync<dynamic>("SELECT Id, Name, Description FROM Account");

            Assert.IsNotNull(results.records);


        }
    }
}
