using System;
namespace Transaction
{
    public class Transaction : BankStatement.Model.BankStatement
    {
        private DateTime date;
        private string desc = String.Empty;

        public DateTime Date{get;set;}
        public string Desc{get; set;}
        public double Debit{get;set;}

        public double Credit{get=>0.0;set=>value = 0.0;}

        
        public Transaction(){
            Debit = 0;
            Desc = "No Purchase Made";
        }
        public Transaction(DateTime dateOf, string desc, double amount){
            Date = dateOf;
            Desc = desc;
            Debit = amount;
            Credit = 0.0;
        }
    }}
