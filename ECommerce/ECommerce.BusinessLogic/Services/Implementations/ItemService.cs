using AutoMapper;
using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Exceptions;
using ECommerce.BusinessLogic.Requests;
using ECommerce.BusinessLogic.Services.Interfaces;
using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;

namespace ECommerce.BusinessLogic.Services.Implementations;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    public ItemService(IItemRepository itemRepository, IMapper mapper) 
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    public async Task<ItemDTO> AddItemAsync(ItemRequest itemRequest)
    {
        var itemAdded = await _itemRepository.AddItemAsync(_mapper.Map<Item>(itemRequest));

        return _mapper.Map<ItemDTO>(itemAdded); 
    }

    public async Task<ItemDTO> DeleteItemAsync(int id)
    {
        var item = await _itemRepository.GetItemByIdAsync(id);

        if(item is null)
        {
            throw new NotFoundException("There is not item with such an id");
        }

        var itemDeleted = await _itemRepository.DeleteItemAsync(item);

        return _mapper.Map<ItemDTO>(itemDeleted);
    }

    public async Task<List<ItemDTO>> GetAllItemsAsync()
    {
        var items = await _itemRepository.GetAllItemsAsync();

        return _mapper.Map<List<ItemDTO>>(items);
    }

    public async Task<ItemDTO> GetItemByIdAsync(int id)
    {
        var item = await _itemRepository.GetItemByIdAsync(id);

        if(item is null )
        {
            throw new NotFoundException("There is no item with such an id");
        }

        return _mapper.Map<ItemDTO>(item);
    }

    public async Task<ItemDTO> UpdateItemAsync(int id, ItemRequest itemRequest)
    {
        var item = await _itemRepository.GetItemByIdAsync(id);

        if(item is null )
        {
            throw new NotFoundException("There is no user with such an id");
        }

        var itemUpdated = await _itemRepository.UpdateItemAsync(_mapper.Map<Item>(itemRequest));

        return _mapper.Map<ItemDTO>(itemUpdated);
    }
}
