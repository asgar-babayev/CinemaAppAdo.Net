using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class SessionsCrud
    {
        public static void GetAll()
        {
            SqlOperation.Select("Select * from Sessions");
        }
        public static void Create(string sessionsTime)
        {
            SqlOperation.Execute($"INSERT INTO Sessions VALUES (N'{sessionsTime}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE Sessions WHERE Id = {id}");
        }

        public static void Update(int id)
        {
            SetSessionTime:
            Console.Write("Set new session time: ");
            string sessionTime = Console.ReadLine();
            if (string.IsNullOrEmpty(sessionTime)) goto SetSessionTime;
            SqlOperation.Execute($"UPDATE Sessions SET SeansTime = '{sessionTime}' WHERE Id = {id}");
        }
    }
}
