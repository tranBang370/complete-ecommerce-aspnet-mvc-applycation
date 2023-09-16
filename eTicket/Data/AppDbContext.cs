using Microsoft.EntityFrameworkCore;
using eTickets.Models;

namespace eTickets.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // cấu hình mô hình dữ liệu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ModelBuilder dùng để cấu hình các kiểu thực thế và mối quan hệ giữa chúng
            // thiết lập cấu trúc cho đối tượng Actor_Movie trong bảng CSDL
            // am => new { am.ActorID, am.MovieID } là 1 lambda expression (cách viết ngắn gọn tạo 1 hàm không tên)
            // tạo 1 khoá tổng hợp (khoá chính từ 2 khoá) ActoID & MovieID 

            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorID,
                am.MovieID
            });

            // (am => am.Movie) là một biểu thức lamda

            // Actor_Movie,
            // quan hệ 1-n với Movie.
            // khoá ngoại là MovieID
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieID);
            //Actor_Movie, quan hệ 1n với Actor
            //khoá ngoại là ActorID
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorID);


            base.OnModelCreating(modelBuilder);
        }
        // Mỗi DbSet được ánh xạ đến một bảng trong cơ sở dữ liệu
        // dùng các DbSet này để chỉnh sửa actor, movies, actor,...
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }



    }
}
