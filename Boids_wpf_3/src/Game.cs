using MyVector2;

public static class Game
{
    public static int boidsCount = 300;
    public static Boid[] boids = new Boid[boidsCount];
    public static AABB aabb = new AABB(Vector2.Zero, new Vector2(50,50));
    public static void Init()
    {
        Subgen.Init(0);
        for (int i = 0; i < boidsCount; i++)
            boids[i] = new Boid(aabb);
    }
    public static void Update()
    {
        Boid.Update(boids,ref aabb,0.02f);
    }
    public static void End()
    {
        System.Console.Write($"{boids[0].ToString()} ");
    }
}