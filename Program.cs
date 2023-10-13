﻿namespace CA23101302
{
    internal class Program
    {
        static void Main()
        {
            List<Dog> dogs = GetDogsFromFile("dogs [Generated by OpenAI].txt");

            //sum
            //ha minden kutyusból lenne egy "átlagos marmagasságú" páldány,
            //és ezek egymás hátára állnának
            //milyen magas lenne a kutyatorony?
            var f01 = dogs.Sum(d => d.Height);
            Console.WriteLine($"sum of height: {f01} feet");

            //avg
            //egy <bármilyen> kutya átlahos súlya:
            var f02 = dogs.Average(d => d.Weight);
            Console.WriteLine($"avg of weight: {f02} pounds");

            //count
            //azon kutyák száma, melyek elélnek akár 15 évig is
            var f03 = dogs.Count(d => d.Lifespan.AvgMax >= 15);
            Console.WriteLine($"long lifespan dogs count: {f03}");

            //min, max [value]
            //legosszabb nevű kutyafajta nevének karaktereinek száma
            var f04 = dogs.Max(d => d.Name.Length);
            Console.WriteLine($"longest breed name char count: {f04}");

            //legkisebb kutya magassága
            var f05 = dogs.Min(d => d.Height);
            Console.WriteLine($"shortest dog height: {f05} inch");

            //minby, maxby ~[location]~ -> init
            //leghosszabb fajtanév:
            var f06 = dogs.MaxBy(d => d.Name.Length);
            Console.WriteLine($"longest breed name: {f06.Name}");

            //legkisebb kutyafajta:
            var f07 = dogs.MinBy(d => d.Height);
            Console.WriteLine($"shortest dog name: {f07.Name}");

            //first
            // HA van <adott tulajdonságú> elem a kollekcióban,
            // akkor visszaadja az elsőt (azaz legkisebb indexűt)
            // HA nincs <adott tulajdonságú> elem,
            // akkor Exceptiont dob (azaz megszakad a program futása, ha ez nincs lekezelve)

            //first or default
            // HA van <adott tulajdonságú> elem a kollekcióban,
            // akkor visszaadja az elsőt (azaz legkisebb indexűt)
            // HA nincs <adott tulajdonságú> elem,
            // akkor ún. default példányt ad vissza,
            // ami érték típusú elemeket tartalmazó kollekció esetén a 'zéró' érték
            // referencia típusú elemeket tartalmazó kollekció esetén null

            // last
            // first, csak LEGNAGYOBB indexű elemmel
            // last or default
            // FirstOrDefault, csak a LEGNAGYOBB indexű elemmel

            // single
            // HA van <adott tulajdonságú> elem a kollekcióban,
            // ÉS adott tulajdonságra vonatkozóan az elem EGYEDI
            // akkor visszaadja azt a példányt, amire <adott tulajdonság> igaz
            // HA TÖBB <adott tulajdonságú> elem is van
            // akkor Exceptiont dob
            // HA EGYÁLTALÁN NINCS <adott tulajdonságú> elem
            // akkor (is) Exceptiont dob (csak másmilyet)

            //single or default
            // ua. mint a single, csak:
            // HA EGYÁLTALÁN NINCS <adott tulajdonságú> elem
            // akkor NEM Exceptiont dob, hanem ún. default példányt ad vissza, ami...
            // bla, bla bla....


            //az első olyan kutya, amiről elmondható, hogy intelligens
            var f08 = dogs.First(d => d.Temperament.Contains("intelligent"));
            Console.WriteLine($"first itelligent dog: {f08.Name}");

            //az első olyan kutya, amiről elmondható, hogytud sakkozni
            var f09 = dogs.FirstOrDefault(d => d.Temperament.Contains("can play chess"));
            if (f09 is not null) Console.WriteLine($"first itelligent dog: {f09.Name}");
            else Console.WriteLine($"none of the dogs can play chess properly :(");

            //az utolsó olyan kutya, amiről elmondható, hogy barátságos
            var f10 = dogs.Last(d => d.Temperament.Contains("friendly"));
            Console.WriteLine($"last friendly dog in the list: {f10.Name}");

            //az utolsó olyan kutya, amit németországból származik
            var f11 = dogs.LastOrDefault(d => d.Origin == "Germany");
            if (f11 is not null) Console.WriteLine($"last german breed: {f11.Name}");
            else Console.WriteLine($"germans never breed dog, they eat them!");

            //az egyetlen olyan kutya, ami nagybritanniából származik
            //var f12a = dogs.Single(d => d.Origin == "United Kingdom");
            //var f12b = dogs.SingleOrDefault(d => d.Origin == "United Kingdom");
            //Console.WriteLine($"the only one british dog breed: {f12a}");

            //az egyetlen olyan kutya, aminek a súlya meghaladja a 100 fontot
            var f13 = dogs.SingleOrDefault(d => d.Weight >= 100);
            Console.WriteLine($"the only one fat dog here: {f13.Name}");

            //az egyetlen olyan kutya, ami magasabb, mint az eiffel torony
            //var f14 = dogs.Single(d => d.Height > 984);
            //Console.WriteLine($"the only breed, who is taller than the Eiffel Tower: {f14.Name}");

            var f15 = dogs.SingleOrDefault(d => d.Height > 984*12);
            if (f15 is not null)
                Console.WriteLine($"the only breed, who is taller than the Eiffel Tower: {f15.Name}");
            else Console.WriteLine($"none of the dogs are taller then the tower!");

            #region contains kitérő
            //nem LINQ, de amúgy 'kvázi' megvalósítja az eldöntés tételének egy speciális esetét:
            //bool tartalmazza = dogs.Contains(f11);
            //Console.WriteLine(tartalmazza);
            //int[] szamok = { 11, 12, 13 };
            //int x = 12;
            //Console.WriteLine("szamokban az x: {0}", szamok.Contains(x));
            //List<Dog> kutyak = new() { new() { Name = "Blöki", } };
            //Dog k = new() { Name = "Blöki", };
            //Console.WriteLine("kutyakban a k: {0}", kutyak.Contains(k));
            #endregion

            var f16 = dogs.Any(d => d.Height > 984 * 12);
            Console.WriteLine($"is there a very tall dog?: {(f16 ? "yes" : "no")}");

            var f17 = dogs.Any(d => d.Origin == "Germany");
            Console.WriteLine($"Es gibt eine deutsch Hund?: {(f17 ? "JA!!!" : "NEIN!!!")}");

            //orderby/orderbydescending
            //groupby
            //select/selectmany
            //where
            //all

            //+ limit
            //+ distinct
        }

        private static List<Dog> GetDogsFromFile(string filename)
        {
            List<Dog> list = new();
            using StreamReader streamReader = new($@"..\..\..\src\{filename}");
            _ = streamReader.ReadLine();
            while (!streamReader.EndOfStream) list.Add(new(streamReader.ReadLine()));
            return list;
        }
        private static void DogListTest(List<Dog> list)
        {
            Console.Write("Number of elements in the list: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(list.Count);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nBreed Name;");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Average Weight (lbs);");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Average Height (inches);");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Temperament;");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Lifespan (years);");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Origin\n");

            foreach (var dog in list)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{dog.Name};");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{dog.Weight};");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{dog.Height:0.0};");
                Console.ForegroundColor = ConsoleColor.Magenta;
                string tmpstr = "";
                foreach (var tem in dog.Temperament) tmpstr += $"{tem}, ";
                tmpstr = tmpstr[..^2];
                Console.Write($"[{tmpstr}];");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{dog.Lifespan.AvgMin}-{dog.Lifespan.AvgMax};");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{dog.Origin}");
            }

            Console.ResetColor();
        }

        #region commentek: prog tételek & SQL
        //DogListTest(dogs);

        /*
        sorozatszámítás (pl.: összegzés) --> átlag
        megszámlálás
        szélsőérték meghatározás (min, max -> loc, val)

        lineáris keresés -> példány (lehet null)
        kiválasztás -> példány
        eldöntés -> logikai

        kiválogatás

        szétválogatás
        */

        /*
        SELECT
        WHERE/HAVING
        DISTINCT
        GROUP BY
        ORDER BY
        TOP n/LIMIT n

        MIN
        MAX
        SUM
        AVG
        COUNT
        ANY/ALL
        */
        #endregion
    }
}