using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class ActorsCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Actors");
        }
        public static void Create(string fullname, int age)
        {
            SqlOperation.Execute($"INSERT INTO Actors VALUES (N'{fullname}', {age})");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Actors WHERE Id = {id}");
        }

        public static void Update(int id)
        {
            SetChoise:
            Console.Write(@"Select the value you want to update (1:Fullname 2:Age): ");
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
                    SetFullname:
                    Console.Write("Enter new fullname: ");
                    string fullname = Console.ReadLine();
                    if (string.IsNullOrEmpty(fullname)) goto SetFullname;
                    SqlOperation.Execute($"UPDATE Actors SET Fullname = '{fullname}' WHERE Id = {id}");
                    break;
                case 2:
                    Setage:
                    Console.Write("Enter new age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if (age < 0) goto Setage;
                    SqlOperation.Execute($"UPDATE Actors SET Age = {age} WHERE Id = {id}");
                    break;
                default:
                    break;
            }
        }
    }
}
