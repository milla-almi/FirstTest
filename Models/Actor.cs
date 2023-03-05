namespace Employee.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string  Bio { get; set; }

        public ICollection<Actor_Movie> Actors_Movies { get; set; }

       
    }
}
