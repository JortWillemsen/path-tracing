using System.Collections;
using Engine.Geometry.Interfaces;

namespace Engine;

public class Scene : Hittable
{
    public List<Hittable> Hittables { get; private set; }

    public Scene(params Hittable[] hittables)
    {
        Hittables = hittables.ToList();
    }

    public void Add(Hittable obj)
    {
        Hittables.Add(obj);
    }

    public HitRecord Hit(Ray r, float tMin, float tMax)
    {
        HitRecord record = new FailRecord();

        var closest = tMax;

        foreach (var obj in Hittables)
        {
            if (obj.Hit(r, tMin, closest) is SuccessRecord success)
            {
                closest = success.Length;

                record = success;
            }
        }

        return record;
    }
}