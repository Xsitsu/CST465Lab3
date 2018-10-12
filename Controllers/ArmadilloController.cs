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

        private string[] armadilloNames =
        {
            "Thaoztitl",
            "V'elth'thax",
            "Thictoxr",
            "Grodrri",
            "Dioll'rorh",
            "Ynuld'endess",
            "Uctaioghal",
            "Ainodrux",
            "Engyjharc",
            "Ukhebrerh",
            "Ngervi",
            "Mhaojhust",
            "Vathleth",
            "Shoudhi",
            "Kopex",
            "Umliognnast",
            "Ishoudri",
            "Ezuthr'zha",
            "Uxughi",
            "Ukthouggd'ithuh"
        };
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
        public IActionResult Index()
        {
            return View();
        }
        IEnumerable[Armadillo]
        public IActionResult List()
        {
            return View();
        }
    }
}