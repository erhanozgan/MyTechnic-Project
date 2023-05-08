namespace myTechnicCase.Application.Dtos.Personnel;

public class PersonnelListDto
{
	public int Id { get; set; }
	public int PersonnelCode { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Address { get; set; }
	public string Title { get; set; }
	public bool Active { get; set; }
	public string TeamName { get; set; }
}