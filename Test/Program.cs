using Linode.Api;
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

                // Get volume
                Volume volume = await linodeClient.Volume.Get(2035297);

                // You can delete it by passing the object as a parameter
                await linodeClient.Volume.Delete(volume);

                // You can also delete it by passing the ID as a parameter.
                await linodeClient.Volume.Delete(2035297);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
