using Linode.Api;
using Linode.Api.Enums;
using Linode.Api.Objets.Domain;
using Linode.Api.Objets.LinodeInstance;
using Linode.Api.Objets.RecordDns;
using Linode.Api.Objets.Volume;
using Newtonsoft.Json;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            try
            {
                LinodeClient linodeClient = new LinodeClient("apikey");
                linodeClient = new LinodeClient(await File.ReadAllTextAsync("D:\\Linode.Api.txt"));

                // Required

                string label = "mySuperServerLinode";
                string regionId = "eu-central";
                string linodeTypeId = "g6-nanode-1";
                string imageId = "linode/debian11";
                string rootPassword = "krGNsg7oPxWTYS^q*KWL8HkHC2nJRUDjE*wT";
                
                // Optional

                // List of authorized users
                List<string> authorizedUsers = new List<string> { "LJChuello" };
                
                // List of enabled public SSH keys
                List<string> authorizedKeys = new List<string>();
                for (int i = 1; i <= 10; i++)
                {
                    // We rely on the 'SshKeyGenerator' library to generate SSH credentials.
                    SshKeyGenerator.SshKeyGenerator sshKeyGenerator = new SshKeyGenerator.SshKeyGenerator(2048);

                    // Add to list
                    authorizedKeys.Add(sshKeyGenerator.ToRfcPublicKey($"{Guid.NewGuid()}"));
                    File.WriteAllText("D:\\key.key", sshKeyGenerator.ToPrivateKey());
                }

                // If true, we indicate that backups are made by Linode
                bool backups = true;

                // If indicated, sets the firewall ID of the firewall that was specified
                long firewallId = 285728;

                // If StackScripts is set, the server executes the Stack Scripts of the specified ID
                long stackscriptId = 1278172;

                // If Private Ip is true, it enables the private IP address on the Linode
                bool privateIp = true;

                // If specified, it is a list of tags with which the Linode will be identified
                List<string> tags = new List<string> { "this", "seper", "server" };

                LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Create(
                    label,
                    regionId,
                    linodeTypeId,
                    imageId,
                    rootPassword,
                    authorizedUsers: authorizedUsers,
                    authorizedKeys: authorizedKeys,
                    backups: backups,
                    firewallId: firewallId,
                    stackscriptId: stackscriptId,
                    privateIp: privateIp,
                    tags: tags
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
