using Raylib_cs;
using System.Numerics;

public class Player
{
    public int state = 0; // 0 = idle 1 = walk
    public Vector2 pos;
    public Color color = Color.DARKGREEN;

    public Rectangle spriteBox = new Rectangle(100, 100, 150, 150);

    public Rectangle sword = new Rectangle(0, 0, 60, 110);

    public Texture2D leftSheet;

    public Texture2D rightsheet;

    public Texture2D downsheet;

    public Texture2D upsheet;

    public Texture2D idleRigh;

    public Texture2D Idlelef;

    public Texture2D Idleup;

    public Texture2D Idledow;

    public int leftMaxFrames;

    public int rightMaxFrames;

    public int downMaxFrames;

    public int upMaxFrames;

    public int maxFrames;

    // public Texture2D[] sprint;

    // public Texture2D[] sprint2;

    // public Texture2D[] sprint3;

    int currentFrame = 0;

    int subFrameCounter = 0;

    public Direction dire;

    Rectangle sourceRect;

    Rectangle sourceRect2;

    Rectangle sourceRect3;

    Rectangle sourceRect4;

    public Color swordColor = Color.PINK; 

    public Player()
    {
        leftSheet = Raylib.LoadTexture(@"Knight/leftSheet.png");
        leftMaxFrames = leftSheet.width / leftSheet.height;

        sourceRect = new Rectangle(0, 0, leftSheet.height, leftSheet.height);

        rightsheet = Raylib.LoadTexture(@"Knight/rightsheet.png");
        rightMaxFrames = rightsheet.width / rightsheet.height;

        sourceRect2 = new Rectangle(0, 0, rightsheet.height, rightsheet.height);


        downsheet = Raylib.LoadTexture(@"Knight/downsheet.png");
        downMaxFrames = downsheet.width / downsheet.height;

        sourceRect3 = new Rectangle(0, 0, downsheet.height, downsheet.height);

        upsheet = Raylib.LoadTexture(@"Knight/upsheet.png");
        upMaxFrames = upsheet.width / upsheet.height;

        sourceRect4 = new Rectangle(0, 0, upsheet.height, upsheet.height);

        idleRigh = Raylib.LoadTexture(@"Knight/KnighIdleRight.png");

        Idlelef = Raylib.LoadTexture(@"Knight/KnightIdleLef.png");

        Idleup = Raylib.LoadTexture(@"Knight/BackIdleKnight.png");

        Idledow = Raylib.LoadTexture(@"Knight/forwardIdleknight.png");



        // sprint = new Texture2D[] {
        //     Raylib.LoadTexture("dimitri1.png"),
        //     Raylib.LoadTexture("dimitri(1).png"),
        //     Raylib.LoadTexture("dimitri2.png"),
        //     Raylib.LoadTexture("dimitri3.png")
        // };
        // sprint2 = new Texture2D[] {
        //     Raylib.LoadTexture("2dimitri-1.png"),
        //     Raylib.LoadTexture("2dimitri-2.png"),
        //     Raylib.LoadTexture("2dimitri-1.png"),
        //     Raylib.LoadTexture("2dimitri-3.png")
        // };

        // sprint3 = new Texture2D[] {
        //     Raylib.LoadTexture("3dimitri1.png"),
        //     Raylib.LoadTexture("3dimitri2.png"),
        //     Raylib.LoadTexture("3dimitri3.png"),
        //     Raylib.LoadTexture("3dimitri4.png")
        // };
    }

    public void Draw()
    {
        if (state == 0)
        {
            if (dire == Direction.right)
            {
                // Raylib.DrawTexture(sprint[0], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
                Raylib.DrawTexturePro(idleRigh, new Rectangle(0, 0, idleRigh.width, idleRigh.height), spriteBox, Vector2.Zero, 0, Color.WHITE);
            }

            else if (dire == Direction.left)
            {

                Raylib.DrawTexturePro(Idlelef, new Rectangle(0, 0, Idlelef.width, Idlelef.height), spriteBox, Vector2.Zero, 0, Color.WHITE);

            }
            else if (dire == Direction.up)
            {

                Raylib.DrawTexturePro(Idleup, new Rectangle(0, 0, Idleup.width, Idleup.height), spriteBox, Vector2.Zero, 0, Color.WHITE);

            }

            else if (dire == Direction.dow)
            {

                Raylib.DrawTexturePro(Idledow, new Rectangle(0, 0, Idledow.width, Idledow.height), spriteBox, Vector2.Zero, 0, Color.WHITE);

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
            if (dire == Direction.right)
            {

                sourceRect.x = currentFrame * sourceRect.width;

                Raylib.DrawTexturePro(leftSheet, sourceRect, spriteBox, Vector2.Zero, 0, Color.WHITE);

                // Raylib.DrawTexture(sprint[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            }
            else if (dire == Direction.left)
            {

                sourceRect2.x = currentFrame * sourceRect2.width;

                Raylib.DrawTexturePro(rightsheet, sourceRect2, spriteBox, Vector2.Zero, 0, Color.WHITE);

                // Raylib.DrawTexture(sprint2[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            }

            else if (dire == Direction.dow)
            {
                // Raylib.DrawTexture(
                // sprint3[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);

                sourceRect3.x = currentFrame * sourceRect3.width;

                Raylib.DrawTexturePro(downsheet, sourceRect3, spriteBox, Vector2.Zero, 0, Color.WHITE);
            }

            else if (dire == Direction.up)
            {

                sourceRect4.x = currentFrame * sourceRect4.width;

                Raylib.DrawTexturePro(upsheet, sourceRect4, spriteBox, Vector2.Zero, 0, Color.WHITE);

            }


        }
        placeSword();
        Raylib.DrawRectangleRec(sword, swordColor);
    }
    public enum Direction
    {
        up, dow, left, right
    }



    // skapa en rectangel
    // se till så att den sitter framför spelaren hela tiden
    // ge den collsion när man klickar på en knapp. 
    public void placeSword()
    {
        sword.y = spriteBox.y + 30;

        if (dire == Direction.right)
        {
            sword.x = spriteBox.x + spriteBox.width;
        }
        else if (dire == Direction.left)
        {
            sword.x = spriteBox.x - sword.width;
        }
        else if (dire == Direction.up)
        {

            sword.y = spriteBox.y - 70;
            sword.x = spriteBox.x + 45;
        }

        else if (dire == Direction.dow)

        {

            sword.y = spriteBox.y - -160;
            sword.x = spriteBox.x + 45;

        }


    }

}