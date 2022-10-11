using System;
using System.Collections.Generic;
using app.model;

namespace app.services
{
    public interface IAppServices
    {
        IList<Show> GetAllShows();

        User Login(String username, String password, IAppObserver client);

        IList<Show> GetFilteredShows(DateTime date);

        void BuyTicket(long showId, String buyerName, int noOfSeats);

        User LoginNewUser(String username, String password, String password2, IAppObserver client);

        void Logout(User user);
    }
}
