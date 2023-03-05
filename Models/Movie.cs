using Employee.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
        public int Price { get; set; }
        public MovieCatagory MovieCatagory { get; set; }

        public ICollection<Actor_Movie> Actors_Movies { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
