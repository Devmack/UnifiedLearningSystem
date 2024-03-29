﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnifiedLearningSystem.Infrastructure.Persistence;

#nullable disable

namespace UnifiedLearningSystem.Infrastructure.Migrations
{
    [DbContext(typeof(UnifiedLearningSystemContext))]
    [Migration("20220512071115_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UnifiedLearningSystem.Domain.Entities.LearningLesson", b =>
                {
                    b.Property<Guid>("AggregateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AggregateID");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("UnifiedLearningSystem.Domain.Entities.LearningTask", b =>
                {
                    b.Property<Guid>("AggregateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LearningLessonAggregateID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AggregateID");

                    b.HasIndex("LearningLessonAggregateID");

                    b.ToTable("LearningTasks");
                });

            modelBuilder.Entity("UnifiedLearningSystem.Domain.Entities.LearningLesson", b =>
                {
                    b.OwnsOne("UnifiedLearningSystem.Domain.ValueObjects.Lesson.LessonTitle", "Title", b1 =>
                        {
                            b1.Property<Guid>("LearningLessonAggregateID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LearningLessonAggregateID");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LearningLessonAggregateID");
                        });

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("UnifiedLearningSystem.Domain.Entities.LearningTask", b =>
                {
                    b.HasOne("UnifiedLearningSystem.Domain.Entities.LearningLesson", null)
                        .WithMany("Tasks")
                        .HasForeignKey("LearningLessonAggregateID");

                    b.OwnsOne("UnifiedLearningSystem.Domain.ValueObjects.TaskDescription", "TaskDescription", b1 =>
                        {
                            b1.Property<Guid>("LearningTaskAggregateID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LearningTaskAggregateID");

                            b1.ToTable("LearningTasks");

                            b1.WithOwner()
                                .HasForeignKey("LearningTaskAggregateID");
                        });

                    b.OwnsOne("UnifiedLearningSystem.Domain.ValueObjects.TaskTitle", "TaskTitle", b1 =>
                        {
                            b1.Property<Guid>("LearningTaskAggregateID")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("LearningTaskAggregateID");

                            b1.ToTable("LearningTasks");

                            b1.WithOwner()
                                .HasForeignKey("LearningTaskAggregateID");
                        });

                    b.Navigation("TaskDescription")
                        .IsRequired();

                    b.Navigation("TaskTitle")
                        .IsRequired();
                });

            modelBuilder.Entity("UnifiedLearningSystem.Domain.Entities.LearningLesson", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
