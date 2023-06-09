﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CantinaFacil.Infrastructure.Data.Migrations.AppMigrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_DOM_PERFIL",
                columns: table => new
                {
                    CD_PERFIL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NM_PERFIL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.CD_PERFIL);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PARAMETRO",
                columns: table => new
                {
                    CD_PARAMETRO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NM_PARAMETRO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TX_VALOR = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DS_PARAMETRO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETRO", x => x.CD_PARAMETRO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PERMISSAO",
                columns: table => new
                {
                    CD_PERMISSAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NM_PERMISSAO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSAO", x => x.CD_PERMISSAO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    CD_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CD_PERFIL = table.Column<int>(type: "int", nullable: false),
                    NR_CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NM_USUARIO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TX_EMAIL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TX_SENHA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TX_TELEFONE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DT_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TP_USUARIO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.CD_USUARIO);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_TB_DOM_PERFIL_CD_PERFIL",
                        column: x => x.CD_PERFIL,
                        principalTable: "TB_DOM_PERFIL",
                        principalColumn: "CD_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PERFIL_PERMISSAO",
                columns: table => new
                {
                    CD_SUBPERFIL_PERMISSAO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CD_PERFIL = table.Column<int>(type: "int", nullable: false),
                    CD_PERMISSAO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBPERFIL_PERMISSAO", x => x.CD_SUBPERFIL_PERMISSAO);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_PERMISSAO_TB_DOM_PERFIL_CD_PERFIL",
                        column: x => x.CD_PERFIL,
                        principalTable: "TB_DOM_PERFIL",
                        principalColumn: "CD_PERFIL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_PERMISSAO_TB_PERMISSAO_CD_PERMISSAO",
                        column: x => x.CD_PERMISSAO,
                        principalTable: "TB_PERMISSAO",
                        principalColumn: "CD_PERMISSAO",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_ESTABELECIMENTO",
                columns: table => new
                {
                    CD_ESTABELECIMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CD_USUARIO = table.Column<int>(type: "int", nullable: false),
                    NM_ESTABELECIMENTO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NR_CNJP = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTABELECIMENTO", x => x.CD_ESTABELECIMENTO);
                    table.ForeignKey(
                        name: "FK_TB_ESTABELECIMENTO_TB_USUARIO_CD_USUARIO",
                        column: x => x.CD_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "CD_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    CD_PRODUTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CD_ESTABELECIMENTO = table.Column<int>(type: "int", nullable: false),
                    NM_PERFIL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VL_VALOR = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.CD_PRODUTO);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_ESTABELECIMENTO_CD_ESTABELECIMENTO",
                        column: x => x.CD_ESTABELECIMENTO,
                        principalTable: "TB_ESTABELECIMENTO",
                        principalColumn: "CD_ESTABELECIMENTO",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ESTABELECIMENTO_CD_USUARIO",
                table: "TB_ESTABELECIMENTO",
                column: "CD_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_PERMISSAO_CD_PERFIL",
                table: "TB_PERFIL_PERMISSAO",
                column: "CD_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_PERMISSAO_CD_PERMISSAO",
                table: "TB_PERFIL_PERMISSAO",
                column: "CD_PERMISSAO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_CD_ESTABELECIMENTO",
                table: "TB_PRODUTO",
                column: "CD_ESTABELECIMENTO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_CD_PERFIL",
                table: "TB_USUARIO",
                column: "CD_PERFIL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PARAMETRO");

            migrationBuilder.DropTable(
                name: "TB_PERFIL_PERMISSAO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_PERMISSAO");

            migrationBuilder.DropTable(
                name: "TB_ESTABELECIMENTO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_DOM_PERFIL");
        }
    }
}
