
public class MovePlayerRequest
{
    public int Direction { get; set; }
    public float Velocity { get; set; }
    
    public float Speed { get; set; }
    public float DeltaTime { get; set; }
    public float Acceleration { get; set; }
}