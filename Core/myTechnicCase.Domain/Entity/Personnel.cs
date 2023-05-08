using myTechnicCase.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;
namespace myTechnicCase.Domain.Entity;

public class Personnel : BaseEntity
{
    public int PersonnelCode { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Title { get; set; }

    public bool Active { get; set; } = true;

    public int? TeamId { get; set; }

    [ForeignKey("TeamId")]
    public Team? TeamFk { get; set; }
}