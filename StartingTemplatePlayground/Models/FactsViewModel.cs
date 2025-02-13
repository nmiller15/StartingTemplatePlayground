using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace StartingTemplatePlayground.Models
{
    public class FactsViewModel
    {
        private readonly IRandomFactProvider _factProvider = null;

        public string Fact { get; set; } = String.Empty;

        public bool ProviderHasBeenUsed = false;

        public bool InternalFactProviderUsed = false;

        public FactsViewModel(bool usesInternal, RandomFactProvider.FactTypes? factType)
        {
            if (usesInternal && factType != null)
            {
                IRandomFactProvider factProvider = new RandomFactProvider();
                _factProvider = factProvider;
                InternalFactProviderUsed = true;
                Fact = _factProvider.GetFact(factType.GetValueOrDefault());
            }
        }
    }
}
