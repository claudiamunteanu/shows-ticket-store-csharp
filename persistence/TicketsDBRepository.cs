using System;
using System.Collections.Generic;
using app.persistence.interfaces;
using app.model;
using log4net;
using System.Data;
using System.Data.SQLite;

namespace app.persistence
{
    public class TicketsDBRepository : ITicketRepository
    {
        private static readonly ILog log = LogManager.GetLogger("UsersDBRepository");

        public TicketsDBRepository()
        {
            log.Info("Creating TicketsDBRepository");
        }

        public List<Ticket> FindAll()
        {
            log.Info("Entering TicketsDBRepository - FindAll");
            IDbConnection con = DBUtils.getConnection();
            List<Ticket> tickets = new List<Ticket> { };
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT s.Sid, s.ArtistName, datetime(s.DateTime / 1000, 'unixepoch') as DateTime, s.Place, s.AvailableSeats, s.SoldSeats from Shows s inner join Tickets on s.Sid = Tickets.ShowId";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long sid = long.Parse(reader["Sid"].ToString());
                        String artistName = reader["BuyerName"].ToString();

                        DateTime date = DateTime.Parse(reader["DateTime"].ToString());

                        String place = reader["Place"].ToString();
                        int availableSeats = int.Parse(reader["AvailableSeats"].ToString());
                        int soldSeats = int.Parse(reader["SoldSeats"].ToString());
                        long tid = long.Parse(reader["Tid"].ToString());

                        Show show = new Show(artistName, date, place, availableSeats, soldSeats)
                        {
                            Id = sid
                        };

                        String buyerName = reader["BuyerName"].ToString();
                        int seats = int.Parse(reader["NoOfSeats"].ToString());

                        Ticket ticket = new Ticket(show, buyerName, seats)
                        {
                            Id = tid
                        };
                        tickets.Add(ticket);
                    }
                }
            }
            log.Info("Exiting TicketsDBRepository - FindAll");
            return tickets;
        }

        public Ticket FindOne(long id)
        {
            log.InfoFormat("Entering TicketsDBRepository - FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            Ticket ticket = null;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT s.Sid, s.ArtistName, datetime(s.DateTime / 1000, 'unixepoch') as DateTime, s.Place, s.AvailableSeats, s.SoldSeats from Shows s inner join Tickets on s.Sid = Tickets.ShowId WHERE Tid=@tid;";
                cmd.Parameters.Add(new SQLiteParameter("@sid", id));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        long sid = long.Parse(reader["Sid"].ToString());
                        String artistName = reader["BuyerName"].ToString();

                        DateTime date = DateTime.Parse(reader["DateTime"].ToString());

                        String place = reader["Place"].ToString();
                        int availableSeats = int.Parse(reader["AvailableSeats"].ToString());
                        int soldSeats = int.Parse(reader["SoldSeats"].ToString());
                        long tid = long.Parse(reader["Tid"].ToString());

                        Show show = new Show(artistName, date, place, availableSeats, soldSeats)
                        {
                            Id = sid
                        };

                        String buyerName = reader["BuyerName"].ToString();
                        int seats = int.Parse(reader["NoOfSeats"].ToString());

                        ticket = new Ticket(show, buyerName, seats)
                        {
                            Id = tid
                        };
                    }
                }
            }
            log.InfoFormat("Exiting TicketsDBRepository - FindOne with value {0}", ticket);
            return ticket;
        }

        public Ticket Save(Ticket entity)
        {
            log.InfoFormat("Entering TicketsDBRepository - Save with value {0}", entity);
            IDbConnection con = DBUtils.getConnection();
            try
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Tickets (ShowId, BuyerName, NoOfSeats) VALUES (@s, @b, @n);";
                    cmd.Parameters.Add(new SQLiteParameter("@s", entity.Show.Id));
                    cmd.Parameters.Add(new SQLiteParameter("@b", entity.BuyerName));
                    cmd.Parameters.Add(new SQLiteParameter("@n", entity.NoOfSeats));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                log.Error(ex);
                Console.WriteLine("Error DB" + ex);
                return entity;
            }
            log.Info("Exiting TicketsDBRepository - Save");
            return null;
        }
    }
}
