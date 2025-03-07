namespace Utilities
{
    public class InputFileReader
    {
        public static string[] ReadLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
        public static string ReadText(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}
