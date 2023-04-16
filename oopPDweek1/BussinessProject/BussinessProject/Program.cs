using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 100;
            int productQuantity = 20;
            string[] name = new string[size];
            string[] password = new string[size];
            string[] foodItem = new string[productQuantity];
            int[] price = new int[productQuantity];
            string role;
            string[] roleName = new string[5];
            
            int option;
            do
            {

                readDATA(size, name, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("enter name :");
                    string n = Console.ReadLine();
                    Console.WriteLine("enter password :");
                    string p = Console.ReadLine();
                    Console.WriteLine("enter your role :");
                    role = Console.ReadLine();
                    signUP(n, p, role);
                }
                else if (option == 2)
                {
                    Console.WriteLine("enter name :");
                    string n = Console.ReadLine();
                    Console.WriteLine("enter password :");
                    string p = Console.ReadLine();
                    string result;
                    result = signIN(size, n, p, name, password, roleName);
                    if (result == "admin")
                    {
                        int output = (adminMenu(foodItem, price, productQuantity));
                    }
                }
            }
            while (option < 3);
                    {
                        Console.WriteLine("invalid option!!!");
                    }
            
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1.Sign up");
            Console.WriteLine("2.Sign in");
            Console.WriteLine("3.exit");
            Console.WriteLine("Enter option :");
            option = int.Parse(Console.ReadLine());
            return option;
           
                

        }
        static string getParse(string record, int field)
        {
            int count = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    count++;
                }
                else if (count == field)
                {
                    item = item + record[x];
                }

            }
            return item;
        }
        static void readDATA(int  size, string[] name, string[] password)
        {
            int x = 0;
            string path = " G:\\oopweek1\\week1\\week1\\data.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    name[x] = getParse(record, 1);
                    password[x] = getParse(record, 2);
                    x++;
                    if (size >= 100)
                    {
                        break;
                    }


                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("No Exists!!!");
            }

        }
         static string signIN(int size,string n,string p,string[] name,string[] password,string[] roleName)
        {
          
            string roles= "null";
            for (int x = 0; x <size;x++)
            {

                if (n == name[x] && p == password[x] )
                {
                   
                    roles = roleName[x];
                    break;
                 
                }
            }
            return roles;
            

        }
        static void signUP( string n, string p,string role)
        {
            string path = " G:\\oopweek1\\week1\\week1\\data.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p + "," + role);
            file.Flush();
            file.Close();

        }
        static void writefoodItem(string[] foodItem, int[] price)
        {
            string path = "G:\\oopPDweek1\\HotelMenu.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(foodItem+ "," +price);
            file.Flush();
            file.Close();

        }
        static void listofFoodItems(string[]foodItem,int[] price,int productQuantity)
        {
            int idx = 0;
            string path = "G:\\oopPDweek1\\HotelMenu.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string menu;
                while ((menu = file.ReadLine()) != null)
                {
                    foodItem[idx] = getParse(menu, 2);
                    price[idx] = int.Parse(getParse(menu, 3));
    
                    if (productQuantity >= 20)
                    {
                        break;
                    }

                }
                file.Close();
            }
                
                else
                {
                    Console.WriteLine("No eXists!!!");
                }
            Console.ReadKey();
            
        }
        static void deleteFood(string[] foodItem, int[] price)
        {
            string path = "G:\\oopPDweek1\\HotelMenu.txt";
            int idx = 0;
            string record;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((record = file.ReadLine()) != null)
                {


                    string foodName = Console.ReadLine();
                    Console.WriteLine("enter food name you want to delete :");
                    foodItem[idx] = " remove";
                    idx++;




                }
            }
        }
        static void updatefood (string[] foodItem, int[] price)
        {
            string path = "G:\\oopPDweek1\\HotelMenu.txt";
            int idx = 0;
            string record;
            if(File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while((record =file.ReadLine())!= null)
                    {


                    string foodName= Console.ReadLine();
                    Console.WriteLine("enter food name :");
                    foodItem[idx] = foodName;
                    idx++;




                }
            }

            

            
            
        }
        static int   adminMenu(string[] foodItem, int[] price, int productQuantity)
        {
            int choice;
            Console.WriteLine("1.view the list of food item");
            Console.WriteLine("2.update food ");
            Console.WriteLine("3.delete food ");
            Console.WriteLine("enter your option : ");
            choice = int.Parse(Console.ReadLine());
            return choice;
            if(choice ==1)
            {
                writefoodItem(foodItem, price);
            }
            else if(choice ==2)
            {
                updatefood(foodItem, price);
            }
            else if (choice ==3)
            {
                deleteFood(foodItem, price);
            }
        }
    }
}
