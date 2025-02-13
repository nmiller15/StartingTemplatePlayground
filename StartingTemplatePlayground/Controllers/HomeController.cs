using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using StartingTemplatePlayground.Models;

namespace StartingTemplatePlayground.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentGenerator _contentGenerator;
        private readonly IRandomFactProvider _randomFactProvider;

        public HomeController(ILogger<HomeController> logger, IContentGenerator contentGenerator, IRandomFactProvider randomFactProvider)
        {
            _logger = logger;
            _contentGenerator = contentGenerator;
            _randomFactProvider = randomFactProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Content(int length = 3)
        {
            var viewModel = new ContentViewModel { Length = length };
            var content = _contentGenerator.Generate(length);
            viewModel.Content = content;
            return View(viewModel);
        }

        public IActionResult Facts()
        {
            var factType = RandomFactProvider.FactTypes.Animal;

            var viewModel = new FactsViewModel(false, null);
            viewModel.Fact = _randomFactProvider.GetFact(factType);

            return View(viewModel);
        }

        public IActionResult OtherFacts()
        {
            var factType = RandomFactProvider.FactTypes.Space;

            var viewModel = new FactsViewModel(true, factType);
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
