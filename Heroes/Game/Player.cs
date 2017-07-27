using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Heroes.Game
{
    public class Player
    {
        String _Name;
        Resources goods;
        Army playerArmy;
        Dictionary<String, Building> city;
        int _HashCode;

        internal Resources Goods { get => goods; set => goods = value; }
        public Dictionary<String, Building> City { get => city; set => city = value; }
        public Army PlayerArmy { get => playerArmy; set => playerArmy = value; }
        public int HashCode { get => _HashCode; }
        public String Name { get => _Name; }
        public Player(String n, int HashCode = 0)
        {
            _Name = n;
            _HashCode = HashCode;
            city = new Dictionary<String, Building>();
            PlayerArmy = new Army();
            goods = new Resources(500, 500, 500, 500, 0);
            City.Add("Wood", new Wood(this));
            City.Add("Claypit", new Claypit(this));
            City.Add("Oremine", new Oremine(this));
            City.Add("Townhall", new Townhall(this));
            City.Add("Archerytent", new Archerytent(this));
            City.Add("Dragonshatchery", new Dragonshatchery(this));
            City.Add("Gryphonshatchery", new Gryphonshatchery(this));
            City.Add("Knightbarrack", new Knightbarrack(this));
        }
        public void Fight(Player player2 , string type)// typ zwraca stworka jaki bedzie atakowany
        {


            int maxIni=FindMaxInitiative(player2);
            if (maxIni == 0)
            {
                ResetInitiative(player2);
                maxIni = FindMaxInitiative(player2);
            }

            for (int a = 0; a < 4; a++)// znalezienie stworka
            {
                if (playerArmy.Container[a].Initiative == maxIni && playerArmy.Container[a].Population!=0 )
                {
                    double damage = playerArmy.Container[a].Attack;// * 0.2
                    playerArmy.Container[a].Initiative = -playerArmy.Container[a].Initiative; //ustawienie ini na wartosc ujemna ( jednostka juz zatakowala)
                    double howMuch;

                    switch (type)
                    {
                        case "A":
                             howMuch = damage / player2.playerArmy.Archers.Health;
                            player2.playerArmy.Archers.Kill(howMuch);
                            break;
                        case "K":
                             howMuch = damage / player2.playerArmy.Knights.Health;
                            player2.playerArmy.Knights.Kill(howMuch);
                            break;
                        case "D":
                            howMuch = damage / player2.playerArmy.Dragons.Health;
                            player2.playerArmy.Dragons.Kill(howMuch);
                            break;
                        case "G":
                            howMuch = damage / player2.playerArmy.Gryphons.Health;
                            player2.playerArmy.Gryphons.Kill(howMuch);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                }
                else if(player2.playerArmy.Container[a].Initiative == maxIni && player2.playerArmy.Container[a].Population != 0 )
                {
                    double damage = player2.playerArmy.Container[a].Attack;
                    double howMuch;
                    player2.playerArmy.Container[a].Initiative = -player2.playerArmy.Container[a].Initiative; //ustawienie ini na wartosc ujemna ( jednostka juz zatakowala)

                    switch (type)
                    {
                        case "A":
                            howMuch = damage / playerArmy.Archers.Health;
                          playerArmy.Archers.Kill(howMuch);
                            break;
                        case "K":
                            howMuch = damage / playerArmy.Knights.Health;
                           playerArmy.Knights.Kill(howMuch);
                            break;
                        case "D":
                            howMuch = damage /playerArmy.Dragons.Health;
                           playerArmy.Dragons.Kill(howMuch);
                            break;
                        case "G":
                            howMuch = damage / playerArmy.Gryphons.Health;
                           playerArmy.Gryphons.Kill(howMuch);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                }

            }


          
        }

        public int FindMaxInitiative(Player player2)
        {
            int maxiniplayer1 = 0;
            int maxiniplayer2 = 0;
            Creature playerWitchMaxIni1=null;
            Creature playerWitchMaxIni2=null;
            for (int a = 0; a < 4; a++)
            {
                this.playerArmy.Container[a].IsFighting = "orange";
                player2.playerArmy.Container[a].IsFighting = "blue";
            }

                for (int a = 0; a < 4; a++)// znalezienie max ini
            {
                if (playerArmy.Container[a].Population > 0)
                {
                    if(maxiniplayer1 < PlayerArmy.Container[a].Initiative)
                    {
                        playerWitchMaxIni1 = this.playerArmy.Container[a];
                        maxiniplayer1 = playerArmy.Container[a].Initiative;
                    }
                }

                if (player2.playerArmy.Container[a].Population > 0)
                {
                    if (maxiniplayer2 < player2.PlayerArmy.Container[a].Initiative)
                    {
                        playerWitchMaxIni2 = player2.playerArmy.Container[a];
                        maxiniplayer2 = player2.playerArmy.Container[a].Initiative;
                    }
                }
            }
            if (maxiniplayer1 >= maxiniplayer2)
            {
                if (playerWitchMaxIni1 != null)
                {
                    playerWitchMaxIni1.IsFighting = "red";
                }
           
               
                return maxiniplayer1;
            }
            else
            {
                if (playerWitchMaxIni2 != null)
                {
                    playerWitchMaxIni2.IsFighting = "red";
                }
                return maxiniplayer2;
            }
            

        }

        public void ResetInitiative(Player player2)
        {
            for (int a = 0; a < 4; a++)
            {
                playerArmy.Container[a].Initiative = Math.Abs(playerArmy.Container[a].Initiative);
                player2.playerArmy.Container[a].Initiative = Math.Abs(player2.playerArmy.Container[a].Initiative);
            }
        }
    }
}
