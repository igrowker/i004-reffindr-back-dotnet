using Reffindr.Application.Services.Interfaces;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.Application;
using Reffindr.Shared.Result;
using Reffindr.Domain.Models;

namespace Reffindr.Application.Services.Classes
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public ApplicationService(IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public async Task<Result<List<ApplicationGetResponseDto>>> GetApplicationsByUserIdAsync(int userId)
        {
            int userAutenticado = _userContext.GetUserId();

            if (userId != userAutenticado)
            {
                return Result<List<ApplicationGetResponseDto>>.Failure("No tienes permisos para ver las aplicaciones de otro usuario.");
            }

            List<Domain.Models.Application> applications = await _unitOfWork.ApplicationRepository.GetApplicationsByUserIdAsync(userId);

            if (applications == null || !applications.Any())
            {
                return Result<List<ApplicationGetResponseDto>>.Failure("No se encontraron aplicaciones para este usuario.");
            }

            // Mapeo manual
            List<ApplicationGetResponseDto> applicationDtos = applications.Select(a => new ApplicationGetResponseDto
            {
                Id = a.Id,
                PropertyId = a.PropertyId,
                PropertyTitle = a.Property?.Title ?? "Sin título",
                PropertyAddress = a.Property?.Address ?? "Sin dirección",
                Status = a.Status ?? "Desconocido",
                CreatedAt = a.CreatedAt
            }).ToList();

            return Result<List<ApplicationGetResponseDto>>.Success(applicationDtos);
        }
    }
}
