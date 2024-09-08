using SalaryPayingSystem.Options.TimeCards;

namespace SalaryPayingSystem.PayClassifications;

public class HourlyClassification(double hourlyPay) : IPayClassification
{
    public double HourlyPay { get; } = hourlyPay;
    private readonly List<TimeCard> _timeCards = [];

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
    
    public TimeCard? GetTimeCard(DateTime date)
    {
        return _timeCards.FirstOrDefault(tc => tc.Date == date);
    }

    public void AddTimeCard(DateTime date, int hours)
    {
        _timeCards.Add(new TimeCard(date, hours));
    }
}