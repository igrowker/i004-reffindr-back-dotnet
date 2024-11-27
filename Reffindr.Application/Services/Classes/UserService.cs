using Reffindr.Application.Services.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;

namespace Reffindr.Application.Services.Classes;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService
        (
            IUnitOfWork unitOfWork
        )
    {
        _unitOfWork = unitOfWork;
    }

}
