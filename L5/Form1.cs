using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace L5
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class Main : Form
    {
        // All lists
        private GenericDoublyLinkedList<Hotel> Hotels;              // List of hotels
        private GenericDoublyLinkedList<Traveller> Travellers;      // List of travellers
        private GenericDoublyLinkedList<Hotel> ChosenHotels;        // List of chosen hotels
        private GenericDoublyLinkedList<Hotel> NotChosenHotels;     // List of NOT chosen hotels
        private GenericDoublyLinkedList<NightTraveller> MostList;   // List of travellers spent most nights
        private GenericDoublyLinkedList<PaidTraveller> PaidList;    // List of travellers who spent no more money than indicated

        // Files
        private string File1;           // First initial file
        private string File2;           // Second initial file
        private string FileResults;     // File of results

        /// <summary>
        /// Default form constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();
            ToggleControls();
            Travellers = new GenericDoublyLinkedList<Traveller>();
            Hotels = new GenericDoublyLinkedList<Hotel>();
            ChosenHotels = new GenericDoublyLinkedList<Hotel>();
            NotChosenHotels = new GenericDoublyLinkedList<Hotel>();
            MostList = new GenericDoublyLinkedList<NightTraveller>();
            PaidList = new GenericDoublyLinkedList<PaidTraveller>();
        }

        /// <summary>
        /// Toggling the controls of menu items
        /// </summary>
        /// <param name="enabled"></param>
        public void ToggleControls(bool enabled = false)
        {
            saveToolStripMenuItem.Enabled = enabled;
            chosenHotelsToolStripMenuItem.Enabled = enabled;
            notChosenHotelsToolStripMenuItem.Enabled = enabled;
            mostNightToolStripMenuItem.Enabled = enabled;
            paidToolStripMenuItem.Enabled = enabled;
        }

        private void label1_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Displaying the data
        /// </summary>
        /// <typeparam name="T">Any object</typeparam>
        /// <param name="label">Name of the table</param>
        /// <param name="tableHeader">Header of the table</param>
        /// <param name="Data">Data about objects</param>
        /// <param name="tableFooter">Footer of the table</param>
        public void Display<T>(string label, string tableHeader, 
            IEnumerable<T> Data, string tableFooter)
            where T: IComparable<T>, IEquatable<T>
        {
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(label);
            richTextBox1.AppendText(tableHeader);
            foreach(T element in Data)
            { 
                richTextBox1.AppendText(element.ToString() + Environment.NewLine);
            }
            richTextBox1.AppendText(tableFooter);
        }

        /// <summary>
        /// Menu item to read file with travellers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void travellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open initial data file: U14a.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File1 = openFileDialog1.FileName;
                try
                {
                    Travellers = IOUtils.ReadTravellers(File1);
                    Display("Travellers",
                     Traveller.Header(),
                    Travellers,
                     Traveller.Footer());
                    if (Travellers.Count != 0 &&
                     Hotels.Count != 0)
                        ToggleControls(true);
                }
                catch (Exception)
                {
                    ToggleControls(false);
                }
            }
        }

        /// <summary>
        /// Menu item to read file with hotels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open initial data file: U14b.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File2 = openFileDialog1.FileName;
                try
                {
                    Hotels = IOUtils.ReadHotels(File2);
                    Display("Hotels",
                        Hotel.Header(),
                        Hotels,
                        Hotel.Footer());
                    if (Travellers.Count != 0 && Hotels.Count != 0)
                        ToggleControls(true);
                }
                catch (Exception)
                {
                    ToggleControls(false);
                }
            }
        }

        /// <summary>
        /// Saving into the result file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save your results";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt|Word Documents|*.doc";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileResults = saveFileDialog1.FileName;
                using (StreamWriter writer = new StreamWriter(FileResults, false))
                {
                    foreach (string item in richTextBox1.Lines)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }

        }

        /// <summary>
        /// Closing the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Create and display chosen hotels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chosenHotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChosenHotels = TaskUtils.CreateChosenHotelList(Travellers, Hotels);
            if (ChosenHotels.Count != 0)
                Display("List of Hotels chosen by travellers",
                   Hotel.Header(),
                   ChosenHotels,
                   Hotel.Footer());
            else
                richTextBox1.AppendText("\nThere are no hotels chosen by travellers");
        }

        /// <summary>
        /// Create and display NOT chosen hotels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notChosenHotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotChosenHotels = TaskUtils.CreateNotChosenHotelList(Travellers, Hotels);
            if (NotChosenHotels.Count != 0)
                Display("List of Hotels NOT chosen by travellers",
                    Hotel.Header(),
                    NotChosenHotels,
                    Hotel.Footer());
            else
                richTextBox1.AppendText("\nAll hotels are chosen by travellers");
        }

        /// <summary>
        /// Create and display list of travellers with most spent nights
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostNightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostList = TaskUtils.MostNightsList(Travellers);
            if (MostList.Count != 0)
                Display("List of Travellers with most nights",
                    NightTraveller.Header(),
                    MostList,
                    NightTraveller.Footer());
            else
                richTextBox1.AppendText("\nThere are no travellers");
        }

        /// <summary>
        /// Create and display travellers spent money no more than indicated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double number = 0;
            if (textBox1.Text == "")
                MessageBox.Show("Enter a number");
            else
            {
                try
                {
                    number = Convert.ToDouble(textBox1.Text);
                    PaidList = TaskUtils.PaidMoreList(Travellers, Hotels, number);
                }
                catch 
                {
                    MessageBox.Show("Error in reading the text");
                }
                if (PaidList.Count != 0)
                {
                    string header = string.Format("List of travellers who paid not more than {0}", number);
                    Display(header,
                            PaidTraveller.Header(),
                            PaidList,
                            PaidTraveller.Footer());
                }
                else
                    richTextBox1.AppendText("\nThere are no such travellers");
            }
        }
    }
}
