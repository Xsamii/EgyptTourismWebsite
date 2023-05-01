using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EgyptTouristWebSite.Migrations
{
    /// <inheritdoc />
    public partial class fixingTouristIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestingPlaces_AspNetUsers_AppUserId",
                table: "InterestingPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_AppUserId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "InterestingPlaceTourist");

            migrationBuilder.DropTable(
                name: "ServiceTourist");

            migrationBuilder.DropTable(
                name: "Tourist");

            migrationBuilder.DropIndex(
                name: "IX_Services_AppUserId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_InterestingPlaces_AppUserId",
                table: "InterestingPlaces");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "InterestingPlaces");

            migrationBuilder.CreateTable(
                name: "AppUserInterestingPlace",
                columns: table => new
                {
                    InterestingPlacesId = table.Column<int>(type: "integer", nullable: false),
                    TouristId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserInterestingPlace", x => new { x.InterestingPlacesId, x.TouristId });
                    table.ForeignKey(
                        name: "FK_AppUserInterestingPlace_AspNetUsers_TouristId",
                        column: x => x.TouristId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserInterestingPlace_InterestingPlaces_InterestingPlaces~",
                        column: x => x.InterestingPlacesId,
                        principalTable: "InterestingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserService",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "integer", nullable: false),
                    TouristsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserService", x => new { x.ServicesId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_AppUserService_AspNetUsers_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserInterestingPlace_TouristId",
                table: "AppUserInterestingPlace",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserService_TouristsId",
                table: "AppUserService",
                column: "TouristsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserInterestingPlace");

            migrationBuilder.DropTable(
                name: "AppUserService");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "InterestingPlaces",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccId = table.Column<int>(type: "integer", nullable: true),
                    TravelAgencyId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    X = table.Column<double>(type: "double precision", nullable: false),
                    Y = table.Column<double>(type: "double precision", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tourist_Accommodations_AccId",
                        column: x => x.AccId,
                        principalTable: "Accommodations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tourist_TravelAgencies_TravelAgencyId",
                        column: x => x.TravelAgencyId,
                        principalTable: "TravelAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InterestingPlaceTourist",
                columns: table => new
                {
                    InterestingPlacesId = table.Column<int>(type: "integer", nullable: false),
                    TouristId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestingPlaceTourist", x => new { x.InterestingPlacesId, x.TouristId });
                    table.ForeignKey(
                        name: "FK_InterestingPlaceTourist_InterestingPlaces_InterestingPlaces~",
                        column: x => x.InterestingPlacesId,
                        principalTable: "InterestingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestingPlaceTourist_Tourist_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTourist",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "integer", nullable: false),
                    TouristsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTourist", x => new { x.ServicesId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_ServiceTourist_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTourist_Tourist_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppUserId",
                table: "Services",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestingPlaces_AppUserId",
                table: "InterestingPlaces",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestingPlaceTourist_TouristId",
                table: "InterestingPlaceTourist",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTourist_TouristsId",
                table: "ServiceTourist",
                column: "TouristsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_AccId",
                table: "Tourist",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_TravelAgencyId",
                table: "Tourist",
                column: "TravelAgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestingPlaces_AspNetUsers_AppUserId",
                table: "InterestingPlaces",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_AppUserId",
                table: "Services",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
