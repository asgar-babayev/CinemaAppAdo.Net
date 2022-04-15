using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class GenresCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Genres");
        }
        public static void Create(string name)
        {
            SqlOperation.Execute($"INSERT INTO Genres VALUES (N'{name}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Genres WHERE Id = {id}");
        }

        public static void Update(int id)
        {
        SetGenreName:
            Console.Write("Set new genre name: ");
            string genreName = Console.ReadLine();
            if (string.IsNullOrEmpty(genreName)) goto SetGenreName;
            SqlOperation.Execute($"UPDATE Genres SET Name = '{genreName}' WHERE Id = {id}");
        }
    }
}
