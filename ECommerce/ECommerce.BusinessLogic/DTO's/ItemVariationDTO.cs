namespace ECommerce.BusinessLogic.DTO_s;

public class ItemVariationDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PriceVariation { get; set; }
    public decimal? TotalPriceItem { get; set; }

}
