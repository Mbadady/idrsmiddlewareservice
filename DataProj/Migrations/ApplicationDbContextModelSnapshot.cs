﻿// <auto-generated />
using System;
using DataProj.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataProj.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataProj.Domain.Claim", b =>
                {
                    b.Property<string>("Idrsid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying")
                        .HasColumnName("idrsid");

                    b.Property<string>("Acqrrn")
                        .HasColumnType("character varying")
                        .HasColumnName("acqrrn");

                    b.Property<double?>("Amount")
                        .HasPrecision(22)
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<string>("Arn")
                        .HasColumnType("character varying")
                        .HasColumnName("arn");

                    b.Property<DateTime?>("Dateoftransaction")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateoftransaction");

                    b.Property<string>("Disputeticketid")
                        .HasColumnType("character varying")
                        .HasColumnName("disputeticketid");

                    b.Property<string>("Disputetype")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("disputetype");

                    b.Property<string>("Errorreason")
                        .HasColumnType("character varying")
                        .HasColumnName("errorreason");

                    b.Property<string>("Processoridtransactionid")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("processoridtransactionid");

                    b.Property<string>("Requestid")
                        .HasColumnType("character varying")
                        .HasColumnName("requestid");

                    b.Property<string>("Stan")
                        .HasColumnType("character varying")
                        .HasColumnName("stan");

                    b.Property<string>("Status")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("status");

                    b.Property<double?>("Transactionamount")
                        .HasPrecision(22)
                        .HasColumnType("double precision")
                        .HasColumnName("transactionamount");

                    b.Property<string>("Typecode")
                        .HasColumnType("character varying")
                        .HasColumnName("typecode");

                    b.HasKey("Idrsid")
                        .HasName("claims_pkey");

                    b.ToTable("claim", (string)null);
                });

            modelBuilder.Entity("DataProj.Domain.Transaction", b =>
                {
                    b.Property<string>("Acqreferenceno")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("acqreferenceno");

                    b.Property<string>("Acqrrn")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("acqrrn");

                    b.Property<string>("Acqstan")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("acqstan");

                    b.Property<double?>("Acquirerfee")
                        .HasColumnType("double precision")
                        .HasColumnName("acquirerfee");

                    b.Property<double?>("Acquirerfiid")
                        .HasColumnType("double precision")
                        .HasColumnName("acquirerfiid");

                    b.Property<string>("Approvalcode")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("approvalcode");

                    b.Property<string>("AtmAcquirer")
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)")
                        .HasColumnName("atm_acquirer");

                    b.Property<string>("AtmLocation")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("atm_location");

                    b.Property<double?>("Batchid")
                        .HasColumnType("double precision")
                        .HasColumnName("batchid");

                    b.Property<string>("Batchnumber")
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("batchnumber");

                    b.Property<double?>("Calculatedfeetobank")
                        .HasColumnType("double precision")
                        .HasColumnName("calculatedfeetobank");

                    b.Property<double?>("Calculatedfeetovnp")
                        .HasColumnType("double precision")
                        .HasColumnName("calculatedfeetovnp");

                    b.Property<string>("Cardnumber")
                        .HasMaxLength(22)
                        .HasColumnType("character varying(22)")
                        .HasColumnName("cardnumber");

                    b.Property<string>("Cardseq")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("cardseq");

                    b.Property<double?>("Creditval")
                        .HasColumnType("double precision")
                        .HasColumnName("creditval");

                    b.Property<string>("Customeracct")
                        .HasMaxLength(65)
                        .HasColumnType("character varying(65)")
                        .HasColumnName("customeracct");

                    b.Property<string>("Domestic")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("domestic");

                    b.Property<string>("Extrrn")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("extrrn");

                    b.Property<string>("Extstan")
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("extstan");

                    b.Property<string>("Feprrn")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("feprrn");

                    b.Property<string>("Host")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("host");

                    b.Property<string>("Invoicenum")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("invoicenum");

                    b.Property<string>("Issuerfiid")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("issuerfiid");

                    b.Property<DateTime?>("Localtransactiondate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("localtransactiondate");

                    b.Property<string>("Localtransactiontime")
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)")
                        .HasColumnName("localtransactiontime");

                    b.Property<string>("Maskedpan")
                        .HasMaxLength(22)
                        .HasColumnType("character varying(22)")
                        .HasColumnName("maskedpan");

                    b.Property<string>("Merchantid")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("merchantid");

                    b.Property<string>("Merchantname")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("merchantname");

                    b.Property<DateTime?>("Onlinesettlementdate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("onlinesettlementdate");

                    b.Property<double?>("Originalamount")
                        .HasColumnType("double precision")
                        .HasColumnName("originalamount");

                    b.Property<string>("Origtype")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("origtype");

                    b.Property<double?>("Origtypeold")
                        .HasColumnType("double precision")
                        .HasColumnName("origtypeold");

                    b.Property<string>("Phase")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("phase");

                    b.Property<string>("Phoneno")
                        .HasMaxLength(22)
                        .HasColumnType("character varying(22)")
                        .HasColumnName("phoneno");

                    b.Property<string>("Processingcode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("processingcode");

                    b.Property<string>("Rawdatarecipient")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("rawdatarecipient");

                    b.Property<double?>("Reimbursementfee")
                        .HasColumnType("double precision")
                        .HasColumnName("reimbursementfee");

                    b.Property<string>("Requestmessagetype")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("requestmessagetype");

                    b.Property<string>("Responsecode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("responsecode");

                    b.Property<string>("Responsedesc")
                        .HasMaxLength(109)
                        .HasColumnType("character varying(109)")
                        .HasColumnName("responsedesc");

                    b.Property<string>("Revrequestid")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("revrequestid");

                    b.Property<double?>("Settlementamount")
                        .HasColumnType("double precision")
                        .HasColumnName("settlementamount");

                    b.Property<string>("SettlementamtCurrencycode")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("settlementamt_currencycode");

                    b.Property<string>("Settlementmentserviceselected")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("settlementmentserviceselected");

                    b.Property<string>("Sign")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("sign");

                    b.Property<string>("Termclass")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("termclass");

                    b.Property<string>("Terminalid")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("terminalid");

                    b.Property<string>("Textmess")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("textmess");

                    b.Property<string>("Toacct2")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("toacct2");

                    b.Property<string>("Tracenumber")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("tracenumber");

                    b.Property<string>("Tranclass")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("tranclass");

                    b.Property<double>("Transactionamount")
                        .HasColumnType("double precision")
                        .HasColumnName("transactionamount");

                    b.Property<string>("TransactionamtCurrencycode")
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("transactionamt_currencycode");

                    b.Property<double?>("Transactionfee")
                        .HasColumnType("double precision")
                        .HasColumnName("transactionfee");

                    b.Property<double?>("Transactionfeeold")
                        .HasColumnType("double precision")
                        .HasColumnName("transactionfeeold");

                    b.Property<string>("Transactiontype")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("transactiontype");

                    b.Property<string>("Transid")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("character varying(38)")
                        .HasColumnName("transid");

                    b.Property<TimeOnly?>("Transimportdate")
                        .HasColumnType("time without time zone")
                        .HasColumnName("transimportdate");

                    b.Property<DateTime?>("Transmissiondate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("transmissiondate");

                    b.Property<string>("Transmissiontime")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("transmissiontime");

                    b.Property<string>("Userdata")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("userdata");

                    b.Property<DateTime?>("Vnpsettdate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("vnpsettdate");

                    b.Property<DateTime?>("Vssprocessingdate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("vssprocessingdate");

                    b.ToTable("transaction", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
