using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ViewEngines.Razor;

namespace JustGiving.Api.JustStats.CustomConfigs
{
    public class RazorConfig : IRazorConfiguration
    {
        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }

        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "Nancy.ViewEngines.Razor";
            yield return "JustGiving.Api.JustStats";
            yield return "JustGiving.Api.JustStats.Domain";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Nancy.ViewEngines.Razor";
            yield return "JustGiving.Api.JustStats";
            yield return "JustGiving.Api.JustStats.Domain";
        }
    }
}
