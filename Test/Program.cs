using Linode.Api;
using Linode.Api.Enums;
using Linode.Api.Objets.Domain;
using Linode.Api.Objets.RecordDns;
using Linode.Api.Objets.Volume;

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

                long domainId = 2873263;

                // Get one
                RecordDns recordDns = await linodeClient.RecordDns.CreateIPv4(domainId, $"{Guid.NewGuid()}", "192.168.100.99", 30);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
