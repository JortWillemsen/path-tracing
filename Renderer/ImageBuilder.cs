using Engine;
using Color = Engine.Vector3;

namespace Renderer;

public static class ImageBuilder
{
    private static string[] Build(Viewport vp)
    {
        Console.WriteLine("Image build started");
        Console.WriteLine("");
        
        var numOfLines = (vp.Cam.ImageWidth * vp.Cam.ImageHeight) + 3;
        var lines = new string[numOfLines];
        
        // PPM header information
        lines[0] = "P3";
        lines[1] = vp.Cam.ImageWidth + " " + vp.Cam.ImageHeight;
        lines[2] = "255";

        for (var j = 0; j < vp.Cam.ImageHeight; j++)
        {
            var curCursorLine = Console.CursorTop;
            
            // Clearing previous progress line
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop);
            
            // Writing new progress line
            Console.Write("Lines remaining: " + (vp.Cam.ImageHeight - j) + " of " + numOfLines);
            
            for (var i = 0; i < vp.Cam.ImageWidth; i++)
            {
                var pixelCenter = vp.Pixel0 + (i * vp.PixelDeltaU) + (j * vp.PixelDeltaV);
                var rayDir = pixelCenter - vp.Cam.Location;
                var r = new Ray(vp.Cam.Location, rayDir);

                var color = RayColor(r);
        
                lines[j * vp.Cam.ImageWidth + 3 + i] = WriteColor(color);
            }
        }

        return lines;
    }

    public static void BuildToFile(Viewport vp, string fileName)
    {
        var path = Directory.GetCurrentDirectory() + fileName;
        
        var lines = Build(vp);
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
    
    static Color RayColor(Ray r)
    {
        if (HitSphere(new Vector3(0f, 0f, -1f), .5f, r))
        {
            return new Color(1f, 0f, 0f);
        }
        
        var unitDir = r.Direction.Unit();

        var a = .5f * (unitDir.Y() + 1f);
        return (1f - a) * new Color(1f, 1f, 1f) + a * new Color(.5f, .6f, 1f );
    }

    static bool HitSphere(Vector3 center, float radius, Ray r)
    {
        var oc = center - r.Origin;

        var a = Vector3.Dot(r.Direction, r.Direction);
        var b = -2f * Vector3.Dot(r.Direction, oc);
        var c = Vector3.Dot(oc, oc) - radius * radius;

        var discriminant = b * b - 4 * a * c;
        return discriminant >= 0;
    }
}