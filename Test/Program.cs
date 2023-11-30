using Linode.Api;
using Linode.Api.Enums;
using Linode.Api.Objets.Firewall;
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

                // Get one
                Firewall firewall = await linodeClient.Firewall.Get(280384);

                // You can delete it by passing the object as a parameter
                await linodeClient.Firewall.Delete(firewall);

                // You can also delete it by passing the ID as a parameter.
                await linodeClient.Firewall.Delete(280384);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
