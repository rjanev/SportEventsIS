using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class prv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportsEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Team1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeamId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Team2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SportEventsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportsEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchSchedules_SportsEvent_SportsEventId",
                        column: x => x.SportsEventId,
                        principalTable: "SportsEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchSchedules_Teams_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchSchedules_Teams_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    years = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchSchedules_SportsEventId",
                table: "MatchSchedules",
                column: "SportsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchSchedules_Team1Id",
                table: "MatchSchedules",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchSchedules_Team2Id",
                table: "MatchSchedules",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchSchedules");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SportsEvent");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
