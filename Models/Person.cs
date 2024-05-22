using System.ComponentModel.DataAnnotations;

namespace Progetto_Tipsit___Gestione_Persona.Models
{
    public class Person
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, Range(1, 100)]
        public int Age { get; set; }

        public Person() { }

        public Person(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
