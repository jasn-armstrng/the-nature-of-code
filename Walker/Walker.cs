// This Class is the first in the quest to complete the above book in C#. Inspired by Wenzy.
using Raylib_cs;

/// <summary>
/// Step-wise paints pixels within a bounded 2D area using customizable movement vectors.
/// </summary>
/// <param name="name">The unique identifier or display name for this Walker.</param>
/// <param name="initialPosition">The starting coordinates (x, y) where the Walker begins.</param>
/// <param name="color">The visual appearance of the Walker, containing both the color value and a human-readable alias.</param>
/// <param name="bounds">The movement boundaries defined as (minX, minY, maxX, maxY) coordinates that constrain the Walker's position.</param>
/// <remarks>
/// Based on the Walker class from Daniel Shiffman's "Nature of Code", Chapter 0 - Randomness.
/// Unlike the original implementation, randomness is provided externally rather than being inherent to the walker.
/// Provides methods for customizing next step, stepping, and debugging functionality.
/// </remarks>
public class Walker(string name, (int x, int y) initialPosition, (Color value, string alias) color, (int minX, int minY, int maxX, int maxY) bounds)
{
    // Properties
    public string Name { get; set; } = name;
    public (int x, int y) Position { get; set; } = initialPosition;
    public (Color value, string alias) Colour { get; set; } = color;
    public (int minX, int minY, int maxX, int maxY) Bounds { get; set; } = bounds;

    /// <summary>
    /// Method <c>Debug</c> Print status information about the Walker to stdout. 
    /// </summary>
    public void Debug()
    {
        Console.WriteLine($"Walker: {Name}: position: ({Position.x}, {Position.y}),  colour: {Colour.alias}");
    }

    /// <summary>
    /// Method <c>NextStep</c> calculates and updates the Walker's position based on a vector. 
    /// </summary>
    public void NextStep(int xStep, int yStep)
    {
        // Calculate the Walker's next position. 
        (int x, int y) nextPosition = (Position.x + xStep, Position.y + yStep);

        // Constrain the Walker between the walking area bounds
        if (nextPosition.x < Bounds.minX) { nextPosition.x = Bounds.minX; }
        if (nextPosition.x > Bounds.maxX) { nextPosition.x = Bounds.maxX - 1; }

        if (nextPosition.y < Bounds.minY) { nextPosition.y = Bounds.minY; }
        if (nextPosition.y > Bounds.maxY) { nextPosition.y = Bounds.maxY - 1; }

        // Update the Walker's next position. Done this way because we can't modify the tuple Positions elements. Below we assign Position a new tuple.
        Position = nextPosition;
    }

    /// <summary>
    /// Method <c>Step</c> renders the Walker's position.
    /// </summary>
    public void Step()
    {
        Raylib.DrawPixel(Position.x, Position.y, Colour.value);
    }
}