namespace GCASS_EventConnect_User.Models;

public class Ballot
{
    public Guid id { get; set; }

    public Guid userId { get; set; }

    public Guid boothId { get; set; }

    public int amount { get; set; }

    public int status { get; set; }

    public Guid createdBy { get; set; }

    public DateTime createdTime { get; set; }

    public Guid updatedBy { get; set; }
    
    public DateTime updatedTime { get; set; }
}

