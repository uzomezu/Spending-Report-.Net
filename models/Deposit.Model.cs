using BankStatement.Model;
namespace Deposit
{
    public class Deposit : BankStatement.Model.BankStatement
    {
        private string desc = String.Empty;
        public DateTime Date{get;set;}
        public string Desc{get;set;}
        public string Debit{get=>"0";set=>value="0";}

        public string Credit{get;set;}

        public Deposit(){}

        public Deposit(DateTime date, string desc, string credit){
            Credit = credit;
            Date = date;
            Desc = desc;
            Debit = "0";
        }
    }
}