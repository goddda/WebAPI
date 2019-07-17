using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HugDb.Migrations
{
    public partial class AddedManyToManyCommitteeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommitteeId",
                table: "Hugs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hugs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CommitteeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCommittees_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCommittees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hugs_CommitteeId",
                table: "Hugs",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hugs_UserId",
                table: "Hugs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommittees_CommitteeId",
                table: "UserCommittees",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommittees_UserId",
                table: "UserCommittees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hugs_Committees_CommitteeId",
                table: "Hugs",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hugs_Users_UserId",
                table: "Hugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hugs_Committees_CommitteeId",
                table: "Hugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Hugs_Users_UserId",
                table: "Hugs");

            migrationBuilder.DropTable(
                name: "UserCommittees");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Hugs_CommitteeId",
                table: "Hugs");

            migrationBuilder.DropIndex(
                name: "IX_Hugs_UserId",
                table: "Hugs");

            migrationBuilder.DropColumn(
                name: "CommitteeId",
                table: "Hugs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hugs");
        }
    }
}
