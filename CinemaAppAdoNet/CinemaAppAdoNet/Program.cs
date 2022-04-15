using System;
using CinemaAppAdoNet.Queries;
using CinemaAppAdoNet.SqlOperations;
namespace CinemaAppAdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int choise;
            int choise1 = 0;
            do
            {
                ShowInfoSwitch();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                        ShowSwitchActor(ref choise1);
                        break;
                    case 2:
                        ShowSwitchCustomer(ref choise1);
                        break;
                    case 3:
                        ShowSwitchGenre(ref choise1);
                        break;
                    case 4:
                        ShowSwitchHall(ref choise1);
                        break;
                    case 5:
                        ShowSwitchMovie(ref choise1);
                        break;
                    case 6:
                        ShowSwitchSessions(ref choise1);
                        break;
                    case 7:
                        ShowSwitchTicket(ref choise1);
                        break;
                    case 8:
                        ShowSwitchMovieGenre(ref choise1);
                        break;
                    case 9:
                        ShowSwitchMovieActor(ref choise1);
                        break;
                    case 10:
                        TicketsCrud.BuyTickets();
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowInfoSwitch()
        {
            Console.WriteLine(@"1-Actors Crud
2-Customers Crud
3-Genres Crud
4-Halls Crud
5-Movies Crud
6-Sessions Crud
7-Tickets Crud
8-MoviesGenres Crud
9-MoviesActors Crud");
        }
        static void ShowInfoCrud()
        {
            Console.WriteLine(@"1-Create
2-Read
3-Update
4-Delete");
        }
        static void ShowSwitchActor(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
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
                        Console.Write("Enter fullname: ");
                        string fullname = Console.ReadLine();
                        if (string.IsNullOrEmpty(fullname))
                        { goto SetFullname; }
                    SetAge:
                        Console.Write("Ente age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        if (age < 0) { goto SetAge; }
                        ActorsCrud.Create(fullname, age);
                        break;
                    case 2:
                        ActorsCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        ActorsCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        ActorsCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchCustomer(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
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
                        Console.Write("Enter fullname: ");
                        string fullname = Console.ReadLine();
                        if (string.IsNullOrEmpty(fullname))
                        { goto SetFullname; }
                    SetAge:
                        Console.Write("Ente age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        if (age < 0) { goto SetAge; }
                        CustomersCrud.Create(fullname, age);
                        break;
                    case 2:
                        CustomersCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        ActorsCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        ActorsCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchGenre(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    SetName:
                        Console.Write("Ente name: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrEmpty(name))
                        { goto SetName; }
                        GenresCrud.Create(name);
                        break;
                    case 2:
                        GenresCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        GenresCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        GenresCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchHall(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    SetName:
                        Console.Write("Ente name: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrEmpty(name))
                        { goto SetName; }
                    SetSeatCount:
                        Console.Write("Ente seat count: ");
                        int seatCount = Convert.ToInt32(Console.ReadLine());
                        if (seatCount < 0) goto SetSeatCount;
                        HallsCrud.Create(name, seatCount);
                        break;
                    case 2:
                        HallsCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        HallsCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        HallsCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchMovie(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    Name:
                        Console.Write("Ente name: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrEmpty(name))
                        { goto Name; }
                    ReleaseDate:
                        Console.Write("Ente release date: ");
                        string releaseDate = Console.ReadLine();
                        if (string.IsNullOrEmpty(releaseDate))
                        { goto ReleaseDate; }
                        MoviesCrud.Create(name, releaseDate);
                        break;
                    case 2:
                        MoviesCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        MoviesCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        MoviesCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchMovieActor(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    ActorId:
                        Console.Write("Ente actor id: ");
                        int actorId = Convert.ToInt32(Console.ReadLine());
                        if (actorId < 0) { goto ActorId; }
                    MovieId:
                        Console.Write("Ente movie id: ");
                        int movieId = Convert.ToInt32(Console.ReadLine());
                        if (movieId < 0) goto MovieId;
                        MoviesActors.Create(actorId, movieId);
                        break;
                    case 2:
                        MoviesActors.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        MoviesActors.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        MoviesActors.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchMovieGenre(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    MovieId:
                        Console.Write("Ente movie id: ");
                        int movieId = Convert.ToInt32(Console.ReadLine());
                        if (movieId < 0) goto MovieId;
                        GenreId:
                        Console.Write("Ente genre id: ");
                        int genreId = Convert.ToInt32(Console.ReadLine());
                        if (genreId < 0) { goto GenreId; }
                        MoviesGenres.Create(genreId, movieId);
                        break;
                    case 2:
                        MoviesGenres.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        MoviesGenres.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        MoviesGenres.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchSessions(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    SessionsTime:
                        Console.Write("Ente sessions time: ");
                        string sessionTime = Console.ReadLine();
                        if (string.IsNullOrEmpty(sessionTime))
                        { goto SessionsTime; }
                        SessionsCrud.Create(sessionTime);
                        break;
                    case 2:
                        SessionsCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        SessionsCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        SessionsCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void ShowSwitchTicket(ref int choise)
        {
            do
            {
                ShowInfoCrud();
            SetChoise:
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto SetChoise;
                }
                switch (choise)
                {
                    case 1:
                    SoldDate:
                        Console.Write("Enter sold date: ");
                        string soldDate = Console.ReadLine();
                        if (string.IsNullOrEmpty(soldDate))
                        { goto SoldDate; }
                    Price:
                        Console.Write("Enter price: ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        if (price < 0) { goto Price; }
                    Place:
                        Console.Write("Enter place: ");
                        int place = Convert.ToInt32(Console.ReadLine());
                        if (place < 0) { goto Place; }
                    MovieId:
                        Console.Write("Enter movie id: ");
                        int movieId = Convert.ToInt32(Console.ReadLine());
                        if (movieId < 0) { goto MovieId; }
                    HallId:
                        Console.Write("Enter hall id: ");
                        int hallId = Convert.ToInt32(Console.ReadLine());
                        if (hallId < 0) { goto HallId; }
                    SessionsId:
                        Console.Write("Enter session id: ");
                        int sessionsId = Convert.ToInt32(Console.ReadLine());
                        if (sessionsId < 0) { goto SessionsId; }
                    CustomerId:
                        Console.Write("Enter customer id: ");
                        int customerId = Convert.ToInt32(Console.ReadLine());
                        if (customerId < 0) { goto CustomerId; }
                        TicketsCrud.Create(soldDate, price, place, movieId, hallId, sessionsId, customerId);
                        break;
                    case 2:
                        TicketsCrud.GetAll();
                        break;
                    case 3:
                    SetUpdateId:
                        int uid = Convert.ToInt32(Console.ReadLine());
                        if (uid < 0) { goto SetUpdateId; }
                        TicketsCrud.Update(uid);
                        break;
                    case 4:
                    SetDeleteId:
                        int dId = Convert.ToInt32(Console.ReadLine());
                        if (dId < 0) { goto SetDeleteId; }
                        TicketsCrud.Delete(dId);
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
    }
}
