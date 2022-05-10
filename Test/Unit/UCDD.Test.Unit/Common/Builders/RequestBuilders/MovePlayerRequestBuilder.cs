
namespace UCDD.Test.Unit.Common.Builders.RequestBuilders;

public class MovePlayerRequestBuilder
{
    private const int DefaultDirection = 0;
    private const float DefaultVelocity = 0f;
    private const float DefaultSpeed = 100f;
    private const float DefaultDeltaTime = 0.02f;
    private const float DefaultAcceleration = 50f;

    private int _direction;
    private float _velocity;
    private float _speed;
    private float _dt;
    private float _acc;

    public static MovePlayerRequestBuilder MovePlayer()
    {
        return new MovePlayerRequestBuilder();
    }
    
    public MovePlayerRequestBuilder()
    {
        _direction = DefaultDirection;
        _velocity = DefaultVelocity;
        _speed = DefaultSpeed;
        _dt = DefaultDeltaTime;
        _acc = DefaultAcceleration;
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
    
    public MovePlayerRequestBuilder Speed(float speed)
    {
        _speed = speed;
        return this;
    }
    
    public MovePlayerRequestBuilder DeltaTime(float dt)
    {
        _dt = dt;
        return this;
    }
    
    public MovePlayerRequestBuilder Acceleration(float acc)
    {
        _acc = acc;
        return this;
    }

    public MovePlayerRequest Build()
    {
        return new MovePlayerRequest
        {
            Direction = _direction,
            Velocity = _velocity,
            Speed = _speed,
            DeltaTime = _dt,
            Acceleration = _acc
        };
    }


    
}