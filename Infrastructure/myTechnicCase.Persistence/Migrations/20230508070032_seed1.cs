using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myTechnicCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personnels",
                columns: new[] { "Id", "Active", "Address", "Email", "Name", "PersonnelCode", "Phone", "Surname", "TeamId", "Title", "UserName" },
                values: new object[,]
                {
                    { 1, true, "Maltepe/Istanbul", "erhanozgan@gmail.com", "Erhan", 337, "+905534535452", "OZGAN", null, "Dr", "erhanozgan" },
                    { 2, true, "Kartal/Istanbul", "deryasef@gmail.com", "Derya", 112, "+905533334455", "SEFEROGLU", null, "Op.Dr", "deryasef" },
                    { 3, true, "Sariyer/Istanbul", "alyaozgan@gmail.com", "Alya", 123, "+905324456767", "OZGAN", null, "Student", "alyaozgan" },
                    { 4, true, "Alsancak/Izmir", "ekremdemir@gmail.com", "Ekrem", 887, "+05543431212", "DEMIR", null, "Controller", "ekremdemir" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personnels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personnels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personnels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personnels",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
