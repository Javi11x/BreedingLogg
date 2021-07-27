using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreedingLogg.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criadores",
                columns: table => new
                {
                    CriadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCriador = table.Column<string>(maxLength: 100, nullable: false),
                    ApellidosCriador = table.Column<string>(maxLength: 100, nullable: false),
                    CorreoC = table.Column<string>(maxLength: 100, nullable: false),
                    DireccionCriadero = table.Column<string>(maxLength: 100, nullable: false),
                    EspecieQC = table.Column<string>(maxLength: 300, nullable: false),
                    FotoCriador = table.Column<string>(nullable: true),
                    FotoCriadero = table.Column<string>(nullable: true),
                    RedSocialC = table.Column<string>(maxLength: 100, nullable: true),
                    UsuarioCriador = table.Column<string>(maxLength: 15, nullable: false),
                    ContraseñaCriador = table.Column<string>(maxLength: 15, nullable: false),
                    NivelCriador = table.Column<string>(nullable: false),
                    StatusCriador = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criadores", x => x.CriadorId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(maxLength: 100, nullable: false),
                    ApellidosUsuario = table.Column<string>(maxLength: 100, nullable: false),
                    UsuarioUsuario = table.Column<string>(maxLength: 15, nullable: false),
                    ContraseñaUsuario = table.Column<string>(maxLength: 15, nullable: false),
                    CorreoUsuario = table.Column<string>(maxLength: 100, nullable: false),
                    NivelUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCiudad = table.Column<string>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjemplaresMachos",
                columns: table => new
                {
                    EjemplarMachoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoEjemplarMacho = table.Column<string>(nullable: true),
                    NombreEjemplarMacho = table.Column<string>(maxLength: 100, nullable: false),
                    CriadorId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    CodigoPostalEjemplarMacho = table.Column<int>(nullable: false),
                    RazaEjemplarMacho = table.Column<string>(nullable: false),
                    ColorEjemplarMacho = table.Column<string>(nullable: false),
                    FechaNacimientoEjemplarMacho = table.Column<DateTime>(nullable: false),
                    VariedadEjemplarMacho = table.Column<string>(maxLength: 100, nullable: false),
                    PedegreeEjemplarMacho = table.Column<string>(maxLength: 50, nullable: false),
                    GeneroEjemplarMacho = table.Column<string>(nullable: false),
                    DescripcionEjemplarMacho = table.Column<string>(maxLength: 500, nullable: false),
                    StatusEjemplarMacho = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjemplaresMachos", x => x.EjemplarMachoId);
                    table.ForeignKey(
                        name: "FK_EjemplaresMachos_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjemplaresMachos_Criadores_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Criadores",
                        principalColumn: "CriadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjemplaresMachos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EjemplarHembras",
                columns: table => new
                {
                    EjemplarHembraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoEjemplarHembra = table.Column<string>(nullable: true),
                    NombreEjemplarHembra = table.Column<string>(maxLength: 100, nullable: false),
                    CriadorId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    CodigoPostalEjemplarHembra = table.Column<int>(nullable: false),
                    RazaEjemplarHembra = table.Column<string>(nullable: false),
                    ColorEjemplarHembra = table.Column<string>(nullable: false),
                    FechaNacimientoEjemplarHembra = table.Column<DateTime>(nullable: false),
                    VariedadEjemplarHembra = table.Column<string>(maxLength: 100, nullable: false),
                    PedegreeEjemplarHembra = table.Column<string>(maxLength: 50, nullable: false),
                    GeneroEjemplarHembra = table.Column<string>(nullable: false),
                    DescripcionEjemplarHembra = table.Column<string>(maxLength: 500, nullable: false),
                    StatusEjemplarHembra = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjemplarHembras", x => x.EjemplarHembraId);
                    table.ForeignKey(
                        name: "FK_EjemplarHembras_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjemplarHembras_Criadores_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Criadores",
                        principalColumn: "CriadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjemplarHembras_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cruces",
                columns: table => new
                {
                    CruceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCria = table.Column<string>(maxLength: 100, nullable: false),
                    GeneroCria = table.Column<string>(nullable: false),
                    EjemplarMachoId = table.Column<int>(nullable: false),
                    EjemplarHembraId = table.Column<int>(nullable: false),
                    FechaEmparejamientoCria = table.Column<DateTime>(nullable: false),
                    FechaNacimientoCria = table.Column<DateTime>(nullable: false),
                    CriasNacidas = table.Column<int>(nullable: false),
                    CriasMachos = table.Column<int>(nullable: false),
                    CriasHembras = table.Column<int>(nullable: false),
                    CriasFallecidas = table.Column<int>(nullable: false),
                    CriadorId = table.Column<int>(nullable: false),
                    StatusCruce = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cruces", x => x.CruceId);
                    table.ForeignKey(
                        name: "FK_Cruces_Criadores_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Criadores",
                        principalColumn: "CriadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cruces_EjemplarHembras_EjemplarHembraId",
                        column: x => x.EjemplarHembraId,
                        principalTable: "EjemplarHembras",
                        principalColumn: "EjemplarHembraId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cruces_EjemplaresMachos_EjemplarMachoId",
                        column: x => x.EjemplarMachoId,
                        principalTable: "EjemplaresMachos",
                        principalColumn: "EjemplarMachoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_EstadoId",
                table: "Ciudades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cruces_CriadorId",
                table: "Cruces",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cruces_EjemplarHembraId",
                table: "Cruces",
                column: "EjemplarHembraId");

            migrationBuilder.CreateIndex(
                name: "IX_Cruces_EjemplarMachoId",
                table: "Cruces",
                column: "EjemplarMachoId");

            migrationBuilder.CreateIndex(
                name: "IX_EjemplaresMachos_CiudadId",
                table: "EjemplaresMachos",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_EjemplaresMachos_CriadorId",
                table: "EjemplaresMachos",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EjemplaresMachos_EstadoId",
                table: "EjemplaresMachos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EjemplarHembras_CiudadId",
                table: "EjemplarHembras",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_EjemplarHembras_CriadorId",
                table: "EjemplarHembras",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EjemplarHembras_EstadoId",
                table: "EjemplarHembras",
                column: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cruces");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EjemplarHembras");

            migrationBuilder.DropTable(
                name: "EjemplaresMachos");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Criadores");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
