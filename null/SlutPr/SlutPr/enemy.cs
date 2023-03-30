using Raylib_cs;
using System.Numerics;

public class Enemy

{
    public Rectangle enemybox = new Rectangle(200, 10, 60, 60);

    public Texture2D enemysheet;

    public int enemymaxframes;

    public float enemyspeed = 1.5f;

    public Enemy()
    {
        enemysheet = Raylib.LoadTexture(@"slime/Slime (1).png");
        enemymaxframes = enemysheet.width / enemysheet.height;


    }

    public void Update(Player target)
    {
        // 1. skapa vector2 för spelarens position
        Vector2 playerpos = new Vector2(target.spriteBox.x, target.spriteBox.y);
        // 2. skapa vector2 för fiendens position
        Vector2 enemypos = new Vector2(enemybox.x, enemybox.y);
        // 3. diff = spelarpos - fiendepos
        Vector2 diff = playerpos - enemypos;
        // 4. diff = Vector2.Normalize(diff) * fiendespeed
        diff = Vector2.Normalize(diff) * enemyspeed;
        // 5. Flytta fienden (diff.x, diff.y)

        enemybox.x += diff.X;
        enemybox.y += diff.Y;


    }

    public void enemydraw()
    {
        Raylib.DrawRectangleRec(enemybox, Color.WHITE);




    }













}


