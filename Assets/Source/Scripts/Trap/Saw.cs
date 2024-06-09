using UnityEngine;
using DG.Tweening;

public class Saw : Trap
{
    [SerializeField] private DirectionMove _directionMove;
    [SerializeField] private float _moveX;
    [SerializeField] private float _moveY;
    [SerializeField] private float _speed;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        Move();
    }

    private void Move()
    {
        switch (_directionMove)
        {
            case DirectionMove.Horizontal:
                transform.DOMoveX((_startPosition.x + _moveX), _speed).SetLoops(-1, LoopType.Yoyo);
                break;
            case DirectionMove.Vertical:
                transform.DOMoveY((_startPosition.y + _moveY), _speed).SetLoops(-1, LoopType.Yoyo);
                break;
        }
    }
}

public enum DirectionMove
{
    Horizontal,
    Vertical
}