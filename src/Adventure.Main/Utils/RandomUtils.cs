using Adventure.Main.Utils.Interfaces;

namespace Adventure.Main.Utils;

public class RandomUtils : IRandomUtils 
{
    private Random Random { get; } = new();
    
    public float NextFloat(float min, float max)
    { 
        var val = this.Random.NextDouble() * (max - min) + min;
        
        return (float)val;
    }
}