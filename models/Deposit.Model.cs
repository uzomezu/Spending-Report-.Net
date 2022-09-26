using BankStatement.Model;
namespace Deposit
{
    public class Deposit : BankStatement.Model.BankStatement
    {
        private string desc = String.Empty;
        public DateTime Date{get;set;}
        public string Desc{get;set;}
        public double Debit{get=>0.0;set=>value=0.0;}

        public double Credit{get;set;}

        public Deposit(){
            Desc = "No Purchase Made";
        }

        public Deposit(DateTime date, string desc, double credit){
            Credit = credit;
            Date = date;
            Desc = desc;
            Debit = 0.0;
        }
    }
}