using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int ID { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        // relationships
        //
        // kiểu dữ liệu của phương thức là List<Movie> -> trả về một danh sách các đối tượng Movie
        // tên phương thức là Movies
        // dùng để lưu trữ danh sách Movie.
        public List<Movie> Movies { get; set; }
    }
}
