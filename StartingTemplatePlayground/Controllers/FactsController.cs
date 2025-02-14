using Microsoft.AspNetCore.Mvc;
using Services;
using StartingTemplatePlayground.Models;

namespace StartingTemplatePlayground.Controllers;

public class FactsController : Controller
{
    private readonly TransientRandomFactGenerator _transientRandomFactGenerator1;
    private readonly TransientRandomFactGenerator _transientRandomFactGenerator2;
    private readonly SingletonRandomFactGenerator _singletonRandomFactGenerator1;
    private readonly SingletonRandomFactGenerator _singletonRandomFactGenerator2;
    private readonly ScopedRandomFactGenerator _scopedRandomFactGenerator1;
    private readonly ScopedRandomFactGenerator _scopedRandomFactGenerator2;
    
    public FactsController(
        TransientRandomFactGenerator transientRandomFactGenerator1,
        TransientRandomFactGenerator transientRandomFactGenerator2,
        SingletonRandomFactGenerator singletonRandomFactGenerator1,
        SingletonRandomFactGenerator singletonRandomFactGenerator2,
        ScopedRandomFactGenerator scopedRandomFactGenerator1,
        ScopedRandomFactGenerator scopedRandomFactGenerator2
    )
    {
        _transientRandomFactGenerator1 = transientRandomFactGenerator1;
        _transientRandomFactGenerator2 = transientRandomFactGenerator2;
        _singletonRandomFactGenerator1 = singletonRandomFactGenerator1;
        _singletonRandomFactGenerator2 = singletonRandomFactGenerator2;
        _scopedRandomFactGenerator1 = scopedRandomFactGenerator1;
        _scopedRandomFactGenerator2 = scopedRandomFactGenerator2;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Singleton");
    }

    public IActionResult Singleton()
    {
        var viewModel = new FactsViewModel();
        var fact1 = _singletonRandomFactGenerator1.GetFact(RandomFactProvider.FactTypes.Space);
        var fact2 = _singletonRandomFactGenerator2.GetFact(RandomFactProvider.FactTypes.Animal);
        viewModel.Fact = fact1;
        viewModel.Fact2 = fact2;
        ViewData["Title"] = "Singleton";
        return View(viewModel);
    }
    
    public IActionResult Transient()
    {
        var viewModel = new FactsViewModel();
        var fact1 = _transientRandomFactGenerator1.GetFact(RandomFactProvider.FactTypes.Space);
        var fact2 = _transientRandomFactGenerator2.GetFact(RandomFactProvider.FactTypes.Animal);
        viewModel.Fact = fact1;
        viewModel.Fact2 = fact2;
        ViewData["Title"] = "Transient";
        return View(viewModel);
    }
    
    public IActionResult Scoped()
    {
        var viewModel = new FactsViewModel();
        var fact1 = _scopedRandomFactGenerator1.GetFact(RandomFactProvider.FactTypes.Space);
        var fact2 = _scopedRandomFactGenerator2.GetFact(RandomFactProvider.FactTypes.Animal);
        viewModel.Fact = fact1;
        viewModel.Fact2 = fact2;
        ViewData["Title"] = "Scoped";
        return View(viewModel);
    }
}