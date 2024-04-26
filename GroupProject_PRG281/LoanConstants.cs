using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_PRG281
{
    public interface ILoanConstants
    {
        int shortTerm { get; }
        int mediumTerm { get; }
        int longTerm { get; }
        int maxLoanAmount { get; }
        string companyName { get; }
    }

    public  class LoanConstants: ILoanConstants
    {
        public int shortTerm { get { return 1; } }
        public int mediumTerm { get { return 3; } }
        public int longTerm { get { return 5; } }
        public int maxLoanAmount { get { return 100000; } }
        public string companyName{ get { return "Unique Building Services Loan Company"; } }

        /*public const int mediumTerm = 3;
        public const int longTerm = 5;

        public const decimal maxLoanAmount = 100000;
        public const string companyName= "Unique Building Services Loan Company";*/

       

        /*public static int ShortTerm => shortTerm;

        public static int MediumTerm => mediumTerm;

        public static int LongTerm => longTerm;

        public static decimal MaxLoanAmount => maxLoanAmount;

        public static string CompanyName => companyName;*/
    }

}
