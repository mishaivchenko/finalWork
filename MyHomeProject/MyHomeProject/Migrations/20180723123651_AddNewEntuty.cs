using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyHomeProject.Migrations
{
    public partial class AddNewEntuty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    IngridientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.IngridientId);
                });

            migrationBuilder.CreateTable(
                name: "Dish_Ingridents",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    IngridientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish_Ingridents", x => new { x.DishId, x.IngridientId });
                    table.ForeignKey(
                        name: "FK_Dish_Ingridents_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dish_Ingridents_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "IngridientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_Ingridents_IngridientId",
                table: "Dish_Ingridents",
                column: "IngridientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dish_Ingridents");

            migrationBuilder.DropTable(
                name: "Ingridients");
        }
    }
}
