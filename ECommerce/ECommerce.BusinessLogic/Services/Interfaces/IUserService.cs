﻿using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;

namespace ECommerce.BusinessLogic.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO> AddAsync(UserRequest request);
    Task<UserDTO> UpdateAsync(UserRequest request);
    Task<UserDTO> DeleteAsync(UserRequest request);
    Task<UserDTO> GetUserById(int id);
    Task<List<UserDTO>> GetAllUsersAsync();
}
