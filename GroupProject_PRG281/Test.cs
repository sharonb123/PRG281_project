using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_PRG281
{
    public class Test : Loan
    {
        public Test(string loanNr, int loanTerm, string custLastName, string custFirstName, decimal loanAmount) : base(loanNr, loanTerm, custLastName, custFirstName, loanAmount)
        {

        }


    }
}
