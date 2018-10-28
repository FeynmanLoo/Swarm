﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swarm.Migrator.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SWARM_CLIENTS",
                columns: table => new
                {
                    NAME = table.Column<string>(maxLength: 120, nullable: false),
                    GROUP = table.Column<string>(maxLength: 120, nullable: true),
                    CONNECTION_ID = table.Column<string>(maxLength: 50, nullable: false),
                    IP = table.Column<string>(maxLength: 50, nullable: false),
                    CREATION_TIME = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWARM_CLIENTS", x => x.NAME);
                });

            migrationBuilder.CreateTable(
                name: "SWARM_JOB_PROPERTIES",
                columns: table => new
                {
                    JOB_ID = table.Column<string>(maxLength: 32, nullable: false),
                    NAME = table.Column<string>(maxLength: 32, nullable: false),
                    VALUE = table.Column<string>(maxLength: 250, nullable: true),
                    CREATION_TIME = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWARM_JOB_PROPERTIES", x => new { x.JOB_ID, x.NAME });
                });

            migrationBuilder.CreateTable(
                name: "SWARM_JOB_STATE",
                columns: table => new
                {
                    JOB_ID = table.Column<string>(maxLength: 32, nullable: false),
                    TRACE_ID = table.Column<string>(maxLength: 32, nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CLIENT = table.Column<string>(maxLength: 120, nullable: false),
                    MSG = table.Column<string>(maxLength: 500, nullable: true),
                    CREATION_TIME = table.Column<DateTimeOffset>(nullable: false),
                    LAST_MODIFICATION_TIME = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWARM_JOB_STATE", x => new { x.JOB_ID, x.TRACE_ID, x.CLIENT });
                });

            migrationBuilder.CreateTable(
                name: "SWARM_JOBS",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 32, nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    TRIGGER = table.Column<int>(nullable: false),
                    PERFORMER = table.Column<int>(nullable: false),
                    EXECUTER = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(maxLength: 120, nullable: false),
                    GROUP = table.Column<string>(maxLength: 120, nullable: false),
                    LOAD = table.Column<int>(nullable: false),
                    SHARDING = table.Column<int>(nullable: false),
                    SHARDING_PARAMETERS = table.Column<string>(maxLength: 500, nullable: true),
                    DESCRIPTION = table.Column<string>(maxLength: 500, nullable: true),
                    RETRY_COUNT = table.Column<int>(nullable: false),
                    OWNER = table.Column<string>(maxLength: 120, nullable: true),
                    CONCURRENT_EXECUTION_DISALLOWED = table.Column<bool>(nullable: false),
                    CREATION_TIME = table.Column<DateTimeOffset>(nullable: false),
                    LAST_MODIFICATION_TIME = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWARM_JOBS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SWARM_LOGS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JOB_ID = table.Column<string>(maxLength: 32, nullable: true),
                    TRACE_ID = table.Column<string>(maxLength: 32, nullable: true),
                    MSG = table.Column<string>(nullable: true),
                    CREATION_TIME = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWARM_LOGS", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_CLIENTS_NAME_GROUP",
                table: "SWARM_CLIENTS",
                columns: new[] { "NAME", "GROUP" },
                unique: true,
                filter: "[GROUP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOB_PROPERTIES_JOB_ID",
                table: "SWARM_JOB_PROPERTIES",
                column: "JOB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOB_STATE_JOB_ID",
                table: "SWARM_JOB_STATE",
                column: "JOB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOB_STATE_JOB_ID_TRACE_ID",
                table: "SWARM_JOB_STATE",
                columns: new[] { "JOB_ID", "TRACE_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOB_STATE_TRACE_ID_CLIENT",
                table: "SWARM_JOB_STATE",
                columns: new[] { "TRACE_ID", "CLIENT" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOBS_GROUP",
                table: "SWARM_JOBS",
                column: "GROUP");

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOBS_NAME",
                table: "SWARM_JOBS",
                column: "NAME");

            migrationBuilder.CreateIndex(
                name: "IX_SWARM_JOBS_OWNER",
                table: "SWARM_JOBS",
                column: "OWNER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SWARM_CLIENTS");

            migrationBuilder.DropTable(
                name: "SWARM_JOB_PROPERTIES");

            migrationBuilder.DropTable(
                name: "SWARM_JOB_STATE");

            migrationBuilder.DropTable(
                name: "SWARM_JOBS");

            migrationBuilder.DropTable(
                name: "SWARM_LOGS");
        }
    }
}
