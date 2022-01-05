using Microsoft.AspNetCore.Http;
using Reactivities.Application.Photos;
using System.Threading.Tasks;

namespace Reactivities.Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}
