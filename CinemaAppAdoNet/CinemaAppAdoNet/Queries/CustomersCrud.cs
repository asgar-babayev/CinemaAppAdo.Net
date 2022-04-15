using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class CustomersCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Customers");
        }
        public static void Create(string fullname, int age)
        {
            SqlOperation.Execute($"INSERT INTO Customers VALUES (N'{fullname}', {age}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Customers WHERE Id = {id}");
        }

        public static void Update(int id)
        {
            Console.Write(@"Select the value you want to update (1:Fullname 2:Age): ");
            int.TryParse(Console.ReadLine(), out int choise);
            switch (choise)
            {
                case 1:
                SetFullname:
                    Console.Write("Enter new fullname: ");
                    string fullname = Console.ReadLine();
                    if (string.IsNullOrEmpty(fullname)) goto SetFullname;
                    SqlOperation.Execute($"UPDATE Customers SET Fullname = '{fullname}' WHERE Id = {id}");
                    break;
                case 2:
                Setage:
                    Console.Write("Enter new age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    if (age < 0) goto Setage;
                    SqlOperation.Execute($"UPDATE Customers SET Age = {age} WHERE Id = {id}");
                    break;
                default:
                    break;
            }
        }
    }
}
