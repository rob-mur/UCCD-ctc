using System;
using NUnit.Framework;
using UCDD.Core.UseCases;
using UCDD.Core.UseCases.MovePlayer;
using UCDD.Test.Unit.Common.Builders.RequestBuilders;
using static NUnit.Framework.Interfaces.TestStatus;

namespace UCDD.Test.Unit.UseCases;

public class Tests
{
    private readonly MovePlayerUseCase _useCase;

    public Tests()
    {
        _useCase = new MovePlayerUseCase();
    }


    [Test]
    public void Velocity_should_follow_direction()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(1)
            .Velocity(0f)
            .Build();

        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.GreaterThan(0));
    }

}