using System.Globalization;
namespace Date.Format
{
    public class DateTimeFormat
    {
        public string Variation {
            get;set;
        }
        public string Date {
            get;set;
        }
        public int MM {
            get;set;
        }
        public int DD {
            get;set;
        }
        public int YYYY {
            get;set;
        }

        public DateTimeFormat(){}

        public DateTimeFormat(string date, string variation){
            Date = date;
            string[] arr = date.Split("/");
            if(variation == "dd/mm/yyyy"){
                DD = Convert.ToInt32(arr[0]);
                MM = Convert.ToInt32(arr[1]);
                YYYY = Convert.ToInt32(arr[2]);
            } else if (variation == "mm/dd/yyyy") {
                MM = Convert.ToInt32(arr[0]);
                DD = Convert.ToInt32(arr[1]);
                YYYY = Convert.ToInt32(arr[0]);
            }

        }

        public DateTime toMMDDYYY(){
            string month = MM.ToString("00");
            string day = DD.ToString("00");
            string year = YYYY.ToString("0000");
            Console.WriteLine("{0} {1} {2} 09",MM,DD,YYYY);
            string[] strArr = {month,day,year};
            Date = String.Join("/",strArr);
            return (DateTime.ParseExact(Date, "mm/dd/yyyy", CultureInfo.CurrentCulture));
        }
    }
}