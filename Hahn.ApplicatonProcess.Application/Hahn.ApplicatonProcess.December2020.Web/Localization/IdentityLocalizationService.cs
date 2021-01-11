using Microsoft.Extensions.Localization;
using System.Reflection;
namespace Hahn.ApplicatonProcess.December2020.Web.Localization
{
    public class IdentityLocalizationService
    {
        public class IdentityResource
        {
        }

        private readonly IStringLocalizer _localizer;
        public IdentityLocalizationService(IStringLocalizerFactory factory)
        {
            var type = typeof(IdentityResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("IdentityResource", assemblyName.Name);
        }
        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }
        public LocalizedString GetLocalizedHtmlString(string key, string parameter)
        {
            return _localizer[key, parameter];
        }
    }
   
}
