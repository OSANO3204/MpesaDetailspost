﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatsAppService.BLL.Data;

namespace WhatsAppService.BLL.Migrations
{
    [DbContext(typeof(WhatsAppServiceContext))]
    [Migration("20220702223215_initila13")]
    partial class initila13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WhatsAppService.Core.Models.MpesaTransaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderPaybill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("amount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("narration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("receiverMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("recieverFullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("mpesatransaction");
                });
#pragma warning restore 612, 618
        }
    }
}