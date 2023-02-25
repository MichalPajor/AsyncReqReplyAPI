using Microsoft.EntityFrameworkCore;

namespace AsyncReqReplyAPI.Models;

public class ListingRequest
{
    public int Id { get; set; }
    public string? RequestBody { get; set; }
    public DateTime? EstimatedCompletionTime { get; set; }
    public string? RequestStatus { get; set; }
    public string RequestId { get; set; } = Guid.NewGuid().ToString();
}