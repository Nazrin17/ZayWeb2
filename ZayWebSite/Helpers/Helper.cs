namespace ZayWebSite.Helpers
{
    public static class Helper
    {
        public static void DeleteFile(string env,string path,string name)
        {
            File.Delete(Path.Combine(env, path,name));
        }
    }
}
