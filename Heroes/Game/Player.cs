using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Heroes.Game
{
    public class Player
    {
        String Name;
        Resources goods;
        Army playerArmy;
        List<Building> city;

        internal Resources Goods { get => goods; set => goods = value; }
        public List<Building> City { get => city; set => city = value; }
        public Army PlayerArmy { get => playerArmy; set => playerArmy = value; }

        public Player(String n)
        {
            Name = n;
            PlayerArmy = new Army();
            goods = new Resources(100, 100, 100, 100, 0);
       //     City.Add(new Wood(this));
         //   City.Add(new Claypit(this));
           // City.Add(new Oremine(this));
            //City.Add(new Townhall(this));
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
                if (playerArmy.Conteiner[a].Initiative == maxIni && playerArmy.Conteiner[a].Population!=0 )
                {
                    double damage = playerArmy.Conteiner[a].Attack;// * 0.2
                    playerArmy.Conteiner[a].Initiative = -playerArmy.Conteiner[a].Initiative; //ustawienie ini na wartosc ujemna ( jednostka juz zatakowala)
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
                else if(player2.playerArmy.Conteiner[a].Initiative == maxIni && player2.playerArmy.Conteiner[a].Population != 0 )
                {
                    double damage = player2.playerArmy.Conteiner[a].Attack;
                    double howMuch;
                    player2.playerArmy.Conteiner[a].Initiative = -player2.playerArmy.Conteiner[a].Initiative; //ustawienie ini na wartosc ujemna ( jednostka juz zatakowala)

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
            for (int a = 0; a < 4; a++)// znalezienie max ini
            {
                if (playerArmy.Conteiner[a].Population > 0)
                {
                    if(maxiniplayer1 < PlayerArmy.Conteiner[a].Initiative)
                    {
                        maxiniplayer1 = playerArmy.Conteiner[a].Initiative;
                    }
                }

                if (player2.playerArmy.Conteiner[a].Population > 0)
                {
                    if (maxiniplayer2 < player2.PlayerArmy.Conteiner[a].Initiative)
                    {
                        maxiniplayer2 = player2.playerArmy.Conteiner[a].Initiative;
                    }
                }
            }
            if (maxiniplayer1 >= maxiniplayer2)
            {
                return maxiniplayer1;
            }
            else
            {
                return maxiniplayer2;
            }
            

        }

        public void ResetInitiative(Player player2)
        {
            for (int a = 0; a < 4; a++)
            {
                playerArmy.Conteiner[a].Initiative = Math.Abs(playerArmy.Conteiner[a].Initiative);
                player2.playerArmy.Conteiner[a].Initiative = Math.Abs(player2.playerArmy.Conteiner[a].Initiative);
            }
        }
    }
}
