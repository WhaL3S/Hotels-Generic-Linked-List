using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Class describing travellers with spent nights
    /// </summary>
    class NightTraveller : IComparable<NightTraveller>, IEquatable<NightTraveller>
    {
        // Properties
        public string NameS { get; set; }
        public int Nights { get; set; }

        // Default constructor
        public NightTraveller() { }

        // Constructor with parameters
        public NightTraveller(string nameS, int night)
        {
            this.NameS = nameS;
            this.Nights = night;
        }

        /// <summary>
        /// Compares current and entered object
        /// </summary>
        /// <param name="other"></param>
        /// <returns>1 if name is bigger
        /// -1 if name is smaller
        /// 0 otherwise
        /// </returns>
        public int CompareTo(NightTraveller other)
        {
            int p = string.Compare(NameS, other.NameS, StringComparison.CurrentCulture);
            if (p > 0)
                return 1;
            else if (p < 0)
                return -1;
            return 0;
        }

        /// <summary>
        /// Overridden Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            NightTraveller pt = obj as NightTraveller;
            return this.Equals(pt);
        }

        /// <summary>
        /// Method to compare if the current and entered objects are equal by name
        /// </summary>
        /// <param name="nt"></param>
        /// <returns></returns>
        public bool Equals(NightTraveller nt)
        {
            return nt.NameS == NameS;
        }

        /// <summary>
        /// Method to get hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return NameS.GetHashCode() ^
                    Nights.GetHashCode();
        }

        /// <summary>
        /// Header of the table
        /// </summary>
        /// <returns></returns>
        public static string Header()
        {
            string line = System.Environment.NewLine +
                    "------------------------------------" + Environment.NewLine;
            line += "|      Name    |  Nights |" + Environment.NewLine;
            line += "------------------------------------" + Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Footer of the table
        /// </summary>
        /// <returns></returns>
        public static string Footer()
        {
            string line = "------------------------------------" + Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Converting properties into the string line
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0,-12} | {1,-10:d} |", NameS, Nights);
        }
    }
}
