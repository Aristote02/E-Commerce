namespace ECommerce.DataAccess.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public Role Role { get; set; }
    public int RoleId {  get; set; }
}
