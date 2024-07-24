using Microsoft.AspNetCore.Http;
using ReadyGo.Domain.Entities;

namespace ReadyGo.Service.Interfaces
{
    public interface IFileService
    {
        ResourceFile SaveReshape(IFormFile file, string userId, int width = 150, int height = 150, int quality = 75);
    }
}
