using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Genders Gender { get; set; }

        public override string ToString() => $"({StudentId}) {Name} - {Age} - {Gender}";
    }
}
