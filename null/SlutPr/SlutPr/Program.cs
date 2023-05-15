global using Raylib_cs;
global using System.Numerics;
//spagettikoden är inspererad av Valve

Raylib.InitWindow(1500, 880, "spel");
Raylib.SetTargetFPS(60);

Player player = new();

Wizard wizard = new();

Rectangle textbox = new Rectangle(660, 700, 800, 900);

List<Room> rooms = new();

string scene = "start";

int roomIndex = 0;

Rectangle DoorDown = new Rectangle(0, 850, Raylib.GetScreenWidth(), 50);

Rectangle DoorUp = new Rectangle(0, 0, (int)Raylib.GetScreenWidth(), 50);

//Start of script


BuildTheLevel();

while (!Raylib.WindowShouldClose())
{
    Update();
    Render();
}

//Logik
void Update()
{
    
    if (Raylib.IsKeyDown(KeyboardKey.KEY_ZERO))
    {
        rooms[roomIndex].enemies.Clear();
        wizard.wizardstate = 1;
    }


    if (player.spriteBox.y < 0)
    {
        player.spriteBox.y = Raylib.GetScreenHeight() - player.spriteBox.height;
        roomIndex++;
        DoorDown.x = 10000;
    }

    if (Raylib.CheckCollisionRecs(player.spriteBox, wizard.wizardbox))
    {
        wizard.wizardstate = 1;
    }



    // Logik
    player.Update();
    // Flytta svärdets x till spelarens x
    // bool if enemy is dead= man kan gå vidare.

    if (rooms[roomIndex].enemies.Count == 0)
    {
        DoorUp.x = 10000;
    }
    else
    {
        DoorUp.x = 0;
    }

    if (player.spriteBox.y >= 800)
    {
        DoorDown.x = 10000;
    }
    else if (player.spriteBox.y < 700)
    {
        DoorDown.x = 0;
    }

    foreach (Enemy enemy in rooms[roomIndex].enemies)
    {
        enemy.Update(player);

        if (Raylib.CheckCollisionRecs(player.sword, enemy.enemybox) && Raylib.IsKeyPressed(KeyboardKey.KEY_J))
        {
            player.swordColor = Color.RED;
            enemy.enemyhp--;
        }


        if (enemy.enemyhp == 0)
        {
            enemy.enemyAlive = false;
        }



        // else { player.swordColor = Color.WHITE; }



        foreach (Rectangle wall in rooms[roomIndex].walls)
        {
            if (Raylib.CheckCollisionRecs(enemy.enemybox, wall))
            {
                enemy.enemybox.x = enemy.enemybefore.X;
                enemy.enemybox.y = enemy.enemybefore.Y;
            }
        }
    }

    rooms[roomIndex].enemies.RemoveAll(e => !e.enemyAlive);

    foreach (Rectangle wall in rooms[roomIndex].walls)
    {
        if (Raylib.CheckCollisionRecs(player.spriteBox, wall))
        {
            player.spriteBox.x = player.positionBefore.X;
            player.spriteBox.y = player.positionBefore.Y;
        }
    }
    if (Raylib.CheckCollisionRecs(player.spriteBox, DoorUp) || Raylib.CheckCollisionRecs(player.spriteBox, DoorDown))
    {
        player.spriteBox.x = player.positionBefore.X;
        player.spriteBox.y = player.positionBefore.Y;
    }
}



// grafik
void Render()
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.GREEN);
    foreach (Enemy enemy in rooms[roomIndex].enemies)
    {
        if (enemy.enemyAlive == true)
        {
            enemy.enemydraw();
        }
    }



    if (player.spriteBox.y < 0)
    {
        wizard.wizardisalive = false;
    }

    // if (Raylib.CheckCollisionRecs(player.spriteBox,wizard.wizardbox))
    // {

    // }


    Raylib.DrawRectangleRec(DoorUp, Color.BLACK);
    Raylib.DrawRectangleRec(DoorDown, Color.BLACK);
    foreach (Rectangle wall in rooms[roomIndex].walls)
    {
        Raylib.DrawRectangleRec(wall, Color.BLACK);
    }

    // Raylib.DrawRectangleRec(player.spriteBox, player.color);

    player.Draw();

    if (wizard.wizardisalive == true){ 
        wizard.wizarddraw();
    }
      Raylib.DrawText($"{roomIndex + 1}", 10, 10, 100, Color.WHITE);


    Raylib.EndDrawing();

}



void BuildTheLevel()
{
    Room room1 = new Room();
    room1.walls.Add(new Rectangle(0, 0, 50, 900));
    room1.walls.Add(new Rectangle(1450, 0, 50, 900));
    rooms.Add(room1);

    Room room2 = new();
    room2.enemies.Add(new Enemy(200, 200));
    room2.enemies.Add(new Enemy(1200, 200));
    room2.walls.Add(new Rectangle(0, 0, 50, 900));
    room2.walls.Add(new Rectangle(1450, 0, 50, 900));
    room2.walls.Add(new Rectangle(0, 440, 550, 10));
    room2.walls.Add(new Rectangle(1000, 440, 550, 10));
    rooms.Add(room2);

    Room room3 = new();
    room3.enemies.Add(new Enemy(300, 300));
    room3.enemies.Add(new Enemy(350, 200));
    room3.enemies.Add(new Enemy(1000, 200));
    room3.walls.Add(new Rectangle(0, 0, 50, 900));
    room3.walls.Add(new Rectangle(1450, 0, 50, 900));
    room3.walls.Add(new(500, 50, 40, 500));
    rooms.Add(room3);

    
    Room room4 = new();
    room4.enemies.Add(new Enemy(300, 300));
    room4.enemies.Add(new Enemy(350, 200));
    room4.enemies.Add(new Enemy(1000, 200));
    room4.enemies.Add(new Enemy(470, 170));
    room4.enemies.Add(new Enemy(560, 100));
    room4.walls.Add(new Rectangle(0, 0, 50, 900));
    room4.walls.Add(new Rectangle(1450, 0, 50, 900));
    room4.walls.Add(new(650, 180, 40, 500));
    room4.walls.Add(new(850, 180, 40, 500));
    rooms.Add(room4);

   
}

