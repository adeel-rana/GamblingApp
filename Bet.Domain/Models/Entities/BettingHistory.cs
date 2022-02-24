namespace Bet.Domain.Models.Entities;
public class BettingHistory
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public double Points { get; set; }
    public string Status { get; set; }
    public DateTime BetTime { get; set; } = DateTime.Now;
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
}