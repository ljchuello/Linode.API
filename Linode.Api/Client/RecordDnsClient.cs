using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Enums;
using Linode.Api.Objets.RecordDns;
using Linode.Api.Objets.RecordDns.Get;
using Linode.Api.Objets.Domain;

namespace Linode.Api.Client
{
    public class RecordDnsClient
    {
        private readonly string _token;

        public RecordDnsClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns a paginated list of Records configured on a Domain in Linode’s DNS Manager.
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public async Task<List<RecordDns>> Get(long domainId)
        {
            List<RecordDns> list = new List<RecordDns>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/domains/{domainId}/records?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (RecordDns row in response.Data)
                {
                    list.Add(row);
                }

                // Finish?
                if (response.Page >= response.Pages)
                {
                    // Yes, finish
                    return list;
                }
            }
        }

        /// <summary>
        /// View a single Record on this Domain.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RecordDns> Get(long domainId, long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/domains/{domainId}/records/{id}");

            // Set
            RecordDns recordDns = JsonConvert.DeserializeObject<RecordDns>(json) ?? new RecordDns();

            // Return
            return recordDns;
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateA(long domainId, string name, string target, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.A;
            recordDns.Name = name;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Tag = null;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateAAAA(long domainId, string name, string target, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.AAAA;
            recordDns.Name = name;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Tag = null;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateCNAME(long domainId, string name, string target, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.CNAME;
            recordDns.Name = name;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Tag = null;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateTXT(long domainId, string name, string target, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.TXT;
            recordDns.Name = name;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Tag = null;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateMX(long domainId, string name, string target, long priority, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.MX;
            recordDns.Name = name;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Priority = priority;
            recordDns.Tag = null;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="protocol"></param>
        /// <param name="priority"></param>
        /// <param name="weight"></param>
        /// <param name="port"></param>
        /// <param name="target"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateSRV(long domainId, string name, string protocol, long priority, long weight, long port, string target, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.SRV;
            recordDns.Service = name;
            recordDns.Protocol = protocol;
            recordDns.Priority = priority;
            recordDns.Weight = weight;
            recordDns.Port = port;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Tag = null;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Adds a new Domain Record to the zonefile this Domain represents.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="tag"></param>
        /// <param name="target"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<RecordDns> CreateCAA(long domainId, string name, string tag, string target, long ttl)
        {
            // Object
            RecordDns recordDns = new RecordDns();
            recordDns.Type = RecordDnsType.CAA;
            recordDns.Name = name;
            recordDns.Target = target;
            recordDns.TtlSec = ttl;
            recordDns.Tag = tag;

            // Preparing raw
            string raw = JsonConvert.SerializeObject(recordDns, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }

        /// <summary>
        /// Deletes a Record on this Domain.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task Delete(long domainId, long recordId)
        {
            await Core.SendDeleteRequest(_token, $"/domains/{domainId}/records/{recordId}");
        }

        /// <summary>
        /// Deletes a Record on this Domain.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordDns"></param>
        /// <returns></returns>
        public async Task Delete(long domainId, RecordDns recordDns)
        {
            await Delete(domainId, recordDns.Id);
        }
    }
}
