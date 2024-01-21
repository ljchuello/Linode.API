using Linode.Api;
using Linode.Api.Objets.StackScript;

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

                // Get 
                StackScript stackScript = await linodeClient.StackScript.Get(1300720);

                // Rename label
                stackScript.Label = "How to be an F1 driver for dummies (By; Valtteri Bottas)";

                // Set images, We add Ubuntu images
                stackScript.Images.Add("linode/ubuntu18.04");
                stackScript.Images.Add("linode/ubuntu20.04");
                stackScript.Images.Add("linode/ubuntu22.04");

                // Update
                stackScript = await linodeClient.StackScript.Update(stackScript);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
