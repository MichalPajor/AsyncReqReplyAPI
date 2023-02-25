namespace AsyncReqReplyAPI.Models.DTOs;

public class ListingResponseDTO
{
    public int Id { get; set; }
    public DateTime? EstimatedCompletionTime { get; set; }
    public string? RequestStatus { get; set; }
    public string? RequestId { get; set; }
}