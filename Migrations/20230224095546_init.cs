using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncReqReplyAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListingRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestBody = table.Column<string>(type: "TEXT", nullable: true),
                    EstimatedCompletionTime = table.Column<string>(type: "TEXT", nullable: true),
                    RequestStatus = table.Column<string>(type: "TEXT", nullable: true),
                    RequestId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingRequest", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingRequest_Id",
                table: "ListingRequest",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingRequest");
        }
    }
}
