using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubActivitiesSystem.Migrations
{
    public partial class MakeEventRegistrationUserNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 刪除舊的唯一索引（event_id, user_id）
            migrationBuilder.DropIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations");

            // 將 user_id 改為可為 null
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "event_registrations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // 重新建立帶 filter 的唯一索引，只對 user_id IS NOT NULL 生效
            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations",
                columns: new[] { "event_id", "user_id" },
                unique: true,
                filter: "[user_id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 刪除帶 filter 的索引
            migrationBuilder.DropIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations");

            // 將 user_id 恢復為 non-nullable（注意：回退若資料含 null 會失敗）
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "event_registrations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            // 恢復原本的唯一索引
            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_event_id_user_id",
                table: "event_registrations",
                columns: new[] { "event_id", "user_id" },
                unique: true);
        }
    }
}