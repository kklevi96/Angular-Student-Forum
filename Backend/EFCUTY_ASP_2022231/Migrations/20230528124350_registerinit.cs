using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCUTY_ASP_2022231.Migrations
{
    public partial class registerinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreditValue = table.Column<int>(type: "int", nullable: false),
                    ExamSubject = table.Column<bool>(type: "bit", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditCount = table.Column<int>(type: "int", nullable: false),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Subjects_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subjects",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditCount = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Student", "STUDENT" }
                });

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
                table: "Subjects",
                columns: new[] { "SubjectCode", "CreditValue", "ExamSubject", "Name", "Semester" },
                values: new object[,]
                {
                    { "KGK666BUKO", 15, false, "Mikro- és makroökonómia", 1 },
                    { "NIXBE1PBNE", 3, true, "Beágyazott és érzékelőalapú rendszerek", 2 },
                    { "NIXMN1HBNE", 7, true, "Analízis 1", 1 },
                    { "NIXSF1HBNE", 7, true, "Szoftvertervezés és -fejlesztés 1.", 1 },
                    { "NIXSF2HBNE", 7, true, "Szoftvertervezés és -fejlesztés 2.", 2 }
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SiteUserId",
                table: "Comments",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SiteUserId",
                table: "Posts",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubjectCode",
                table: "Posts",
                column: "SubjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
