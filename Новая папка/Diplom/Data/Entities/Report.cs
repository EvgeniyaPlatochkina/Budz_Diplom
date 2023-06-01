using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Data.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateOfСreation { get; set; }
        public int UserId { get; set; }


        public User User { get; set; } = null!;
    }
}
