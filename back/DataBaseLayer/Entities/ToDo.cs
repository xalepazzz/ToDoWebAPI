using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Entities
{
    public class ToDo
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Description { get; set; } = string.Empty;
        DateTime StartTime { get; set; }
        DateTime CreateTime { get; set; } = DateTime.Now;
        bool Status { get; set; }
        DateTime EndTime { get; set; }


    }
}
