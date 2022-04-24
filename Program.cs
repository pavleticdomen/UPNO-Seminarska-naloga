using System;

class KavniAvtomat
{

    // Začetna količina sestavin za pripravo kave v avtomatu
    public static int voda_avtomat = 100; // mililiter
    public static int mleko_avtomat = 200;
    public static int kava_avtomat = 20; // gram

    // Sestavine za pripravo napitka

    // Espresso
    public static int voda_esp = 30;
    public static int kava_esp = 9;
    public static double cena_esp = 1.1;

    // Latte
    public static int voda_latte = 50;
    public static int mleko_latte = 150;
    public static int kava_latte = 9;
    public static double cena_latte = 1.6;

    // Cappuccino
    public static int voda_cap = 40;
    public static int mleko_cap = 60;
    public static int kava_cap = 9;
    public static double cena_cap = 1.4;

    // Zaslužek naprave
    public static double zasluzek = 0;

    // Spremenljivka za potek while loop-a
    public static bool avtomatDeluje = true;


    static void Main(string[] args)
    {

        while (avtomatDeluje)
        {
            Console.WriteLine("Kakšno kavo želite?");
            Console.WriteLine("Lahko izbirate med: espresso/latte/cappuccino");
            string narocilo_uporabnika = Console.ReadLine();

            if (narocilo_uporabnika == "porocilo")
            {
                Console.WriteLine($"Sestavine v napravi\n Voda: {voda_avtomat} mililitrov\n Mleko: {mleko_avtomat} gramov\n Kava: {kava_avtomat} gramov\n Zaslužek: {zasluzek} evrov");
            }
            else if (narocilo_uporabnika == "off")
            {
                Console.WriteLine("Izklapljam napravo.");
                avtomatDeluje = false;
            }
            else
            {
                if (narocilo_uporabnika == "espresso")
                {
                    if (PreverjanjeSestavin(voda_esp, 0, kava_esp))
                    {
                        if (ZadostnoPlacilo(PreverjanjePlacila(), cena_esp))
                        {
                            PripravaNapitka(voda_esp, 0, kava_esp);
                        }
                    }

                }
                else if (narocilo_uporabnika == "latte")
                {
                    if (PreverjanjeSestavin(voda_latte, mleko_latte, kava_latte))
                    {
                        if (ZadostnoPlacilo(PreverjanjePlacila(), cena_latte))
                        {
                            PripravaNapitka(voda_latte, mleko_latte, kava_latte);
                        }
                    }

                }
                else if (narocilo_uporabnika == "cappuccino")
                {
                    if (PreverjanjeSestavin(voda_esp, mleko_latte, kava_esp))
                    {
                        if (ZadostnoPlacilo(PreverjanjePlacila(), cena_cap))
                        {
                            PripravaNapitka(voda_cap, mleko_cap, kava_cap);
                        }
                    }

                }
            }
        }

        static bool PreverjanjeSestavin(int voda, int mleko, int kava)
        {
            // Vrne true kadar je naročilo lahko narejeno in false kadar naročila ni mogoče izvesti oz. kadar ni dovolj sestavin v avtomatu
            if (voda_avtomat < voda || mleko_avtomat < mleko || kava_avtomat < kava)
            {
                Console.WriteLine("Naročila ni mogoče izvesti. Premalo sestavin.");
                avtomatDeluje = false;
                return false;
            }
            else
            {
                return true;
            }
        }

        static double PreverjanjePlacila()
        {
            Console.WriteLine("Prosimo vstavite kovance. Avtomat sprejema kovance po 1 evro, 50 centov, 20 centov in 10 centov.");

            Console.WriteLine("1 evro: ");
            double en_evro = Convert.ToInt32(Console.ReadLine()) * 1.0;

            Console.WriteLine("50 centov: ");
            double petdeset = Convert.ToInt32(Console.ReadLine()) * 0.50;

            Console.WriteLine("20 centov: ");
            double dvajset = Convert.ToInt32(Console.ReadLine()) * 0.20;

            Console.WriteLine("10 centov: ");
            double deset = Convert.ToInt32(Console.ReadLine()) * 0.10;

            double placiloSkupaj = en_evro + petdeset + dvajset + deset;

            return placiloSkupaj;
        }

        static bool ZadostnoPlacilo(double placiloSkupaj, double cenaNapitka)
        {
            // Vrne true kadar je plačilo zadostno, ali pa false kadar ni dovolj denarja
            if (placiloSkupaj >= cenaNapitka)
            {
                double drobiz = placiloSkupaj - cenaNapitka;
                drobiz = Math.Round(drobiz, 2);
                zasluzek += cenaNapitka;
                Console.WriteLine($"Tukaj je vaš ostanek: {drobiz} evra.");
                return true;
            }
            else
            {
                Console.WriteLine("Ni dovolj denarja. Vračam vstavljen denar.");
                return false;
            }
        }

        static void PripravaNapitka(int voda, int mleko, int kava)
        {
            voda_avtomat -= voda;
            mleko_avtomat -= mleko;
            kava_avtomat -= kava;
            Console.WriteLine("Izvolite vaš napitek.");
        }
    }
}