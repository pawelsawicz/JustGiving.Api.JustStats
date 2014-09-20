using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace JustGiving.Api.JustStats.DAL
{
    public class FundraisingPageRepository
    {
        private readonly RestClient _restClient;
        private readonly IDeserializer _deserializer;
        
        public FundraisingPageRepository()
        {
            _restClient = new RestClient("https://api.justgiving.com/v1");
            _deserializer = new JsonDeserializer();
        }

        public async Task<List<Donation>> GetNewestDonations()
        {
            var result = new List<Donation>();
            var restRequest = new RestRequest("/fundraising/pages", Method.GET);
            restRequest.AddParameter("pagesize", 150);
            restRequest.AddHeader("Accept", "application/json");
            var restResult = await _restClient.ExecuteGetTaskAsync(restRequest);
            try
            {
                result = _deserializer.Deserialize<List<Donation>>(restResult);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }
    }

    public class Donation
    {
        public double? Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationRef { get; set; }
        public string DonorDisplayName { get; set; }
        public double? EstimatedTaxReclaim { get; set; }
        public int Id { get; set; }
        public string ThirdPartyReference { get; set; }
        public int CharityId { get; set; }
    }
}
