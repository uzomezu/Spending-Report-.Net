// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using BankStatement.Model;
using Transaction;
using Deposit;
using Date.Format;

var fileName = "./data/transactions.CSV";
List<BankStatement.Model.BankStatement> statements = new List<BankStatement.Model.BankStatement>();
try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                int tick = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if(tick>0){
                        var row = line.Split(',');
                        DateTime date = DateTime.Parse(row[0].Trim());
                        if (row[4] != ""){
                            statements.Add(new Deposit.Deposit(date, row[2], Double.Parse(row[4])));
                        } else {
                            statements.Add(new Transaction.Transaction(date, row[2], Double.Parse(row[3])));
                        }

                    }
                    tick++;
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

/*
Test Query: Acknowledging that bank statements from stores 
like Walmart or Target contain the same query paramter of {{StoreName || StoreWebsite}} in all caps Standard case
*/
var query = (from statement in statements
             where statement.Desc.Contains("WALMARTCOM") 
             || statement.Desc.Contains("Walmart")
             group statement by statement.Date.Month into byDate
             orderby byDate.Key
             select byDate).ToList(); // Placing these walmart purchases I've made into Queryable Lists

foreach(var item in query){
    var avg = (from s in item select s.Debit).ToList().Average();
    var totalSpent = (from s in item select s.Debit).ToList().Sum();
    Console.WriteLine(
        $"Month: {item.Key}\nAverage Spent: {avg}\nTotal Spent: {totalSpent}\nNumber of Purchases: {item.Count()}\n"
        );
}