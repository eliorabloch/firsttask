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
                for(int j=1; j<31; j++)
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
                            int saveAmount = amount;
                            int newAmount=0;
                            int newMonth=0;
                            if (day+amount>31)
                            {
                             amount = 31 - day;//חודש נוכחי
                             newAmount = saveAmount - amount;//חודש הבא
                             newMonth = month + 1;
                            }

                            //if ((amount == 2) && (capacity[day, month]))//If 2 days are taken the costumer can still reserve the first or the second day. 
                            //{
                            //    Console.WriteLine("The request has been answerred");
                            //    break;
                            //}

                            bool available = false;
                            int forSum = 0;
                            
                            if (!capacity[month,day+1])// If the room ia availeble we will enter the for.
                            {
                                for (int i = 0; i < amount-1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                                {
                                    if (capacity[month,day + i])
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

                            bool available2 = false;
                            if (available)
                            {
                                for (int i = 0; i < newAmount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                                {
                                    if (capacity[newMonth, day + i])
                                    {
                                        Console.WriteLine("Sorry, the request has been denighd.");
                                        forSum = i;
                                        break;
                                    }
                                }
                                if (forSum == amount - 2 || forSum == 0)// If none of the days were taken (not including the first and the last), we will update the available flag to be true. 
                                {
                                    available2 = true;
                                }
                            }
                            if (available && available2)// This is where we update the capacity.
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    capacity[month, day + i] = true;
                                }
                                for (int i = 1; i < newAmount+1; i++)
                                {
                                    capacity[newMonth,i] = true;
                                }
                                Console.WriteLine("The request has been answerred" );
                            }
                            if (newMonth == 0)// if it only one month.
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    capacity[month, day + i] = true;
                                }
                            }
                            //if the custumer orderd more then one month, we will put true mark on the 31st of the first month he picked.
                            //if the 31st is the first day he orderd, we will do nothing.
                          //  {
                              //  if (day != 31)
                               // {
                               //     capacity[month, 31] = true;
                                //}
                          //  }//
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine();
                            for (int i=1;i<12;i++)
                            {
                                for (int j = 1; j < 31; j++)
                                {
                                    if (capacity[i, j])
                                    {
                                        Console.WriteLine("First day of stay: ");
                                        Console.WriteLine("Month: ");
                                        Console.WriteLine(i);
                                        Console.WriteLine("Day: ");
                                        Console.WriteLine(j);
                                        Console.WriteLine("Last day of stay: ");
                                    
                                        j++; 
                                        while (capacity[i, j])
                                        {
                                            j++;
                                        }
                                        Console.WriteLine("Month: ");
                                        Console.WriteLine(i);
                                        Console.WriteLine("Day: ");
                                        Console.WriteLine(j - 1);
                                    }

                                }
                            }
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine();
                            int counter = 0;
                            for (int i=0; i<11; i++)
                            {
                                for (int j=0;j<30; j++)
                                {
                                    if(capacity[i,j])
                                    {
                                        counter++;
                                    }
                                }
                            }
                            Console.WriteLine("The amount of taken days: ");
                            Console.WriteLine(counter);
                            Console.WriteLine("The precentege of the yearly capacity: ");
                            double precent = 0;
                              precent=  ((double)counter/365) * (100);
                            Console.WriteLine(precent);
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            finishRun = false;
                            Console.WriteLine();
                            Console.WriteLine("thanx for using our hotel services,we hope you enjoy your stay!");
                            Console.WriteLine("have a nice day");
                            Console.ReadKey();
                            return;
                        }
                    default:
                            Console.WriteLine(" Please enter a valid number.");
                            break;
                }
            }
           
        }
        
    }
}
