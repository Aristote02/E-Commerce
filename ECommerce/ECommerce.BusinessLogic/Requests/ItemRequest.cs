using System.ComponentModel.DataAnnotations;

namespace ECommerce.BusinessLogic.Requests
{
	public class ItemRequest
	{
		[Required]
		[MinLength(3)]
		[MaxLength(14)]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
	}
}
