using System.Text;

namespace PathTracer;

public static class ImageBuilder
{
    private static string[] Build(int width, int height)
    {
        var lines = new string[256*256 + 3];
        
        // PPM header information
        lines[0] = "P3";
        lines[1] = width + " " + height;
        lines[2] = "255";

        for (var j = 0; j < height; j++)
        {
            for (var i = 0; i < width; i++)
            {
                var r = decimal.ToDouble(i) / (width - 1);
                var g = decimal.ToDouble(j) / (height - 1);
                var b = 0.0d;

                var ir = (int) (255.999 * r);
                var ig = (int) (255.999 * g);
                var ib = (int) (255.999 * b);
        
                lines[j * width + 3 + i] = ir + " " + ig + " " +  ib;
            }
        }

        return lines;
    }

    public static void BuildToFile(int width, int height, string filePath)
    {
        var lines = Build(width, height);
        Console.WriteLine(Directory.GetCurrentDirectory());
        using var outputFile = new StreamWriter(Directory.GetCurrentDirectory() + filePath);
        foreach (var line in lines)
        {
            outputFile.WriteLine(line);
        }
    }
}