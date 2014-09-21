using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using JustGiving.Api.JustStats.Domain;
using Nancy;

namespace JustGiving.Api.JustStats.Modules
{
    public class StatisticsModule : NancyModule
    {
        private readonly FundraisingPageService _fundraisingPageService;

        public StatisticsModule(FundraisingPageService fundraisingPageService)
        {
            _fundraisingPageService = fundraisingPageService;

            Get["/statistics/{name}", true] = async (x, ct) =>
            {
                return await _fundraisingPageService.GetDonationsCountByDays();
            };

            Get["/statistics/{name}/calendar", true] = async (x, ct) =>
            {
                var model = await _fundraisingPageService.GetDonationsCountByDays();
                return View["Calendar", model];
            };
        }

        
    }
}
