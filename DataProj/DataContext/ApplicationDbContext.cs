
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Util;
using DataProj.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataProj.DataContext;

public partial class ApplicationDbContext : DbContext
{

    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Claim> Claims { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseNpgsql(Constants.connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transaction");

            entity.Property(e => e.Acqreferenceno)
                .HasMaxLength(50)
                .HasColumnName("acqreferenceno");
            entity.Property(e => e.Acqrrn)
                .HasMaxLength(300)
                .HasColumnName("acqrrn");
            entity.Property(e => e.Acqstan)
                .HasMaxLength(38)
                .HasColumnName("acqstan");
            entity.Property(e => e.Acquirerfee).HasColumnName("acquirerfee");
            entity.Property(e => e.Acquirerfiid).HasColumnName("acquirerfiid");
            entity.Property(e => e.Approvalcode)
                .HasMaxLength(30)
                .HasColumnName("approvalcode");
            entity.Property(e => e.AtmAcquirer)
                .HasMaxLength(45)
                .HasColumnName("atm_acquirer");
            entity.Property(e => e.AtmLocation)
                .HasMaxLength(200)
                .HasColumnName("atm_location");
            entity.Property(e => e.Batchid).HasColumnName("batchid");
            entity.Property(e => e.Batchnumber)
                .HasMaxLength(14)
                .HasColumnName("batchnumber");
            entity.Property(e => e.Calculatedfeetobank).HasColumnName("calculatedfeetobank");
            entity.Property(e => e.Calculatedfeetovnp).HasColumnName("calculatedfeetovnp");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(22)
                .HasColumnName("cardnumber");
            entity.Property(e => e.Cardseq)
                .HasMaxLength(3)
                .HasColumnName("cardseq");
            entity.Property(e => e.Creditval).HasColumnName("creditval");
            entity.Property(e => e.Customeracct)
                .HasMaxLength(65)
                .HasColumnName("customeracct");
            entity.Property(e => e.Domestic)
                .HasMaxLength(1)
                .HasColumnName("domestic");
            entity.Property(e => e.Extrrn)
                .HasMaxLength(300)
                .HasColumnName("extrrn");
            entity.Property(e => e.Extstan)
                .HasMaxLength(14)
                .HasColumnName("extstan");
            entity.Property(e => e.Feprrn)
                .HasMaxLength(300)
                .HasColumnName("feprrn");
            entity.Property(e => e.Host)
                .HasMaxLength(38)
                .HasColumnName("host");
            entity.Property(e => e.Invoicenum)
                .HasMaxLength(50)
                .HasColumnName("invoicenum");
            entity.Property(e => e.Issuerfiid)
                .HasMaxLength(40)
                .HasColumnName("issuerfiid");
            entity.Property(e => e.Localtransactiondate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("localtransactiondate");
            entity.Property(e => e.Localtransactiontime)
                .HasMaxLength(24)
                .HasColumnName("localtransactiontime");
            entity.Property(e => e.Maskedpan)
                .HasMaxLength(22)
                .HasColumnName("maskedpan");
            entity.Property(e => e.Merchantid)
                .HasMaxLength(50)
                .HasColumnName("merchantid");
            entity.Property(e => e.Merchantname)
                .HasMaxLength(200)
                .HasColumnName("merchantname");
            entity.Property(e => e.Onlinesettlementdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("onlinesettlementdate");
            entity.Property(e => e.Originalamount).HasColumnName("originalamount");
            entity.Property(e => e.Origtype)
                .HasMaxLength(12)
                .HasColumnName("origtype");
            entity.Property(e => e.Origtypeold).HasColumnName("origtypeold");
            entity.Property(e => e.Phase)
                .HasMaxLength(38)
                .HasColumnName("phase");
            entity.Property(e => e.Phoneno)
                .HasMaxLength(22)
                .HasColumnName("phoneno");
            entity.Property(e => e.Processingcode)
                .HasMaxLength(100)
                .HasColumnName("processingcode");
            entity.Property(e => e.Rawdatarecipient)
                .HasMaxLength(20)
                .HasColumnName("rawdatarecipient");
            entity.Property(e => e.Reimbursementfee).HasColumnName("reimbursementfee");
            entity.Property(e => e.Requestmessagetype)
                .HasMaxLength(255)
                .HasColumnName("requestmessagetype");
            entity.Property(e => e.Responsecode)
                .HasMaxLength(100)
                .HasColumnName("responsecode");
            entity.Property(e => e.Responsedesc)
                .HasMaxLength(109)
                .HasColumnName("responsedesc");
            entity.Property(e => e.Revrequestid)
                .HasMaxLength(38)
                .HasColumnName("revrequestid");
            entity.Property(e => e.Settlementamount).HasColumnName("settlementamount");
            entity.Property(e => e.SettlementamtCurrencycode)
                .HasMaxLength(38)
                .HasColumnName("settlementamt_currencycode");
            entity.Property(e => e.Settlementmentserviceselected)
                .HasMaxLength(3)
                .HasColumnName("settlementmentserviceselected");
            entity.Property(e => e.Sign)
                .HasMaxLength(1)
                .HasColumnName("sign");
            entity.Property(e => e.Termclass)
                .HasMaxLength(4)
                .HasColumnName("termclass");
            entity.Property(e => e.Terminalid)
                .HasMaxLength(25)
                .HasColumnName("terminalid");
            entity.Property(e => e.Textmess)
                .HasMaxLength(1000)
                .HasColumnName("textmess");
            entity.Property(e => e.Toacct2)
                .HasMaxLength(300)
                .HasColumnName("toacct2");
            entity.Property(e => e.Tracenumber)
                .HasMaxLength(38)
                .HasColumnName("tracenumber");
            entity.Property(e => e.Tranclass)
                .HasMaxLength(3)
                .HasColumnName("tranclass");
            entity.Property(e => e.Transactionamount).HasColumnName("transactionamount");
            entity.Property(e => e.TransactionamtCurrencycode)
                .HasMaxLength(38)
                .HasColumnName("transactionamt_currencycode");
            entity.Property(e => e.Transactionfee).HasColumnName("transactionfee");
            entity.Property(e => e.Transactionfeeold).HasColumnName("transactionfeeold");
            entity.Property(e => e.Transactiontype)
                .HasMaxLength(255)
                .HasColumnName("transactiontype");
            entity.Property(e => e.Transid)
                .HasMaxLength(38)
                .HasColumnName("transid");
            entity.Property(e => e.Transimportdate).HasColumnName("transimportdate");
            entity.Property(e => e.Transmissiondate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transmissiondate");
            entity.Property(e => e.Transmissiontime)
                .HasMaxLength(10)
                .HasColumnName("transmissiontime");
            entity.Property(e => e.Userdata)
                .HasMaxLength(200)
                .HasColumnName("userdata");
            entity.Property(e => e.Vnpsettdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("vnpsettdate");
            entity.Property(e => e.Vssprocessingdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("vssprocessingdate");
        });

        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.Idrsid).HasName("claims_pkey");

            entity.ToTable("claim");

            entity.Property(e => e.Idrsid)
                .HasColumnType("character varying")
                .HasColumnName("idrsid");
            entity.Property(e => e.Acqrrn)
                .HasColumnType("character varying")
                .HasColumnName("acqrrn");
            entity.Property(e => e.Amount)
                .HasPrecision(22)
                .HasColumnName("amount");
            entity.Property(e => e.Arn)
                .HasColumnType("character varying")
                .HasColumnName("arn");
            entity.Property(e => e.Dateoftransaction).HasColumnName("dateoftransaction");
            entity.Property(e => e.Disputeticketid)
                .HasColumnType("character varying")
                .HasColumnName("disputeticketid");
            entity.Property(e => e.Errorreason)
                .HasColumnType("character varying")
                .HasColumnName("errorreason");
            entity.Property(e => e.Requestid)
                .HasColumnType("character varying")
                .HasColumnName("requestid");
            entity.Property(e => e.Stan)
                .HasColumnType("character varying")
                .HasColumnName("stan");
            entity.Property(e => e.Status)
                .HasMaxLength(5)
                .HasColumnName("status");
            entity.Property(e => e.Transactionamount)
                .HasPrecision(22)
                .HasColumnName("transactionamount");
            entity.Property(e => e.Typecode)
                .HasColumnType("character varying")
                .HasColumnName("typecode");
            entity.Property(e => e.Processoridtransactionid)
               .HasColumnType("character varying")
               .HasColumnName("Processoridtransactionid");
            entity.Property(e => e.Disputetype)
                .HasColumnType("character varying")
                .HasColumnName("Disputetype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
