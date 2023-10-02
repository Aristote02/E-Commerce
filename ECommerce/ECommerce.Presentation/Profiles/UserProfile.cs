using AutoMapper;
using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;
using ECommerce.DataAccess.Entities;

namespace ECommerce.Presentation.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UserRequest, User>()
			.ForMember(dest => dest.UserName, options  => options.MapFrom(source => source.Name));
		CreateMap<User, UserDTO>()
			.ReverseMap();
	}
}
