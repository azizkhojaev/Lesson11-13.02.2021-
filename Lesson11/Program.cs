using System;
using System.Collections.Generic;
using System.Threading;
namespace Lesson11
{
    static class Homework
    {
        public static void Task1()
        {
                Console.WriteLine("Welcome !!!!");
                Console.WriteLine("1 => Insert ");
                Console.WriteLine("2 => Update ");
                Console.WriteLine("3 => Delate ");
                Console.WriteLine("4 => Select ");
                Console.WriteLine("5 => Checking Ballance system ");
                Console.WriteLine("6 => Exit ");
                Console.Write("Your choice in number ");
                var x = Convert.ToInt32(Console.ReadLine());
                if (x == 1)
                {
                    Console.Write("Client Name ");
                    var name = Console.ReadLine();
                    Console.Write("Client Balance ");
                    var balance = Convert.ToDecimal(Console.ReadLine());

                    Thread insert = new Thread(() => ClientHelper.Insert(name, balance));
                    insert.Start();


                }
                else if (x == 2)
                {
                    Console.Write("enter id of a Clint for updatiog ");
                    var id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("enter new Clients name ");
                    var name = Console.ReadLine();
                    Console.Write("enter new Clients balance ");
                    var balance = Convert.ToDecimal(Console.ReadLine());

                    Thread update = new Thread(() => ClientHelper.Update(id, name, balance));
                    update.Start();
                }
                else if (x == 3)
                {
                    Console.Write("Enter an ID of Client to Delete it from the List ");
                    var y = Convert.ToInt32(Console.ReadLine());
                    Thread delete = new Thread(() => ClientHelper.Delete(y));
                    delete.Start();
                }
                else if (x == 4)
                {
                    Thread select = new Thread(ClientHelper.Select);
                    select.Start();
                }
                else if (x == 5)
                    Task2();
                else
                    Console.WriteLine("Wrong Input");
        }
        public static void Task2()
        {
            BallanceChecker.Check();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Homework.Task1();
           
           //  Console.WriteLine(" Working of the Second Part");

           // Homework.Task2();
        }
    }
    class Client
    {

        public int Id = 0;
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public static List<Client> mylist = new List<Client>();
        public static List<Client> mylistforcheck = new List<Client>();
    }
    class ClientHelper
    {
        public static object locker = new Object();
        public static void Insert(string name, decimal balance)
        {
            lock(locker)
            {
                var NewClient = new Client();
                var lastid = LastIdFinderInClient() + 1;

                NewClient.Id = lastid;

                NewClient.Name = name;

                NewClient.Balance = balance;

                Client.mylist.Add(NewClient);
                Console.Clear();
                if (ClientFinder(lastid) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your Client has been added Sucessfuly ");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Homework.Task1();
            }
        }
        public static void Update(int x, string name, decimal balance)
        {
            lock(locker)
            {
                foreach (var client in Client.mylist)
                {
                    if (client.Id == x)
                    {
                        Client.mylist.Remove(client);
                        break;
                    }
                }
                var UpdateClient = new Client();
                UpdateClient.Id = x;
                UpdateClient.Name = name;
                UpdateClient.Balance = balance;
                Client.mylist.Add(UpdateClient);
                Homework.Task1();
            }
        }
        public static void Delete(int x)
        {
           lock(locker)
            {
                foreach (var client in Client.mylist)
                {
                    if (client.Id == x)
                    {
                        Client.mylist.Remove(client);

                        if (ClientFinder(x) == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You Client has been deleted successfuly ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    }
                }
                Homework.Task1();
            }    
        }
        public static void Select()
        {
           lock(locker)
            {
                foreach (var client in Client.mylist)
                {
                    Console.Write("ID -> " + client.Id);
                    Console.Write("  Name -> " + client.Name);
                    Console.Write("  Blance -> " + client.Balance);
                    Console.WriteLine();
                }
                Homework.Task1();
            }
        }
        public static int LastIdFinderInClient()
        {
                int lastid = 0;
                foreach (var item in Client.mylist)
                {
                    lastid++;
                }
                return lastid;
        }
        public static int ClientFinder(int id)
        {
            int Temp = 0;
            foreach (var item in Client.mylist)
                if (item.Id==id)
                {
                    Temp = 1;
                    break; 
                }
            return Temp;

        }
    }

    static class BallanceChecker
    {
        public static void Check()
        {

            foreach (var item1 in Client.mylist)
            {
                foreach (var item2 in Client.mylist)
                {
                    if (item1.Id != item2.Id)
                    {
                        if (item1.Balance < item2.Balance)
                        {
                            Console.WriteLine();
                            var temp = item2.Balance - item1.Balance;
                            Console.WriteLine("Id = " + item1.Id + " name = " + item1.Name + "  ballance = " + item1.Balance);
                            Console.WriteLine("Id = " + item2.Id + " name = " + item2.Name + "  ballance = " + item2.Balance);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Result =  " + temp);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Thread.Sleep(700);
                        }
                        else if (item1.Balance > item2.Balance)
                        {
                            Console.WriteLine();
                            var temp = item2.Balance - item1.Balance;
                            Console.WriteLine("Id = " + item1.Id + " name = " + item1.Name + "  ballance = " + item1.Balance);
                            Console.WriteLine("Id = " + item2.Id + " name = " + item2.Name + "  ballance = " + item2.Balance);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Result =  " + temp);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Thread.Sleep(700);
                        }
                    }
                    
                }
            }
            Console.WriteLine("This is the end");
        }
    }

}
