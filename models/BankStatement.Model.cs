namespace BankStatement.Model
{
    public interface BankStatement
    {
        public DateTime Date{get;set;}
        public string Desc{get;set;}
        public string Debit{get;set;}
        public string Credit{get;set;}
    }
}