using System;

namespace FreeWheelDataAccess.Models
{
    public class Rating
    {
       
        
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public Decimal GivenRating { get; set; }
    }
}
