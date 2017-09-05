﻿// <auto-generated />
using LegionTDServerReborn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace LegionTDServerReborn.Migrations
{
    [DbContext(typeof(LegionTdContext))]
    [Migration("20170905180141_AddedBugReports")]
    partial class AddedBugReports
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("LegionTDServerReborn.Models.Ability", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("CastRange");

                    b.Property<float>("Cooldown");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("GoldCost");

                    b.Property<int>("ManaCost");

                    b.HasKey("Name");

                    b.ToTable("Abilities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ability");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.BugReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Descriptions");

                    b.Property<bool>("Done");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("BugReports");
                });

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

            modelBuilder.Entity("LegionTDServerReborn.Models.FractionStatistic", b =>
                {
                    b.Property<string>("FractionName");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<int>("LostGames");

                    b.Property<float>("PickRate");

                    b.Property<int>("WonGames");

                    b.HasKey("FractionName", "TimeStamp");

                    b.ToTable("FractionStatistics");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<float>("Duration");

                    b.Property<bool>("IsTraining");

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

                    b.Property<int>("Builds");

                    b.Property<int>("EarnedGold");

                    b.Property<int>("EarnedTangos");

                    b.Property<int>("Experience");

                    b.Property<string>("FractionName");

                    b.Property<int>("Kills");

                    b.Property<int>("Leaks");

                    b.Property<int>("LostDuels");

                    b.Property<int>("RatingChange");

                    b.Property<int>("Sends");

                    b.Property<int>("Team");

                    b.Property<bool>("Won");

                    b.Property<int>("WonDuels");

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

            modelBuilder.Entity("LegionTDServerReborn.Models.Ranking", b =>
                {
                    b.Property<int>("Type");

                    b.Property<bool>("Ascending");

                    b.Property<long>("PlayerId");

                    b.Property<int>("Position");

                    b.HasKey("Type", "Ascending", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("Position");

                    b.ToTable("Rankings");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Unit", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("ArmorPhysical");

                    b.Property<float>("AttackDamageMax");

                    b.Property<float>("AttackDamageMin");

                    b.Property<float>("AttackRange");

                    b.Property<float>("AttackRate");

                    b.Property<float>("BountyGoldMax");

                    b.Property<float>("BountyGoldMin");

                    b.Property<int>("Experience");

                    b.Property<string>("FractionName");

                    b.Property<string>("LegionAttackType");

                    b.Property<string>("LegionDefendType");

                    b.Property<float>("MagicResistance");

                    b.Property<string>("ParentName");

                    b.Property<float>("StatusHealth");

                    b.Property<float>("StatusHealthRegen");

                    b.Property<float>("StatusMana");

                    b.Property<float>("StatusManaRegen");

                    b.Property<int>("Type");

                    b.HasKey("Name");

                    b.HasIndex("FractionName");

                    b.HasIndex("ParentName");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.UnitAbility", b =>
                {
                    b.Property<string>("UnitName");

                    b.Property<int>("Slot");

                    b.Property<string>("AbilityName");

                    b.HasKey("UnitName", "Slot");

                    b.HasIndex("AbilityName");

                    b.ToTable("UnitAbilities");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.SpawnAbility", b =>
                {
                    b.HasBaseType("LegionTDServerReborn.Models.Ability");

                    b.Property<string>("UnitName");

                    b.HasIndex("UnitName")
                        .IsUnique();

                    b.ToTable("SpawnAbility");

                    b.HasDiscriminator().HasValue("SpawnAbility");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Duel", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Match", "Match")
                        .WithMany("Duels")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.FractionStatistic", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Fraction", "Fraction")
                        .WithMany("Statistics")
                        .HasForeignKey("FractionName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.PlayerMatchData", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Fraction", "Fraction")
                        .WithMany("PlayedMatches")
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

            modelBuilder.Entity("LegionTDServerReborn.Models.Ranking", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Player", "Player")
                        .WithMany("Rankings")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.Unit", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Fraction", "Fraction")
                        .WithMany("Units")
                        .HasForeignKey("FractionName");

                    b.HasOne("LegionTDServerReborn.Models.Unit", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentName");
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.UnitAbility", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Ability", "Ability")
                        .WithMany("Casters")
                        .HasForeignKey("AbilityName");

                    b.HasOne("LegionTDServerReborn.Models.Unit", "Unit")
                        .WithMany("Abilities")
                        .HasForeignKey("UnitName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LegionTDServerReborn.Models.SpawnAbility", b =>
                {
                    b.HasOne("LegionTDServerReborn.Models.Unit", "Unit")
                        .WithOne("SpawnAbility")
                        .HasForeignKey("LegionTDServerReborn.Models.SpawnAbility", "UnitName");
                });
#pragma warning restore 612, 618
        }
    }
}
