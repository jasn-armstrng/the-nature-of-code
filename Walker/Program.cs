

// Think about how this can be part of a game development pipeline/backend.
// What is good API design here. 

using Raylib_cs;

// Initialization
const int screenWidth = 800;
const int screenHeight = 450;

Raylib.InitWindow(screenWidth, screenHeight, "Walker");
Raylib.SetTargetFPS(60);

// Instantiate a new randon object. Which we will use to generate a random integer between n and m (inclusive of n, exclusive of m)
// that will be applied to the x and y of our walker's step vector.
Random stagger = new(); // Previously new Random(). Now using target-typed new expressions to simplify object creation when the type can be inferred from the context. C# 9.0+ 

// Instantiate a new walker - Our drunk
Walker drunk = new(
    name: "Johnny",
    initialPosition: (screenWidth / 2, screenHeight / 2),
    color: (Color.White, "White"),
    bounds: (0, 0, screenWidth, screenHeight-30) // This gives us screenWidth * screenHeight unique positions to step. Here 800 * 450 = 360,000 unique steps.
                                                 // I did `screenHeight-30` after the fact to exclude the text area at the bottom, which will span the width of the window. 
    );

// Announce our walker to the stage
drunk.Debug();

// Draw the background here
Raylib.ClearBackground(Color.Black);

// Main game loop
while (!Raylib.WindowShouldClose()) // Becomes false when the window is closed by user action
{
    // Question: What should stay out here?

    // Question: What is does it mean to draw stuff on the screen? 
    Raylib.BeginDrawing();
    {
        // What can be drawn in here?

        // Don't redraw background because we want to see steps. 
        // We need to consider memory usage here. Each step drawn is data kept in memory.
        // Questions: 
        //  - 1. How much steps should we be storing for good performance and artistic aesthetic?
        //  - 2. What data structure should be use to store the steps? I'm thinking something that does FIFO; getting rid of older steps first.
        //  - 3. How much memory is needed to store a coloured pixel at a position?
        //  - 4. How do we managing more walkers and their steps? 

        // Start by drawing our walker at starting point defined at initialisation
        drunk.Paint();

        // On screen information
        Raylib.DrawText("Drunkard's walk", 10, 425, 20, Color.Green); 
    }
    Raylib.EndDrawing();

    // Next step is random.
    // If we have more drunks and we want a unique random x, y for each, is using the pattern below the best approach?
    drunk.Step(stagger.Next(-5, 6), stagger.Next(-5, 6));
}

// De-initialization
Raylib.CloseWindow();