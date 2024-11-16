namespace Engine.Geometry.Interfaces;

public interface Hittable
{
    public HitRecord Hit(Ray r, float tMin, float tMax);
}

public abstract class HitRecord { }

public class SuccessRecord : HitRecord
{
    public float Length { get; private set; }
    public Vector3 Point { get; private set; }
    public Vector3 Normal { get; private set; }

    public SuccessRecord(float length, Vector3 point, Vector3 normal)
    {
        Length = length;
        Point = point;
        Normal = normal;
    }
}

public class FailRecord : HitRecord { }