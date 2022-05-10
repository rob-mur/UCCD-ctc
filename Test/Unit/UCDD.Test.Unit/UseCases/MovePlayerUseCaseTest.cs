using NUnit.Framework;
using UCDD.Core.UseCases.MovePlayer;
using UCDD.Test.Unit.Common.Builders.RequestBuilders;

namespace UCDD.Test.Unit.UseCases;

public class Tests
{
    private readonly MovePlayerUseCase _useCase;

    public Tests()
    {
        _useCase = new MovePlayerUseCase();
    }


    [Test]
    public void Velocity_should_follow_direction_right()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(1)
            .Velocity(0f)
            .Build();

        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.GreaterThan(0));
    }
    
    [Test]
    public void Velocity_should_follow_direction_left()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(-1)
            .Velocity(0f)
            .Build();

        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.LessThan(0));
    }
    
    [Test]
    public void Velocity_should_be_capped_at_speed()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(1)
            .Velocity(100f)
            .Speed(100f)
            .Build();

        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.EqualTo(100f));
    }
    
    [Test]
    public void Should_take_into_account_dt()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(1)
            .Velocity(0f)
            .DeltaTime(0.5f)
            .Speed(100f)
            .Build();

        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.LessThan(100f));
    }
    
    [Test]
    public void Should_take_into_account_acc()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(1)
            .Velocity(0f)
            .DeltaTime(0.5f)
            .Acceleration(500f)
            .Speed(100f)
            .Build();

        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.EqualTo(100f));
    }

    [Test]
    public void Should_decelerate_using_acc()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(0)
            .Velocity(100f)
            .Build();
        
        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.LessThan(100f));
    }
    
    [Test]
    public void Should_accelerate_double_if_against_grain()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(1)
            .Velocity(-100f)
            .DeltaTime(1f)
            .Acceleration(50f)
            .Build();
        
        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.EqualTo(0f));
    }
    
    [Test]
    public void Should_snap_to_zero()
    {
        var request = MovePlayerRequestBuilder.MovePlayer()
            .Direction(0)
            .Velocity(99f)
            .DeltaTime(1f)
            .Acceleration(100f)
            .Build();
        
        var response = _useCase.Handle(request);
        
        Assert.That(response.Velocity, Is.EqualTo(0f));
    }
    
}