namespace TaskManagment.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public int Age { get; set; }

        //DTO edilecekler.
        public int Birthday { get; set;}
        public string? Description { get; set; } 
    }
}
