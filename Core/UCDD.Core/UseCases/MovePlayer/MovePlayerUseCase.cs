
using Godot;

namespace UCDD.Core.UseCases.MovePlayer
{
    public class MovePlayerUseCase : IUseCase<MovePlayerRequest, MovePlayerResponse>
    {
        public MovePlayerResponse Handle(MovePlayerRequest request)
        {
            var currentMoveDirection = Mathf.Sign(request.Velocity);
            var newMoveDirection = request.Direction == 0 ? -currentMoveDirection : request.Direction;
            var againstGrainFactor = currentMoveDirection != newMoveDirection && request.Direction != 0 ? 2f : 1f;
            var minSpeedFactor = 1f;
            var maxSpeedFactor = 1f;
            if (request.Direction == 0f)
            {
                minSpeedFactor = currentMoveDirection == 1 ? 0f : 1f;
                maxSpeedFactor = currentMoveDirection == -1 ? 0f : 1f;
            }
                
            return new MovePlayerResponse
            {
                Velocity = Mathf.Clamp(request.Velocity + newMoveDirection * request.Acceleration * request.DeltaTime * againstGrainFactor, -request.Speed * minSpeedFactor, request.Speed * maxSpeedFactor)
            };
        }
    }
}