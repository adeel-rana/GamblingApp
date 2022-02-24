namespace Bet.Domain.Models;
public class ResponseInfo
{
    public string Status { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}
