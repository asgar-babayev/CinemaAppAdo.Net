using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class TodaysMovieCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from TodaysMovie");
        }
        public static void Create(int movieId, int sessionsId, int hallId, decimal price)
        {
            SqlOperation.Execute($"INSERT INTO TodaysMovie VALUES ({movieId},{price}, {sessionsId}, {hallId}, {price})");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE TodaysMovie WHERE Id = {id}");
        }
        public static void Update(int id)
        {
        SetChoise:
            Console.Write(@"Select the value you want to update 
(1:movieId 2:sessionsId 3:hallId, 4:price): ");
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
                    Console.Write("Enter new movieId: ");
                    try
                    {
                        Console.Write("Enter new movieId: ");
                        int movieId = Convert.ToInt32(Console.ReadLine());
                        if (movieId < 0) { Console.WriteLine("Enter again"); goto SetMovieId; }
                        SqlOperation.Execute($"UPDATE TodaysMovie SET MovieId = {movieId} WHERE Id = {id}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetMovieId;
                    }
                    break;
                case 2:
                SessionsId:
                    Console.Write("Enter new movieId: ");
                    try
                    {
                        Console.Write("Enter new movieId: ");
                        int sessionsId = Convert.ToInt32(Console.ReadLine());
                        if (sessionsId < 0) { Console.WriteLine("Enter again"); goto SessionsId; }
                        SqlOperation.Execute($"UPDATE TodaysMovie SET SessionsId = {sessionsId} WHERE Id = {id}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetMovieId;
                    }
                    break;
                case 3:
                SetHallId:
                    try
                    {
                        Console.Write("Enter new hallId: ");
                        int hallId = Convert.ToInt32(Console.ReadLine());
                        if (hallId < 0) { Console.WriteLine("Enter again"); goto SetHallId; }
                        SqlOperation.Execute($"UPDATE TodaysMovie SET HallId = {hallId} WHERE Id = {id}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 4:
                SetPrice:
                    Console.Write("Enter new price: ");
                    try
                    {
                        int price = Convert.ToInt32(Console.ReadLine());
                        if (price < 0) { Console.WriteLine("Price can't negative"); goto SetPrice; }
                        SqlOperation.Execute($"UPDATE TodaysMovie SET Price = {price} WHERE Id = {id}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetChoise;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
