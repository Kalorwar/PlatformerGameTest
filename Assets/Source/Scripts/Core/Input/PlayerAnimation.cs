using UnityEngine;
using Zenject;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Player _player;
    private IInput _input;
    private float _velocity;
    
    [Inject]
    private void Constructor(IInput input)
    {
        _input = input;
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }
}