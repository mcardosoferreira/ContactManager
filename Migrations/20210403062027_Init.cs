using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Neighborhood = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telephones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContactId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telephones_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Neighborhood", "State" },
                values: new object[] { 1, "salvador", "casa 29", "Castelo Branco", "bahia" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Neighborhood", "State" },
                values: new object[] { 2, "salvador", "casa 29", "Stiep", "bahia" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Neighborhood", "State" },
                values: new object[] { 3, "salvador", "casa 29", "Rio Vermelho", "bahia" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Neighborhood", "State" },
                values: new object[] { 4, "salvador", "casa 29", "Federação", "bahia" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Neighborhood", "State" },
                values: new object[] { 5, "salvador", "casa 29", "Barra", "bahia" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "LastName", "Name" },
                values: new object[] { 5, 1, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandre@Montanha.com", "Montanha", "Alexandre" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "LastName", "Name" },
                values: new object[] { 1, 2, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "lauro@oliveira.com", "Oliveira", "Lauro" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "LastName", "Name" },
                values: new object[] { 2, 3, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto@Soares.com", "Soares", "Roberto" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "LastName", "Name" },
                values: new object[] { 3, 4, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronaldo@Marconi.com", "Marconi", "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "LastName", "Name" },
                values: new object[] { 4, 5, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodrigo@Carvalho.com", "Carvalho", "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 4, 5, "134679" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 3, 1, "124578" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 7, 1, "258741" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 8, 1, "147963" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 1, 2, "123456" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 6, 2, "976431" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 2, 3, "654321" });

            migrationBuilder.InsertData(
                table: "Telephones",
                columns: new[] { "Id", "ContactId", "Number" },
                values: new object[] { 5, 4, "875421" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_ContactId",
                table: "Telephones",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telephones");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
