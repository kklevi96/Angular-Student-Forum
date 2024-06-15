using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCUTY_ASP_2022231.Migrations
{
    public partial class commentLikeInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "162a3e99-8b3d-458b-bb31-f06a165a51cf");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "57b014a3-d8a3-474b-bd4d-2f04697f2609");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "9c14727d-820a-41b4-bdb6-7b368dfbcafa");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "a460a850-0918-4c0e-a080-7f5a2e43e024");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "b34ec95f-207d-4161-97ff-27213523c2b1");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "677d57e4-0b2e-4a2d-b8f0-f5345b787740");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "e9257da2-3e21-4075-a40c-c1f3cabd5cd4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e09b088f-9642-467a-b726-6ec6f4581eb4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e69c9cd7-1379-4616-b7b3-42a4a6b256be");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "0aedbfd7-6016-464c-9ecf-7e1c4b4092da");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "15e19689-f9fc-4490-ac21-7aedbf63041b");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "9ed94baa-be2f-4610-b72a-3937538c95d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bc9af58-38da-4f65-a71a-d5f43a27db15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b5811d4-0454-4e36-8afc-d8c35f30df93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf3a39b0-5d34-4ec5-bc70-064201401e4e");

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_AspNetUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c", 0, "2c334318-5062-463b-b6b7-5ae5f26f5272", null, false, "Mariann", "Kiss", false, null, null, "MARIANNKISS@UNI-OBUDA.HU", "AQAAAAEAACcQAAAAEJ7XIVO7sQSislS6WbuhEspvbJNjCmUtxFegJqBzCwNgCwHfoEBZ5Qma8m//vieZkQ==", null, false, "ee220ca4-ebbb-4b1a-bb73-79a85e6c26ee", false, "mariannkiss@uni-obuda.hu" },
                    { "5c5ea378-c525-4000-9b65-b3273b3832fd", 0, "815e6c08-e89d-477b-bbb4-14d062afd434", null, false, "Ferenc", "Kovács", false, null, null, "ISTVANTAKACS@GMAIL.COM", "AQAAAAEAACcQAAAAEGcoIRfma2ORvK68n0SiIHx1nupzE9G2mDYrexI+/7Exr2EbBkTx8j3Gu6BMKoXMYw==", null, false, "67ca1e81-6697-43b5-a3ca-a7e68036a38a", false, "istvantakacs@gmail.com" },
                    { "858b4134-610f-478a-a51a-fc92df8285b4", 0, "e7c12940-aff3-494c-8d88-b8386b270850", null, false, "Béla", "Kovács", false, null, null, "BELA.KOVACS@GMAIL.COM", "AQAAAAEAACcQAAAAEOeE9McqfdscPmnJQ+R42QEPZGavVv/frkYTpXZM9+j8BozLCPdmIsuwGw5Bhq4rNQ==", null, false, "872d0d23-2c6c-443f-9be7-f75425f9a49c", false, "bela.kovacs@gmail.com" },
                    { "c11d804b-64e8-4a5c-8cd7-095fddbde1d1", 0, "e3e9588d-a8ce-4b69-817a-bf536437ab2d", null, false, "Júlia", "Horváth", false, null, null, "JULIAHORVATH@YAHOO.COM", "AQAAAAEAACcQAAAAELx7yP4tw6836EucqYtItDr6E8zEGHG6w1l+zelwGty8R7qA3bblZv0v5KqLhu3ySg==", null, false, "931db490-fcb8-41ec-9a7b-c7ac71debb01", false, "juliahorvath@yahoo.com" },
                    { "d7691624-73f7-4872-b5a9-f8a2d0a0610f", 0, "de134f26-d238-4581-b895-8290352d2207", null, false, "József", "Kiss", false, null, null, "JOZSEFKISS@GMAIL.COM", "AQAAAAEAACcQAAAAELIQRB11xiNd7xFiNc8lycC2nQcnxy0w3SqwapKKQQcx0iWreJrTYtR6lExyHHoZ6Q==", null, false, "2a2c8fc7-d214-4fb1-a746-03ebab359367", false, "jozsefkiss@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "EditCount", "LastEdited", "SiteUserId", "SubjectCode", "Timestamp" },
                values: new object[,]
                {
                    { "a9e4e4fb-4a77-45fa-9d55-8e272314902a", "Kedves mindenki! Ugye tudják, hogy a zárthelyi dolgozatot kiválthatják beadandó dolgozat megírásával?\nDe akkor legfeljebb hármast tudok majd adni.", 0, null, "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c", "KGK666BUKO", new DateTime(2022, 10, 29, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "ac8e029a-615e-4842-9697-c37c17e7c7b8", "Sziasztok! Tudtok valamit, hogy mi lesz a jövő heti zh-ban?", 0, null, "858b4134-610f-478a-a51a-fc92df8285b4", "KGK666BUKO", new DateTime(2022, 10, 23, 11, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "b21b472e-5884-4bca-ab91-aa24f282b704", "Jövő héten lesz óra?", 0, null, "c11d804b-64e8-4a5c-8cd7-095fddbde1d1", "NIXBE1PBNE", new DateTime(2022, 10, 28, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "b4e8f9a3-68fa-4986-8736-822d21f4d924", "Határérték-számításban tud valaki segíteni?", 0, null, "5c5ea378-c525-4000-9b65-b3273b3832fd", "NIXMN1HBNE", new DateTime(2022, 9, 7, 7, 45, 28, 0, DateTimeKind.Unspecified) },
                    { "f762a131-9c21-4a2c-95cd-2f0699a734b7", "Hányat lehet hiányozni sztf laboron?", 0, null, "d7691624-73f7-4872-b5a9-f8a2d0a0610f", "NIXMN1HBNE", new DateTime(2022, 10, 15, 11, 11, 22, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "EditCount", "LastEdited", "PostId", "SiteUserId", "Timestamp" },
                values: new object[,]
                {
                    { "00e26a4e-d12b-4a76-a027-372c2ffa7fc2", "Ne szívass, akkor meg mit problémáztál szeptemberben? Én mehetek pótzh-ra...", 0, null, "b4e8f9a3-68fa-4986-8736-822d21f4d924", "c11d804b-64e8-4a5c-8cd7-095fddbde1d1", new DateTime(2022, 10, 22, 11, 5, 33, 0, DateTimeKind.Unspecified) },
                    { "25fd21d5-c860-4853-82b7-71add3f1a51f", "Nekem se megy, meg szerintem senkinek se, mindenkinek bukó lesz a zh:D", 0, null, "b4e8f9a3-68fa-4986-8736-822d21f4d924", "c11d804b-64e8-4a5c-8cd7-095fddbde1d1", new DateTime(2022, 9, 10, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "67bf5686-4ddc-413c-b0cb-ffea5ec36d16", "Mondjuk nem is volt olyan rossz, 69% lett a zh-m^^", 0, null, "b4e8f9a3-68fa-4986-8736-822d21f4d924", "5c5ea378-c525-4000-9b65-b3273b3832fd", new DateTime(2022, 10, 20, 21, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "ceabd46c-5b76-4a71-acd9-f868c67aa90e", "Ne felejtse el, hogy én is látom, ne tegezzen mindenkit csak úgy.\nEgyébként tesztes kérdések lesznek, Marshall-keresztet mindenképp nézzék át!", 0, null, "ac8e029a-615e-4842-9697-c37c17e7c7b8", "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c", new DateTime(2022, 10, 28, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "f203a975-67ba-4a17-97b0-ebb783dde8ce", "Figyelj oda, hogy ez nem az sztf topik! Egyébként matekról meg progról is négy hiányzásnál letiltanak.", 0, null, "f762a131-9c21-4a2c-95cd-2f0699a734b7", "858b4134-610f-478a-a51a-fc92df8285b4", new DateTime(2022, 10, 29, 8, 13, 28, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentId",
                table: "CommentLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_SiteUserId",
                table: "CommentLikes",
                column: "SiteUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "00e26a4e-d12b-4a76-a027-372c2ffa7fc2");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "25fd21d5-c860-4853-82b7-71add3f1a51f");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "67bf5686-4ddc-413c-b0cb-ffea5ec36d16");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "ceabd46c-5b76-4a71-acd9-f868c67aa90e");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: "f203a975-67ba-4a17-97b0-ebb783dde8ce");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "a9e4e4fb-4a77-45fa-9d55-8e272314902a");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "b21b472e-5884-4bca-ab91-aa24f282b704");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c11d804b-64e8-4a5c-8cd7-095fddbde1d1");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "ac8e029a-615e-4842-9697-c37c17e7c7b8");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "b4e8f9a3-68fa-4986-8736-822d21f4d924");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: "f762a131-9c21-4a2c-95cd-2f0699a734b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c5ea378-c525-4000-9b65-b3273b3832fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "858b4134-610f-478a-a51a-fc92df8285b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7691624-73f7-4872-b5a9-f8a2d0a0610f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0bc9af58-38da-4f65-a71a-d5f43a27db15", 0, "bde6adb6-1962-48f4-9c0f-f13d806bfe21", null, false, "József", "Kiss", false, null, null, "JOZSEFKISS@GMAIL.COM", "AQAAAAEAACcQAAAAEIBBlCtTLgkwzyT71Q1Mcp6jGlvmTC6U6bMYEKr4EMfzjH6gaf9SMrobU0Qvjk9IKA==", null, false, "87af08bb-cf08-4af6-b4e6-aa0c1cf62b3b", false, "jozsefkiss@gmail.com" },
                    { "2b5811d4-0454-4e36-8afc-d8c35f30df93", 0, "ce290124-1fc1-4a03-9129-28d04fd72f82", null, false, "Ferenc", "Kovács", false, null, null, "ISTVANTAKACS@GMAIL.COM", "AQAAAAEAACcQAAAAED25xYCraNdhemu7Gm2Ya8ZLSZ5FwAAacUOEERwndTKQcNQDFO5NiChQ6mtMcXdVjQ==", null, false, "69d9792d-be85-4408-ae1e-211a1f2504e7", false, "istvantakacs@gmail.com" },
                    { "cf3a39b0-5d34-4ec5-bc70-064201401e4e", 0, "db4d8487-356f-439c-b278-18aa25a4945a", null, false, "Béla", "Kovács", false, null, null, "BELA.KOVACS@GMAIL.COM", "AQAAAAEAACcQAAAAEAFnKS5x3j3Uf5h30/nZx2/8ey5ndrbKq+4esJPvOqB6Wdki8oElNF72qidbZMrQCg==", null, false, "52d30c35-3d1d-44bb-80c4-3875704f2869", false, "bela.kovacs@gmail.com" },
                    { "e09b088f-9642-467a-b726-6ec6f4581eb4", 0, "17e304f0-b027-4a5e-aa25-cfd588ff4d51", null, false, "Júlia", "Horváth", false, null, null, "JULIAHORVATH@YAHOO.COM", "AQAAAAEAACcQAAAAEG9g8FoSL7VlSfSSQ21+czPtIyRy/vL7Rk0q6q+6QHCatRprg8Ht9BsyOvoadhST8A==", null, false, "1174f3c0-b602-46af-a9f0-c9f2aa32fd2c", false, "juliahorvath@yahoo.com" },
                    { "e69c9cd7-1379-4616-b7b3-42a4a6b256be", 0, "f64bbaa4-a8d0-424f-9168-597d9a80637f", null, false, "Mariann", "Kiss", false, null, null, "MARIANNKISS@UNI-OBUDA.HU", "AQAAAAEAACcQAAAAEJhQi5m4F2YEr+h2FcK9lrWt11LmpEPv/MdGKsyuYgIoeRp8W/yDOI7seUkc9zcajw==", null, false, "03c9505d-b3ca-412d-bd1c-33c88f69f7fc", false, "mariannkiss@uni-obuda.hu" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "EditCount", "LastEdited", "SiteUserId", "SubjectCode", "Timestamp" },
                values: new object[,]
                {
                    { "0aedbfd7-6016-464c-9ecf-7e1c4b4092da", "Határérték-számításban tud valaki segíteni?", 0, null, "2b5811d4-0454-4e36-8afc-d8c35f30df93", "NIXMN1HBNE", new DateTime(2022, 9, 7, 7, 45, 28, 0, DateTimeKind.Unspecified) },
                    { "15e19689-f9fc-4490-ac21-7aedbf63041b", "Sziasztok! Tudtok valamit, hogy mi lesz a jövő heti zh-ban?", 0, null, "cf3a39b0-5d34-4ec5-bc70-064201401e4e", "KGK666BUKO", new DateTime(2022, 10, 23, 11, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "677d57e4-0b2e-4a2d-b8f0-f5345b787740", "Kedves mindenki! Ugye tudják, hogy a zárthelyi dolgozatot kiválthatják beadandó dolgozat megírásával?\nDe akkor legfeljebb hármast tudok majd adni.", 0, null, "e69c9cd7-1379-4616-b7b3-42a4a6b256be", "KGK666BUKO", new DateTime(2022, 10, 29, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "9ed94baa-be2f-4610-b72a-3937538c95d1", "Hányat lehet hiányozni sztf laboron?", 0, null, "0bc9af58-38da-4f65-a71a-d5f43a27db15", "NIXMN1HBNE", new DateTime(2022, 10, 15, 11, 11, 22, 0, DateTimeKind.Unspecified) },
                    { "e9257da2-3e21-4075-a40c-c1f3cabd5cd4", "Jövő héten lesz óra?", 0, null, "e09b088f-9642-467a-b726-6ec6f4581eb4", "NIXBE1PBNE", new DateTime(2022, 10, 28, 8, 15, 28, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "EditCount", "LastEdited", "PostId", "SiteUserId", "Timestamp" },
                values: new object[,]
                {
                    { "162a3e99-8b3d-458b-bb31-f06a165a51cf", "Nekem se megy, meg szerintem senkinek se, mindenkinek bukó lesz a zh:D", 0, null, "0aedbfd7-6016-464c-9ecf-7e1c4b4092da", "e09b088f-9642-467a-b726-6ec6f4581eb4", new DateTime(2022, 9, 10, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "57b014a3-d8a3-474b-bd4d-2f04697f2609", "Ne szívass, akkor meg mit problémáztál szeptemberben? Én mehetek pótzh-ra...", 0, null, "0aedbfd7-6016-464c-9ecf-7e1c4b4092da", "e09b088f-9642-467a-b726-6ec6f4581eb4", new DateTime(2022, 10, 22, 11, 5, 33, 0, DateTimeKind.Unspecified) },
                    { "9c14727d-820a-41b4-bdb6-7b368dfbcafa", "Figyelj oda, hogy ez nem az sztf topik! Egyébként matekról meg progról is négy hiányzásnál letiltanak.", 0, null, "9ed94baa-be2f-4610-b72a-3937538c95d1", "cf3a39b0-5d34-4ec5-bc70-064201401e4e", new DateTime(2022, 10, 29, 8, 13, 28, 0, DateTimeKind.Unspecified) },
                    { "a460a850-0918-4c0e-a080-7f5a2e43e024", "Ne felejtse el, hogy én is látom, ne tegezzen mindenkit csak úgy.\nEgyébként tesztes kérdések lesznek, Marshall-keresztet mindenképp nézzék át!", 0, null, "15e19689-f9fc-4490-ac21-7aedbf63041b", "e69c9cd7-1379-4616-b7b3-42a4a6b256be", new DateTime(2022, 10, 28, 8, 15, 28, 0, DateTimeKind.Unspecified) },
                    { "b34ec95f-207d-4161-97ff-27213523c2b1", "Mondjuk nem is volt olyan rossz, 69% lett a zh-m^^", 0, null, "0aedbfd7-6016-464c-9ecf-7e1c4b4092da", "2b5811d4-0454-4e36-8afc-d8c35f30df93", new DateTime(2022, 10, 20, 21, 15, 28, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
