using Linode.Api;
using Linode.Api.Objets.Domain;
using Linode.Api.Objets.RecordDns;

namespace Demo
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

                // Get domain
                Domain domain = await linodeClient.Domain.Get(2948568);

                // Get record DNS
                RecordDns recordDns = await linodeClient.RecordDns.Get(domain.Id, 34430418);

                // Set change
                recordDns.Target = "192.168.100.15";

                // Update
                recordDns = await linodeClient.RecordDns.Update(2948568, recordDns);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
