using System.ComponentModel.DataAnnotations;

namespace WebMinimumApi1.Model
{
    public class ToDoDTO
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
