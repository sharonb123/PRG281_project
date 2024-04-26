using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace GroupProject_PRG281
{
    
    public enum Menu
    {
        LoanPersonal = 1,
        LoanBusiness,
        DisplayCurrentLoans,
        Exit
    }
    internal class Program
    {
        public static int loanTerm, userChoice, count = 0, personLoanCount = 0, businessLoanCount = 0;
        public static string loanNr, custLastName, custFirstName, checkItem, text, textTitle;
        public static decimal loanAmount, primeInterestRate;
        public static bool businessLoanSelected = false, personLoanSelected = false, displayTime = true;

        static void Main(string[] args)
        {
            bool runPro = true;
            string[] loanArr = new string[5];
            ILoanConstants loanConstants = new LoanConstants();

            Thread dateThread = new Thread(displayDate);
            
            Console.WriteLine(loanConstants.companyName + " welcomes you to our loan application");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to start the application:");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            dateThread.Start();
            Console.ReadLine();

            displayTime = false;
            Console.Clear();

            textTitle = "Select prime interest rate:";
            text = "Please enter the prime interest rate";
            primeInterestRate = checkforCharDeci(text);

                
            
            while(runPro == true)
            {

                if(count < 5)
                {
                    Console.Clear();
                    Console.WriteLine("Number of enteries left: " + (5 - count));
                    Console.WriteLine("---------------------------------------------------");
                    textTitle = "Select an option:";
                    text = "Please select one of the following options:\n1. Personal Loan\n2. Business Loan\n3. Display Current Loans\n4. Exit";
                    userChoice = checkforCharInt(text);

                    switch (userChoice)
                    {
                        case (int)Menu.LoanPersonal:
                            {
                                Console.Clear();
                                personLoanSelected = true;

                                textTitle = "You have selected personal loan";

                                enterInfo();

                                Console.Clear();

                                Loan newLoan = new PersonalLoan(loanNr, loanTerm, custLastName, custFirstName, loanAmount, primeInterestRate);

                                Console.WriteLine("---------------------------------------------------");

                                if (newLoan.ToString().Substring(0, 1) != "L")
                                {
                                    Console.WriteLine(newLoan.ToString());
                                    loanArr[count] = newLoan.ToString();
                                    count++;
                                }
                                else
                                {
                                    Console.WriteLine(newLoan.ToString());
                                }
                                personLoanSelected = false;

                                break;
                            }
                        case (int)Menu.LoanBusiness:
                            {

                                Console.Clear();
                                businessLoanSelected = true;

                                textTitle = "You have selected business loan";

                                enterInfo();

                                Console.Clear();

                                Loan newLoan = new BusinessLoan(loanNr, loanTerm, custLastName, custFirstName, loanAmount, primeInterestRate);

                                Console.WriteLine("---------------------------------------------------");

                                if (newLoan.ToString().Substring(0, 1) != "L")
                                {
                                    Console.WriteLine(newLoan.ToString());
                                    loanArr[count] = newLoan.ToString();
                                    count++;
                                }
                                else
                                {
                                    Console.WriteLine(newLoan.ToString());
                                }
                                businessLoanSelected = false;

                                break;
                            }
                        case (int)Menu.DisplayCurrentLoans:
                            {
                                for(int j = 0; j <= count; j++)
                                {
                                    if(loanArr[j] != null)
                                    {
                                        if (loanArr[j].Substring(17, 2) == "bl")
                                        {
                                            Console.WriteLine("Loans that have been created:");
                                            Console.WriteLine("\n---------------------------------------------------");
                                            Console.WriteLine("Business Loan");
                                            Console.WriteLine("---------------------------------------------------");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n---------------------------------------------------");
                                            Console.WriteLine("Personal Loan");
                                            Console.WriteLine("---------------------------------------------------");
                                        }
                                        Console.WriteLine(loanArr[j]);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("No loans have been added");
                                    }
                                    
                                }
                                break;
                            }
                        case (int)Menu.Exit:
                            {
                                Console.Clear();
                                Console.WriteLine("You have selected exit application");
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("Thank you for using the application");
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("Please press enter to continue");
                                Console.ReadLine();
                                Environment.Exit(1);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please choose from the allocated options.");
                                break;
                            }
                    }

                    
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Loans that have been created:");
                    Console.WriteLine("---------------------------------------------------");
                    for(int i = 0; i < 5; i++)
                    {
                        
                        if(loanArr[i].Substring(17, 2) == "bl")
                        {
                            Console.WriteLine("\n---------------------------------------------------");
                            Console.WriteLine("Business Loan");
                            Console.WriteLine("---------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("\n---------------------------------------------------");
                            Console.WriteLine("Personal Loan");
                            Console.WriteLine("---------------------------------------------------");
                        }
                        Console.WriteLine(loanArr[i]);
                        Console.WriteLine("---------------------------------------------------");
                    }

                    runPro = false;
                }
                
            }

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Thank you for using the application");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Please press enter to continue");
            Console.ReadLine();
        }

        public static void enterInfo()
        {

            text = "First Name:";
            custFirstName = checkforCharStr(text);

            text = "Last Name:";
            custLastName = checkforCharStr(text);

            text = "Loan Amount (Max amount R100000):";
            loanAmount = checkforCharDeci(text);

            text = "Loan Term: (1 / 3 or 5 Years)";
            loanTerm = checkforCharInt(text);

            Console.WriteLine("Your loan number is:");

            if (personLoanSelected == true)
            {
                personLoanCount = personLoanCount + 1;
                loanNr = "pl: " + personLoanCount;
            }
            else
            {
                businessLoanCount = businessLoanCount + 1;
                loanNr = "bl: " + businessLoanCount;

            }
            

            
        }

        public static int checkforCharInt(string textDesc)
        {
            bool checkQuest = true;
            int val = 0;

            while (checkQuest == true)
            {
                Console.WriteLine(textTitle);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(textDesc);
                checkItem = Console.ReadLine();

                try
                {
                    val = int.Parse(checkItem);

                    if (val > 0)
                    {
                        checkQuest = false;

                    }
                    else if (val < 0 && val != -1)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Please avoid using negative values");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();

                        Console.Clear();
                    }
                    else
                    {
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("------------------- Error -------------------------");
                    Console.WriteLine(err);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please make sure not to use any characters");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.Clear();
            return val;
        }

        public static decimal checkforCharDeci(string textDesc)
        {
            bool checkQuest = true;
            decimal val = 0;

            while (checkQuest == true)
            {
                try
                {
                    Console.WriteLine(textTitle);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(textDesc);
                    checkItem = Console.ReadLine();
                    val = decimal.Parse(checkItem);

                    if (val > 0)
                    {
                        checkQuest = false;

                    }
                    else if (val < 0)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Please avoid using negative values");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();

                        Console.Clear();
                    }
                    else
                    {
                    }

                }
                catch (Exception err)
                {
                    Console.WriteLine("------------------- Error -------------------------");
                    Console.WriteLine(err);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please make sure not to use any characters");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();
                    Console.Clear();

                }


            }
            Console.Clear();
            return val;
        }

        public static string checkforCharStr(string textDesc)
        {
            bool checkQuest = true;
            string val = "";

            while (checkQuest == true)
            {
                try
                {
                    Console.WriteLine(textTitle);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(textDesc);
                    checkItem = Console.ReadLine();
                    if (checkItem == "") throw new ApplicationException("Please enter the proper information.");
                    val = checkItem;
                    checkQuest = false;
                }
                catch (ApplicationException err)
                {
                    Console.WriteLine("------------------- Error -------------------------");
                    string error = err.ToString();
                    Console.WriteLine(error.Substring(29, 39));
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Please press enter to continue");
                    Console.ReadLine();
                    Console.Clear();

                }


            }
            Console.Clear();
            return val;
        }

        public static void displayDate()
        {

            while(displayTime == true)
            {
                Console.SetCursorPosition(20, 2);
                Console.Write("                                                     ");
                Console.SetCursorPosition(20, 2);
                Console.Write("     Date: " + DateTime.Now);
                Thread.Sleep(1000);
            }
            
        }
    }
}