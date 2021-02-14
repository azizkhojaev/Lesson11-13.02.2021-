using System;
using System.Collections.Generic;

namespace Lesson11
{
    static class Homework
    {
        
        public static void DZ1()
        {
            Console.WriteLine("Welcome !!!!");
            Console.WriteLine("1. Insert ");
            Console.WriteLine("2. Update " );
            Console.WriteLine("3. Delate " );
            Console.WriteLine("4. Select " );
            Console.Write("Your choice in number " );
            var x = Convert.ToInt32(Console.ReadLine()); 
            if (x==1)
            {
                Console.Write("Client Name ");
                var name = Console.ReadLine();
                Console.Write("Client Balance " );
                var balance = Convert.ToDecimal(Console.ReadLine());
                Client.Insert(name, balance);


            }
            else if (x==2)
            {
                Client.Update(); 
            }
            else if (x==3)
            {

                Console.Write("Enter an ID to Delete it from List ");
                var y = Convert.ToInt32(Console.ReadLine());
                Client.Delete(y); 
            }
            else if (x==4)
            {
                Client.Select();
            }
        }
        public static void DZ2()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Homework.DZ1();
            //Homework.DZ2(); 
        }
    }
     class Client
    {
        public static List<Client> mylist=new List<Client>();
        public int Id = 0; 
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public static void Insert(string name, decimal balance)
        {
            var NewClient = new Client();
            NewClient.Id++;
            NewClient.Name = name;
            NewClient.Balance = balance;
            mylist.Add(NewClient);
            Console.WriteLine("Your Client has been added Sucessfuly " );

            Homework.DZ1();
        }
        public static void Update()
        {

        }
        public static void Delete( int x)
        {
            foreach (var client in Client.mylist)
            {
                if (client.Id == x)
                {
                    Client.mylist.Remove(client);
                    Console.WriteLine("You Client has been deleted successfuly " );
                    break; 
                }
            }

            Homework.DZ1();
        }
        public static void Select()
        {
            foreach (var client in Client.mylist)
            {
                Console.WriteLine(client.Id+" "+client.Name+" "+client.Balance);
            }
            Homework.DZ1();
        }

    }

}
