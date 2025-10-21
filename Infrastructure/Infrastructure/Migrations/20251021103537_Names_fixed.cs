using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Names_fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImageEntity");

            migrationBuilder.DropTable(
                name: "PropertyEntitiy");

            migrationBuilder.AddColumn<string>(
                name: "ProfilPictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_ApplicationUserId",
                table: "Property",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropColumn(
                name: "ProfilPictureUrl",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "PropertyEntitiy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyEntitiy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyEntitiy_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImageEntity_PropertyEntitiy_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyEntitiy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyEntitiy_ApplicationUserId",
                table: "PropertyEntitiy",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImageEntity_PropertyId",
                table: "PropertyImageEntity",
                column: "PropertyId");
        }
    }
}
