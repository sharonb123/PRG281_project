using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_PRG281
{
    //Abstract class that implements the LoanConstants interface
    public class Loan : LoanConstants
    {
        // Loan includes a loan number^, customer lastname^,customer firstname^,loan amount^, interest rate^, and term^.
        private int loanTerm;
        private string custLastName, custFirstName, loanNr;
        private decimal loanAmount;
        public decimal interestRate;

        public Loan(string loanNr, int loanTerm, string custLastName, string custFirstName, decimal loanAmount)
        {
            this.LoanNr = loanNr;
            this.LoanTerm = loanTerm; //loan terms are set in years (as they should be 1, 3 or 5 years)
            this.CustLastName = custLastName;
            this.CustFirstName = custFirstName;
            this.LoanAmount = loanAmount;

            //Force loan that is not in the defined 3 term to a short term loan
            if (this.LoanTerm != shortTerm && this.LoanTerm != mediumTerm && this.LoanTerm != longTerm)
            {
                this.LoanTerm = 1;
                Console.WriteLine("Due to invalid loan term, the loan term has been set to a short term loan (1 year)");
            }
        }

        public string LoanNr { get => loanNr; set => loanNr = value; }
        public int LoanTerm { get => loanTerm; set => loanTerm = value; }
        public string CustLastName { get => custLastName; set => custLastName = value; }
        public string CustFirstName { get => custFirstName; set => custFirstName = value; }
        public decimal LoanAmount { get => loanAmount; set => loanAmount = value; }
        public decimal InterestRate { get => interestRate; set => interestRate = value; }

        //Display the loan data
        public override string ToString()
        {
            //Do not allow loan amount greater than 100000
            if (LoanAmount > maxLoanAmount)
            {
                return $"Loans greater than R{maxLoanAmount} are not permitted.";
            }
            else
            {
                return $"The loan number: {LoanNr} \nThe loan is given to {CustFirstName} {CustLastName} \nThis loan is valid for {loanTerm} years. \nThe amount lend is R{LoanAmount} at an interest rate of {InterestRate}%";
            }
            
        }
    }
}
