﻿using Reffindr.Application.Services.Interfaces;
using Reffindr.Application.Utilities.Mappers;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.UnitOfWork;
using Reffindr.Shared.DTOs.Response.Property;
using Reffindr.Shared.Result;
using System.Threading;

namespace Reffindr.Application.Services.Classes
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PropertyGetResponseDto>> GetFavorites(int userId)
        {
            List<Property> favoriteProperties = new List<Property>();
            favoriteProperties = await _unitOfWork.FavoriteRepository.GetFavoritesByUser(userId);

            List<PropertyGetResponseDto> favoritePropertiesGetDto = favoriteProperties.Select(x => x.ToResponse()).ToList();

            return favoritePropertiesGetDto;
        }

        public async Task AddFavorite(int userId, int propertyId, CancellationToken cancellationToken)
        {
            // Verificar si ya está en favoritos
            var existingFavoriteId = await _unitOfWork.FavoriteRepository.GetFavoriteByUserAndProperty(userId, propertyId);
            if (existingFavoriteId != 0)
            {
                throw new Exception("This property is already in your favorites.");
            }

            var favorite = new Favorite
            {
                UserId = userId,
                PropertyId = propertyId,
                IsDeleted = false
            };

            await _unitOfWork.FavoriteRepository.Create(favorite, cancellationToken);
            await _unitOfWork.Complete(cancellationToken);

        }

        public async Task RemoveFavorite(int userId, int propertyId, CancellationToken cancellationToken)
        {
            // Verificar si ya está en favoritos
            var existingFavoriteId = await _unitOfWork.FavoriteRepository.GetFavoriteByUserAndProperty(userId, propertyId);
            if (existingFavoriteId == 0)
            {
                throw new Exception("This property is not in your favorites.");
            }

            await _unitOfWork.FavoriteRepository.SoftDelete(existingFavoriteId);
            await _unitOfWork.Complete(cancellationToken);
        }
    }
}
