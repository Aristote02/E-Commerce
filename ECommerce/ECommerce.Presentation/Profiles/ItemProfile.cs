using AutoMapper;
using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;
using ECommerce.DataAccess.Entities;

namespace ECommerce.Presentation.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<ItemRequest, Item>();
        CreateMap<Item, ItemDTO>();
    }
}
