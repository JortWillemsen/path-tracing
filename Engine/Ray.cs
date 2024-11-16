using Point = Engine.Vector3;

namespace Engine;

public class Ray
{
    private readonly Point _origin;
    private readonly Vector3 _direction;
    
    public Ray(Point origin, Vector3 direction)
    {
        _origin = origin;
        _direction = direction;
    }

    public Point At(float t)
    {
        return _origin + t * _direction;
    }
}