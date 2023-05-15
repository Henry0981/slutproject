
using System;
using System.Numerics;
public class Sword
{
    public Rectangle Swordbox = new Rectangle(100, 100, 20, 20);
    public bool attacking = true;

    public Texture2D swordsprite;

    public int swordDirection = 1;

    public Texture2D swordsheet;

    public Rectangle SwordSourceRect;

    int SwordsubFrameCounter = 0;

    int SwordcurrentFrame = 0;

    public int SwordMaxFrames;

    public Sword()

    {
        // swordsprite= Raylib.LoadTexture (@"sword/sword.png");

        swordsheet = Raylib.LoadTexture(@"sword/swordsheet.png");

        SwordMaxFrames = (swordsheet.height / swordsheet.width) + 1;

        SwordSourceRect = new Rectangle(0, 0, swordsheet.height, swordsheet.height);
        Swordbox.width = swordsheet.height;
        Swordbox.height = swordsheet.height;



    }

    public void swordDraw()

    {
        // Raylib.DrawTexture(swordsprite,400,400,Color.WHITE);

        SwordsubFrameCounter++;
        if (SwordsubFrameCounter == 10)
        {
            SwordsubFrameCounter = 0;
            SwordcurrentFrame++;
            if (SwordcurrentFrame > SwordMaxFrames)
            {
                SwordcurrentFrame = 0;
            }
            SwordSourceRect.x = SwordcurrentFrame * SwordSourceRect.height;


        }

        if (attacking == true)
        {


            Raylib.DrawTexturePro(swordsheet, SwordSourceRect, Swordbox, Vector2.Zero, 0, Color.WHITE);

        }





    }

}