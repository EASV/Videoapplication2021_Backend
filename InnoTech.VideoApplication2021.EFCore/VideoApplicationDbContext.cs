using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.VideoApplication2021.EFCore
{
    public class VideoApplicationDbContext: DbContext
    {
        public VideoApplicationDbContext(DbContextOptions<VideoApplicationDbContext> options) : base(options) {}
    }
}