
namespace UCDD.Test.Unit.Common.Builders.RequestBuilders;

public class MovePlayerRequestBuilder
{
    private const int DefaultDirection = 0;
    private const float DefaultVelocity = 0f;

    private int _direction;
    private float _velocity;

    public static MovePlayerRequestBuilder MovePlayer()
    {
        return new MovePlayerRequestBuilder();
    }
    
    public MovePlayerRequestBuilder()
    {
        _direction = DefaultDirection;
        _velocity = DefaultVelocity;

    }

    public MovePlayerRequestBuilder Direction(int direction)
    {
        _direction = direction;
        return this;
    }

    public MovePlayerRequestBuilder Velocity(float velocity)
    {
        _velocity = velocity;
        return this;
    }

    public MovePlayerRequest Build()
    {
        return new MovePlayerRequest
        {
            Direction = _direction,
            Velocity = _velocity
        };
    }
    
}