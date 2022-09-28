namespace Shared;

public class IIN : ValueObject
{
    public string Value { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}