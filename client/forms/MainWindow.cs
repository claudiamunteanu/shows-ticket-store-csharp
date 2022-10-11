using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using app.model;
using app.services;

namespace app.client.forms
{
    public partial class MainWindow : Form
    {
        private AppClientController Controller;

        private IList<Show> Shows;
        private IList<Show> FilteredShows;

        public MainWindow(AppClientController ctrl)
        {
            InitializeComponent();

            Controller = ctrl;

            InitLogin();

            this.Text = "Welcome " + Controller.GetUser().Username + "!";
            Shows = Controller.GetAllShows();
            FilteredShows = new List<Show>();
            InitDataGridViewShows();

            Controller.updateEvent += userUpdate;
        }

        private void InitDataGridViewShows()
        {
            Console.WriteLine("Updating the table of the shows");
            dataGridViewShows.Rows.Clear();
            foreach (Show s in Shows)
            {
                string[] row = new string[] { s.ArtistName, s.DateTime.ToString(), s.Place, s.AvailableSeats.ToString(), s.SoldSeats.ToString() };
                dataGridViewShows.Rows.Add(row);
            }
            Console.WriteLine("Finished updating the table of the shows");
        }

        private void InitDataGridViewFilteredShows()
        {
            Console.WriteLine("Updating the table of the filtered shows");
            dataGridViewFilteredShows.Rows.Clear();
            foreach (Show s in FilteredShows)
            {
                string[] row = new string[] { s.Id.ToString(), s.DateTime.ToString("dd/MM/yyyy"), s.ArtistName, s.Place, s.DateTime.ToString("HH:mm"), s.AvailableSeats.ToString() };
                dataGridViewFilteredShows.Rows.Add(row);
            }
            Console.WriteLine("Finished updating the table of the filtered shows");
        }

        private void btnSearchShows_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker.Value;
            FilteredShows = Controller.GetFilteredShows(date);
            InitDataGridViewFilteredShows();
            labelErrors.Text = "";
            labelTitle.Text = "Shows from date " + date.ToString("dd/MM/yyyy");
            this.numericUpDownNoOfSeats.Minimum = 1;
            this.numericUpDownNoOfSeats.Maximum = 100;
        }

        private void dataGridViewFilteredShows_CellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                int availableSeats = Convert.ToInt32(e.Value);

                if (availableSeats == 0)
                {
                    dataGridViewFilteredShows.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void dataGridViewFilteredShows_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dataGridViewFilteredShows.SelectedCells[0].RowIndex;
            int availableSeats = Int32.Parse(dataGridViewFilteredShows.Rows[selectedRow].Cells["AvailableSeatsColumn2"].Value.ToString());
            labelErrors.Text = "";
            if (availableSeats > 0)
            {
                numericUpDownNoOfSeats.Minimum = 1;
                numericUpDownNoOfSeats.Maximum = availableSeats;
                numericUpDownNoOfSeats.Value = 1;
                btnBuyTicket.Enabled = true;
            }
            else
            {
                numericUpDownNoOfSeats.Minimum = 0;
                numericUpDownNoOfSeats.Maximum = 0;
                btnBuyTicket.Enabled = false;
            }
        }

        private void InitLogin()
        {
            WelcomeWindow welcomeForm = new WelcomeWindow(Controller);
            welcomeForm.ShowDialog();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Controller.Logout();
            this.Hide();
            FilteredShows.Clear();
            dataGridViewFilteredShows.Rows.Clear();
            labelErrors.Text = "";
            labelTitle.Text = "";
            InitLogin();
            User user = Controller.GetUser();
            if (user != null)
            {
                this.Text = "Welcome " + user.Username + "!";
                this.Show();
            }
            else
                Application.Exit();
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = dataGridViewFilteredShows.SelectedCells[0].RowIndex;
                long showId = long.Parse(dataGridViewFilteredShows.Rows[selectedRow].Cells["IdColumn2"].Value.ToString());
                String buyerName = textBoxBuyerName.Text;
                int seats = Int32.Parse(numericUpDownNoOfSeats.Value.ToString());
                Controller.BuyTicket(showId, buyerName, seats);
                textBoxBuyerName.Clear();
                numericUpDownNoOfSeats.Minimum = 1;
                labelErrors.ForeColor = Color.Black;
                labelErrors.Text = "Ticket bought successfully!";
            }
            catch (AppException ex)
            {
                labelErrors.ForeColor = Color.Red;
                labelErrors.Text = ex.Message;
            }
        }

        public void userUpdate(object sender, AppUserEventArgs e)
        {
            if (e.UserEventType == AppUserEvent.TicketBought)
            {
                long[] ticketData = (long[]) e.Data;
                Console.WriteLine("[MainWindow] ticketBought " + ticketData.ToString());
                dataGridViewShows.BeginInvoke(new UpdateDataGridViewCallback(this.updateShows), new Object[]{ticketData});
                dataGridViewFilteredShows.BeginInvoke(new UpdateDataGridViewCallback(this.updateFilteredShows), new Object[] {ticketData});
            }
        }
        //for updating the GUI

        //1. define a method for updating the ListBox
        
        private void updateShows(long[] ticketData)
        {
            Console.WriteLine("Updating the list of the shows...");
            Show show = null;
            int index = 0;
            foreach (Show s in Shows)
            {
                if (s.Id == ticketData[0])
                {
                    show = s;
                    index = Shows.IndexOf(show);
                    break;
                }
            }
            int seats = show.AvailableSeats - int.Parse(ticketData[1].ToString());
            show.AvailableSeats = seats;
            Shows[index] = show;
            Console.WriteLine("Finished updating the list of the shows");
            InitDataGridViewShows();
        }

        private void updateFilteredShows(long[] ticketData)
        {
            Console.WriteLine("Updating the list of the filtered shows");
            Show show = null;
            int index = 0;
            foreach (Show s in FilteredShows)
            {
                if (s.Id == ticketData[0])
                {
                    show = s;
                    index = FilteredShows.IndexOf(show);
                    break;
                }
            }
            if (show != null)
            {
                int seats = show.AvailableSeats - int.Parse(ticketData[1].ToString());
                show.AvailableSeats = seats;
                FilteredShows[index] = show;
                Console.WriteLine("Finished updating the list of the filtered shows");
                InitDataGridViewFilteredShows();
            }
        }


        //2. define a delegate to be called back by the GUI Thread
        public delegate void UpdateDataGridViewCallback(long [] ticketData);



        //3. in the other thread call like this:
        /*
         * list.Invoke(new UpdateListBoxCallback(this.updateListBox), new Object[]{list, data});
         * 
         * */
    }
}
