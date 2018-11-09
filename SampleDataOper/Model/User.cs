using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataOper.Model
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string DepartName { get; set; }
        public string DdId { get; set; }
        public string Avatar { get; set; }
        public string LoginStr { get; set; }
        public UserRole Role { get; set; }
        public DateTime? LoginOverTime { get; set; }
        [NotMapped]
        public string Ticket { get; set; }
    }

    public enum UserRole
    {
        一般用户=0,
        打样开发=1,
        样衣管理员=2,
        管理员=3
    }
}
