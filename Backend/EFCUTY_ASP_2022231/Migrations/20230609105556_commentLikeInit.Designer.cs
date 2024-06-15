﻿// <auto-generated />
using System;
using EFCUTY_ASP_2022231.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCUTY_ASP_2022231.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230609105556_commentLikeInit")]
    partial class commentLikeInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.ApiUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "858b4134-610f-478a-a51a-fc92df8285b4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e7c12940-aff3-494c-8d88-b8386b270850",
                            EmailConfirmed = false,
                            FirstName = "Béla",
                            LastName = "Kovács",
                            LockoutEnabled = false,
                            NormalizedUserName = "BELA.KOVACS@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOeE9McqfdscPmnJQ+R42QEPZGavVv/frkYTpXZM9+j8BozLCPdmIsuwGw5Bhq4rNQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "872d0d23-2c6c-443f-9be7-f75425f9a49c",
                            TwoFactorEnabled = false,
                            UserName = "bela.kovacs@gmail.com"
                        },
                        new
                        {
                            Id = "d7691624-73f7-4872-b5a9-f8a2d0a0610f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "de134f26-d238-4581-b895-8290352d2207",
                            EmailConfirmed = false,
                            FirstName = "József",
                            LastName = "Kiss",
                            LockoutEnabled = false,
                            NormalizedUserName = "JOZSEFKISS@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELIQRB11xiNd7xFiNc8lycC2nQcnxy0w3SqwapKKQQcx0iWreJrTYtR6lExyHHoZ6Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2a2c8fc7-d214-4fb1-a746-03ebab359367",
                            TwoFactorEnabled = false,
                            UserName = "jozsefkiss@gmail.com"
                        },
                        new
                        {
                            Id = "5c5ea378-c525-4000-9b65-b3273b3832fd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "815e6c08-e89d-477b-bbb4-14d062afd434",
                            EmailConfirmed = false,
                            FirstName = "Ferenc",
                            LastName = "Kovács",
                            LockoutEnabled = false,
                            NormalizedUserName = "ISTVANTAKACS@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGcoIRfma2ORvK68n0SiIHx1nupzE9G2mDYrexI+/7Exr2EbBkTx8j3Gu6BMKoXMYw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "67ca1e81-6697-43b5-a3ca-a7e68036a38a",
                            TwoFactorEnabled = false,
                            UserName = "istvantakacs@gmail.com"
                        },
                        new
                        {
                            Id = "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2c334318-5062-463b-b6b7-5ae5f26f5272",
                            EmailConfirmed = false,
                            FirstName = "Mariann",
                            LastName = "Kiss",
                            LockoutEnabled = false,
                            NormalizedUserName = "MARIANNKISS@UNI-OBUDA.HU",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ7XIVO7sQSislS6WbuhEspvbJNjCmUtxFegJqBzCwNgCwHfoEBZ5Qma8m//vieZkQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ee220ca4-ebbb-4b1a-bb73-79a85e6c26ee",
                            TwoFactorEnabled = false,
                            UserName = "mariannkiss@uni-obuda.hu"
                        },
                        new
                        {
                            Id = "c11d804b-64e8-4a5c-8cd7-095fddbde1d1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3e9588d-a8ce-4b69-817a-bf536437ab2d",
                            EmailConfirmed = false,
                            FirstName = "Júlia",
                            LastName = "Horváth",
                            LockoutEnabled = false,
                            NormalizedUserName = "JULIAHORVATH@YAHOO.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELx7yP4tw6836EucqYtItDr6E8zEGHG6w1l+zelwGty8R7qA3bblZv0v5KqLhu3ySg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "931db490-fcb8-41ec-9a7b-c7ac71debb01",
                            TwoFactorEnabled = false,
                            UserName = "juliahorvath@yahoo.com"
                        });
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SiteUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("SiteUserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = "ceabd46c-5b76-4a71-acd9-f868c67aa90e",
                            Content = "Ne felejtse el, hogy én is látom, ne tegezzen mindenkit csak úgy.\nEgyébként tesztes kérdések lesznek, Marshall-keresztet mindenképp nézzék át!",
                            EditCount = 0,
                            PostId = "ac8e029a-615e-4842-9697-c37c17e7c7b8",
                            SiteUserId = "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c",
                            Timestamp = new DateTime(2022, 10, 28, 8, 15, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "f203a975-67ba-4a17-97b0-ebb783dde8ce",
                            Content = "Figyelj oda, hogy ez nem az sztf topik! Egyébként matekról meg progról is négy hiányzásnál letiltanak.",
                            EditCount = 0,
                            PostId = "f762a131-9c21-4a2c-95cd-2f0699a734b7",
                            SiteUserId = "858b4134-610f-478a-a51a-fc92df8285b4",
                            Timestamp = new DateTime(2022, 10, 29, 8, 13, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "25fd21d5-c860-4853-82b7-71add3f1a51f",
                            Content = "Nekem se megy, meg szerintem senkinek se, mindenkinek bukó lesz a zh:D",
                            EditCount = 0,
                            PostId = "b4e8f9a3-68fa-4986-8736-822d21f4d924",
                            SiteUserId = "c11d804b-64e8-4a5c-8cd7-095fddbde1d1",
                            Timestamp = new DateTime(2022, 9, 10, 8, 15, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "67bf5686-4ddc-413c-b0cb-ffea5ec36d16",
                            Content = "Mondjuk nem is volt olyan rossz, 69% lett a zh-m^^",
                            EditCount = 0,
                            PostId = "b4e8f9a3-68fa-4986-8736-822d21f4d924",
                            SiteUserId = "5c5ea378-c525-4000-9b65-b3273b3832fd",
                            Timestamp = new DateTime(2022, 10, 20, 21, 15, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "00e26a4e-d12b-4a76-a027-372c2ffa7fc2",
                            Content = "Ne szívass, akkor meg mit problémáztál szeptemberben? Én mehetek pótzh-ra...",
                            EditCount = 0,
                            PostId = "b4e8f9a3-68fa-4986-8736-822d21f4d924",
                            SiteUserId = "c11d804b-64e8-4a5c-8cd7-095fddbde1d1",
                            Timestamp = new DateTime(2022, 10, 22, 11, 5, 33, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.CommentLike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SiteUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("SiteUserId");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("SiteUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SiteUserId");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = "ac8e029a-615e-4842-9697-c37c17e7c7b8",
                            Content = "Sziasztok! Tudtok valamit, hogy mi lesz a jövő heti zh-ban?",
                            EditCount = 0,
                            SiteUserId = "858b4134-610f-478a-a51a-fc92df8285b4",
                            SubjectCode = "KGK666BUKO",
                            Timestamp = new DateTime(2022, 10, 23, 11, 15, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "f762a131-9c21-4a2c-95cd-2f0699a734b7",
                            Content = "Hányat lehet hiányozni sztf laboron?",
                            EditCount = 0,
                            SiteUserId = "d7691624-73f7-4872-b5a9-f8a2d0a0610f",
                            SubjectCode = "NIXMN1HBNE",
                            Timestamp = new DateTime(2022, 10, 15, 11, 11, 22, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "b4e8f9a3-68fa-4986-8736-822d21f4d924",
                            Content = "Határérték-számításban tud valaki segíteni?",
                            EditCount = 0,
                            SiteUserId = "5c5ea378-c525-4000-9b65-b3273b3832fd",
                            SubjectCode = "NIXMN1HBNE",
                            Timestamp = new DateTime(2022, 9, 7, 7, 45, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "a9e4e4fb-4a77-45fa-9d55-8e272314902a",
                            Content = "Kedves mindenki! Ugye tudják, hogy a zárthelyi dolgozatot kiválthatják beadandó dolgozat megírásával?\nDe akkor legfeljebb hármast tudok majd adni.",
                            EditCount = 0,
                            SiteUserId = "1dcd6024-a0fe-4bc1-8969-6e17927c1d9c",
                            SubjectCode = "KGK666BUKO",
                            Timestamp = new DateTime(2022, 10, 29, 8, 15, 28, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "b21b472e-5884-4bca-ab91-aa24f282b704",
                            Content = "Jövő héten lesz óra?",
                            EditCount = 0,
                            SiteUserId = "c11d804b-64e8-4a5c-8cd7-095fddbde1d1",
                            SubjectCode = "NIXBE1PBNE",
                            Timestamp = new DateTime(2022, 10, 28, 8, 15, 28, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Subject", b =>
                {
                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CreditValue")
                        .HasColumnType("int");

                    b.Property<bool>("ExamSubject")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("SubjectCode");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectCode = "NIXMN1HBNE",
                            CreditValue = 7,
                            ExamSubject = true,
                            Name = "Analízis 1",
                            Semester = 1
                        },
                        new
                        {
                            SubjectCode = "NIXSF1HBNE",
                            CreditValue = 7,
                            ExamSubject = true,
                            Name = "Szoftvertervezés és -fejlesztés 1.",
                            Semester = 1
                        },
                        new
                        {
                            SubjectCode = "NIXSF2HBNE",
                            CreditValue = 7,
                            ExamSubject = true,
                            Name = "Szoftvertervezés és -fejlesztés 2.",
                            Semester = 2
                        },
                        new
                        {
                            SubjectCode = "NIXBE1PBNE",
                            CreditValue = 3,
                            ExamSubject = true,
                            Name = "Beágyazott és érzékelőalapú rendszerek",
                            Semester = 2
                        },
                        new
                        {
                            SubjectCode = "KGK666BUKO",
                            CreditValue = 15,
                            ExamSubject = false,
                            Name = "Mikro- és makroökonómia",
                            Semester = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Comment", b =>
                {
                    b.HasOne("EFCUTY_ASP_2022231.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", "Author")
                        .WithMany()
                        .HasForeignKey("SiteUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.CommentLike", b =>
                {
                    b.HasOne("EFCUTY_ASP_2022231.Models.Comment", "Liked")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", "Liker")
                        .WithMany()
                        .HasForeignKey("SiteUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liked");

                    b.Navigation("Liker");
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Post", b =>
                {
                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", "Author")
                        .WithMany()
                        .HasForeignKey("SiteUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EFCUTY_ASP_2022231.Models.Subject", "Subject")
                        .WithMany("Posts")
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EFCUTY_ASP_2022231.Models.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Comment", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EFCUTY_ASP_2022231.Models.Subject", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}