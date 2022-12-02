using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.Common;

namespace Libraries.Model
{
    public class User : BaseModel
    {
        [Leng(1, 100)]
        public string Name { get; set; }

        public string Account { get; set; }

        [Regex(@"^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Regex(@"^[0-9]{11}$")]
        public string Mobile { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        [Mapping("state")]
        public int Status { get; set; }

        public int UserType { get; set; }

        public DateTime LastLoginTime { get; set; }

        public int CreatorId { get; set; }

        public DateTime CreateTime { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }
    }
}
