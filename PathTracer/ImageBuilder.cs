using System.Text;

namespace PathTracer;

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
}