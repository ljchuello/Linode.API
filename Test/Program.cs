﻿using Linode.Api;
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

                List<LinodeType> list = await linodeClient.LinodeType.Get();

                LinodeType linodeType = await linodeClient.LinodeType.Get("g7-highmem-2");

                string json = JsonConvert.SerializeObject(linodeType, Formatting.Indented);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}