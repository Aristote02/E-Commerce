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
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if(user is not null)
        {
            throw new ExistException("A user with this email already exist");
        }

        var userWithRole = SetUserRole(_mapper.Map<User>(request));
        var userAdded =  await  _userRepository.AddAsync(userWithRole);

        return _mapper.Map<UserDTO>(userAdded);
    }

    public async Task<UserDTO> DeleteAsync(UserRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if(user is null)
        {
            throw new NotFoundException("There is no user with that email");
        }

        var userDeleted = await _userRepository.DeleteAsync(_mapper.Map<User>(request));

        return _mapper.Map<UserDTO>(userDeleted);
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        return _mapper.Map<List<UserDTO>>(users); 
    }

    public async Task<UserDTO> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        
        if(user is null)
        {
            throw new NotFoundException("There is no user with that Id");
        }

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> UpdateAsync(UserRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        
        if(user is null)
        {
            throw new NotFoundException("There is no user with that Email to be updated");
        }

        var userUpdated = await _userRepository.UpdateAsync(_mapper.Map<User>(request));

        return _mapper.Map<UserDTO>(userUpdated);
    }

    private User SetUserRole(User user)
    {
        user.RoleId = -2;

        return user;
    }
}
