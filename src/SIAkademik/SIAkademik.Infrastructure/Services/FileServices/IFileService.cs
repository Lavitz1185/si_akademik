using Microsoft.AspNetCore.Http;
using SIAkademik.Domain.Shared;

namespace SIAkademik.Infrastructure.Services.FileServices;

public interface IFileService
{
    bool IsExist(Uri uri);
    Result Delete(Uri uri);
    Task<Result<Uri>> UploadFile<TModel>(IFormFile formFile, string folderPath, string[] permittedExtension, long minSizeLimit, long maxSizeLimit);
}
