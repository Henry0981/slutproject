using Raylib_cs;
using System.Numerics;

public class Wizard

 {
    public bool wizardisalive = true;
   public Rectangle wizardbox = new Rectangle(100,250,150,150);

   public Texture2D wizardsheet;

   public int wizardMaxframes;

   public int wizardstate = 0;

   Rectangle sourcerectwizard;

    int wizardsubFrameCounter = 0;

    int wizardcurrentframe = 0;

    public Texture2D idlewizard;

 public Wizard()
 {

    wizardsheet = Raylib.LoadTexture(@"wizard/Wizard1.png");
        wizardMaxframes = wizardsheet.width / wizardsheet.height;

    sourcerectwizard= new Rectangle(0, 0, wizardsheet.height, wizardsheet.height);

      idlewizard = Raylib.LoadTexture(@"wizard/Wizard.png");

 }



    public void wizarddraw () 
    {

       if (wizardstate==0)
       {
          Raylib.DrawTexturePro(idlewizard, new Rectangle(0, 0, idlewizard.width, idlewizard.height), wizardbox, Vector2.Zero, 0, Color.WHITE);

       }

       if (wizardstate==1)

       {
             wizardsubFrameCounter++;
            if (wizardsubFrameCounter == 10)
            {
                wizardsubFrameCounter = 0;
                wizardcurrentframe++;
                if (wizardcurrentframe == wizardMaxframes)
                {
                    wizardcurrentframe = 0;
                }
            }
           

                sourcerectwizard.x = wizardcurrentframe * sourcerectwizard.width;

                Raylib.DrawTexturePro(wizardsheet, sourcerectwizard, wizardbox, Vector2.Zero, 0, Color.WHITE);

                // Raylib.DrawTexture(sprint[currentFrame], (int)spriteBox.x, (int)spriteBox.y, Color.WHITE);
            
       }
    }

 }