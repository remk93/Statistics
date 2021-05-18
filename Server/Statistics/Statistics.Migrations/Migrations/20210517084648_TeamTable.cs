using Microsoft.EntityFrameworkCore.Migrations;

namespace Statistics.Migrations.Migrations
{
    public partial class TeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    City = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Conference = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Division = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team_Id", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UX_Team_Code",
                table: "Team",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
