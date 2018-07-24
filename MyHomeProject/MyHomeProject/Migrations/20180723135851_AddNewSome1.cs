using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyHomeProject.Migrations
{
    public partial class AddNewSome1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingridents_Dish_DishId",
                table: "Dish_Ingridents");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingridents_Ingridients_IngridientId",
                table: "Dish_Ingridents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish_Ingridents",
                table: "Dish_Ingridents");

            migrationBuilder.RenameTable(
                name: "Dish_Ingridents",
                newName: "Dish_Ingrident");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_Ingridents_IngridientId",
                table: "Dish_Ingrident",
                newName: "IX_Dish_Ingrident_IngridientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish_Ingrident",
                table: "Dish_Ingrident",
                columns: new[] { "DishId", "IngridientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingrident_Dish_DishId",
                table: "Dish_Ingrident",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingrident_Ingridients_IngridientId",
                table: "Dish_Ingrident",
                column: "IngridientId",
                principalTable: "Ingridients",
                principalColumn: "IngridientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingrident_Dish_DishId",
                table: "Dish_Ingrident");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingrident_Ingridients_IngridientId",
                table: "Dish_Ingrident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish_Ingrident",
                table: "Dish_Ingrident");

            migrationBuilder.RenameTable(
                name: "Dish_Ingrident",
                newName: "Dish_Ingridents");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_Ingrident_IngridientId",
                table: "Dish_Ingridents",
                newName: "IX_Dish_Ingridents_IngridientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish_Ingridents",
                table: "Dish_Ingridents",
                columns: new[] { "DishId", "IngridientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingridents_Dish_DishId",
                table: "Dish_Ingridents",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingridents_Ingridients_IngridientId",
                table: "Dish_Ingridents",
                column: "IngridientId",
                principalTable: "Ingridients",
                principalColumn: "IngridientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
