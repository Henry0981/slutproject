global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1500, 880, "spel");
Raylib.SetTargetFPS(60);

float speed = 3.2f;
Player player = new();


while (!Raylib.WindowShouldClose())
{
    // Logik
    // skapa en rectangel 

    player.state = 0;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        player.dire = Player.Direction.lef;
        player.state = 1;
        player.spriteBox.x -= speed;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
        player.dire = Player.Direction.righ;
        player.state = 1;
        player.spriteBox.x += speed;

    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
      
        player.spriteBox.y -= speed;

    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))

    {
        player.dire = Player.Direction.dow;
        player.state = 1;
        player.spriteBox.y += speed;

    }


    // grafik
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.GREEN);

    // Raylib.DrawRectangleRec(player.spriteBox, player.color);
           
    player.Draw();

    Raylib.EndDrawing();

}