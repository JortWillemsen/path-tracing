namespace Engine.Geometry;

public class Sphere
{
    public Vector3 Center { get; private set; }
    public float Radius { get; private set; }

    public Sphere(Vector3 center, float radius)
    {
        Center = center;
        Radius = radius;
    }
    
    // Function that returns point on the ray where it hit the sphere. 
    public float Hit(Ray r)
    {
        var oc = Center - r.Origin;

        var a = Vector3.Dot(r.Direction, r.Direction);
        var b = -2f * Vector3.Dot(r.Direction, oc);
        var c = Vector3.Dot(oc, oc) - Radius * Radius;

        var discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
            return -1f;

        return (-b - (float) Math.Sqrt(discriminant) ) / (2f * a);
    }
}