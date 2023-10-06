using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.Models
{
    public class Citizen:Base
    {
        [SugarColumn(ColumnDataType ="nvarchar(20)")]
        public string Name { get; set; }

        [SugarColumn(IsPrimaryKey =true)]
        public string PhoneNo { get; set; }

        [SugarColumn(IsPrimaryKey = true)]
        public string Email { get; set; }

        public int State { get; set; }

        public string Password { get; set; }
        public DateTime RegisterTime { get; set; }

        public DateTime LastOnlineTime { get; set; }

        public string Avatar { get; set; }
    }
}
