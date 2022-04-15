using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace CinemaAppAdoNet.Queries
{
    public class TicketsCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Tickets");
        }
        public static void Create(string soldDate, decimal price, int place, int movieId, int hallId, int sessionsId, int customerId)
        {
            SqlOperation.Execute($"INSERT INTO Tickets VALUES (N'{soldDate}','{price}', '{place}', '{movieId}', '{hallId}', '{sessionsId}', '{customerId}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Tickets WHERE Id = {id}");
        }

        public static void Update(int id)
        {
        SetChoise:
            Console.Write(@"Select the value you want to update 
(1:Sold Date 2:Place 3:TodaysMovieId, 4:CustomerId): ");
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
                SetSoldDate:
                    Console.Write("Enter new sold date: ");
                    string soldDate = Console.ReadLine();
                    Regex regex = new Regex(@"\d{4}-[01]\d-[0-3]\dT[0-2]\d:[0-5]\d:[0-5]\d(?:\.\d+)?Z?");
                    if (!regex.IsMatch(soldDate)) { Console.WriteLine("Enter again"); goto SetSoldDate; }
                    SqlOperation.Execute($"UPDATE Tickets SET SoldDate = '{soldDate}' WHERE Id = {id}");
                    break;
                case 2:
                SetPlace:
                    Console.Write("Enter new place: ");
                    try
                    {
                        int place = Convert.ToInt32(Console.ReadLine());
                        if (place < 0) { Console.WriteLine("Enter again"); goto SetPlace; }
                        SqlOperation.Execute($"UPDATE Tickets SET Place = {place} WHERE Id = {id}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetPlace;
                    }
                    break;
                case 3:
                SetTodaysMovieId:
                    try
                    {
                        Console.Write("Enter new movieId: ");
                        int movieId = Convert.ToInt32(Console.ReadLine());
                        if (movieId < 0) { Console.WriteLine("Enter again"); goto SetTodaysMovieId; }
                        SqlOperation.Execute($"UPDATE Tickets SET TodaysMovieId = {movieId} WHERE Id = {id}");

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetTodaysMovieId;
                    }
                    break;
                case 4:
                SetCustomerId:
                    try
                    {
                        Console.Write("Enter new customerId: ");
                        int customerId = Convert.ToInt32(Console.ReadLine());
                        if (customerId < 0) { Console.WriteLine("Enter again"); goto SetCustomerId; }
                        SqlOperation.Execute($"UPDATE Tickets SET CustomerId = {customerId} WHERE Id = {id}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto SetCustomerId;
                    }
                    break;
                default:
                    Console.WriteLine("Enter again");
                    break;
            }
        }

        public static void BuyTickets()
        {
            using (SqlOperation.conn)
            {
                Console.WriteLine("Enter id");
                int todaysMovieId = int.Parse(Console.ReadLine());
                SqlOperation.conn.Open();
                string comm = $@"SELECT COUNT(Place) from Tickets
WHERE TodaysMovieId = {todaysMovieId}";

                SqlDataAdapter da = new SqlDataAdapter(comm, SqlOperation.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var i = dt.Rows[0][0];

                string comm2 = $@"SELECT Halls.SeatCount From TodaysMovies
Join Halls
On
Halls.Id = TodaysMovies.HallId
Where TodaysMovies.Id = {todaysMovieId}";

                da = new SqlDataAdapter(comm2, SqlOperation.conn);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                var i2 = dt2.Rows[0][0];
                int place = Convert.ToInt32(i);
                int seatCount = Convert.ToInt32(i2);
                string result = "";
                if (place < seatCount)
                {
                    string selectPlaceQuery = $"Select Place From Tickets where Tickets.TodaysMovieId = {todaysMovieId}";
                    da = new SqlDataAdapter(selectPlaceQuery, SqlOperation.conn);
                    DataTable dt3 = new DataTable();
                    da.Fill(dt3);
                    Console.WriteLine("Enter place");
                    int Place2 = Convert.ToInt32(Console.ReadLine());
                    bool isOk = true;

                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            result += dr[j];
                            if (result == Place2.ToString())
                            {
                                Console.WriteLine("Yer doludur");
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if (isOk == true)
                    {
                        Console.WriteLine("Enter customerId: ");
                        int CustomerId = Convert.ToInt32(Console.ReadLine());
                        InsertTickets(todaysMovieId, CustomerId, Place2);
                        Console.WriteLine("Created");
                    }
                }
            }
        }

        private static void InsertTickets(int TodaysMovieId, int CustomerId, int Place)
        {
            string query = $@"INSERT INTO Tickets (TodaysMovieId , CustomerId, Place)
Values ({TodaysMovieId},{CustomerId},{Place})";
            using (SqlCommand command = new SqlCommand(query, SqlOperation.conn))
            {
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"({result} row affected)");
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine("-------------------------------");
                }
            }
        }
    }
}
