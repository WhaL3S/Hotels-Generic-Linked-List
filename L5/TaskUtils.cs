using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5
{
    /// <summary>
    /// Class for tasks
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Creates list of hotels chosen by travellers
        /// </summary>
        /// <param name="Travellers">List of travellers</param>
        /// <param name="Hotels">List of hotels</param>
        /// <returns>Generic doubly linked list</returns>
        public static GenericDoublyLinkedList<Hotel> CreateChosenHotelList(
            GenericDoublyLinkedList<Traveller> Travellers, 
            GenericDoublyLinkedList<Hotel> Hotels)
        {
            GenericDoublyLinkedList<Hotel> chosen = new GenericDoublyLinkedList<Hotel>();
            foreach(Hotel h in Hotels)
                foreach (Traveller t in Travellers)
                    if (h.Name == t.HName && !chosen.Contains(h))
                        chosen.AddToEnd(h);
            return chosen;
        }

        /// <summary>
        /// Creates list of hotels NOT chosen by travellers
        /// </summary>
        /// <param name="Travellers">List of travellers</param>
        /// <param name="Hotels">List of hotels</param>
        /// <returns>Generic doubly linked list</returns>
        public static GenericDoublyLinkedList<Hotel> CreateNotChosenHotelList(
            GenericDoublyLinkedList<Traveller> Travellers,
            GenericDoublyLinkedList<Hotel> Hotels)
        {
            GenericDoublyLinkedList<Hotel> notChosen = new GenericDoublyLinkedList<Hotel>();
            foreach(Hotel h in Hotels)
                if(!CreateChosenHotelList(Travellers, Hotels).Contains(h))
                    notChosen.AddToEnd(h);
            return notChosen;
        }

        /// <summary>
        /// Private method to create list of travellers with spent nights
        /// </summary>
        /// <param name="Travellers">List of travellers</param>
        /// <returns>Generic doubly linked list</returns>
        private static GenericDoublyLinkedList<NightTraveller> CreateTravellersNightsList(
            GenericDoublyLinkedList<Traveller> Travellers)
        {
            GenericDoublyLinkedList<NightTraveller> NightTravellers = 
                new GenericDoublyLinkedList<NightTraveller>();
            foreach (Traveller t1 in Travellers)
            {
                int sum = 0;
                foreach (Traveller t2 in Travellers)
                    if (t1.NameS == t2.NameS)
                        sum = sum + t2.Nights;
                NightTraveller nt = new NightTraveller(t1.NameS, sum);
                NightTravellers.AddToEnd(nt);
            }
            return NightTravellers;
        }

        /// <summary>
        /// Method to create list of travellers with most spent nights
        /// </summary>
        /// <param name="Travellers">List of travellers</param>
        /// <returns>Generic doubly linked list</returns>
        public static GenericDoublyLinkedList<NightTraveller> MostNightsList(
                GenericDoublyLinkedList<Traveller> Travellers)
        {
            int mostNights = 0;
            GenericDoublyLinkedList<NightTraveller> most =
               new GenericDoublyLinkedList<NightTraveller>();
            GenericDoublyLinkedList<NightTraveller> list = CreateTravellersNightsList(Travellers);
            foreach (NightTraveller nt in list)
                if(nt.Nights > mostNights)
                    mostNights = nt.Nights;
            foreach(NightTraveller nt in list)
                if (mostNights == nt.Nights && !most.Contains(nt))
                    most.AddToEnd(nt);
            most.Sort();
            return most;
        }

        /// <summary>
        /// Private method to create list of travellers with spent money
        /// </summary>
        /// <param name="Travellers">List of travellers</param>
        /// <param name="Hotels">List of hotels</param>
        /// <returns>Generic doubly linked list</returns>
        private static GenericDoublyLinkedList<PaidTraveller> TravellersSumList(
                        GenericDoublyLinkedList<Traveller> Travellers, 
                        GenericDoublyLinkedList<Hotel> Hotels)
        {
            GenericDoublyLinkedList<PaidTraveller> list = new GenericDoublyLinkedList<PaidTraveller>();
            foreach(Traveller t in Travellers)
            {
                PaidTraveller pt = new PaidTraveller(t.NameS, 0);
                if(!list.Contains(pt))
                    list.AddToEnd(pt);
            }
            foreach(PaidTraveller pt in list)
            {
                double sum = 0;
                foreach(Traveller t in Travellers)
                    if(pt.NameS == t.NameS)
                        PriceSummarizer(ref sum, Hotels, t);
                pt.Spent = sum;
            }
            return list;
        }

        /// <summary>
        /// Private method to summarize the total cost of each traveller
        /// </summary>
        /// <param name="sum">Total sum of money</param>
        /// <param name="Hotels">List of hotels</param>
        /// <param name="t">Traveller</param>
        private static void PriceSummarizer(ref double sum, GenericDoublyLinkedList<Hotel> Hotels, Traveller t)
        {
            foreach (Hotel h in Hotels)
                if (t.HName == h.Name && t.HType == h.Type)
                    sum = sum + h.Price;
        }

        /// <summary>
        /// Method to create list of travellers who spent NO more than indicated number
        /// </summary>
        /// <param name="Travellers">List of travellers</param>
        /// <param name="Hotels">List of hotels</param>
        /// <param name="number">Indicated number to not be exceeded</param>
        /// <returns>Generic doubly linked list</returns>
        public static GenericDoublyLinkedList<PaidTraveller> PaidMoreList(
                       GenericDoublyLinkedList<Traveller> Travellers,
                       GenericDoublyLinkedList<Hotel> Hotels, double number)
        {
            GenericDoublyLinkedList<PaidTraveller> list = TravellersSumList(Travellers, Hotels);
            GenericDoublyLinkedList<PaidTraveller> paidMoreList = new GenericDoublyLinkedList<PaidTraveller>();
            foreach(PaidTraveller pt in list)
                if(pt.Spent <= number && pt.Spent > 0)
                    paidMoreList.AddToEnd(pt);
            return paidMoreList;
        }
    }
}
