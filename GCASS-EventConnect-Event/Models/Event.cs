using System.ComponentModel.DataAnnotations.Schema;

namespace GCASS_EventConnect_Event.Models;

public class Event
{
    public Guid id { get; set; }
    public String title { get; set; }
    public int type { get; set; }
    public String description { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public String location { get; set; }
    public int status { get; set; }
    public Guid createdBy { get; set; }
    public DateTime createdTime { get; set; }
    public Guid updatedBy { get; set; }
    public DateTime updatedTime { get; set; }
}

