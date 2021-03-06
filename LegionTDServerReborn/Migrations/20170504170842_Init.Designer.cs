﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LegionTDServerReborn.Models;

namespace LegionTDServerReborn.Migrations
{
    [DbContext(typeof(LegionTdContext))]
    [Migration("20170504170842_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("LegionTDServerReborn.Models.Duel", b =>
                {
                    b.Property<int>("MatchId");

                    b.Property<int>("Order");

                    b.Property<float>("TimeStamp");

                    b.Property<int>("Winner");

                    b.HasKey("MatchId", "Order");

                    b.ToTable("Duels");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Fraction", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Fractions");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<float>("Duration");

                    b.Property<int>("LastWave");

                    b.Property<int>("Winner");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Player", b =>
                {
                    b.Property<long>("SteamId");

                    b.HasKey("SteamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.PlayerMatchData", b =>
                {
                    b.Property<int>("MatchId");

                    b.Property<long>("PlayerId");

                    b.Property<bool>("Abandoned");

                    b.Property<int>("EarnedGold");

                    b.Property<int>("EarnedTangos");

                    b.Property<string>("FractionName");

                    b.Property<int>("RatingChange");

                    b.Property<int>("Team");

                    b.HasKey("MatchId", "PlayerId");

                    b.HasIndex("FractionName");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerMatchDatas");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.PlayerUnitRelation", b =>
                {
                    b.Property<int>("MatchId");

                    b.Property<long>("PlayerId");

                    b.Property<string>("UnitName");

                    b.Property<int>("Build");

                    b.Property<int>("Killed");

                    b.Property<int>("Leaked");

                    b.Property<int>("Send");

                    b.HasKey("MatchId", "PlayerId", "UnitName");

                    b.HasIndex("UnitName");

                    b.ToTable("PlayerUnitRelations");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Unit", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Experience");

                    b.Property<string>("FractionName");

                    b.Property<int>("Type");

                    b.HasKey("Name");

                    b.HasIndex("FractionName");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Duel", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Match", "Match")
                        .WithMany("Duels")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.PlayerMatchData", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Fraction", "Fraction")
                        .WithMany()
                        .HasForeignKey("FractionName");

                    b.HasOne("LegionTDServerReborn.Models.Match", "Match")
                        .WithMany("PlayerDatas")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LegionTDServerReborn.Models.Player", "Player")
                        .WithMany("MatchDatas")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.PlayerUnitRelation", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LegionTDServerReborn.Models.PlayerMatchData", "PlayerMatch")
                        .WithMany("UnitDatas")
                        .HasForeignKey("MatchId", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Unit", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Fraction", "Fraction")
                        .WithMany()
                        .HasForeignKey("FractionName");
                });
        }
    }
}
