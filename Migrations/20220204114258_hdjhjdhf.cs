﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace shipwithme.Migrations
{
    public partial class hdjhjdhf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Registration");
        }
    }
}
