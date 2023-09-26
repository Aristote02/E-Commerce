#region Using Region
using AutoMapper;
using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Exceptions;
using ECommerce.BusinessLogic.Requests;
using ECommerce.BusinessLogic.Services.Interfaces;
using ECommerce.DataAccess.Entities;
using ECommerce.DataAccess.Repositories.Interfaces;
#endregion

namespace ECommerce.BusinessLogic.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserDTO> AddAsync(UserRequest request)
    {
        var user = _userRepository.GetUserByEmailAsync(request.Email);

        if(user is not null)
        {
            throw new ExistException("A user with this email already exist");
        }

       var userAdded =  await  _userRepository.AddAsync(_mapper.Map<User>(request));

        return _mapper.Map<UserDTO>(userAdded);
    }

    public Task<UserDTO> DeleteAsync(UserRequest userDTO)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDTO>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> UpdateAsync(UserRequest userDTO)
    {
        throw new NotImplementedException();
    }
}
