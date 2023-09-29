using AutoMapper;
using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Exceptions;
using ECommerce.BusinessLogic.Requests;
using ECommerce.BusinessLogic.Services.Interfaces;
using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;

namespace ECommerce.BusinessLogic.Services.Implementations;

public class ItemVariationService : IItemVariationService
{
    private readonly IItemVariationRepository _itemVariationRepository;
    private readonly IMapper _mapper;
    public ItemVariationService(IItemVariationRepository itemVariationRepository, IMapper mapper)
    {
        _itemVariationRepository = itemVariationRepository;
        _mapper = mapper;
    }

    public async Task<ItemVariationDTO> AddItemVariationAsync(ItemVariationRequest itemVariationRequest)
    {
        var itemVariation = await _itemVariationRepository.AddItemVariationAsync(_mapper.Map<ItemVariation>(itemVariationRequest));

        return _mapper.Map<ItemVariationDTO>(itemVariation);
    }

    public async Task<ItemVariationDTO> DeleteItemVariationAsync(int id)
    {
        var itemVariation = await _itemVariationRepository.GetItemVariationByIdAsync(id);

        if (itemVariation is null)
        {
            throw new NotFoundException("There is not item with such an id");
        }

        var itemVariationDeleted = _itemVariationRepository.DeleteItemVariationAsync(itemVariation);

        return _mapper.Map<ItemVariationDTO>(itemVariationDeleted);
    }

    public async Task<List<ItemVariationDTO>> GetAllItemsVariationAsync()
    {
        var itemVariation = await _itemVariationRepository.GetAllItemVariationsAsync();

        return _mapper.Map<List<ItemVariationDTO>>(itemVariation);
    }

    public async Task<ItemVariationDTO> GetItemVariationByIdAsync(int id)
    {
        var itemVariation = await _itemVariationRepository.GetItemVariationByIdAsync(id);

        if (itemVariation is null)
        {
            throw new NotFoundException("There is no itemVariation with such an id");
        }

        return _mapper.Map<ItemVariationDTO>(itemVariation);
    }

    public async Task<ItemVariationDTO> UpdateItemVariationAsync(int id, ItemVariationRequest itemVariationRequest)
    {
        var itemVariation = await _itemVariationRepository.GetItemVariationByIdAsync(id);

        if (itemVariation is null)
        {
            throw new NotFoundException("There is no user with such an id");
        }

        var itemVariationUpdated = await _itemVariationRepository.UpdateItemVariationAsync(_mapper.Map<ItemVariation>(itemVariationRequest));

        return _mapper.Map<ItemVariationDTO>(itemVariationUpdated);
    }
}
