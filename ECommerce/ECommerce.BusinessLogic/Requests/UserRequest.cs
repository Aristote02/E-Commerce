using System.ComponentModel.DataAnnotations;

namespace ECommerce.BusinessLogic.Requests;

public class UserRequest
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
}
