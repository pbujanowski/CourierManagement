﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CourierManagement.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pesel = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senders",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(nullable: false),
                    RecipientId = table.Column<int>(nullable: false),
                    DeliveryCourierId = table.Column<int>(nullable: false),
                    AcceptanceDate = table.Column<DateTime>(nullable: false),
                    SentDate = table.Column<DateTime>(nullable: false),
                    ReceivedDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    InsuranceCost = table.Column<decimal>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    IsFragile = table.Column<bool>(nullable: false),
                    IsInsured = table.Column<bool>(nullable: false),
                    IsSent = table.Column<bool>(nullable: false),
                    IsReceived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Couriers_DeliveryCourierId",
                        column: x => x.DeliveryCourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Senders_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Senders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainedDeliveryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    ComplaintDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Deliveries_ComplainedDeliveryId",
                        column: x => x.ComplainedDeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeliveryId = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    AcceptanceDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    IsReturned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Returns_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Couriers",
                columns: new[] { "Id", "Address", "Birthdate", "City", "Company", "EmailAddress", "FirstName", "Gender", "LastName", "Pesel", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 1, "ul. Jasna 1", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gliwice", null, "jan.kowalski@mail.com", "Jan", 1, "Kowalski", "00000000001", "123-456-789", "44-100" },
                    { 2, "ul. Ciemna 2", new DateTime(1980, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Knurów", null, "janina.kowalska@mail.com", "Janina", 2, "Kowalska", "000000000002", "789-456-123", "44-193" }
                });

            migrationBuilder.InsertData(
                table: "Recipients",
                columns: new[] { "Id", "Address", "City", "Company", "EmailAddress", "FirstName", "Gender", "LastName", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 1, "ul. Odbiorcza 1", "Gliwice", "Firma Krzak", "pan.odbiorca@mail.com", "Pan", 1, "Odbiorca", "135-246-357", "44-100" },
                    { 2, "ul. Odbiorcza 2", "Gliwice", "Firma Kogucik", "pani.odbiorczyni@mail.com", "Pani", 2, "Odbiorczyni", "246-357-468", "44-100" }
                });

            migrationBuilder.InsertData(
                table: "Senders",
                columns: new[] { "Id", "Address", "City", "Company", "EmailAddress", "FirstName", "Gender", "LastName", "PhoneNumber", "PostalCode" },
                values: new object[,]
                {
                    { 1, "ul. Nadawcza 1", "Gliwice", "Firma Krzak", "pan.nadawca@mail.com", "Pan", 1, "Nadawca", "135-246-357", "44-100" },
                    { 2, "ul. Nadawcza 2", "Gliwice", "Firma Kogucik", "pani.nadawczyni@mail.com", "Pani", 2, "Nadawczyni", "246-357-468", "44-100" }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "AcceptanceDate", "Cost", "DeliveryCourierId", "Height", "InsuranceCost", "IsFragile", "IsInsured", "IsReceived", "IsSent", "Length", "PaymentType", "ReceivedDate", "RecipientId", "SenderId", "SentDate", "Weight", "Width" },
                values: new object[] { 1, new DateTime(2019, 4, 1, 18, 6, 4, 535, DateTimeKind.Local), 100m, 1, 300, 0m, false, false, false, false, 200, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, 250 });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "AcceptanceDate", "Cost", "DeliveryCourierId", "Height", "InsuranceCost", "IsFragile", "IsInsured", "IsReceived", "IsSent", "Length", "PaymentType", "ReceivedDate", "RecipientId", "SenderId", "SentDate", "Weight", "Width" },
                values: new object[] { 2, new DateTime(2019, 4, 1, 18, 6, 4, 542, DateTimeKind.Local), 50m, 2, 200, 0m, true, false, false, false, 1000, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2019, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000, 200 });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ComplainedDeliveryId",
                table: "Complaints",
                column: "ComplainedDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryCourierId",
                table: "Deliveries",
                column: "DeliveryCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RecipientId",
                table: "Deliveries",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_SenderId",
                table: "Deliveries",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_DeliveryId",
                table: "Returns",
                column: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Senders");
        }
    }
}