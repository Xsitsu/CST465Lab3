using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ArmadilloLib;

namespace Lab3.Controllers
{
    public class ArmadilloController : Controller
    {
        private Random rand = new Random();

        private string[] armadilloNames = System.IO.File.ReadLines("RandomNames.txt").ToArray();
        private ArmadilloFarm farm = new ArmadilloFarm();
        public ArmadilloController()
        {
            for (int i = 0; i < 10; i++)
            {
                string name = armadilloNames[rand.Next(1, armadilloNames.Length)];
                int age = rand.Next(2, 7);
                int shellHardness = (int)(age * 1.4) + rand.Next(1, 4);
                bool isPainted = ((age + shellHardness) % 4 == 0);

                farm.FarmAnimals.Add(new Armadillo() { Name = name, Age = age, ShellHardness = shellHardness, IsPainted = isPainted });
            }
        }
        [Route("/SearchAnimals")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(farm.FarmAnimals);
        }
        [HttpPost]
        public IActionResult Search(string name)
        {
            return View("SearchResults", farm.FarmAnimals.Where(a => a.Name.Contains(name)));
        }
    }
}