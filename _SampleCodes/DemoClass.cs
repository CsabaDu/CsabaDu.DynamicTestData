namespace CsabaDu.DynamicTestData.SampleCodes;

public class DemoClass
{
    public const string GreaterThanCurrentDateTimeMessage = "The dateTime parameter cannot be greater than the current date and time.";

    public bool IsOlder(DateTime thisDate, DateTime otherDate)
    {
        throwIfDateTimeGreaterThanCurrent(thisDate, nameof(thisDate));
        throwIfDateTimeGreaterThanCurrent(otherDate, nameof(otherDate));

        return thisDate > otherDate;

        static void throwIfDateTimeGreaterThanCurrent(DateTime dateTime, string paramName)
        {
            if (dateTime > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(paramName, GreaterThanCurrentDateTimeMessage);
            }
        }
    }
}
