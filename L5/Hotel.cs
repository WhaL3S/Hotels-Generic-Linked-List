using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Class describing hotel
    /// </summary>
    public class Hotel : IComparable<Hotel>, IEquatable<Hotel>
    {
        // Properties
        public string Name { get; set; }    
        public string Type { get; set; }
        public double Price { get; set; }

        // Default constructor
        public Hotel() {}

        // Constructor with parameters
        public Hotel(string name, string type, double price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        /// <summary>
        /// Compares current and entered hotels 
        /// </summary>
        /// <param name="other">Another hotel to compare with</param>
        /// <returns>1 if name is bigger
        /// -1 if name is smaller
        /// 0 otherwise
        /// </returns>
        public int CompareTo(Hotel other)
        {
            int p = string.Compare(Name, other.Name, StringComparison.CurrentCulture);
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
            Hotel h = obj as Hotel;
            return this.Equals(h);
        }

        /// <summary>
        /// Checks if the current and entered hotels are equal
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public bool Equals(Hotel h)
        {
            return (h.Name == Name) &&
                   (h.Type == Type);
        }

        /// <summary>
        /// Overridden method to get hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                   Type.GetHashCode() ^
                   Price.GetHashCode();
        }

        /// <summary>
        /// Header of the table
        /// </summary>
        /// <returns></returns>
        public static string Header()
        {
            string line = System.Environment.NewLine +
                        "------------------------------------------------------------" +
                        Environment.NewLine;
                   line += "|      Hotel       |       Type        |  Price |" +
                        Environment.NewLine;
                   line += "------------------------------------------------------------" +
                        Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Footer of the table
        /// </summary>
        /// <returns></returns>
        public static string Footer()
        {
            string line = "------------------------------------------------------------" +
                        Environment.NewLine;
            return line;
        }

        /// <summary>
        /// Converting properties into string line
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("| {0,-15} | {1,-15} | {2,-5:f2} |",
                            Name, 
                            Type, 
                            Price);
        }
    }
}
