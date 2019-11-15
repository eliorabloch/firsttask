//eliora bloch 206343501
//liel orenstein 209220730

/*this program runns orders for a hotel. It reserves room, checks hotels capacity,and more...*/

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
            capacity = new bool[12, 31];// Matrix of hotel capacity
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    capacity[i, j] = false;
                }
            }
            bool finishRun = true;
            while (finishRun)// This while capsules the switch.
            {
                Console.WriteLine();
                Console.WriteLine("Hello, welcome, please choose a number from 1 to 4: ");
                Console.WriteLine("1- Check availability.");
                Console.WriteLine("2- Show hotel capacity.");
                Console.WriteLine("3- Show yearly capacity percentige.");
                Console.WriteLine("4- Exit.");
                Console.WriteLine();
                ConsoleKeyInfo choice = Console.ReadKey();//Cin a number from the keybord. (If it is not number from 1-4 it will go into error defult).
                switch (choice.Key)
                {
                    case ConsoleKey.D1:// This case takes a reservation from the customer if the room is availeble, if not- it will inform him.
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter the date you want to reserve.");
                            Console.WriteLine("Day: ");
                            //We will cin a key by the customer (on day, month, amount). We will parse it into an int, and we will also check that the numbers are in the corrent range.
                            string costumerDay = Console.ReadLine();
                            int day, day2;
                            bool succeedDay = int.TryParse(costumerDay, out day);//We check if the parsing went well.
                            bool succeedDay2 = true;
                            day -= 1;// We will remove 1 from the day number,because the array starts from 0.
                            if (succeedDay)
                            {
                                while ((day > 30 || day < 0) && (succeedDay2))//We check that the day is in the range.
                                {
                                    Console.WriteLine("You have entered an invalid day, please enter a correct number.");
                                    string costumerDay2 = Console.ReadLine();
                                    succeedDay2 = int.TryParse(costumerDay2, out day2);
                                    day = day2;
                                    day -= 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry, we can not handle this problem.");//This is incase the custumor entered somthing other then a number.
                                return;
                            }
                            //Here we do for the month the exact things we did for the day.
                            Console.WriteLine("Month: ");
                            string costumerMonth = Console.ReadLine();
                            int month, month2;
                            bool succeedMonth = int.TryParse(costumerMonth, out month);
                            bool succeedMonth2 = true;
                            month -= 1;
                            if (succeedMonth)
                            {
                                while ((month > 11 || month < 0) && (succeedMonth2))
                                {
                                    Console.WriteLine("You have entered an invalid day, please enter a correct number.");
                                    string costumerMonth2 = Console.ReadLine();
                                    succeedMonth2 = int.TryParse(costumerMonth2, out month2);
                                    month = month2;
                                    month -= 1;
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
                            if (!succeedAmount)
                            {
                                Console.WriteLine("Sorry, we can not handle this problem.");
                                return;
                            }
                            int saveAmount = amount;
                            int newAmount = 0;
                            int newMonth = 0;
                            if (day + amount > 30)//Here we check if we have on order that takes place in two monthes or more.
                            {
                                amount = 31 - day;//Accurate month
                                newAmount = saveAmount - amount;//Next month
                                newMonth = month + 1;
                            }
                            bool available = false;
                            int forSum = 0;
                            if (!capacity[month, day])// If the room ia availeble we will enter the for.
                            {
                                for (int i = 0; i < amount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                                {
                                    if (capacity[month, day + i])
                                    {
                                        Console.WriteLine("Sorry, the request has been denighd.");
                                        forSum = i;
                                        break;
                                    }
                                }
                                if (forSum == amount - 2 || forSum == 0)// If none of the days were taken (not including the first and the last), we will update the available flag to be true. 
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
                            //We will go in to this if incase we have an order of more then one month.
                            if (available && available2)// This is where we update the capacity.
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    capacity[month, day + i] = true;
                                }
                                for (int i = 1; i < newAmount + 1; i++)
                                {
                                    capacity[newMonth, i] = true;
                                }
                                Console.WriteLine("The request has been answerred");
                            }
                            if (newMonth == 0)// If its only one month.
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    capacity[month, day + i] = true;
                                }
                            }
                            //if ((day == 30) && (month == 12) && (amount > 1))
                            //{
                            //    Console.WriteLine("Sorry, we can not get yout resservation.");
                            //    Console.WriteLine("See you next year!");
                            //}
                            break;
                        }

                    //Case two will show the custumor all the taken days,in a list.
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine();
                            for (int i = 0; i < 12; i++)
                            {
                                for (int j = 0; j < 31; j++)
                                {
                                    if (capacity[i, j])//It will enter this if if the matrix has true on this day and month
                                    {
                                        Console.WriteLine("First day of stay: ");
                                        Console.WriteLine("Month: ");
                                        Console.WriteLine(++i);//We  do ++ because we did -- at the begining,do to the matrix starting from 0
                                        Console.WriteLine("Day: ");
                                        Console.WriteLine(++j);// Same as ++i.
                                        Console.WriteLine("Last day of stay: ");
                                        --i; --j;
                                        while (capacity[i, j])//As long as we still have true, have the days ++.
                                        {
                                            if (j == 30 && i != 12)
                                            {
                                                i++;
                                                j = 1;
                                            }
                                            j++;
                                        }
                                        Console.WriteLine("Month: ");
                                        Console.WriteLine(++i);
                                        Console.WriteLine("Day: ");
                                        Console.WriteLine(j);
                                        --j;
                                        --i;
                                    }
                                }
                            }
                            break;
                        }

                    //Case 3 checks the hotell capacity yearly percentige. and prints it out to the custumor.
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine();
                            int counter = 0;
                            for (int i = 0; i < 11; i++)
                            {
                                for (int j = 0; j < 30; j++)
                                {
                                    if (capacity[i, j])
                                    {
                                        counter++;// The counter will count how many days are taken.
                                    }
                                }
                            }
                            Console.WriteLine("The amount of taken days: ");
                            Console.WriteLine(counter);
                            Console.WriteLine("The precentege of the yearly capacity: ");
                            double precent = 0;
                            precent = ((double)counter / 365) * (100);
                            Console.WriteLine(precent);
                            break;
                        }

                    //This case is the exit case.
                    case ConsoleKey.D4:
                        {
                            finishRun = false;
                            Console.WriteLine();
                            Console.WriteLine("thanx for using our hotel services,we hope you enjoy your stay!");
                            Console.WriteLine("have a nice day.");
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

/*
Hello, welcome, please choose a number from 1 to 4:
1- Check availability.
2- Show hotel capacity.
3- Show yearly capacity percentige.
4- Exit.

1
Please enter the date you want to reserve.
Day:
1
Month:
1
Please enter the amount of days for your stay.
4
The request has been answerred

Hello, welcome, please choose a number from 1 to 4:
1- Check availability.
2- Show hotel capacity.
3- Show yearly capacity percentige.
4- Exit.

1
Please enter the date you want to reserve.
Day:
1
Month:
1
Please enter the amount of days for your stay.
3
Sorry, the request has been denighd.

Hello, welcome, please choose a number from 1 to 4:
1- Check availability.
2- Show hotel capacity.
3- Show yearly capacity percentige.
4- Exit.

1
Please enter the date you want to reserve.
Day:
4
Month:
6
Please enter the amount of days for your stay.
9
The request has been answerred

Hello, welcome, please choose a number from 1 to 4:
1- Check availability.
2- Show hotel capacity.
3- Show yearly capacity percentige.
4- Exit.

2
First day of stay:
Month:
1
Day:
1
Last day of stay:
Month:
1
Day:
4
First day of stay:
Month:
6
Day:
4
Last day of stay:
Month:
6
Day:
12

Hello, welcome, please choose a number from 1 to 4:
1- Check availability.
2- Show hotel capacity.
3- Show yearly capacity percentige.
4- Exit.

3
The amount of taken days:
13
The precentege of the yearly capacity:
3.56164383561644

Hello, welcome, please choose a number from 1 to 4:
1- Check availability.
2- Show hotel capacity.
3- Show yearly capacity percentige.
4- Exit.

4
thanx for using our hotel services,we hope you enjoy your stay!
have a nice day.
*/

