using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
            _restClient = new RestClient("https://api.justgiving.com/0f938d22/v1");
            _deserializer = new JsonDeserializer();
        }

        public async Task<List<Donation>> GetNewestDonations()
        {
            var result = new List<Donation>();
            var requestPath = string.Format("/fundraising/pages/stephen-sutton-tct/donations");
            var restRequest = new RestRequest(requestPath , Method.GET);
            restRequest.AddParameter("pageSize", 150);
            var restResult = await _restClient.ExecuteGetTaskAsync<List<Donation>>(restRequest);
            try
            {
                result = restResult.Data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }
    }

    [DataContract(Name = "donation", Namespace = "")]
    public class Donation
    {
        [DataMember(Name = "amount")]
        public decimal? Amount { get; set; }

        [DataMember(Name = "donationDate", EmitDefaultValue = false, IsRequired = false)]
        public DateTime? DonationDate { get; set; }

        //public string DonationRef { get; set; }
        //public string DonorDisplayName { get; set; }
        //public double? EstimatedTaxReclaim { get; set; }
        //public int Id { get; set; }
        //public string ThirdPartyReference { get; set; }
        //public int CharityId { get; set; }
    }
}
