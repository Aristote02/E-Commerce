namespace ECommerce.DataAccess.Entities;

public class Computer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public ComputerCategory Category { get; set; }
    public int ComputerCategoryId { get; set; }
}
