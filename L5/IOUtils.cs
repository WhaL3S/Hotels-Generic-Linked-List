using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L5
{
    /// <summary>
    /// Class to work with reading
    /// </summary>
    class IOUtils
    {
        /// <summary>
        /// Reads the file about travellers
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static GenericDoublyLinkedList<Traveller> ReadTravellers(string filename)
        {
            GenericDoublyLinkedList<Traveller> travellers = new GenericDoublyLinkedList<Traveller>();
            string line = null;
            try 
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        string nameS = parts[0];
                        string hname = parts[1];
                        string htype = parts[2];
                        int nights = Convert.ToInt32(parts[3]);
                        Traveller t = new Traveller(nameS, hname, htype, nights);
                        if (!travellers.Contains(t))
                            travellers.AddToEnd(t);
                    }
                }    
            }
            catch(Exception)
            {
                throw;
            }
            return travellers;
        }

        /// <summary>
        /// Reads the file with hotels
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static GenericDoublyLinkedList<Hotel> ReadHotels(string filename)
        {
            GenericDoublyLinkedList<Hotel> hotels = new GenericDoublyLinkedList<Hotel>();
            string line = null;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        string name = parts[0];
                        string type = parts[1];
                        double price = Convert.ToDouble(parts[2]);
                        Hotel h = new Hotel(name, type, price);
                        if (!hotels.Contains(h))
                            hotels.AddToEnd(h);
                    }
                }
            }
            catch (Exception)
            {
                throw; 
            }
            return hotels;
        }
    }
}
