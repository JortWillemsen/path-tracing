using Engine.Geometry.Interfaces;

namespace Engine.Materials;

public class Reflective : Material
{
    public Vector3 Albedo { get; private set; }

    public Reflective(Vector3 albedo)
    {
        Albedo = albedo;
    }

    public override Scatter Scatter(Ray rayIn, SuccessRecord record)
    {
        var reflectedDir = rayIn.Direction.Reflect(record.Normal);

        return new Scatter
        {
            Albedo = Albedo,
            Outgoing = new Ray(record.Point, reflectedDir)
        };
    }
}