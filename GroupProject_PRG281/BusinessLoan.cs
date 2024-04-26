using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_PRG281
{

    internal class BusinessLoan : Loan
    {
        decimal primeInterestRate;

        public BusinessLoan(string loanNr, int loanTerm, string custLastName, string custFirstName, decimal loanAmount, decimal primeInterestRate) : base(loanNr, loanTerm, custLastName, custFirstName, loanAmount)
        {
            this.primeInterestRate = primeInterestRate;

            InterestRate = primeInterestRate + 1;
        }

        public decimal PrimeInterestRate { get => primeInterestRate; set => primeInterestRate = value; }
        
    }
}
