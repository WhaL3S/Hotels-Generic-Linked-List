using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Class describing each traveller
    /// </summary>
    public class Traveller : IComparable<Traveller>, IEquatable<Traveller>
    {
        // Properties
        public string NameS { get; set; }
        public string HName { get; set; }   // Hotel's name
        public string HType { get; set; }   // Hotel's type
        public int Nights { get; set; }

        // Default constructor
        public Traveller() {}

        // Constructor with parameters
        public Traveller(string nameS, string hname, string htype, int nights)
        {
            this.NameS = nameS;
            this.HName = hname;
            this.HType = htype;
            this.Nights = nights;
        }

        /// <summary>
        /// Compares current and entered traveller 
        /// </summary>
        /// <param name="other">Another traveller to compare with</param>
        /// <returns>1 if name is bigger
        /// -1 if name is smaller
        /// 0 otherwise
        /// </returns>
        public int CompareTo(Traveller other)
        {
            int p = String.Compare(NameS, other.NameS, StringComparison.CurrentCulture);
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
            Traveller sh = obj as Traveller;
            return this.Equals(sh);
        }

        /// <summary>
        /// Checks if the current and entered travellers are equal
        /// </summary>
        /// <param name="sh"></param>
        /// <returns></returns>
        public bool Equals(Traveller sh)
        {
            return (sh.NameS == NameS) &&
                   (sh.HName == HName) &&
                   (sh.HType == HType) &&
                   (sh.Nights == Nights);
        }

        /// <summary>
        /// Method to get hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return NameS.GetHashCode() ^
                   HName.GetHashCode() ^
                   HType.GetHashCode() ^
                   Nights.GetHashCode();
        }

        /// <summary>
        /// Header of the table
        /// </summary>
        /// <returns></returns>
        public static string Header()
        {
            string line = System.Environment.NewLine +
                    "--------------------------------------------------------------------------" +
                    Environment.NewLine;
            line += "|       Name      |    Hotel    |     Type      | Nights |" +
                    Environment.NewLine; 
            line += "--------------------------------------------------------------------------" +
                    Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Footer of the table
        /// </summary>
        /// <returns></returns>
        public static string Footer()
        {
            string line = "--------------------------------------------------------------------------" +
                Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Converting properties into string line
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0,-15} | {1,-10} | {2, -10} | {3,-9:d} |",
                            NameS,
                            HName,
                            HType,
                            Nights);
        }
    }
}
