global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1500, 880, "spel");
Raylib.SetTargetFPS(60);

float speed = 3.2f;
Player player = new();
List<Enemy> enemies = new();
enemies.Add(new Enemy());
string scene = "start";
bool isOverlapping = false;


while (!Raylib.WindowShouldClose())
{
    // Logik
    // skapa en rectangel 

    player.state = 0;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        player.dire = Player.Direction.left;
        player.state = 1;
        player.spriteBox.x -= speed;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
        player.dire = Player.Direction.right;
        player.state = 1;
        player.spriteBox.x += speed;

    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        player.dire = Player.Direction.up;
        player.state = 1;
        player.spriteBox.y -= speed;

    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))

    {
        player.dire = Player.Direction.dow;
        player.state = 1;
        player.spriteBox.y += speed;
    }

    foreach (Enemy enemy in enemies)
    {
        enemy.Update(player);

        if (Raylib.CheckCollisionRecs(player.sword, enemy.enemybox))
        {
            isOverlapping = true;
        }
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_J) && isOverlapping == true)
    {
        Console.WriteLine("HIT");
        player.swordColor = Color.RED;
    }
    else
    {
        player.swordColor = Color.PINK;
    }
    // om y postion visst värde gör det här!!!!!!

    // grafik
    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.GREEN);
        foreach (Enemy enemy in enemies)
        {
            enemy.enemydraw();

        }
    }

    if (scene == "game")
    {
        Raylib.ClearBackground(Color.GREEN);
    }

    // Raylib.DrawRectangleRec(player.spriteBox, player.color);

    player.Draw();



    Raylib.EndDrawing();

}