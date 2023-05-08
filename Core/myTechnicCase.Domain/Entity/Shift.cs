using myTechnicCase.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace myTechnicCase.Domain.Entity;

public class Shift : BaseEntity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
}