using System;
using System.Collections.Generic;
using System.Text;

namespace BusienessLayer.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId {  get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } = null;
        public DateTime? StartTime { get; set; } = null;
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = false;
        public DateTime? EndTime { get; set; } = null;


    }
}
