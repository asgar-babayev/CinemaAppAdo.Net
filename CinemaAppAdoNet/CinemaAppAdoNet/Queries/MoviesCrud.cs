using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CinemaAppAdoNet.Queries
{
    public class MoviesCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Movies");
        }
        public static void Create(string name, string releaseDate)
        {
            SqlOperation.Execute($"INSERT INTO Movies VALUES (N'{name}', N'{releaseDate}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Movies WHERE Id = {id}");
        }

        public static void Update(int id)
        {
        SetChoise:
            Console.Write(@"Select the value you want to update (1:Name 2:Release date): ");
            int choise;
            try
            {
                choise = Convert.ToInt32(Console.ReadLine());
                if (choise < 0) { Console.WriteLine("Choise can't negative"); goto SetChoise; }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                goto SetChoise;
            }
            switch (choise)
            {
                case 1:
                SetMovieName:
                    Console.Write("Enter new movie name: ");
                    string movieName = Console.ReadLine();
                    if (string.IsNullOrEmpty(movieName)) goto SetMovieName;
                    SqlOperation.Execute($"UPDATE Movies SET Name = '{movieName}' WHERE Id = {id}");
                    break;
                case 2:
                SetReleaseDate:
                    Console.Write("Enter new release date: ");
                    Regex regex = new Regex(@"^([\d]{4})([\-])([\d]{2})([\-])([\d]{2})$");
                    string releaseDate = Console.ReadLine();
                    if (!regex.IsMatch(releaseDate)) { Console.WriteLine("Enter again"); goto SetReleaseDate; }
                    SqlOperation.Execute($"UPDATE Movies SET ReleaseDate = '{releaseDate}' WHERE Id = {id}");
                    break;
                default:
                    break;
            }
        }
    }
}
