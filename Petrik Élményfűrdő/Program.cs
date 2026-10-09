using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrik_Élményfűrdő
{
    internal class Program
    {
        static void Fomenu()
        {
            Console.WriteLine("=== PETRIK ÉLMÉNYFŰRDŐ ===");
            Console.WriteLine();

            Console.WriteLine("1.) Belépőjegy vásárlása");
            Console.WriteLine("2.) Csúszdapark ellenőrzés");
            Console.WriteLine("3.) Éttermi kedvezmény kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés");

            Console.WriteLine();
            Console.Write("Választás: ");
        }

        static string JegyTipus(int eletkor)
        {
            if (eletkor <= 5)
            {
                return "Baba jegy";
            }

            else if (eletkor <= 13)
            {
                return "Gyerekjegy";
            }

            else if (eletkor <= 17)
            {
                return "Diákjegy";
            }

            else if (eletkor <= 64)
            {
                return "Felnőttjegy";
            }

            else
            {
                return "Nyugdíjas jegy";
            }
        }

        static int JegyAr(int eletkor)
        {
            if (eletkor <= 5)
            {
                return 0;
            }

            else if (eletkor <= 13)
            {
                return 1800;
            }

            else if (eletkor <= 17)
            {
                return 2400;
            }

            else if (eletkor <= 64)
            {
                return 3900;
            }

            else
            {
                return 2000;
            }
        } 

        static string CuszdaEllenorzes(int csuszda, int magassag)
        {
           switch (csuszda)
            {
                case 1:
                    if (magassag >= 100)
                    {
                        return "Használhatod a Mini Csúszdát!";
                    }

                    else
                    {
                        return "Sajnos túl alacsony vagy ehhez a csúszdához!";
                    }
                    break;

                case 2:
                    if (magassag >= 140)
                    {
                        return "Használhatod a Kamikaze csúszdát!";
                    }
                    else
                    {
                        return "Sajnos túl alacsony vagy ehhez a csúszdához!";
                    }
                    break;

                case 3:
                    if (magassag >= 120)
                    {
                        return "Használhatod a Black Hole csúszdát!";
                    }
                    else
                    {
                        return "Sajnos túl alacsony vagy ehhez a csúszdához!";
                    }
                    break;

                default:
                    return "Túl alacsony vagy a csúszdák használatához!";
            }
        }

        static int KedvezmenyesAr(int osszeg, int kedvezmeny)
        {
            switch (kedvezmeny)
            {
                case 1:
                    return osszeg;
                    break;

                case 2:
                    return osszeg - ((osszeg * 15) / 100);
                    break;

                case 3:
                    return osszeg - ((osszeg * 20) / 100);
                    break;

                default:
                    return Convert.ToInt32("Nincs ilyen kedvezmény");
            }   
        }

        static void Main(string[] args)
        {
            int valasztas = 0;

            int bevetel = 0;

           
            do
            {

                Console.Clear();
                Fomenu();

                try
                {
                    valasztas = Convert.ToInt32(Console.ReadLine());

                    switch (valasztas)
                    {
                        case 1:

                            Console.Clear();

                            Console.WriteLine("=== Belépőjegy vásárlása ===");

                            Console.WriteLine();

                            Console.Write("Név: ");
                            string nev = Console.ReadLine();

                            Console.Write("Életor: ");
                            int eletkor = Convert.ToInt32(Console.ReadLine());

                            if (eletkor < 0 || eletkor > 120)
                            {
                                Console.WriteLine("Hibás életkor!");
                            }

                            else
                            {
                                string jegyTipus = JegyTipus(eletkor);

                                int ar = JegyAr(eletkor);

                                Console.WriteLine();

                                Console.WriteLine($"Jegytípus: {jegyTipus}");

                                Console.WriteLine($"Fizetendő: {ar} Ft");

                                bevetel += ar;
                            }

                            Console.ReadLine();
                            break;

                        case 2:

                            Console.Clear();

                            Console.WriteLine();

                            Console.WriteLine("=== CSÚSZDAPARK ===");

                            Console.WriteLine("1.) Mini Csúszda");
                            Console.WriteLine("2.) Kamikaze");
                            Console.WriteLine("3.) Black Hole");

                            Console.WriteLine("Melyik csúszdát választod? ");

                            int csuszda = Convert.ToInt32(Console.ReadLine());

                            if (csuszda < 1 || csuszda > 3)
                            {
                                Console.Write("Nincs ilyen csúszda!");
                            }

                            else
                            {
                                Console.Write("Magasságod: ");

                                int magassag = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine(CuszdaEllenorzes(csuszda, magassag));
                            }
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.Clear();

                            Console.WriteLine("=== ÉTTERMI KEDVEZMÉNY ===");
                            Console.WriteLine("1.) Nincs kedvezmény");
                            Console.WriteLine("2.) Diákkedvezmény - 15%");
                            Console.WriteLine("3.) Családi kedvezmény - 20%");

                            Console.Write("Eredeti összeg: ");

                            int osszeg = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Kedvezmény: ");

                            int kedvezmeny = Convert.ToInt32(Console.ReadLine());

                            if (kedvezmeny < 1 || kedvezmeny > 3)
                            {
                                Console.WriteLine("Nincs ilyen kedvezménytípus!");
                            }

                            else
                            {
                                int fizetes = KedvezmenyesAr(osszeg, kedvezmeny);

                                Console.WriteLine($"Fizetendő: {fizetes} Ft");
                            }

                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();

                            Console.WriteLine();

                            Console.WriteLine("=== NAPI BEVÉTEL ===");

                            Console.WriteLine($"A fürdő mai bevétele: {bevetel} Ft");

                            Console.ReadLine();
                            break;

                        case 5:
                            Console.WriteLine("Viszlát!");
                            Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Válassz az 1-5 lehetőség közül!");

                            Console.ReadLine();

                            break;
                    }
                }

                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Hiba! Egész számot kell megadni!");

                    Console.ReadLine();
                }

            } while (valasztas != 5);
        }
    }
}
