using System;
using System.Collections.Generic;
using System.Configuration;
using app.persistence.interfaces;
using app.model;
using System.Data;
using log4net;
using System.Data.SQLite;
using log4net.Config;

namespace app.persistence
{
    public class ShowsDBRepository : IShowRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ShowsDBRepository");

        public ShowsDBRepository()
        {
            log.Info("Creating ShowsDBRepository");
        }

        public List<Show> FilterByDate(DateTime date)
        {
            log.InfoFormat("Entering ShowsDBRepository - FilterByDate with value {0}", date);
            IDbConnection con = DBUtils.getConnection();
            List<Show> shows = new List<Show> { };
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Shows where date(DateTime/1000, 'unixepoch')='" + date.ToString("yyyy-MM-dd") + "'";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long sid = long.Parse(reader["Sid"].ToString());
                        String artistName = reader["ArtistName"].ToString();

                        long milliseconds = long.Parse(reader["DateTime"].ToString());
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
                        DateTime dateTime = dateTimeOffset.DateTime;

                        String place = reader["Place"].ToString();
                        int availableSeats = int.Parse(reader["AvailableSeats"].ToString());
                        int soldSeats = int.Parse(reader["SoldSeats"].ToString());

                        Show show = new Show(artistName, dateTime, place, availableSeats, soldSeats)
                        {
                            Id = sid
                        };
                        shows.Add(show);
                    }
                }
            }
            log.Info("Exiting ShowsDBRepository - FilterByDate");
            return shows;
        }

        public List<Show> FindAll()
        {
            log.Info("Entering ShowsDBRepository - FindAll");
            IDbConnection con = DBUtils.getConnection();
            List<Show> shows = new List<Show> { };
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Shows";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long sid = long.Parse(reader["Sid"].ToString());
                        String artistName = reader["ArtistName"].ToString();

                        String dateTimeString = reader["DateTime"].ToString();
                        long milliseconds = long.Parse(dateTimeString);
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
                        DateTime date = dateTimeOffset.DateTime;

                        String place = reader["Place"].ToString();
                        int availableSeats = int.Parse(reader["AvailableSeats"].ToString());
                        int soldSeats = int.Parse(reader["SoldSeats"].ToString());

                        Show show = new Show(artistName, date, place, availableSeats, soldSeats)
                        {
                            Id = sid
                        };
                        shows.Add(show);
                    }
                }
            }
            log.Info("Exiting ShowsDBRepository - FindAll");
            return shows;
        }

        public Show FindOne(long id)
        {
            log.InfoFormat("Entering ShowsDBRepository - FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            Show show = null;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Shows WHERE Sid=" + id + ";";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        long sid = long.Parse(reader["Sid"].ToString());
                        String artistName = reader["ArtistName"].ToString();

                        long milliseconds = long.Parse(reader["DateTime"].ToString());
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
                        DateTime date = dateTimeOffset.DateTime;

                        String place = reader["Place"].ToString();
                        int availableSeats = int.Parse(reader["AvailableSeats"].ToString());
                        int soldSeats = int.Parse(reader["SoldSeats"].ToString());

                        show = new Show(artistName, date, place, availableSeats, soldSeats)
                        {
                            Id = sid
                        };

                    }
                }
                log.InfoFormat("Exiting ShowsDBRepository - FindOne with value {0}", show);
            }
            return show;
        }

        public Show Save(Show entity)
        {
            log.InfoFormat("Entering ShowsDBRepository - Save with value {0}", entity);
            IDbConnection con = DBUtils.getConnection();
            try
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Shows (ArtistName, DateTime, Place, AvailableSeats, SoldSeats) VALUES (@a, @d, @p, @as, @ss);";

                    var paramArtistName = cmd.CreateParameter();
                    paramArtistName.ParameterName = "@a";
                    paramArtistName.Value = entity.ArtistName;
                    cmd.Parameters.Add(paramArtistName);

                    DateTime dateTime = entity.DateTime;
                    dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
                    DateTimeOffset dateTimeOffset = dateTime;
                    long unixtime = dateTimeOffset.ToUnixTimeMilliseconds();

                    var paramDateTime = cmd.CreateParameter();
                    paramDateTime.ParameterName = "@d";
                    paramDateTime.Value = unixtime;
                    cmd.Parameters.Add(paramDateTime);

                    var paramPlace = cmd.CreateParameter();
                    paramPlace.ParameterName = "@p";
                    paramPlace.Value = entity.Place;
                    cmd.Parameters.Add(paramPlace);

                    var paramAvailableSeats = cmd.CreateParameter();
                    paramAvailableSeats.ParameterName = "@as";
                    paramAvailableSeats.Value = entity.AvailableSeats;
                    cmd.Parameters.Add(paramAvailableSeats);

                    var paramSoldSeats = cmd.CreateParameter();
                    paramSoldSeats.ParameterName = "@ss";
                    paramSoldSeats.Value = entity.SoldSeats;
                    cmd.Parameters.Add(paramSoldSeats);

                    cmd.ExecuteNonQuery(); ;
                }
            }
            catch(SQLiteException ex)
            {
                log.Error(ex);
                Console.WriteLine("Error DB" + ex);
                return entity;
            }
            
            log.Info("Exiting ShowsDBRepository - Save");
            return null;
        }

        public void UpdateSeats(long id, int noOfSeats)
        {
            log.InfoFormat("Entering ShowsDBRepository - UpdateSeats with values {0}, {1}", id, noOfSeats);
            IDbConnection con = DBUtils.getConnection();
            try
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "update Shows set AvailableSeats=AvailableSeats-@seats, SoldSeats=SoldSeats+@seats where Sid=" + id + ";";

                    var paramSeats = cmd.CreateParameter();
                    paramSeats.ParameterName = "@seats";
                    paramSeats.Value = noOfSeats;
                    cmd.Parameters.Add(paramSeats);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                log.Error(ex);
                Console.WriteLine("Error DB" + ex);
            }
            log.Info("Exiting ShowsDBRepository - UpdateSeats");
        }
    }
}
