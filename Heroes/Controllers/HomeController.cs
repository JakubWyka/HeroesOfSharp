using System;
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
            if (players[0].IsMyTurn)
                players[0].Fight(players[1], type);
            else
                players[1].Fight(players[0], type);
        }

        [HttpPost, HttpGet]
        public IActionResult Fight(string type) //typ okresla stworka jaki zostal zatakowany
        {
            var players = PlayersList();
            if (type != null)
            {
                StartFight(players, type);
                ViewData["Message"] = type;
            }
            if (players[0].IsMyTurn)
                players[0].FindMaxInitiative(players[1]);
            else
                players[1].FindMaxInitiative(players[0]);

            if (players[0].PlayerArmy.IsEmpty || players[1].PlayerArmy.IsEmpty)
            {
                players[0].EnemyPlayerName = "";
                players[1].EnemyPlayerName = "";
            }
            return View(players);
        }

        [NonAction]
        public List<Game.Player> PlayersList()
        {
            if (TempData.ContainsKey("Player") && Players.ContainsKey(TempData.Peek("Player").ToString()) && Players.ContainsKey(Players[TempData.Peek("Player").ToString()].EnemyPlayerName))
                return new List<Player> { Players[TempData.Peek("Player").ToString()],
                    Players[Players[TempData.Peek("Player").ToString()].EnemyPlayerName]};
            else if (TempData.ContainsKey("Player") && Players.ContainsKey(TempData.Peek("Player").ToString()))
                return new List<Player> { Players[TempData.Peek("Player").ToString()] };
            else return null;
        }



        public IActionResult Index()
        {
            return View(Players.Select(k => k.Value).ToList());
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
            if (!Players.ContainsKey(Name))
            {
                ViewData["Message"] = "Success! Created new player (" + Name + ")! Don't forget your password ;)";
                TempData.Add("Player", Name);
                Players.Add(Name, new Player(Name, Pass.GetHashCode()));
            }
            else if (!TempData.ContainsKey("Player") && Pass.GetHashCode() == Players[Name].HashCode)
            {
                ViewData["Message"] = "Weclome back " + Name + "!";
                TempData.Add("Player", Name);
            }
            else
                ViewData["Message"] = "Incorect login";
            return View("Message");
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
                return "<img src = \"/images/Gold.jpeg\" style = \"width: 30px; height: 30px;\" data-toggle=\"tooltip\" title=\"Gold\"/> <span>" + p.Goods.Gold.ToString() +
                "</span> <img src = \"/images/Ore.jpg\" style = \"width: 30px; height: 30px; margin-left: 10px;\" data-toggle=\"tooltip\" title=\"Ore\"/> <span>" + p.Goods.Ore.ToString() +
                "</span> <img src = \"/images/Wood.jpg\" style = \"width: 30px; height: 30px; margin-left: 10px;\" data-toggle=\"tooltip\" title=\"Wood\"/> <span>" + p.Goods.Wood.ToString() +
                "</span> <img src = \"/images/Clay.jpg\" style = \"width: 30px; height: 30px; margin-left: 10px;\" data-toggle=\"tooltip\" title=\"Clay\"/> <span>" + p.Goods.Clay.ToString() +
                "</span>";
            }
            else return "";

        }
        [HttpGet]
        public string AmIAttacked()
        {
            if (TempData.ContainsKey("Player"))
                return Players[TempData.Peek("Player").ToString()].EnemyPlayerName;
            else
                return "";
        }

        [HttpGet]
        public IActionResult FightInfo()
        {

            var players = PlayersList();
            return PartialView("FightInfo", players);
        }

        [HttpPost]
        public IActionResult AttackPlayer(string player)
        {
            Players[TempData.Peek("Player").ToString()].EnemyPlayerName = player;
            Players[TempData.Peek("Player").ToString()].IsMyTurn = true;
            Players[player].EnemyPlayerName = TempData.Peek("Player").ToString();
            Players[player].IsMyTurn = false;
            return RedirectToAction("Fight");
        }
        public IActionResult Logout()
        {
            TempData.Clear();
            ViewData["Message"] = "Logout";
            return View("Message");
        }
    }
}
