using System;

namespace app.model
{
    [Serializable]
    public class Show : Entity<long>
    {
        public string ArtistName { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public int AvailableSeats { get; set; }
        public int SoldSeats { get; set; }

        public Show()
        {

        }

        public Show(string artistName, DateTime dateTime, string place, int availableSeats, int soldSeats)
        {
            ArtistName = artistName;
            DateTime = dateTime;
            Place = place;
            AvailableSeats = availableSeats;
            SoldSeats = soldSeats;
        }

        public override string ToString()
        {
            return string.Format(
                "[Show: ID={0}, ArtistName={1}, DateTime={2}, Place={3}, AvailableSeats={4}, SoldSeats={5}]", Id,
                ArtistName, DateTime, Place, AvailableSeats, SoldSeats);
        }
    }
}
