using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcore02.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrganizersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizerProfiles_Organizers_OrganizerId",
                table: "OrganizerProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.RenameTable(
                name: "Organizers",
                newName: "EventOrganizers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventOrganizers",
                table: "EventOrganizers",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventOrganizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "EventOrganizers",
                principalColumn: "OrganizerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizerProfiles_EventOrganizers_OrganizerId",
                table: "OrganizerProfiles",
                column: "OrganizerId",
                principalTable: "EventOrganizers",
                principalColumn: "OrganizerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventOrganizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizerProfiles_EventOrganizers_OrganizerId",
                table: "OrganizerProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventOrganizers",
                table: "EventOrganizers");

            migrationBuilder.RenameTable(
                name: "EventOrganizers",
                newName: "Organizers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "OrganizerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizerProfiles_Organizers_OrganizerId",
                table: "OrganizerProfiles",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "OrganizerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
