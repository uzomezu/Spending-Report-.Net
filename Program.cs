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

var fileName = "./transactions.CSV";
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
                        if (row[2].Contains("Deposit")){
                            statements.Add(new Deposit.Deposit(date, row[2], row[4]));                           
                        } else {
                            statements.Add(new Transaction.Transaction(date, row[2], row[3]));
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

var query = (from statement in statements
             where statement.Desc.Contains("WALMARTCOM")
             || statement.Desc.Contains("Walmart")
             select statement.Debit);

foreach (var num in query){
    Console.WriteLine(num);
}