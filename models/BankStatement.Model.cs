namespace BankStatement.Model
{
    public interface BankStatement
    {
        public DateTime Date{get;set;}
        public string Desc{get;set;}
        public double Debit{get;set;}
        public double Credit{get;set;}
    }
}