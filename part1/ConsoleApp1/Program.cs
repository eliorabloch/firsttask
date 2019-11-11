using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] capacity;
            capacity = new bool[12, 31];// matrix of hotel capacity
            for(int i=0; i<12;i++)//This for fills the array with false values
            {
                for(int j=0; j<31; j++)
                {
                    capacity[i, j] = false;
                }
            }
            bool finishRun=true;
            while (finishRun)// This while capsules the switch.
            {
                Console.WriteLine();
                Console.WriteLine("hello, please chose a number from 1 to 4: ");
                Console.WriteLine("1- check availability.");
                Console.WriteLine("2- show hotel capacity.");
                Console.WriteLine("3- show yearly capacity percentige.");
                Console.WriteLine("4- exit.");
                Console.WriteLine();
                ConsoleKeyInfo choice = Console.ReadKey();//cin a number from the keybord. (if it is not number from 1-4 it will go into error defult).
                switch (choice.Key)
                {
                    case ConsoleKey.D1:// This case take a reservation from the customer if the room ia availeble, if not- it will inform him.
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter the date you want to reserve.");
                            Console.WriteLine("Day: ");
                            //we will cin a key by the customer (on day, month, amount). We will parse it into an int, and we will also check that the numbers are in the corrent range.
                            string costumerDay = Console.ReadLine();
                            int day,day2;
                            bool succeedDay = int.TryParse(costumerDay, out day);
                            bool succeedDay2 = true;
                            if (succeedDay)
                            {
                                while ((day > 31 || day < 1)&&(succeedDay2))
                                {
                                    
                                    Console.WriteLine("You enteted an auvalid day, please enter a correct number.");
                                    string costumerDay2 = Console.ReadLine();
                                    succeedDay2 = int.TryParse(costumerDay2, out day2);
                                    day = day2;
                                } 
                            }
                            else
                            {
                                Console.WriteLine("Sorry, we can not handle this problem.");
                                return;
                            }
                            Console.WriteLine("Month: ");
                            string costumerMonth = Console.ReadLine();
                            int month, month2;
                            bool succeedMonth = int.TryParse(costumerMonth, out month);
                            bool succeedMonth2 = true;
                            if (succeedMonth)
                            {
                                while ((month > 12 || month < 1) && (succeedMonth2))
                                {
                                    Console.WriteLine("You enteted an auvalid day, please enter a correct number.");
                                    string costumerMonth2 = Console.ReadLine();
                                    succeedMonth2 = int.TryParse(costumerMonth2, out month2);
                                    month = month2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry, we can not handle this problem.");
                                return;
                            }
                            Console.WriteLine("Please enter the amount of days for your stay.");
                            string amountOfDays = Console.ReadLine();
                            int amount;
                            bool succeedAmount = int.TryParse(amountOfDays, out amount);
                            if(!succeedAmount)
                            {
                                Console.WriteLine("Sorry, we can not handle this problem.");
                                return;
                            }
                            
                            if((amount==2)&&(capacity[day,month]))//If 2 days are taken the costumer can still reserve the first or the second day. 
                            {
                                Console.WriteLine("The request has been answerred");
                                break;
                            }
                            bool available = false;
                            if (!capacity[day+1, month])// If the room ia availeble we will enter the for.
                            {
                                int forSum = 0;
                                for (int i = 0; i < amount-1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                                {
                                    if (capacity[day + i, month])
                                    {
                                        Console.WriteLine("Sorry, the request has been denighd.");
                                        forSum = i;
                                        break;
                                    }
                                }
                                if (forSum == amount-2|| forSum == 0)// If none of the days were taken (not including the first and the last), we will update the available flag to be true. 
                                {
                                    available = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry, the request has been denighd.");
                            }
                            if (available)// This is where we update the capacity.
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    capacity[day + i, month] = true;
                                }
                                Console.WriteLine("The request has been answerred" );
                            }
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            finishRun = false;
                            Console.WriteLine();
                            break;
                        }
                    default:
                            Console.WriteLine(" Please enter a valid number.");
                            break;
                }
            }
           
        }
        
    }
}
