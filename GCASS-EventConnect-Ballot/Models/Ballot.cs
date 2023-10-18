using System.ComponentModel.DataAnnotations.Schema;

namespace GCASS_EventConnect_Ballot.Models;

public class Ballot
{
    public Guid id { get; set; }

    [Column("user_id")]
    public Guid userId { get; set; }

    [Column("booth_id")]
    public Guid boothId { get; set; }

    public int amount { get; set; }

    public int status { get; set; }

    [Column("created_time")]
    public DateTime createdTime { get; set; }
    
    [Column("updated_time")]
    public DateTime updatedTime { get; set; }
}

