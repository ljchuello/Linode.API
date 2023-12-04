using Linode.Api;
using Linode.Api.Enums;
using Linode.Api.Objets.Domain;
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

                long domainId = 2872671;

                // Get
                Domain domain = await linodeClient.Domain.Get(domainId);

                // You can delete it by passing the object as a parameter
                await linodeClient.Domain.Delete(domain);

                // You can also delete it by passing the ID as a parameter.
                await linodeClient.Domain.Delete(2872671);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
