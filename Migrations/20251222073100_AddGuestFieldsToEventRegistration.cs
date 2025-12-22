using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubActivitiesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddGuestFieldsToEventRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "event_registrations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "guest_email",
                table: "event_registrations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guest_name",
                table: "event_registrations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guest_phone",
                table: "event_registrations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations",
                columns: new[] { "event_id", "user_id" },
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistration_EventId_GuestEmail",
                table: "event_registrations",
                columns: new[] { "event_id", "guest_email" },
                unique: true,
                filter: "[guest_email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistration_EventId_GuestEmail",
                table: "event_registrations");

            migrationBuilder.DropColumn(
                name: "guest_email",
                table: "event_registrations");

            migrationBuilder.DropColumn(
                name: "guest_name",
                table: "event_registrations");

            migrationBuilder.DropColumn(
                name: "guest_phone",
                table: "event_registrations");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "event_registrations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations",
                columns: new[] { "event_id", "user_id" },
                unique: true);
        }
    }
}
