namespace Engine;

public class Vector3
{
    private readonly float[] _e = new float[3] { 0, 0, 0};

    public float X() { return _e[0]; }
    public float Y() { return _e[1]; }
    public float Z() { return _e[2]; }

    public Vector3(float x, float y, float z)
    {
        this._e[0] = x;
        this._e[1] = y;
        this._e[2] = z;
    }

    public float Dot(Vector3 a, Vector3 b)
    {
        return
            a.X() * b.X() +
            a.Y() * b.Y() +
            a.Z() * b.Z();
    }
    
    public Vector3 Cross(Vector3 a, Vector3 b)
    {
        return new Vector3(
            a.Y() * b.Z() - a.Z() * b.Y(),
            a.Z() * b.X() - a.X() * b.Z(),
            a.X() * b.Y() - a.Y() * b.X());
    }

    public Vector3 Unit(Vector3 a)
    {
        return a / a.Length();
    }
    
    public static Vector3 operator + (Vector3 a, Vector3 b)
    {
        return new Vector3(
            a.X() + b.X(),
            a.Y() + b.Y(),
            a.Z() + b.Z());
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3(
            a.X() - b.X(),
            a.Y() - b.Y(),
            a.Z() - b.Z());
    }

    public static Vector3 operator *(Vector3 a, Vector3 b)
    {
        return new Vector3(
            a.X() * b.X(),
            a.Y() * b.Y(),
            a.Z() * b.Z());
    }
    
    public static Vector3 operator *(Vector3 a, float d)
    {
        return new Vector3(
            a.X() * d,
            a.Y() * d,
            a.Z() * d);
    }
    
    public static Vector3 operator *(float d, Vector3 a)
    {
        return a * d;
    }

    public static Vector3 operator /(Vector3 a, float d)
    {
        return (1 / d) * a;
    }
    
    public static Vector3 operator /(float d, Vector3 a)
    {
        return a * (1 / d);
    }

    public float Length()
    {
        return (float)Math.Sqrt(LengthSquared());
    }

    public float LengthSquared()
    {
        return _e[0] * _e[0] + _e[1] * _e[1] + _e[2] * _e[2];
    }

    public override string ToString()
    {
        return _e[0] + " " + _e[1] + " " + _e[2];
    }
}

