using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class MoviesGenres
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from MoviesGenres");
        }
        public static void Create(int movieId, int genreId)
        {
            SqlOperation.Execute($"INSERT INTO MoviesGenres VALUES ('{movieId}', '{genreId}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE MoviesGenres WHERE Id = {id}");
        }

        public static void Update(int id)
        {
        SetChoise:
            Console.Write(@"Select the value you want to update (1:MovieId 2:GenreId): ");
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
                SetMovieId:
                    try
                    {
                        Console.Write("Enter new movie id: ");
                        int movieId = Convert.ToInt32(Console.ReadLine());
                        if (movieId < 0) { Console.WriteLine("Enter again"); goto SetMovieId; }
                        SqlOperation.Execute($"UPDATE MoviesGenres SET MovieId = '{movieId}' WHERE Id = {id}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetMovieId;
                    }
                    break;
                case 2:
                SetGenreId:
                    try
                    {
                        Console.Write("Enter new genre id: ");
                        int genreId = Convert.ToInt32(Console.ReadLine());
                        if (genreId < 0) { Console.WriteLine("Enter again"); goto SetGenreId; }
                        SqlOperation.Execute($"UPDATE MoviesGenres SET GenreId = '{genreId}' WHERE Id = {id}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetGenreId;
                    }
                    break;
                default:
                    Console.WriteLine("Enter again");
                    break;
            }
        }
    }
}
