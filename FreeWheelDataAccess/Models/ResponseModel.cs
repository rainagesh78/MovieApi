using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWheel.DataAccess.Models
{
    public class ResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        public string Genres { get; set; }
        public Decimal AverageRating { get; set; }
    }
}
