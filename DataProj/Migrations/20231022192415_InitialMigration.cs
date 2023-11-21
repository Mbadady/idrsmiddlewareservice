using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProj.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "claim",
                columns: table => new
                {
                    idrsid = table.Column<string>(type: "character varying", nullable: false),
                    stan = table.Column<string>(type: "character varying", nullable: true),
                    amount = table.Column<double>(type: "double precision", precision: 22, nullable: true),
                    transactionamount = table.Column<double>(type: "double precision", precision: 22, nullable: true),
                    dateoftransaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    acqrrn = table.Column<string>(type: "character varying", nullable: true),
                    arn = table.Column<string>(type: "character varying", nullable: true),
                    typecode = table.Column<string>(type: "character varying", nullable: true),
                    disputeticketid = table.Column<string>(type: "character varying", nullable: true),
                    errorreason = table.Column<string>(type: "character varying", nullable: true),
                    requestid = table.Column<string>(type: "character varying", nullable: true),
                    processoridtransactionid = table.Column<string>(type: "character varying", nullable: false),
                    disputetype = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("claims_pkey", x => x.idrsid);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    transid = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: false),
                    onlinesettlementdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rawdatarecipient = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    vssprocessingdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    vnpsettdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    terminalid = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    atm_acquirer = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    atm_location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    cardnumber = table.Column<string>(type: "character varying(22)", maxLength: 22, nullable: true),
                    cardseq = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    transactionamount = table.Column<double>(type: "double precision", nullable: false),
                    transactionamt_currencycode = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    settlementamount = table.Column<double>(type: "double precision", nullable: true),
                    settlementamt_currencycode = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    reimbursementfee = table.Column<double>(type: "double precision", nullable: true),
                    localtransactiondate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    localtransactiontime = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    tracenumber = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    batchnumber = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    responsedesc = table.Column<string>(type: "character varying(109)", maxLength: 109, nullable: true),
                    responsecode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    transactiontype = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    requestmessagetype = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    processingcode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    settlementmentserviceselected = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    calculatedfeetovnp = table.Column<double>(type: "double precision", nullable: true),
                    calculatedfeetobank = table.Column<double>(type: "double precision", nullable: true),
                    sign = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    approvalcode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    acqrrn = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    revrequestid = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    transmissiondate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    transmissiontime = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    feprrn = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    extrrn = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    acqstan = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    origtype = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    transactionfee = table.Column<double>(type: "double precision", nullable: true),
                    issuerfiid = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    acquirerfiid = table.Column<double>(type: "double precision", nullable: true),
                    domestic = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    host = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    origtypeold = table.Column<double>(type: "double precision", nullable: true),
                    transactionfeeold = table.Column<double>(type: "double precision", nullable: true),
                    batchid = table.Column<double>(type: "double precision", nullable: true),
                    customeracct = table.Column<string>(type: "character varying(65)", maxLength: 65, nullable: true),
                    termclass = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    extstan = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    acquirerfee = table.Column<double>(type: "double precision", nullable: true),
                    phase = table.Column<string>(type: "character varying(38)", maxLength: 38, nullable: true),
                    merchantname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    phoneno = table.Column<string>(type: "character varying(22)", maxLength: 22, nullable: true),
                    invoicenum = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    acqreferenceno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    maskedpan = table.Column<string>(type: "character varying(22)", maxLength: 22, nullable: true),
                    userdata = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    transimportdate = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    merchantid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    textmess = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    creditval = table.Column<double>(type: "double precision", nullable: true),
                    originalamount = table.Column<double>(type: "double precision", nullable: true),
                    tranclass = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    toacct2 = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "claim");

            migrationBuilder.DropTable(
                name: "transaction");
        }
    }
}
