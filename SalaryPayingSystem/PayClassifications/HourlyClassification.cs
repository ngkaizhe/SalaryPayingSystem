namespace SalaryPayingSystem.PayClassifications;

public class HourlyClassification(double hourlyRate) : IPayClassification
{
    public double HourlyRate { get; } = hourlyRate;
    private List<TimeCard> _timeCards = [];

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
}