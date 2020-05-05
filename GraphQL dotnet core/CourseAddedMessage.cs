using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class CourseAddedMessage
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
    }
}
