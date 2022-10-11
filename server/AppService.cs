using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.persistence.interfaces;
using app.server.validators;
using app.services;
using app.model;

namespace app.server
{
    public class AppService : MarshalByRefObject, IAppServices
    {
        private IShowRepository ShowRepository;
        private ITicketRepository TicketRepository;
        private IUserRepository UserRepository;
        private UserValidator UserValidator;
        private TicketValidator TicketValidator;

        private readonly IDictionary<long, IAppObserver> LoggedClients;

        public AppService(IShowRepository showRepository, ITicketRepository ticketRepository, IUserRepository userRepository, UserValidator userValidator, TicketValidator ticketValidator)
        {
            this.ShowRepository = showRepository;
            this.TicketRepository = ticketRepository;
            this.UserRepository = userRepository;
            this.UserValidator = userValidator;
            this.TicketValidator = ticketValidator;

            LoggedClients = new Dictionary<long, IAppObserver>();
        }

        public IList<Show> GetAllShows()
        {
            return ShowRepository.FindAll();
        }

        public User Login(String username, String password, IAppObserver client)
        {
            UserValidator.Validate(new List<string>(new[] { username, password }));
            User user = UserRepository.GetUser(username, password);
            if (user == null)
                throw new AppException("There is no user with this username\nand password!");
            else
            {
                if (LoggedClients.ContainsKey(user.Id))
                    throw new AppException("User already logged in!");
                LoggedClients[user.Id] = client;
            }
            return user;
        }

        public IList<Show> GetFilteredShows(DateTime date)
        {
            return ShowRepository.FilterByDate(date);
        }

        public void BuyTicket(long showId, String buyerName, int noOfSeats)
        {
            TicketValidator.Validate(new List<string>(new[] { showId.ToString(), buyerName }));
            Ticket ticket = new Ticket(ShowRepository.FindOne(showId), buyerName, noOfSeats);
            TicketRepository.Save(ticket);
            ShowRepository.UpdateSeats(showId, noOfSeats);
            long[] ticketData = { showId, (long)noOfSeats };
            NotifyTicketBought(ticketData);
        }

        private void NotifyTicketBought(long [] ticketData)
        {
            Console.WriteLine("notify ticket bought ");
            foreach (long userID in LoggedClients.Keys)
            {
                IAppObserver client = LoggedClients[userID];
                Task.Run(() => client.TicketBought(ticketData));
            }
        }

        public User LoginNewUser(String username, String password, String password2, IAppObserver client)
        {
            UserValidator.Validate(new List<string>(new[] { username, password }));
            if (!password.Equals(password2))
                throw new AppException("The passwords have to match!");
            User user = UserRepository.Save(new User(username, password));
            if (user != null)
                throw new AppException("There already exists an user with this username!");
            User user2 = UserRepository.GetUser(username, password);
            LoggedClients[user2.Id] = client;
            return user2;
        }

        public void Logout(User user)
        {
            LoggedClients.Remove(user.Id);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
