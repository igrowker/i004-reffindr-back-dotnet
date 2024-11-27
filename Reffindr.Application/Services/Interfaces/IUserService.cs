﻿using Reffindr.Shared.DTOs.Response.User;

namespace Reffindr.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userRequestDto, CancellationToken cancellationToken);
}
