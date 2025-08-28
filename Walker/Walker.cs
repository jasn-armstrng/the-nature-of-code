using Raylib_cs;

// Define the Walker class.
// TODO:
// - 1. Write a class description. [Keyword there is description, lean into the meaning of the word].
//      Write the same description in Balkan. 
// - 2. Move to a Walker.cs file. It makes sense to have one class per file because it's easy to do side by side comparisons of the contents.
// - 3. Document methods
public class Walker
{
    // Properties
    public string Name { get; set; } // For identification in the program
    public (int x, int y) Position { get; set; }
    public (Color value, string alias) Colour { get; set; } // Also for identification
    public (int minX, int minY, int maxX, int maxY) Bounds { get; set; } // The walkable area  

    // Constructor to initialize the object
    public Walker(string name, (int x, int y) initialPosition, (Color value, string alias) colour, (int minX, int minY, int maxX, int maxY) bounds)
    {
        Name = name;
        Position = initialPosition;
        Colour = colour;
        Bounds = bounds;
    }

    // Debug info for now
    public void StartWalker()
    {
        Console.WriteLine($"{Name} has started at position {Position.x},{Position.y}, wearing {Colour.alias}.");
    }

    public void Step(int xStep, int yStep)
    {
        // Calculate its new position 
        (int x, int y) newPosition = (Position.x + xStep, Position.y + yStep);

        // Keep the walker between the walking area bounds
        if (newPosition.x < Bounds.minX) { newPosition.x = Bounds.minX; }
        if (newPosition.x > Bounds.maxX) { newPosition.x = Bounds.maxX - 1; }

        if (newPosition.y < Bounds.minY) { newPosition.y = Bounds.minY; }
        if (newPosition.y > Bounds.maxY) { newPosition.y = Bounds.maxY - 1; }

        // Update its position
        Position = newPosition;
    }

    // Draw the walker to the screen
    public void Show()
    {
        Raylib.DrawPixel(Position.x, Position.y, Colour.value);
    }
}