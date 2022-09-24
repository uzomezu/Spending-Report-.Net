using System;
namespace Transaction
{
    public class Transaction : BankStatement.Model.BankStatement
    {
        private DateTime date;
        private string desc = String.Empty;

        private string debit;

        public DateTime Date{get;set;}
        public string Desc{get; set;}
        public string Debit{get;set;}

        public string Credit{get=>"0";set=>value = "0";}

        
        public Transaction(){}
        public Transaction(DateTime dateOf, string desc, string amount){
            Date = dateOf;
            Desc = desc;
            Debit = amount;
            Credit = "0";
        }
    }}
