using System;
using System.Collections.Generic;
using app.services;
using app.model;

namespace app.client
{
    public class AppClientController : MarshalByRefObject, IAppObserver
    {
        public event EventHandler<AppUserEventArgs> updateEvent; //ctrl calls it when it has received an update
        private readonly IAppServices Server;
        private User User;

        public AppClientController(IAppServices server)
        {
            this.Server = server;
            User = null;
        }

        public void Login(String username, String password)
        {
            User = Server.Login(username, password, this);
            Console.WriteLine("Login succeeded ....");
            Console.WriteLine("Current user {0}", User);
        }

        public void NewUserLogin(String username, String password, String confirmPassword)
        {
            User = Server.LoginNewUser(username, password, confirmPassword, this);
            Console.WriteLine("New User Login succeeded ....");
            Console.WriteLine("Current user {0}", User);
        }

        public void Logout()
        {
            Console.WriteLine("Loging out....");
            Server.Logout(User);
            User = null;
        }

        public User GetUser()
        {
            return User;
        }

        public IList<Show> GetAllShows()
        {
            IList<Show> shows = Server.GetAllShows();
            Console.WriteLine("Showing all shows ....");
            return shows;
        }

        public IList<Show> GetFilteredShows(DateTime date)
        {
            IList<Show> filteredShows = Server.GetFilteredShows(date);
            Console.WriteLine("Showing all filtered shows ....");
            return filteredShows;
        }

        public void BuyTicket(long showId, String buyerName, int seats)
        {
            //display the ticket bought on the user window
            long[] ticketData = new long[] { showId, seats };
            //AppUserEventArgs userArgs = new AppUserEventArgs(AppUserEvent.TicketBought, ticketData);
            //OnUserEvent(userArgs);
            //sends the ticket to the server
            Server.BuyTicket(showId, buyerName, seats);
        }

        public void TicketBought(long[] ticketData)
        {
            AppUserEventArgs userArgs = new AppUserEventArgs(AppUserEvent.TicketBought, ticketData);
            Console.WriteLine("Ticket received");
            OnUserEvent(userArgs);
        }

        protected virtual void OnUserEvent(AppUserEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }
    }
}
