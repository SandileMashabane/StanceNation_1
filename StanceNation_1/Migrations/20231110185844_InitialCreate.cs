using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StanceNation_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    eventName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    eventDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventImage = table.Column<Byte[]>(type: "varbinary(max)", nullable: false),
                    eventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventPrice2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.eventName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
