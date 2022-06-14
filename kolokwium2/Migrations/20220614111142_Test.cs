using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolokwium2.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTrack_Musician_MusicansIdMusician",
                table: "MusicianTrack");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTrack_Track_TracksIdTrack",
                table: "MusicianTrack");

            migrationBuilder.RenameColumn(
                name: "TracksIdTrack",
                table: "MusicianTrack",
                newName: "IdTrack");

            migrationBuilder.RenameColumn(
                name: "MusicansIdMusician",
                table: "MusicianTrack",
                newName: "IdMusician");

            migrationBuilder.RenameIndex(
                name: "IX_MusicianTrack_TracksIdTrack",
                table: "MusicianTrack",
                newName: "IX_MusicianTrack_IdTrack");

            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[,]
                {
                    { 1, "EMI" },
                    { 2, "Sony" },
                    { 3, "Warner" }
                });

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "Janek" },
                    { 2, "Stachu", "Jones", null },
                    { 3, "Jan", "Paweł", "Lolek" }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 2, 2f, null, "Track2" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[,]
                {
                    { 1, "Album1", 1, new DateTime(2022, 6, 14, 13, 11, 41, 774, DateTimeKind.Local).AddTicks(5210) },
                    { 2, "Album2", 2, new DateTime(2022, 6, 14, 13, 11, 41, 774, DateTimeKind.Local).AddTicks(5260) },
                    { 3, "Album3", 3, new DateTime(2022, 6, 14, 13, 11, 41, 774, DateTimeKind.Local).AddTicks(5270) }
                });

            migrationBuilder.InsertData(
                table: "MusicianTrack",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 1.5f, 1, "Track1" });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 3, 3f, 2, "Track3" });

            migrationBuilder.InsertData(
                table: "MusicianTrack",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTrack_Musician_IdMusician",
                table: "MusicianTrack",
                column: "IdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTrack_Track_IdTrack",
                table: "MusicianTrack",
                column: "IdTrack",
                principalTable: "Track",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTrack_Musician_IdMusician",
                table: "MusicianTrack");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTrack_Track_IdTrack",
                table: "MusicianTrack");

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MusicianTrack",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MusicianTrack",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MusicLabel",
                keyColumn: "IdMusicLabel",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "IdTrack",
                table: "MusicianTrack",
                newName: "TracksIdTrack");

            migrationBuilder.RenameColumn(
                name: "IdMusician",
                table: "MusicianTrack",
                newName: "MusicansIdMusician");

            migrationBuilder.RenameIndex(
                name: "IX_MusicianTrack_IdTrack",
                table: "MusicianTrack",
                newName: "IX_MusicianTrack_TracksIdTrack");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTrack_Musician_MusicansIdMusician",
                table: "MusicianTrack",
                column: "MusicansIdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTrack_Track_TracksIdTrack",
                table: "MusicianTrack",
                column: "TracksIdTrack",
                principalTable: "Track",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
