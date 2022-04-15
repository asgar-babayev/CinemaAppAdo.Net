using CinemaAppAdoNet.SqlOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppAdoNet.Queries
{
    public class MoviesActors
    {
        public static void GetAll()
        {
            SqlOperation.Select(@"Select * from MoviesActors");
        }
        public static void Create(int actorId, int movieId)
        {
            SqlOperation.Execute($"INSERT INTO MoviesActors VALUES ('{actorId}', '{movieId}')");
        }

        public static void Delete(int id)
        {
            SqlOperation.Execute($"DELETE MoviesActors WHERE Id = {id}");
        }

        public static void Update(int id)
        {
        SetId:
            Console.Write(@"Select the value you want to update (1:ActorId 2:MovieId): ");
            int.TryParse(Console.ReadLine(), out int choise);
            if (choise < 0) { Console.WriteLine("Choise can't negative"); goto SetId; }
            switch (choise)
            {
                case 1:
                SetActorId:
                    Console.Write("Enter new actor id: ");
                    int actorId = Convert.ToInt32(Console.ReadLine());
                    if (actorId < 0) goto SetActorId;
                    SqlOperation.Execute($"UPDATE MoviesActors SET ActorId = '{actorId}' WHERE Id = {id}");
                    break;
                case 2:
                SetMovieId:
                    Console.Write("Enter new movie id: ");
                    int movieId = Convert.ToInt32(Console.ReadLine());
                    if (movieId < 0) goto SetMovieId;
                    SqlOperation.Execute($"UPDATE MoviesActors SET MovieId = '{movieId}' WHERE Id = {id}");
                    break;
                default:
                    break;
            }
        }
    }
}
