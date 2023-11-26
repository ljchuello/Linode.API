using Linode.Api;
using Linode.Api.Objets.Region;
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

                List<Region> list = await linodeClient.Region.Get();

                Region region = await linodeClient.Region.Get(list[0].Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
