using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isen.Dotnet.Web.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Models.Implementation;

namespace Isen.Dotnet.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityRepository _repository;

        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }

        public IActionResult Detail(int? id)
        {
            // Pas d'id > form vide (création)
            if (id == null) return View();
            // Récupérer la ville et la passer à la vue
            var model = _repository.Single(id.Value);
            return View(model);
        }

        [HttpPost]
        public IActionResult Detail(City model)
        {
            _repository.Update(model);
            return RedirectToAction("Index");
        }
    }
}
