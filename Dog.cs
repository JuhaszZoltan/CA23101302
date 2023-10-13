using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23101302
{
    internal class Dog
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public float Height { get; set; }
        public List<string> Temperament { get; set; }
        public string TemperamentStr { get; set; }
        public (int AvgMin, int AvgMax) Lifespan { get; set; }
        public string Origin { get; set; }

        public Dog(string datarow)
        {
            string[] splts = datarow.Split(';');
            Name = splts[0];
            Weight = int.Parse(splts[1]);
            Height = float.Parse(splts[2].Replace('.', ','));
            TemperamentStr = splts[3].ToLower();
            Temperament = TemperamentStr
                .Replace("and", "")
                .Replace(" ", "")
                .Split(',')
                .ToList();
            string[] lsv = splts[4].Split('-');
            Lifespan = (int.Parse(lsv[0]), int.Parse(lsv[1]));
            Origin = splts[5];
        }
    }
}
