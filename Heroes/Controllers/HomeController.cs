﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Heroes.Game;


namespace Heroes.Controllers
{

    public class HomeController : Controller
    {
        static Dictionary<String, Player> Players = new Dictionary<String, Player>();
        [NonAction]
        public void StartFight(List<Game.Player> players, string type)
        {
            Game.Player P1 = players[0]; //P1 atakujacy
            Game.Player P2 = players[1];
            P1.Fight(P2, type);
        }

        public IActionResult Fight()
        {

            var players = PlayersList();

            return View(players);


        }
        //zmienic na 1 funkcje

        public IActionResult AttackArcher()
        {

            var players = PlayersList();
            StartFight(players, "A");
            ViewData["Message"] = "archer";
            return View(players);


        }


        public IActionResult AttackKnight()
        {


            var players = PlayersList();
            StartFight(players, "K");
            ViewData["Message"] = "knight";
            return View(players);


        }
        public IActionResult AttackGryphon()
        {

            var players = PlayersList();
            StartFight(players, "G");
            ViewData["Message"] = "gryph";
            return View(players);


        }


        public IActionResult AttackDragon()
        {


            var players = PlayersList();
            StartFight(players, "D");
            ViewData["Message"] = "dragon";
            return View(players);


        }


        [NonAction]
        public List<Game.Player> PlayersList()
        {
            if (Game.test.MyGlobalVariable1 == null)
            {
                Game.Player P1 = new Game.Player("1");
                Game.Player P2 = new Game.Player("2");  //stworzenie 2 graczy do testow  
                Game.test.MyGlobalVariable1 = P1;
                Game.test.MyGlobalVariable1.PlayerArmy.Archers.AddReinforcements(19);
                Game.test.MyGlobalVariable1.PlayerArmy.Knights.AddReinforcements(19);
                Game.test.MyGlobalVariable1.PlayerArmy.Dragons.AddReinforcements(3);
                Game.test.MyGlobalVariable1.PlayerArmy.Gryphons.AddReinforcements(7);
                Game.test.MyGlobalVariable2 = P2;
                Game.test.MyGlobalVariable2.PlayerArmy.Gryphons.AddReinforcements(7);
                Game.test.MyGlobalVariable2.PlayerArmy.Dragons.AddReinforcements(7);
                Game.test.MyGlobalVariable2.PlayerArmy.Knights.AddReinforcements(7);
                Game.test.MyGlobalVariable2.PlayerArmy.Archers.AddReinforcements(7);
                return new List<Game.Player>{
     P1,
    P2,
            };
            }
            else return new List<Game.Player>{
    Game.test.MyGlobalVariable1,
    Game.test.MyGlobalVariable2,
            };

        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Town()
        {
            Player p = Players[TempData.Peek("Player").ToString()];
            var buildings = from building in p.City select building;
            return View(buildings.Select(k => k.Value).ToList());
        }

        public IActionResult Hero()
        {
            Player p = Players[TempData.Peek("Player").ToString()];
            var army = p.PlayerArmy.Container;
            return View(army.ToList<Creature>());
        }

        [HttpPost]
        public IActionResult Build(string submit)
        {
            try
            {
                Players[TempData.Peek("Player").ToString()].City[submit].Levelup();
                var time = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
                Players[TempData.Peek("Player").ToString()].City[submit].LastProduce = time;
            }
            catch (Exception e)
            {
                TempData.Add("Message", e.Message);
            }

            return RedirectToAction("Town");
        }

        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPlayer(string Name, string Pass)
        {
            ViewData["Message"] = "Success! Created new player (" + Name + ")! Don't forget your password ;)";
            if (!Players.ContainsKey(Name))
                Players.Add(Name, new Player(Name, Pass.GetHashCode()));
            if (!TempData.ContainsKey("Player") && Pass.GetHashCode() == Players[Name].HashCode)
                TempData.Add("Player", Name);
            else
                ViewData["Message"] = "Incorect login";
            return View();
        }
        [HttpPost]
        public IActionResult Recruit(string Archer, string Dragon, string Gryphon, string Knight)
        {
            Player p = Players[TempData.Peek("Player").ToString()];
            var r = new Resources(0, 0, 0, 0, 0);
            try
            {
                if (Archer != null)
                {
                    r.Troops = Int32.Parse(Archer);
                    p.City["Archerytent"].Getresources(r);
                }
                if (Dragon != null)
                {
                    r.Troops = Int32.Parse(Dragon);
                    p.City["Dragonshatchery"].Getresources(r);
                }
                if (Gryphon != null)
                {
                    r.Troops = Int32.Parse(Gryphon);
                    p.City["Gryphonshatchery"].Getresources(r);
                }
                if (Knight != null)
                {
                    r.Troops = Int32.Parse(Knight);
                    p.City["Knightbarrack"].Getresources(r);
                }
            }
            catch (Exception e)
            {
                TempData.Add("Message", e.Message);
            }
            return RedirectToAction("Town");
        }

        [HttpGet]
        public string Produce()
        {
            var time = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;

            if (TempData.ContainsKey("Player"))
            {
                Player p = Players[TempData.Peek("Player").ToString()];
                ViewData["Ore"] = p.Goods.Ore;
                ViewData["Gold"] = p.Goods.Gold;
                ViewData["Clay"] = p.Goods.Clay;
                ViewData["Wood"] = p.Goods.Wood;
                var buildings = from b in Players[TempData.Peek("Player").ToString()].City.Select(k => k.Value).ToList()
                                where b.Level > 0
                                select b;
                foreach (var b in buildings)
                {
                    if (time - b.LastProduce >= b.Interval)
                    {
                        for (long i = 0; i < (time - b.LastProduce) / b.Interval; i++)
                            b.Produce();
                        time = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
                        b.LastProduce = time;
                    }
                }
                return "<img src = \"/images/Gold.jpeg\" style = \"width: 30px; height: 30px;\" /> <span>" + ViewData["Gold"].ToString() +
                "</span> <img src = \"/images/Ore.jpg\" style = \"width: 30px; height: 30px; margin-left: 10px;\" /> <span>" + ViewData["Ore"].ToString() +
                "</span> <img src = \"/images/Wood.jpg\" style = \"width: 30px; height: 30px; margin-left: 10px;\" /> <span>" + ViewData["Wood"].ToString() +
                "</span> <img src = \"/images/Clay.jpg\" style = \"width: 30px; height: 30px; margin-left: 10px;\" /> <span>" + ViewData["Clay"].ToString() +
                "</span>";
            }
            else return "";

        }
    }
}
