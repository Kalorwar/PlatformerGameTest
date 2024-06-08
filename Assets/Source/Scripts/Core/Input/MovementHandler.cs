using System;
using UnityEngine;

public class MovementHandler : IDisposable
{
    private IInput _input;
    private IMovable _movable;

    public MovementHandler(IInput input, IMovable movable)
    {
        _input = input;
        _movable = movable;

        _input.OnClickLeft += ClickLeft;
        _input.OnClickRight += ClickRight;
        _input.OnClickUp += ClickUp;
        _input.OnClickDown += ClockDown;
    }
    
    public void Dispose()
    {
        _input.OnClickUp -= ClickUp;
        _input.OnClickLeft -= ClickLeft;
        _input.OnClickRight -= ClickRight;
    }

    private void ClickRight()
    {
        _movable.Rigidbody2D.velocity = new Vector2(1 * _movable.Speed, _movable.Rigidbody2D.velocity.y);
    }

    private void ClickLeft()
    {
        _movable.Rigidbody2D.velocity = new Vector2(-1 * _movable.Speed, _movable.Rigidbody2D.velocity.y);
    }

    private void ClickUp()
    {
        _movable.Rigidbody2D.velocity = new Vector2(_movable.Rigidbody2D.velocity.x, 1 * _movable.JumpForce);
    }

    private void ClockDown()
    {
        _movable.Rigidbody2D.velocity = new Vector2(_movable.Rigidbody2D.velocity.x, -1);
    }
}