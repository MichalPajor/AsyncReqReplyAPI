using AsyncReqReplyAPI.Data;
using AsyncReqReplyAPI.Models;
using AsyncReqReplyAPI.Models.DTOs;
using AsyncReqReplyAPI.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=RequestDB.db"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapPost("api/v1/products", async (AppDbContext context, IMapper mapper, ListingRequestDTO request) =>
{
    if (request == null)
    {
        return Results.BadRequest();
    }
    var product = mapper.Map<ListingRequest>(request);
    product.RequestStatus = "Accepted";
    product.EstimatedCompletionTime = EstimateProductInsert.Calculate(request.ProductsList);
    product.RequestBody = JsonConvert.SerializeObject(request.ProductsList);
    await context.ListingRequests.AddAsync(product);
    await context.SaveChangesAsync();

    var response = mapper.Map<ListingResponseDTO>(product);

    return Results.Accepted($"api/v1/productstatus/{product.RequestId}", response);
});

app.MapGet("api/v1/productstatus/{requestId}", (AppDbContext context, IMapper mapper, string requestId) =>
{
    var request = context.ListingRequests.Where(p => p.RequestId == requestId).FirstOrDefault();
    if (request == null)
    {
        return Results.NotFound();
    }
    var response = mapper.Map<ListingStatusDTO>(request);
    if (response.RequestStatus == "Completed")
    {
        return Results.Redirect($"https://localhost:7273/api/v1/products/{Guid.NewGuid().ToString()}");
    }
    response.ResourceURL = String.Empty;
    return Results.Ok(response);
});

app.MapGet("api/v1/products/{requestId}", (string requestId) =>
{
    return Results.Ok("Final result");
});

app.Run();

