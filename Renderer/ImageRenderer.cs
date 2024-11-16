using Engine;
using Engine.Geometry;
using Engine.Geometry.Interfaces;
using Color = Engine.Vector3;

namespace Renderer;

public static class ImageRenderer
{
    private static string[] Render(Camera cam, Scene scene)
    {
        Console.WriteLine("Image build started");
        Console.WriteLine("");
        
        var numOfLines = (cam.ImageWidth * cam.ImageHeight) + 3;
        var lines = new string[numOfLines];
        
        // PPM header information
        lines[0] = "P3";
        lines[1] = cam.ImageWidth + " " + cam.ImageHeight;
        lines[2] = "255";

        var samplesPerPixel = 100;
        
        for (var j = 0; j < cam.ImageHeight; j++)
        {
            var curCursorLine = Console.CursorTop;
            
            // Clearing previous progress line
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop);
            
            // Writing new progress line
            Console.Write("Lines remaining: " + (cam.ImageHeight - j) + " of " + cam.ImageHeight);
            
            for (var i = 0; i < cam.ImageWidth; i++)
            {
                var pixelColor = Color.Zero();

                for (int sample = 0; sample < samplesPerPixel; sample++)
                {
                    var r = cam.GetRay(i, j);
                    pixelColor += RayColor(r, scene);
                }
                
                lines[j * cam.ImageWidth + 3 + i] = WriteColor(1f / samplesPerPixel * pixelColor);
            }
        }

        return lines;
    }

    public static void RenderToFile(Camera vp, Scene scene, string fileName)
    {
        var path = Directory.GetCurrentDirectory() + fileName;
        
        var lines = Render(vp, scene);
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
        
        var intensity = new Interval(0f, 0.999f);
        
        int rByte = (int) (256 * intensity.Clamp(r));
        int gByte = (int) (256 * intensity.Clamp(g));
        int bByte = (int) (256 * intensity.Clamp(b));

        return string.Join(" ", rByte, gByte, bByte);

    }
    
    static Color RayColor(Ray r, Scene scene)
    {
        var hit = scene.Hit(r, new Interval(0f, Utils.Infinity));
        
        if (hit is SuccessRecord success)
        {
            return 0.5f * (success.Normal + new Vector3(1f, 1f, 1f));
        }
        
        var unitDir = Vector3.Unit(r.Direction);

        var a = .5f * (unitDir.Y() + 1f);
        return (1f - a) * new Color(1f, 1f, 1f) + a * new Color(.5f, .7f, 1f );
    }
}