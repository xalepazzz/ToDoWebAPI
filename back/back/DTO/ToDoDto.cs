using System;
using System.Collections.Generic;
using System.Text;

namespace BusienessLayer.DTO
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Status { get; set; } = false;
        public DateTime? EndTime { get; set; }
    }
}
