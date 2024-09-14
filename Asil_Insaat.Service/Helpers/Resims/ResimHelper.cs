using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Resims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Asil_Insaat.Service.Helpers.Resims
{
    public class ResimHelper : IResimHelper
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string wwwroot;
        private const string imgFolder = "images";
        private const string yaziResimFolder = "yazi-images";
        private const string referansResimFolder = "Referans-images";
        public ResimHelper(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            wwwroot = this.webHostEnvironment.WebRootPath;
        }


        public void Delete(string resimIsim)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{resimIsim}");
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);
        }
        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }


        public async Task<ResimYüklemeViewModel> Upload(string name, IFormFile imageFile, ResimType resimType, string? folderName = null)
        {
            folderName ??= resimType == ResimType.Referans? referansResimFolder : yaziResimFolder;

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");

            string oldFilName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);
            name = ReplaceInvalidChars(name);
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string mesaj = resimType == ResimType.User
                ? $"{newFileName} isimli kullanıcı resmi başarılı bir şekilde eklenmiştir."
                : $"{newFileName} isimli makalenin resmi başarılı bir şekilde eklenmiştir. ";
            return new ResimYüklemeViewModel()
            {
                TamIsim = $"{folderName}/{newFileName}"
            };
        }
    }
}
