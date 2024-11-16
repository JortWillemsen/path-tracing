using Engine;
using Color = Engine.Vector3;

namespace Renderer;

public static class ImageBuilder
{
    private static string[] Build(int width, int height)
    {
        Console.WriteLine("Image build started");
        Console.WriteLine("");
        
        const int numOfLines = 256 * 256 + 3;
        var lines = new string[numOfLines];
        
        // PPM header information
        lines[0] = "P3";
        lines[1] = width + " " + height;
        lines[2] = "255";

        for (var j = 0; j < height; j++)
        {
            var curCursorLine = Console.CursorTop;
            
            // Clearing previous progress line
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop);
            
            // Writing new progress line
            Console.Write("Lines remaining: " + (height - j) + " of " + numOfLines);
            
            for (var i = 0; i < width; i++)
            {
                var color = new Color(
                    (float) i / (width - 1),
                    (float) j / (height - 1),
                    0.0f);
        
                lines[j * width + 3 + i] = WriteColor(color);
            }
        }

        return lines;
    }

    public static void BuildToFile(int width, int height, string fileName)
    {
        var path = Directory.GetCurrentDirectory() + fileName;
        
        var lines = Build(width, height);
        using var outputFile = new StreamWriter(path);
        foreach (var line in lines)
        {
            outputFile.WriteLine(line);
        }
        
        Console.WriteLine();
        Console.WriteLine("Image output finished at: \n");
        Console.WriteLine(path);
    }

    public static string WriteColor(Color pixel)
    {
        var r = pixel.X();
        var g = pixel.Y();
        var b = pixel.Z();

        int rByte = (int) (255.999 * r);
        int gByte = (int) (255.999 * g);
        int bByte = (int) (255.999 * b);

        return string.Join(" ", rByte, gByte, bByte);

    }
}