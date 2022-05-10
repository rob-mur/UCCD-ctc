
using Godot;

public class MovePlayerUseCase : IUseCase<MovePlayerRequest, MovePlayerResponse>
{
    public MovePlayerResponse Handle(MovePlayerRequest request)
    {
        var sign = request.Direction == 0 ? -Mathf.Sign(request.Velocity) : request.Direction;
        return new MovePlayerResponse
        {
            Velocity = Mathf.Clamp(request.Velocity + sign * request.Acceleration * request.DeltaTime, -request.Speed, request.Speed)
        };
    }
}