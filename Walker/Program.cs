// Demonstrate our Walker class
using Raylib_cs;

public class Program
{
    const int screenWidth = 800;
    const int screenHeight = 450;

    public static void Main()
    {
        Raylib.InitWindow(screenWidth, screenHeight, "Walker");
        Raylib.SetTargetFPS(60);

        // Instantiate a new randon object. Which we will use to generate a random integer between n and m (inclusive of n, exclusive of m)
        Random random = new Random();

        // Instantiate a new Walker
        Walker drunk = new Walker(
            name: "Johnny",
            initialPosition: (screenWidth / 2, screenHeight / 2),
            color: (Color.White, "White"),
            bounds: (0, 0, screenWidth, screenHeight-30) // This gives us screenWidth * screenHeight unique positions to step. Here 800 * 450 = 360,000 unique steps.
                                                         // I did `screenHeight-30` after the fact to exclude the text area at the bottom, which will span the width of the window. 
            );

        // Our Walker's initial values (Where they start)
        drunk.Debug();

        // Draw the background here. Only once because we want to see our Walker's steps.
        Raylib.ClearBackground(Color.Black);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            {
                // On screen information - Demo purposes. mostly.
                Raylib.DrawText("Drunkard's walk", 10, 425, 20, Color.Green); 

                // Drow our random walker to the screen.
                drunk.Step();
            }
            Raylib.EndDrawing();

            // Apply a random vector to our next step
            drunk.NextStep(random.Next(-5, 6), random.Next(-5, 6));
        }

        // De-initialization
        Raylib.CloseWindow();
    }
}

