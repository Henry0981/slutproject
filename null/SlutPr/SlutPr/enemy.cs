using Raylib_cs;
using System.Numerics;

public class Enemy

{

    public int enemyhp = 5;

    public bool enemyAlive = true;
    public Rectangle enemybox = new Rectangle(200, 10, 120, 120);

    public Vector2 enemybefore;

    public Texture2D enemysheet;

    public Texture2D enemysheet2;

    public int enemymaxframes;

    public int enemymaxframes2;

    Rectangle sourcerectenemy;

    Rectangle sourcerectenemy2;

    public float enemyspeed = 1.2f;

    int enemysubFrameCounter = 0;

    int enemycurrentframe = 0;
    Vector2 diff = new Vector2();


    public Enemy(int x, int y)
    {
        enemysheet = Raylib.LoadTexture(@"slime/Slime (1).png");
        enemymaxframes = enemysheet.width / enemysheet.height;

        sourcerectenemy = new Rectangle(0, 0, enemysheet.height, enemysheet.height);

        enemysheet2 = Raylib.LoadTexture(@"slime\slime2..png");

        sourcerectenemy2 = new Rectangle(0, 0, enemysheet2.height, enemysheet2.height);
        enemybox.x = x;
        enemybox.y = y;
    }

    public void Update(Player target)
    {
         enemybefore = new Vector2(enemybox.x, enemybox.y);
        // 1. skapa vector2 för spelarens position
        Vector2 playerpos = new Vector2(target.spriteBox.x, target.spriteBox.y);
        // 2. skapa vector2 för fiendens position
        Vector2 enemypos = new Vector2(enemybox.x, enemybox.y);
        // 3. diff = spelarpos - fiendepos
        diff = playerpos - enemypos;
        // 4. diff = Vector2.Normalize(diff) * fiendespeed
        diff = Vector2.Normalize(diff) * enemyspeed;
        // 5. Flytta fienden (diff.x, diff.y)

        enemybox.x += diff.X;
        enemybox.y += diff.Y;
    }

    public void enemydraw()
    {



        enemysubFrameCounter++;
        if (enemysubFrameCounter == 10)
        {
            enemysubFrameCounter = 0;
            enemycurrentframe++;
            if (enemycurrentframe == enemymaxframes)
            {
                enemycurrentframe = 0;
            }
        }

        if (diff.X > 0)
        {

            sourcerectenemy.x = enemycurrentframe * sourcerectenemy.width;
            Raylib.DrawTexturePro(enemysheet, sourcerectenemy, enemybox, Vector2.Zero, 0, Color.WHITE);

        }

        else
        {
            sourcerectenemy2.x = enemycurrentframe * sourcerectenemy2.width;
            Raylib.DrawTexturePro(enemysheet2, sourcerectenemy2, enemybox, Vector2.Zero, 0, Color.WHITE);
        }

        

    }
   






}


