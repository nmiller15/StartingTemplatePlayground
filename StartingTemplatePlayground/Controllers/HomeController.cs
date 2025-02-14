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
        private readonly IRandomFactProvider _randomFactProvider2;

        public HomeController(ILogger<HomeController> logger, IContentGenerator contentGenerator, IRandomFactProvider randomFactProvider, IRandomFactProvider randomFactProvider2)
        {
            _logger = logger;
            _contentGenerator = contentGenerator;
            _randomFactProvider = randomFactProvider;
            _randomFactProvider2 = randomFactProvider2;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
