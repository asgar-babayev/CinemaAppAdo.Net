using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class HallsCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Halls");
        }
        public static void Create(string name, int seatCount)
        {
            SqlOperation.Execute($"INSERT INTO Halls VALUES (N'{name}', {seatCount})");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Halls WHERE Id = {id}");
        }

        public static void Update(int id)
        {
        SetId:
            Console.Write(@"Select the value you want to update (1:Name 2:Seat count): ");
            int.TryParse(Console.ReadLine(), out int choise);
            if (choise < 0) { Console.WriteLine("Choise can't negative"); goto SetId; }
            switch (choise)
            {
                case 1:
                SetHallName:
                    Console.Write("Enter new hall name: ");
                    string hallName = Console.ReadLine();
                    if (string.IsNullOrEmpty(hallName)) goto SetHallName;
                    SqlOperation.Execute($"UPDATE Halls SET Name = '{hallName}' WHERE Id = {id}");
                    break;
                case 2:
                Start:
                    Console.Write("Enter new seat count: ");
                    int seatCount = Convert.ToInt32(Console.ReadLine());
                    if (seatCount < 0) goto Start;
                    SqlOperation.Execute($"UPDATE Halls SET SeatCount = {seatCount} WHERE Id = {id}");
                    break;
                default:
                    break;
            }
        }
    }
}
