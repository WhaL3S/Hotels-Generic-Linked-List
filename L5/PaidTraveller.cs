using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Class describing travellers and total spent money
    /// </summary>
    public class PaidTraveller : IComparable<PaidTraveller>, IEquatable<PaidTraveller>
    {
        // Properties
        public string NameS { get; set; }
        public double Spent { get; set; }

        // Default constructor
        public PaidTraveller() {}

        // Constructor with parameters
        public PaidTraveller(string nameS, double spent)
        {
            this.NameS = nameS;
            this.Spent = spent;
        }

        /// <summary>
        /// Compares the current and entered object by name
        /// </summary>
        /// <param name="other"></param>
        /// <returns>1 if name is bigger
        /// -1 if name is smaller
        /// 0 otherwise
        /// </returns>
        public int CompareTo(PaidTraveller other)
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
            PaidTraveller pt = obj as PaidTraveller;
            return this.Equals(pt);
        }

        /// <summary>
        /// Checks if the current and entered objects are equal by name
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Equals(PaidTraveller pt)
        {
            return pt.NameS == NameS;
        }

        /// <summary>
        /// Method to get hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return NameS.GetHashCode() ^
                    Spent.GetHashCode();
        }

        /// <summary>
        /// Header of the table
        /// </summary>
        /// <returns></returns>
        public static string Header()
        {
            string line = System.Environment.NewLine +
                            "-------------------------------------" + Environment.NewLine;
                    line += "|      Name     |    Sum    |" + Environment.NewLine;
                    line += "-------------------------------------" + Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Footer of the table
        /// </summary>
        /// <returns></returns>
        public static string Footer()
        {
            string line = "-------------------------------------" + Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Converting properties into the string line
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0,-13} | {1,8:f2} |", NameS, Spent);
        }
    }
}
