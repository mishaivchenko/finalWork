using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyHomeProject.Migrations
{
    public partial class changeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingrident_Dish_DishId",
                table: "Dish_Ingrident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingrident_Dishes_DishId",
                table: "Dish_Ingrident",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Ingrident_Dishes_DishId",
                table: "Dish_Ingrident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Ingrident_Dish_DishId",
                table: "Dish_Ingrident",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
