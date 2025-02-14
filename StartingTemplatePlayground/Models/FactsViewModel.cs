using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace StartingTemplatePlayground.Models
{
    public class FactsViewModel
    {
        public string Fact { get; set; } = String.Empty;
        public string Fact2 { get; set; } = String.Empty;

        public FactsViewModel(string fact)
        {
            Fact = fact;
        }
        
        public FactsViewModel() { }
    }
}
