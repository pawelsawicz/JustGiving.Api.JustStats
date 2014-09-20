using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace JustGiving.Api.JustStats.Modules
{
    public class StatisticsModule : NancyModule
    {
        public StatisticsModule()
        {
            Get["/statistics/{name}"] = parameter =>
            {
                return parameter.name;
            };
        }
    }
}
