using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustGiving.Api.JustStats.DAL;

namespace JustGiving.Api.JustStats.Domain
{
    public class FundraisingPageService
    {
        private readonly FundraisingPageRepository _fundraisingPageRepository;

        public FundraisingPageService(FundraisingPageRepository fundraisingPageRepository)
        {
            _fundraisingPageRepository = fundraisingPageRepository;
        }

        public async Task<List<CalendarViewModel>> GetDonationsCountByDays()
        {
            var result = new List<CalendarViewModel>();
            var sourceOfData = await _fundraisingPageRepository.GetNewestDonations();
            result = sourceOfData.GroupBy(item => item.DonationDate.Value).Select(s => new CalendarViewModel
            {
                Count = s.Count(),
                DateTime = s.Key.ToShortDateString()
            }).ToList();
            return result;
        }

        public async Task<FundraisingPageStatictics> GetFundraisingPageStatictics()
        {
            var result = new FundraisingPageStatictics();
            var sourceOfData = await _fundraisingPageRepository.GetFundraisingPageDetails();
            result.TotalTotalRaisedPercentage = int.Parse(sourceOfData.TotalRaisedPercentageOfFundraisingTarget);
            return result;
        }
    }

    public class FundraisingPageStatictics
    {
        public int TotalTotalRaisedPercentage { get; set; }
    }

    public class CalendarViewModel
    {
        public string DateTime { get; set; }
        public int Count { get; set; }
    }
}
