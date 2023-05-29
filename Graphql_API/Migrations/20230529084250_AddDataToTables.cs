using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Graphql_API.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"), "Bob's avenue", "Bob Baggins" },
                    { new Guid("9b9692f5-be70-44d6-bb6c-a7df544fac6e"), "Jack's street", "Jack Dickins" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("0583f813-6136-43a9-becd-f9c01dadf68c"), "Savings acc", new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"), 2 },
                    { new Guid("0aca45d7-72ee-43e8-80c0-521aac234c73"), "Cash acc", new Guid("9b9692f5-be70-44d6-bb6c-a7df544fac6e"), 0 },
                    { new Guid("4695d684-c9f4-49c7-9670-97a66f3402bf"), "Expense acc", new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("0583f813-6136-43a9-becd-f9c01dadf68c"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("0aca45d7-72ee-43e8-80c0-521aac234c73"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("4695d684-c9f4-49c7-9670-97a66f3402bf"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("8ca8c0c6-a305-430e-91d2-9e55ad9a28cc"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("9b9692f5-be70-44d6-bb6c-a7df544fac6e"));
        }
    }
}
