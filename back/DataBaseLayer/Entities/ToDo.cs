using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
        public DateTime? EndTime { get; set; } = null;


    }
}
