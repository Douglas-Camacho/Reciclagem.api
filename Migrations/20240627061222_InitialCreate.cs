using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reciclagem.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaminhaoModel",
                columns: table => new
                {
                    CaminhaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaminhaoModel", x => x.CaminhaoId);
                });

            migrationBuilder.CreateTable(
                name: "CapacidadeCaminhaoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CaminhaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Local = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Capacidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    NivelAtual = table.Column<double>(type: "BINARY_DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacidadeCaminhaoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CidadaoModel",
                columns: table => new
                {
                    CidadaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadaoModel", x => x.CidadaoId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaminhaoModel");

            migrationBuilder.DropTable(
                name: "CapacidadeCaminhaoModel");

            migrationBuilder.DropTable(
                name: "CidadaoModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
