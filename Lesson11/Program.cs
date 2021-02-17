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
            Console.WriteLine("1. Insert ");
            Console.WriteLine("2. Update ");
            Console.WriteLine("3. Delate ");
            Console.WriteLine("4. Select ");
            Console.Write("Your choice in number ");
            var x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                Console.Write("Client Name ");
                var name = Console.ReadLine();
                Console.Write("Client Balance ");
                var balance = Convert.ToDecimal(Console.ReadLine());

                Thread insert = new Thread(() => Client.Insert(name, balance));
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

                Thread update = new Thread(() => Client.Update(id, name, balance));
                update.Start();
            }
            else if (x == 3)
            {
                Console.Write("Enter an ID of Client to Delete it from the List ");
                var y = Convert.ToInt32(Console.ReadLine());
                Thread delete = new Thread(() => Client.Delete(y));
                delete.Start();
            }
            else if (x == 4)
            {
                Thread select = new Thread(Client.Select);
                select.Start();
            }
            else
                Console.WriteLine("Wrong Input");
        }
        public static void Task2()
        {
            int id = 5;
            decimal balance1 = 5000;
            decimal balance2 = 2000;
            var Timer = new Timer(id,balance1,balance2);
            Timer.BalanceChecker();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Homework.Task1();

            Console.WriteLine();
            Console.WriteLine(" Working of the Second Part");

            Homework.Task2();
        }
    }
    class Client
    {
        public static List<Client> mylist = new List<Client>();
        public int Id = 0;
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public static void Insert(string name, decimal balance)
        {
            var NewClient = new Client();
            var lastid = 1;
            foreach (var item in Client.mylist) { lastid++; }

            NewClient.Id = lastid;

            NewClient.Name = name;

            NewClient.Balance = balance;

            mylist.Add(NewClient);
            Console.WriteLine("Your Client has been added Sucessfuly ");
        }
        public static void Update(int x, string name, decimal balance)
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
            mylist.Add(UpdateClient);
        }
        public static void Delete(int x)
        {
            foreach (var client in Client.mylist)
            {
                if (client.Id == x)
                {
                    Client.mylist.Remove(client);
                    Console.WriteLine("You Client has been deleted successfuly ");
                    break;
                }
            }
        }
        public static void Select()
        {
            foreach (var client in Client.mylist)
            {
                Console.Write("ID -> " + client.Id);
                Console.Write("  Name -> " + client.Name);
                Console.Write("  Blance -> " + client.Balance);
                Console.WriteLine();
            }

        }
    }
    class Timer
    {
        public int ID = 0;
        public decimal ballance1 { get; set; }
        public decimal ballance2 { get; set; }
        public Timer(int id,decimal b1, decimal b2)
        {
            ID = id;
            ballance1 = b1;
            ballance2 = b2; 
        }

        public void BalanceChecker()
        {
            if (ballance1<ballance2)
            {
                var temp = ballance2 - ballance1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Id = "+ID + "  oldballance = " + ballance1 + "  newballance = " + ballance2 + "  + " + temp);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (ballance2<ballance1)
            {
                var temp = ballance2 - ballance1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id = " + ID + "  oldballance = " + ballance1 + "  newballance = " + ballance2 + "   " + temp);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }

}
