using Newtonsoft.Json;

namespace CleanArchitectureIntro.WebAPI.Middlewares;

public sealed class ErrorResult : ErrorStatusCode
{
    public string Message { get; set; } = null!;
}


public class ErrorStatusCode
{
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public sealed class ValidationErrorDetails : ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
