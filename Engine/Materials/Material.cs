using Engine.Geometry.Interfaces;

namespace Engine.Materials;

public abstract class Material
{
    public abstract Scatter Scatter(Ray rayIn, SuccessRecord record);
}

public struct Scatter
{
    public Vector3 Albedo { get; set; }
    public Ray Outgoing { get; set; }
}