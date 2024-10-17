using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Pipeline
{
    class WorkItem
    {
        static int items = 1;

        public WorkItem()
        {
            Id = items;
            items++;
        }

        public int WorkTime { get; set; }

        public int Id { get; set; }
    }
}
