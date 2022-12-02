using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.Model
{
    public class Album
    {
        [Key]
        public long Id { get; set; }

        public int RankId { get; set; }
        [Required]
        public string Name { get; set; }

        public string BandName { get; set; }

        public string? ImgUrl { get; set; }

        public string? Type { get; set; }

        public DateTime? ReleaseTime { get; set; }

        public string[]? Genres { get; set; }

        public string? Label { get; set; }

        public string? Format { get; set; }

        public TimeSpan? TotalLength { get; set; }
    }
}
