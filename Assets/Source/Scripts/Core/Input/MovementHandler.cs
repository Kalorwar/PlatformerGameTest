using System;
using UnityEngine;

public class MovementHandler : IDisposable
{
    private IInput _input;
    private IMovable _movable;
    private IGroundChecker _groundChecker;

    public MovementHandler(IInput input, IMovable movable, IGroundChecker groundChecker)
    {
        _input = input;
        _movable = movable;
        _groundChecker = groundChecker;

        _input.OnClickLeft += ClickLeft;
        _input.OnClickRight += ClickRight;
        _input.OnClickUp += ClickUp;
    }
    
    public void Dispose()
    {
        _input.OnClickUp -= ClickUp;
        _input.OnClickLeft -= ClickLeft;
        _input.OnClickRight -= ClickRight;
    }

    private void ClickRight()
    {
        _movable.Rigidbody.velocity = new Vector2(1 * _movable.Speed, _movable.Rigidbody.velocity.y);
    }

    private void ClickLeft()
    {
        _movable.Rigidbody.velocity = new Vector2(-1 * _movable.Speed, _movable.Rigidbody.velocity.y);
    }

    private void ClickUp()
    {
        if(_groundChecker.IsGround) 
            _movable.Rigidbody.velocity = new Vector2(_movable.Rigidbody.velocity.x, 1 * _movable.JumpForce);
    }
}