﻿// <auto-generated />
using System;
using Feedler.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Feedler.Migrations
{
    [DbContext(typeof(FeedlerContext))]
    [Migration("20180403184747_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Feedler.Models.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Feedler.Models.CollectionFeed", b =>
                {
                    b.Property<Guid?>("CollectionId");

                    b.Property<string>("FeedId");

                    b.HasKey("CollectionId", "FeedId");

                    b.HasIndex("FeedId");

                    b.ToTable("CollectionFeed");
                });

            modelBuilder.Entity("Feedler.Models.Feed", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Feeds");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Feed");
                });

            modelBuilder.Entity("Feedler.Models.RSSFeed", b =>
                {
                    b.HasBaseType("Feedler.Models.Feed");

                    b.Property<string>("Uri");

                    b.ToTable("RSSFeed");

                    b.HasDiscriminator().HasValue("RSSFeed");
                });

            modelBuilder.Entity("Feedler.Models.CollectionFeed", b =>
                {
                    b.HasOne("Feedler.Models.Collection", "Collection")
                        .WithMany("CollectionFeeds")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Feedler.Models.Feed", "Feed")
                        .WithMany()
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
