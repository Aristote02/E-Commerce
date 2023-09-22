namespace ECommerce.DataAccess.Entities;

public class ComputerCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Computer> Computers { get; set; }
}
