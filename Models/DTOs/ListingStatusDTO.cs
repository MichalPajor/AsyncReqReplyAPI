namespace AsyncReqReplyAPI.Models.DTOs;

public class ListingStatusDTO
{
    public string? RequestStatus { get; set; }
    public DateTime? EstimatedCompletionTime { get; set; }
    public string? ResourceURL { get; set; }
}