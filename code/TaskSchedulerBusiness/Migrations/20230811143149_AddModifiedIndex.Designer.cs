﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskSchedulerBusiness.Data;

#nullable disable

namespace TaskSchedulerBusiness.Migrations
{
    [DbContext(typeof(MonitorTaskSchedulerDbContext))]
    [Migration("20230811143149_AddModifiedIndex")]
    partial class AddModifiedIndex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskSchedulerBusiness.Model.Task", b =>
                {
                    b.Property<string>("HostName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Days")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Delete_Task_If_Not_Rescheduled")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("End_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Idle_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Run_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logon_Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Months")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Next_Run_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power_Management")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repeat_Every")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repeat_Stop_If_Still_Running")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repeat_Until_Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repeat_Until_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Run_As_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scheduled_Task_State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_In")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stop_Task_If_Runs_X_Hours_and_X_Mins")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task_To_Run")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HostName", "TaskName");

                    b.HasIndex("Modified");

                    b.ToTable("Task", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
