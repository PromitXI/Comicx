using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sqlapp.Models;

namespace Sqlapp.Services
{
    public class ComicBookService
    {
        // Ensure to change the below variables to reflect the connection details for your database
        private static string db_source = "blulibrary.database.windows.net";
        private static string db_user = "promit";
        private static string db_password = "FlipFlop@123";
        private static string db_database = "comics";

        private SqlConnection GetConnection()
        {
            // Here we are creating the SQL connection
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public IEnumerable<ComicBook> GetComicBooks()
        {
            List<ComicBook> comicBooks = new List<ComicBook>();
            string query = "SELECT id, title, publication_year, cover FROM comic_books";
            using (SqlConnection connection = GetConnection())
            {
                // Open the connection
                connection.Open();

                // Execute the query to get the data from the comic_books table
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Use SqlDataReader to read the data from the query result
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComicBook comicBook = new ComicBook()
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                PublicationYear = reader.GetInt32(2),

                                Cover = reader.IsDBNull(3) ? null : reader.GetString(3)
                            };

                            comicBooks.Add(comicBook);
                        }
                    }
                }

                // Close the connection
                connection.Close();
            }

            return comicBooks;
        }

    }
}
