using Linode.Api;
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

                List<Firewall> list = await linodeClient.Firewall.Get();

                Firewall firewall = await linodeClient.Firewall.Get(list[0].Id);

                string json = JsonConvert.SerializeObject(firewall, Formatting.Indented);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
