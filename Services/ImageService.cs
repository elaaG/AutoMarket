using Microsoft.AspNetCore.Hosting;

namespace AutoMarket.Services
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveImage(IFormFile file)
        {
            if (file == null) return "/images/default-car.jpg";

            var uploads = Path.Combine(_env.WebRootPath, "images");
            Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return "/images/" + fileName;
        }
    }
}
