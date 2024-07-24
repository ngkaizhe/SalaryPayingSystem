namespace SalaryPayingSystem.PayClassifications;

public class HourlyClassification(double hourlyRate) : IPayClassification
{
    private double _hourlyRate = hourlyRate;
    private List<TimeCard> _timeCards = [];

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
}