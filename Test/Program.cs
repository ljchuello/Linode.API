using Linode.Api;
using Linode.Api.Enums;
using Linode.Api.Objets.Domain;
using Linode.Api.Objets.Firewall;
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

                Firewall firewall = await linodeClient.Firewall.Get(2857258);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
