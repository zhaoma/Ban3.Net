namespace Ban3.Infrastructures.Common.Extensions.Converters;

/// <summary>
/// 
/// </summary>
public class DateOnlyConverter
    : DateTimeConverter
{
    public DateOnlyConverter()
        : base("yyyy-MM-dd")
    {
    }
}