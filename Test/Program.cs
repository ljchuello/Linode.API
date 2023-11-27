using Linode.Api;
using Linode.Api.Objets.Image;
using Linode.Api.Objets.LinodeType;
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

                List<Image> list = await linodeClient.Image.Get();

                Image image = await linodeClient.Image.Get("linode/almalinux8");

                string json = JsonConvert.SerializeObject(image, Formatting.Indented);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
