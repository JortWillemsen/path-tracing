namespace PathTracer;

public static class ImageBuilder
{
    public static void Build(int width, int height)
    {
        Console.WriteLine("P3\n" + width + " " + height + "\n255\n");

        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                var r = decimal.ToDouble(i) / (width - 1);
                var g = decimal.ToDouble(j) / (height - 1);
                var b = 0.0d;

                int ir = (int) (255.999 * r);
                int ig = (int) (255.999 * g);
                int ib = (int) (255.999 * b);
        
                Console.WriteLine(ir + " " + ig + " " +  "ib" + "\n");
            }
        }
    }
}