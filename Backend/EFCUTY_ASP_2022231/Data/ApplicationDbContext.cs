using EFCUTY_ASP_2022231.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCUTY_ASP_2022231.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public DbSet<Subject> Subjects { get; set; }
        //public DbSet<SiteUser> Users { get; set; }
        public DbSet<ApiUser> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLike> CommentLikes { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CommentLike>()
                .HasOne(t => t.Liked)
                .WithMany(c => c.Likes)
                .HasForeignKey(l => l.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CommentLike>()
                .HasOne(t => t.Liker)
                .WithMany()
                .HasForeignKey(l => l.SiteUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(t => t.Post)
                .WithMany(t => t.Comments)
                .HasForeignKey(t => t.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.SiteUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(t => t.Subject)
                .WithMany(t => t.Posts)
                .HasForeignKey(t => t.SubjectCode)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Post>()
                .HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.SiteUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Student", NormalizedName = "STUDENT" }

            );

            var hasher = new PasswordHasher<ApiUser>();

            ApiUser u1 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "bela.kovacs@gmail.com",
                NormalizedUserName = "BELA.KOVACS@GMAIL.COM",
                FirstName = "Béla",
                LastName = "Kovács",
                PasswordHash = hasher.HashPassword(null, "Bela1234")
            };

            ApiUser u2 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "jozsefkiss@gmail.com",
                NormalizedUserName = "JOZSEFKISS@GMAIL.COM",
                FirstName = "József",
                LastName = "Kiss",
                PasswordHash = hasher.HashPassword(null, "Jozsi1234")
            };

            ApiUser u3 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "istvantakacs@gmail.com",
                NormalizedUserName = "ISTVANTAKACS@GMAIL.COM",
                FirstName = "Ferenc",
                LastName = "Kovács",
                PasswordHash = hasher.HashPassword(null, "Ferikee1234")
            };

            ApiUser u4 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "mariannkiss@uni-obuda.hu",
                NormalizedUserName = "MARIANNKISS@UNI-OBUDA.HU",
                FirstName = "Mariann",
                LastName = "Kiss",
                PasswordHash = hasher.HashPassword(null, "MikMak12")
            };

            ApiUser u5 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "juliahorvath@yahoo.com",
                NormalizedUserName = "JULIAHORVATH@YAHOO.COM",
                FirstName = "Júlia",
                LastName = "Horváth",
                PasswordHash = hasher.HashPassword(null, "Juliska99")
            };

            builder.Entity<ApiUser>().HasData(u1, u2, u3, u4, u5);

            Subject s1 = new()
            {
                Name = "Analízis 1",
                CreditValue = 7,
                ExamSubject = true,
                Semester = 1,
                SubjectCode = "NIXMN1HBNE"
            };

            Subject s2 = new()
            {
                Name = "Szoftvertervezés és -fejlesztés 1.",
                CreditValue = 7,
                ExamSubject = true,
                Semester = 1,
                SubjectCode = "NIXSF1HBNE"
            };

            Subject s3 = new()
            {
                Name = "Szoftvertervezés és -fejlesztés 2.",
                CreditValue = 7,
                ExamSubject = true,
                Semester = 2,
                SubjectCode = "NIXSF2HBNE"
            };

            Subject s4 = new()
            {
                Name = "Beágyazott és érzékelőalapú rendszerek",
                CreditValue = 3,
                ExamSubject = true,
                Semester = 2,
                SubjectCode = "NIXBE1PBNE"
            };

            Subject s5 = new()
            {
                Name = "Mikro- és makroökonómia",
                CreditValue = 15,
                ExamSubject = false,
                Semester = 1,
                SubjectCode = "KGK666BUKO"
            };

            builder.Entity<Subject>().HasData(s1, s2, s3, s4, s5);


            Post p1 = new()
            {
                Content = "Sziasztok! Tudtok valamit, hogy mi lesz a jövő heti zh-ban?",
                SiteUserId = u1.Id,
                SubjectCode = s5.SubjectCode,
                Timestamp = new DateTime(2022, 10, 23, 11, 15, 28)
            };

            Post p2 = new()
            {
                Content = "Hányat lehet hiányozni sztf laboron?",
                SiteUserId = u2.Id,
                SubjectCode = s1.SubjectCode,
                Timestamp = new DateTime(2022, 10, 15, 11, 11, 22)
            };

            Post p3 = new()
            {
                Content = "Határérték-számításban tud valaki segíteni?",
                SiteUserId = u3.Id,
                SubjectCode = s1.SubjectCode,
                Timestamp = new DateTime(2022, 9, 7, 7, 45, 28)
            };

            Post p4 = new()
            {
                Content = "Kedves mindenki! Ugye tudják, hogy a zárthelyi dolgozatot kiválthatják beadandó dolgozat megírásával?" +
                "\nDe akkor legfeljebb hármast tudok majd adni.",
                SiteUserId = u4.Id,
                SubjectCode = s5.SubjectCode,
                Timestamp = new DateTime(2022, 10, 29, 8, 15, 28)
            };

            Post p5 = new()
            {
                Content = "Jövő héten lesz óra?",
                SiteUserId = u5.Id,
                SubjectCode = s4.SubjectCode,
                Timestamp = new DateTime(2022, 10, 28, 8, 15, 28)
            };


            builder.Entity<Post>().HasData(p1, p2, p3, p4, p5);

            Comment c1 = new()
            {
                Content = "Ne felejtse el, hogy én is látom, ne tegezzen mindenkit csak úgy." +
                "\nEgyébként tesztes kérdések lesznek, Marshall-keresztet mindenképp nézzék át!",
                SiteUserId = u4.Id,
                PostId = p1.Id,
                Timestamp = new DateTime(2022, 10, 28, 8, 15, 28)
            };

            Comment c2 = new()
            {
                Content = "Figyelj oda, hogy ez nem az sztf topik! Egyébként matekról meg progról is négy hiányzásnál letiltanak.",
                SiteUserId = u1.Id,
                PostId = p2.Id,
                Timestamp = new DateTime(2022, 10, 29, 8, 13, 28)
            };

            Comment c3 = new()
            {
                Content = "Nekem se megy, meg szerintem senkinek se, mindenkinek bukó lesz a zh:D",
                SiteUserId = u5.Id,
                PostId = p3.Id,
                Timestamp = new DateTime(2022, 9, 10, 8, 15, 28)
            };

            Comment c4 = new()
            {
                Content = "Mondjuk nem is volt olyan rossz, 69% lett a zh-m^^",
                SiteUserId = u3.Id,
                PostId = p3.Id,
                Timestamp = new DateTime(2022, 10, 20, 21, 15, 28)
            };

            Comment c5 = new()
            {
                Content = "Ne szívass, akkor meg mit problémáztál szeptemberben? Én mehetek pótzh-ra...",
                SiteUserId = u5.Id,
                PostId = p3.Id,
                Timestamp = new DateTime(2022, 10, 22, 11, 5, 33)
            };

            builder.Entity<Comment>().HasData(c1, c2, c3, c4, c5);

            base.OnModelCreating(builder);
        }
    }
}
