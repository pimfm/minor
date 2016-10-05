using Microsoft.AspNetCore.Mvc;
using Minor_Dag18.Entities;
using Minor_Dag18.Services.Agents;
using System.Collections.Generic;

namespace Minor_Dag18.Controllers
{
    public class MonumentController : Controller
    {
        private IMonumentAgent _agent;

        public MonumentController(IMonumentAgent agent)
        {
            _agent = agent;
        }

        public ViewResult Index()
        {
            List<Monument> model = new List<Monument>();

            return View(model);
        }
    }
}