﻿using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes;

public class ImageRepository : GenericRepository<Image> , IImageRepository
{
    public ImageRepository(ApplicationDbContext options) : base(options)
    {
        
    }

    public async Task<Image> GetImage(int userId)
    {
        Image? imageInDb = await _dbSet.Where(x => x.UserId == userId).FirstOrDefaultAsync();

        return imageInDb!;
    }
    

}
