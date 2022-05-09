using System;
using Godot;

namespace UCDD.Infrastructure.Engine.game.player
{
    public class Player : KinematicBody2D
    {
        private readonly MovePlayerUseCase _movePlayer;
        private int _direction;
        private Vector2 _velocity;

        public Player()
        {
            _movePlayer = new MovePlayerUseCase();
        }

        public override void _Input(InputEvent @event)
        {
            _direction = Convert.ToInt16(Input.IsActionPressed("ui_right")) - Convert.ToInt16(Input.IsActionPressed("ui_left"));
        }

        public override void _PhysicsProcess(float delta)
        {
            var response = _movePlayer.Handle(new MovePlayerRequest
            {
                Direction = _direction,
                Velocity = _velocity.x
            });

            _velocity = MoveAndSlide(new Vector2(response.Velocity, _velocity.y));
        }
    }
}
