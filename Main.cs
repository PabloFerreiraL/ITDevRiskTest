using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        int nTrades = int.Parse(Console.ReadLine());
        
        for(int i = 0; i < nTrades; i++){
            // read the input from the user N times, splitting the different values in the line and putting them on array
            string input = Console.ReadLine();
            string[] tradeInfos = input.Split(' ');

            // create a Trade object with the trade's info received from the user
            Trade trade = new Trade(double.Parse(tradeInfos[0]), tradeInfos[1], DateTime.ParseExact(tradeInfos[2], "MM/dd/yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(trade.categorizeTrade(referenceDate));
        }
    }
}