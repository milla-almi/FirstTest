namespace Employee.Models
{
    public class Producer 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
