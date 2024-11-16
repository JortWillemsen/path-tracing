namespace Engine;

public class Utils
{
    public static float Pi => 3.1415926535897932385f;
    public static float Infinity => float.PositiveInfinity;

    public static float DegreesToRadans(float degrees)
    {
        return degrees * Pi / 180f;
    }
}