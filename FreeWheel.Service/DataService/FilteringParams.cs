using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWheel.Service.DataService
{
        public class FilteringParams
        {
            public string title { get; set; } = "";
            public int YearOfRelease { get; set; } = 0;
            public string genres { get; set; } = "";
        }
}
