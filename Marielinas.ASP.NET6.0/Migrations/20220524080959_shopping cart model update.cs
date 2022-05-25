using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marielinas.ASP.NET6._0.Migrations
{
    public partial class shoppingcartmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
