namespace Better.Way.To.Configure.EFCore.Models;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = null!;
    public string Company { get; set; } = null!;
}