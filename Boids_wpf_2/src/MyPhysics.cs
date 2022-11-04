#if (UNITY_STANDALONE)
using UnityEngine;
#else
using System;
using System.Numerics;
#endif

public struct Sphere
{
    public Vector3 position;
    public float radius;
    public Sphere(Vector3 position, float radius)
    {
        this.position = position;
        this.radius = radius;
    }
}
public struct Ray
{
    public Vector3 from;
    public Vector3 dir;
}
public struct RaycastResult
{
    public float distance;
    public Vector3 point;
    public Vector3 normal;
}
public struct AABB
{
    public Vector2 p0;
    public Vector2 p1;
    public AABB(Vector2 p0, Vector2 p1)
    {
        this.p0 = p0;
        this.p1 = p1;
    }
    public Vector2 Size => (p0 - p1).Abs();
    public float MinX => MathF.Min(p0.X,p1.X);
    public float MinY => MathF.Min(p0.Y,p1.Y);
    public float MaxX => MathF.Max(p0.X,p1.X);
    public float MaxY => MathF.Max(p0.Y,p1.Y);
    public Vector2 WrapAround(Vector2 point)
    {
        var size = this.Size;
        if      (point.X < this.MinX) point.X += size.X;
        else if (point.X > this.MaxX) point.X -= size.X;
        if      (point.Y < this.MinY) point.Y += size.Y;
        else if (point.Y > this.MaxY) point.Y -= size.Y;
        return point;
    }
}
public class MyPhysics
{
    public static Vector3 ClosesPoint(Vector3 point, Sphere sphere)
    {
        var diff = point-sphere.position;
        var dir = Adapter.Normalized(diff);
        var dist = Adapter.Magnitude(diff);
        if (dist > sphere.radius) dist = 6f;
        return sphere.position+dir*dist;
    }
    public static RaycastResult? Raycast(Ray ray, Sphere sphere)
    {
        var position = sphere.position;
        var radius = sphere.radius;
        var from = ray.from;
        var dir = ray.dir;
        var diff = from - position;
        var a = Adapter.MagnitudeSquared(ray.dir);
        var b = Vector3.Dot(dir,diff) * 2;
        var c = Adapter.MagnitudeSquared(diff) - radius*radius;
        var delta = b * b - 4 * a * c;
        if (delta < 0) return null;
        var dist = (float)(-b - Adapter.Sqrt(delta)) / (2 * a);
        if (dist < 0) return null;
        var point = from+dir*dist;
        var normal = point-position;
        var result = new RaycastResult();
        result.distance = dist;
        result.point = point;
        result.normal = normal;
        return result;
    }
    public static bool InsideOrTouching(Vector3 point, Sphere sphere) => Adapter.Magnitude(point-sphere.position) <= sphere.radius;
}