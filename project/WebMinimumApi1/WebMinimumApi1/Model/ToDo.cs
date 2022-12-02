using System.ComponentModel.DataAnnotations;

namespace WebMinimumApi1.Model
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
