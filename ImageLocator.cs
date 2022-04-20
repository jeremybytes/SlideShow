using System.IO;

namespace SlideShow;
public static class ImageLocator
{
    public static List<string> GetImagesFromLocation(string folder)
    {
        var images = new List<string>();
        var files = Directory.EnumerateFiles(folder,
            "*.*", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            if (IsImage(file))
            {
                images.Add(file);
            }
        }
        return images;
    }

    public static readonly List<string> ImageExtensions =
        new() { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

    private static bool IsImage(string file)
    {
        return ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant());
    }
}
