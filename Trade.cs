interface ITrade
{
double Value { get; } //indicates the transaction amount in dollars
string ClientSector { get; } //indicates the client's sector which can be "Public" or "Private"
DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected
}

public class Trade : ITrade
{
    private double _value { get; }
    private string _clientSector { get; }
    private DateTime _nextPaymentDate { get; }
    private string _category { get; set; }

    public double Value
    {
        get { return _value; }
    }

    public string ClientSector
    {
        get { return _clientSector; }
    }

    public DateTime NextPaymentDate
    {
        get { return _nextPaymentDate; }
    }

    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    public Trade(double value, string clientSector, DateTime nextPaymentDate)
    {
        _value = value;
        _clientSector = clientSector;
        _nextPaymentDate = nextPaymentDate;
        _category = null;
    }

     public string categorizeTrade(DateTime referenceDate){
        // Verifies if trade is Expired
        if((NextPaymentDate - referenceDate).TotalDays < -30){
            Category = "EXPIRED";
            return Category;
        }

        // Verifies if trade can be High or Medium risk
        else if(Value > 1000000){
            if(ClientSector == "Private")
                Category = "HIGHRISK";
            else if(ClientSector == "Public")
                Category = "MEDIUMRISK";

            return Category;
        }

        // Defines as "uncategorized" if the trade is not in any of the categories ahead
        else Category = "uncategorized";
        return Category;
    }
}