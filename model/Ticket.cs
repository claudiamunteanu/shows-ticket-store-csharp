using System;

namespace app.model
{
    [Serializable]
    public class Ticket : Entity<long>
    {
        public Show Show { get; set; }
        public string BuyerName { get; set; }
        public int NoOfSeats { get; set; }

        public Ticket()
        {

        }

        public Ticket(Show show, string buyerName, int noOfSeats)
        {
            Show = show;
            BuyerName = buyerName;
            NoOfSeats = noOfSeats;
        }

        public override string ToString()
        {
            return Id + " " + Show + " " + BuyerName + " " + NoOfSeats;
        }
    }
}
