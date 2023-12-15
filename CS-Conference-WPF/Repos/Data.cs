using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Conference_WPF.Repos
{
    internal static class Data
    {
        public static List<string> GetCanadianCities()
        {
            return new List<string>()
            {
                "Montreal","Ottawa","Toronto","Vancouver", "Quebec City", "Calgary"
            };
        }

        public static List<string> GetUSCities()
        {
            return new List<string>()
            {
                "New York","Washington","Huston","Dallas", "LA"
            };
        }

        public static List<string> GetOtherCities()
        {
            return new List<string>()
            {
                "Damascus","Paris","Cairo","Stockholm", "Moscow", "London","Other"
            };
        }


    }
}
