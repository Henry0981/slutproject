using Raylib_cs;
using System.Numerics;

public class Player
{
    public int state = 0; // 0 = idle 1 = walk

    public Vector2 pos;
    public Color color = Color.DARKGREEN;

    public Rectangle spriteBox = new Rectangle(100, 100, 200, 200);

    public Texture2D leftSheet;
    public int leftMaxFrames;

    public int maxFrames;

    public Texture2D[] sprint;

    public Texture2D[] sprint2;

    public Texture2D[] sprint3;

    int currentFrame = 0;

    int subFrameCounter = 0;

    public Direction dire;

    Rectangle sourceRect;



    public Player()
    {
        leftSheet = Raylib.LoadTexture(@"dmitri\leftSheet.png");
        leftMaxFrames = leftSheet.width / leftSheet.height;

        sourceRect = new Rectangle(0, 0, leftSheet.height, leftSheet.height);

        sprint = new Texture2D[] {
            Raylib.LoadTexture("dimitri1.png"),
            Raylib.LoadTexture("dimitri(1).png"),
            Raylib.LoadTexture("dimitri2.png"),
            Raylib.LoadTexture("dimitri3.png")
        };
        sprint2 = new Texture2D[] {
            Raylib.LoadTexture("2dimitri-1.png"),
            Raylib.LoadTexture("2dimitri-2.png"),
            Raylib.LoadTexture("2dimitri-1.png"),
            Raylib.LoadTexture("2dimitri-3.png")
        };

        sprint3 = new Texture2D[] {
            Raylib.LoadTexture("3dimitri1.png"),
            Raylib.LoadTexture("3dimitri2.png"),
            Raylib.LoadTexture("3dimitri3.png"),
            Raylib.LoadTexture("3dimitri4.png")
        };
    }

    public void Draw()
    {
        if (state == 0)
        {
            if (dire == Direction.righ)
            {
                Raylib.DrawTexture(sprint[0], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            }
        }
        if (state == 1)
        {

            subFrameCounter++;
            if (subFrameCounter == 10)
            {
                subFrameCounter = 0;
                currentFrame++;
                if (currentFrame == leftMaxFrames)
                {
                    currentFrame = 0;
                }
            }
            if (dire == Direction.righ)
            {
                Raylib.DrawTexture(sprint[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            }
            else if (dire == Direction.lef)
            {
                sourceRect.x = currentFrame * sourceRect.width;

                Raylib.DrawTexturePro(leftSheet, sourceRect, spriteBox, Vector2.Zero, 0, Color.WHITE);

                // Raylib.DrawTexture(sprint2[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            }

            else if (dire == Direction.dow)
            {
                Raylib.DrawTexture(sprint3[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            }
        }

    }
    public enum Direction
    {
        up, dow, lef, righ
    }
}