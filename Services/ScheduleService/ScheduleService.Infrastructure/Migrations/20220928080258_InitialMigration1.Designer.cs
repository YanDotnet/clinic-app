// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScheduleService.Infrastructure.Persistence;

#nullable disable

namespace ScheduleService.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220928080258_InitialMigration1")]
    partial class InitialMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ScheduleService.Domain.Days.Day", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("ScheduleService.Domain.Registrations.Registration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DayId")
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<string>("RegisteredUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("ScheduleService.Domain.Schedules.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleService.Domain.Days.Day", b =>
                {
                    b.HasOne("ScheduleService.Domain.Schedules.Schedule", null)
                        .WithMany("Days")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ScheduleService.Domain.ValueObjects.TimeRange", "AvailableTime", b1 =>
                        {
                            b1.Property<string>("DayId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("End")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("DayId");

                            b1.ToTable("Days");

                            b1.WithOwner()
                                .HasForeignKey("DayId");
                        });

                    b.Navigation("AvailableTime")
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleService.Domain.Registrations.Registration", b =>
                {
                    b.HasOne("ScheduleService.Domain.Days.Day", null)
                        .WithMany("Registrations")
                        .HasForeignKey("DayId");

                    b.OwnsOne("ScheduleService.Domain.ValueObjects.TimeRange", "Time", b1 =>
                        {
                            b1.Property<string>("RegistrationId")
                                .HasColumnType("text");

                            b1.Property<DateTime>("End")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("RegistrationId");

                            b1.ToTable("Registrations");

                            b1.WithOwner()
                                .HasForeignKey("RegistrationId");
                        });

                    b.Navigation("Time")
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleService.Domain.Days.Day", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("ScheduleService.Domain.Schedules.Schedule", b =>
                {
                    b.Navigation("Days");
                });
#pragma warning restore 612, 618
        }
    }
}
