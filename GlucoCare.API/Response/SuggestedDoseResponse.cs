namespace GlucoCare.API.Response;

public class SuggestedDoseResponse
{
    public decimal SuggestedDose { get; set; }
    public int StatusCode { get; set; } = 200;
    public string Error { get; set; }
}