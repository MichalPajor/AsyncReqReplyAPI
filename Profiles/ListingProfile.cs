using AsyncReqReplyAPI.Models;
using AsyncReqReplyAPI.Models.DTOs;
using AutoMapper;

namespace AsyncReqReplyAPI.Profiles;

public class ListingProfile : Profile
{
    public ListingProfile()
    {
        CreateMap<ListingRequestDTO, ListingRequest>();
        CreateMap<ListingRequest, ListingResponseDTO>();
        CreateMap<ListingRequest, ListingStatusDTO>();
    }
}