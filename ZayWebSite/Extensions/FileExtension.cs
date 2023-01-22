using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ZayWebSite.Extensions
{
    public  static class FileExtension
    {
        public static string CreateFile(this IFormFile formFile,string env,string path)
        {
            string imagename=Guid.NewGuid()+formFile.FileName;
            string fullpath=Path.Combine(env,path,imagename);
            using (FileStream file=new FileStream(fullpath,FileMode.Create))
            {
                formFile.CopyTo(file);
            }
            return imagename;
        }
    }
}
