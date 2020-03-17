using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GestionOffer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    domaine = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    fax = table.Column<string>(nullable: false),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    tel = table.Column<int>(nullable: false),
                    typeEnterprise = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: false),
                    libelle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: false),
                    libelle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Direction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: false),
                    libelle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    domaine = table.Column<string>(nullable: false),
                    fax = table.Column<string>(nullable: false),
                    typeEnterprise = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bidderId = table.Column<int>(nullable: true),
                    city = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: false),
                    region = table.Column<string>(nullable: false),
                    street = table.Column<string>(nullable: false),
                    zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Bidder_bidderId",
                        column: x => x.bidderId,
                        principalTable: "Bidder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    categorieId = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    commissionId = table.Column<int>(nullable: true),
                    dateCreation = table.Column<DateTime>(nullable: false),
                    dateLimit = table.Column<DateTime>(nullable: false),
                    dateOpened = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    directionId = table.Column<int>(nullable: false),
                    etat = table.Column<string>(nullable: false),
                    intitule = table.Column<string>(nullable: false),
                    manager = table.Column<string>(nullable: true),
                    placeDepot = table.Column<string>(nullable: false),
                    placeOpened = table.Column<string>(nullable: false),
                    publish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offer_Categorie_categorieId",
                        column: x => x.categorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_Commission_commissionId",
                        column: x => x.commissionId,
                        principalTable: "Commission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_Direction_directionId",
                        column: x => x.directionId,
                        principalTable: "Direction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    mail = table.Column<string>(nullable: false),
                    numberTel = table.Column<int>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diffusion",
                columns: table => new
                {
                    offerId = table.Column<int>(nullable: false),
                    bidderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diffusion", x => new { x.offerId, x.bidderId });
                    table.ForeignKey(
                        name: "FK_Diffusion_Bidder_bidderId",
                        column: x => x.bidderId,
                        principalTable: "Bidder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diffusion_Offer_offerId",
                        column: x => x.offerId,
                        principalTable: "Offer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateCreation = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    offerId = table.Column<int>(nullable: false),
                    pathFile = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Offer_offerId",
                        column: x => x.offerId,
                        principalTable: "Offer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bidderId = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    dateDepot = table.Column<DateTime>(nullable: false),
                    libelle = table.Column<string>(nullable: false),
                    offerId = table.Column<int>(nullable: false),
                    typeDepot = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plis_Bidder_bidderId",
                        column: x => x.bidderId,
                        principalTable: "Bidder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plis_Offer_offerId",
                        column: x => x.offerId,
                        principalTable: "Offer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    commissionId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => new { x.commissionId, x.userId });
                    table.ForeignKey(
                        name: "FK_Member_Commission_commissionId",
                        column: x => x.commissionId,
                        principalTable: "Commission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Depouillement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(nullable: true),
                    dateDepouille = table.Column<DateTime>(nullable: true),
                    noteFinance = table.Column<byte>(nullable: true),
                    noteTechnical = table.Column<byte>(nullable: true),
                    plisId = table.Column<int>(nullable: true),
                    transCript = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depouillement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depouillement_Plis_plisId",
                        column: x => x.plisId,
                        principalTable: "Plis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    dateContract = table.Column<DateTime>(nullable: true),
                    depouilleId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    payment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Depouillement_depouilleId",
                        column: x => x.depouilleId,
                        principalTable: "Depouillement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_bidderId",
                table: "Address",
                column: "bidderId",
                unique: true,
                filter: "[bidderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_depouilleId",
                table: "Contract",
                column: "depouilleId",
                unique: true,
                filter: "[depouilleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Depouillement_plisId",
                table: "Depouillement",
                column: "plisId",
                unique: true,
                filter: "[plisId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Diffusion_bidderId",
                table: "Diffusion",
                column: "bidderId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_offerId",
                table: "Documents",
                column: "offerId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_userId",
                table: "Member",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_categorieId",
                table: "Offer",
                column: "categorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_commissionId",
                table: "Offer",
                column: "commissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_directionId",
                table: "Offer",
                column: "directionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plis_bidderId",
                table: "Plis",
                column: "bidderId");

            migrationBuilder.CreateIndex(
                name: "IX_Plis_offerId",
                table: "Plis",
                column: "offerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProviderId",
                table: "User",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Diffusion");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Depouillement");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Plis");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Bidder");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Commission");

            migrationBuilder.DropTable(
                name: "Direction");
        }
    }
}
