using System;
using System.Collections.Generic;
using app.persistence.interfaces;
using app.model;
using log4net;
using System.Data;
using System.Data.SQLite;

namespace app.persistence
{
    public class UsersDBRepository : IUserRepository
    {
        private static readonly ILog log = LogManager.GetLogger("UsersDBRepository");

        public UsersDBRepository()
        {
            log.Info("Creating UsersDBRepository");
        }

        public List<User> FindAll()
        {
            log.Info("Entering UsersDBRepository - FindAll");
            IDbConnection con = DBUtils.getConnection();
            List<User> users = new List<User> { };
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long uid = long.Parse(reader["Uid"].ToString());
                        String username = reader["Username"].ToString();
                        String password = reader["Password"].ToString();
                        User user = new User(username, password)
                        {
                            Id = uid
                        };
                        users.Add(user);
                    }
                }
            }
            log.Info("Exiting UsersDBRepository - FindAll");
            return users;
        }

        public User FindOne(long id)
        {
            log.InfoFormat("Entering UsersDBRepository - FindOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();
            User user = null;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Uid=@uid;";
                cmd.Parameters.Add(new SQLiteParameter("@uid", id));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        long uid = long.Parse(reader["Uid"].ToString());
                        String username = reader["Username"].ToString();
                        String password = reader["Password"].ToString();
                        user = new User(username, password)
                        {
                            Id = uid
                        };
                    }
                }
            }
            log.InfoFormat("Exiting UsersDBRepository - FindOne with value {0}", user);
            return user;
        }

        public User GetUser(string username, string password)
        {
            log.InfoFormat("Entering UsersDBRepository - GetUser with values {0}, {1}", username, password);
            IDbConnection con = DBUtils.getConnection();
            User user = null;
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Username=@username and Password=@password;";
                cmd.Parameters.Add(new SQLiteParameter("@username", username));
                cmd.Parameters.Add(new SQLiteParameter("@password", password));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        long uid = long.Parse(reader["Uid"].ToString());
                        String username2 = reader["Username"].ToString();
                        String password2 = reader["Password"].ToString();
                        user = new User(username2, password2)
                        {
                            Id = uid
                        };
                    }
                }
            }
            log.InfoFormat("Exiting UsersDBRepository - GetUser with value {0}", user);
            return user;
        }

        public User Save(User entity)
        {
            log.InfoFormat("Entering UsersDBRepository - Save with value {0}", entity);
            IDbConnection con = DBUtils.getConnection();
            try
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Users (Username, Password) VALUES (@username, @password);";
                    cmd.Parameters.Add(new SQLiteParameter("@username", entity.Username));
                    cmd.Parameters.Add(new SQLiteParameter("@password", entity.Password));

                    cmd.ExecuteNonQuery();
                }

            }
            catch (SQLiteException ex)
            {
                log.Error(ex);
                Console.WriteLine("Error DB" + ex);
                return entity;
            }
            log.Info("Exiting UsersDBRepository - Save");
            return null;
        }
    }
}
