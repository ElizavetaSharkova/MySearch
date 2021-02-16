﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySearch.DbProviders;
using MySearch.Interfaces;
using MySearch.Models;

namespace MySearch.Migrations
{
    [DbContext(typeof(SearchContext))]
    [Migration("20190910151802_addType")]
    partial class addType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MySearch.Models.RequestHeader", b =>
                {
                    b.Property<int>("RequestHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HeaderName");

                    b.Property<string>("HeaderValue");

                    b.Property<int?>("engineSearchEngineId");

                    b.HasKey("RequestHeaderId");

                    b.HasIndex("engineSearchEngineId");

                    b.ToTable("RequestHeaders");
                });

            modelBuilder.Entity("MySearch.Models.RequestsParameter", b =>
                {
                    b.Property<int>("RequestsParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParametrName");

                    b.Property<string>("ParametrValue");

                    b.Property<int?>("engineSearchEngineId");

                    b.HasKey("RequestsParameterId");

                    b.HasIndex("engineSearchEngineId");

                    b.ToTable("RequestsParameters");
                });

            modelBuilder.Entity("MySearch.Models.ResponseType", b =>
                {
                    b.Property<int>("ResponseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateElement");

                    b.Property<string>("DescriptionElement");

                    b.Property<string>("RootElement");

                    b.Property<string>("TitleElement");

                    b.Property<string>("Type");

                    b.Property<string>("UrlElement");

                    b.HasKey("ResponseTypeId");

                    b.ToTable("ResponseTypes");
                });

            modelBuilder.Entity("MySearch.Models.SearchEngine", b =>
                {
                    b.Property<int>("SearchEngineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BaseUrl");

                    b.Property<string>("Name");

                    b.Property<int?>("TypeResponseTypeId");

                    b.HasKey("SearchEngineId");

                    b.HasIndex("TypeResponseTypeId");

                    b.ToTable("SearchEngines");
                });

            modelBuilder.Entity("MySearch.Models.SearchRequest", b =>
                {
                    b.Property<int>("SearchRequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("SearchDate");

                    b.Property<string>("SearchString");

                    b.HasKey("SearchRequestId");

                    b.ToTable("SearchRequests");
                });

            modelBuilder.Entity("MySearch.Models.SearchResult", b =>
                {
                    b.Property<int>("SearchResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("IndexedTime");

                    b.Property<int?>("RequestSearchRequestId");

                    b.Property<int?>("SearchEngineId");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("SearchResultId");

                    b.HasIndex("RequestSearchRequestId");

                    b.HasIndex("SearchEngineId");

                    b.ToTable("SearchResults");
                });

            modelBuilder.Entity("MySearch.Models.RequestHeader", b =>
                {
                    b.HasOne("MySearch.Models.SearchEngine", "engine")
                        .WithMany("Headers")
                        .HasForeignKey("engineSearchEngineId");
                });

            modelBuilder.Entity("MySearch.Models.RequestsParameter", b =>
                {
                    b.HasOne("MySearch.Models.SearchEngine", "engine")
                        .WithMany("Parameters")
                        .HasForeignKey("engineSearchEngineId");
                });

            modelBuilder.Entity("MySearch.Models.SearchEngine", b =>
                {
                    b.HasOne("MySearch.Models.ResponseType", "Type")
                        .WithMany("Engines")
                        .HasForeignKey("TypeResponseTypeId");
                });

            modelBuilder.Entity("MySearch.Models.SearchResult", b =>
                {
                    b.HasOne("MySearch.Models.SearchRequest", "Request")
                        .WithMany("SearchResults")
                        .HasForeignKey("RequestSearchRequestId");

                    b.HasOne("MySearch.Models.SearchEngine", "SearchEngine")
                        .WithMany()
                        .HasForeignKey("SearchEngineId");
                });
#pragma warning restore 612, 618
        }
    }
}
