namespace UCDD.Core.UseCases.MovePlayer;

public class MovePlayerUseCase : IUseCase<MovePlayerRequest, MovePlayerResponse>
{
    public MovePlayerResponse Handle(MovePlayerRequest request)
    {
        return new MovePlayerResponse
        {
            Velocity = 1f
        };
    }
}