using AsyncReqReplyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncReqReplyAPI.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ListingRequest>(entity =>
        {
            entity.ToTable("ListingRequest");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id).IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            entity.Property(e => e.RequestBody).HasColumnName("RequestBody");
            entity.Property(e => e.EstimatedCompletionTime).HasColumnName("EstimatedCompletionTime");
            entity.Property(e => e.RequestStatus).HasColumnName("RequestStatus");
            entity.Property(e => e.RequestId).HasColumnName("RequestId");

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
