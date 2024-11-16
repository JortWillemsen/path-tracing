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
    public bool FrontFacing { get; private set; }

    public SuccessRecord(float length, Vector3 point, Vector3 outwardNormal, Ray r)
    {
        Length = length;
        Point = point;
        Normal = outwardNormal;
        SetFaceNormal(outwardNormal, r);
    }

    public void SetFaceNormal(Vector3 outwardNormal, Ray r)
    {
        FrontFacing = Vector3.Dot(r.Direction, outwardNormal) < 0;
        Normal = FrontFacing ? outwardNormal : -outwardNormal;
    }
}

public class FailRecord : HitRecord { }