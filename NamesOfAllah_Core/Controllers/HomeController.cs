using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NamesOfAllah_Core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
           // ViewData["Names"] = (new namesOfAllah.Models.Names()).ListOfNames.ToList();

            return View();
        }

        public IActionResult Contact(string name)
        {
            ViewData["name"] = name;
            namesOfAllah.Models.Names Names = new namesOfAllah.Models.Names();
            KeyValuePair<string, namesOfAllah.Models.Name> currName = Names.ListOfNames.First((kvp) =>
            {
                if (kvp.Key.Contains(name))
                    return true;
                else
                    return false;
            });
            ViewData["description"] = currName.Value.Description;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
