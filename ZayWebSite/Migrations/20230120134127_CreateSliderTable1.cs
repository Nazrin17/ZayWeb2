﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZayWebSite.Migrations
{
    public partial class CreateSliderTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sliders");
        }
    }
}
