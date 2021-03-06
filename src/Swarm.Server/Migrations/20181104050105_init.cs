﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swarm.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Group = table.Column<string>(maxLength: 120, nullable: true),
                    ConnectionId = table.Column<string>(maxLength: 50, nullable: false),
                    Ip = table.Column<string>(maxLength: 50, nullable: false),
                    Os = table.Column<string>(maxLength: 50, nullable: false),
                    CoreCount = table.Column<int>(nullable: false),
                    Memory = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsConnected = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    LastModificationTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Trigger = table.Column<int>(nullable: false),
                    Performer = table.Column<int>(nullable: false),
                    Executor = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    NodeId = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Group = table.Column<string>(maxLength: 120, nullable: false),
                    Load = table.Column<int>(nullable: false),
                    Sharding = table.Column<int>(nullable: false),
                    ShardingParameters = table.Column<string>(maxLength: 500, nullable: true),
                    AllowConcurrent = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Owner = table.Column<string>(maxLength: 120, nullable: true),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    LastModificationTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Value = table.Column<string>(maxLength: 250, nullable: true),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<string>(maxLength: 32, nullable: true),
                    TraceId = table.Column<string>(maxLength: 32, nullable: true),
                    State = table.Column<int>(nullable: false),
                    Client = table.Column<string>(maxLength: 120, nullable: true),
                    Msg = table.Column<string>(maxLength: 500, nullable: true),
                    Sharding = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    LastModificationTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<string>(maxLength: 32, nullable: true),
                    TraceId = table.Column<string>(maxLength: 32, nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Node",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectionString = table.Column<string>(maxLength: 250, nullable: false),
                    Provider = table.Column<string>(maxLength: 250, nullable: false),
                    SchedName = table.Column<string>(maxLength: 250, nullable: false),
                    TriggerTimes = table.Column<long>(nullable: false),
                    NodeId = table.Column<string>(maxLength: 32, nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    LastModificationTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Node", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ConnectionId",
                table: "Client",
                column: "ConnectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_CreationTime",
                table: "Client",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Name_Group",
                table: "Client",
                columns: new[] { "Name", "Group" },
                unique: true,
                filter: "[Group] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CreationTime",
                table: "Job",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Group",
                table: "Job",
                column: "Group");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Name",
                table: "Job",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Owner",
                table: "Job",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Name_Group",
                table: "Job",
                columns: new[] { "Name", "Group" });

            migrationBuilder.CreateIndex(
                name: "IX_JobProperty_JobId",
                table: "JobProperty",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobProperty_JobId_Name",
                table: "JobProperty",
                columns: new[] { "JobId", "Name" },
                unique: true,
                filter: "[JobId] IS NOT NULL AND [Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobState_CreationTime",
                table: "JobState",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_JobState_JobId",
                table: "JobState",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobState_JobId_TraceId",
                table: "JobState",
                columns: new[] { "JobId", "TraceId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobState_Sharding_TraceId_Client",
                table: "JobState",
                columns: new[] { "Sharding", "TraceId", "Client" },
                unique: true,
                filter: "[TraceId] IS NOT NULL AND [Client] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobState_Sharding_JobId_TraceId_Client",
                table: "JobState",
                columns: new[] { "Sharding", "JobId", "TraceId", "Client" },
                unique: true,
                filter: "[JobId] IS NOT NULL AND [TraceId] IS NOT NULL AND [Client] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CreationTime",
                table: "Log",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Log_JobId",
                table: "Log",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_JobId_TraceId",
                table: "Log",
                columns: new[] { "JobId", "TraceId" });

            migrationBuilder.CreateIndex(
                name: "IX_Node_CreationTime",
                table: "Node",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Node_NodeId",
                table: "Node",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Node_SchedName",
                table: "Node",
                column: "SchedName");

            migrationBuilder.CreateIndex(
                name: "IX_Node_SchedName_NodeId",
                table: "Node",
                columns: new[] { "SchedName", "NodeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "JobProperty");

            migrationBuilder.DropTable(
                name: "JobState");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Node");
        }
    }
}
