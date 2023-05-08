using myTechnicCase.Domain.Entity.Base;
namespace myTechnicCase.Domain.Entity;

public class Team : BaseEntity
{
    public Team()
    {
        Personnels = new HashSet<Personnel>();
    }
    public string Name { get; set; }
    public int SupervisorPersonnelId { get; set; }
    public virtual ICollection<Personnel>? Personnels { get; set; }

}