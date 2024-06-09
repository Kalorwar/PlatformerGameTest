using System;
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

    private void Update()
    {
        Falling();
    }

    private void OnEnable()
    {
        _input.OnClickLeft += ClickLeft;
        _input.OnClickRight += ClickRight;
        _input.OnButtonUp += ButtonUp;
        _input.OnClickUp += Jump;
    }

    private void OnDisable()
    {
        _input.OnClickLeft -= ClickLeft;
        _input.OnClickRight -= ClickRight;
        _input.OnButtonUp -= ButtonUp;
        _input.OnClickUp -= Jump;
    }

    private void ClickRight()
    {
        _spriteRenderer.flipX = false;
        _velocity = 1;
        _velocity = Math.Clamp(_velocity, 0, 1);
        _animator.SetFloat(AssetsPath.AnimationPath.Velocity, _velocity);
    }

    private void ClickLeft()
    {
        _spriteRenderer.flipX = true;
        _velocity = 1;
        _velocity = Math.Clamp(_velocity, 0, 1);
        _animator.SetFloat(AssetsPath.AnimationPath.Velocity, _velocity);
    }
    
    private void ButtonUp()
    {
        _velocity = 0;
        _animator.SetFloat(AssetsPath.AnimationPath.Velocity, _velocity);
    }
    
    private void Falling()
    {
        if (_player.IsGround)
        {
            _animator.SetBool(AssetsPath.AnimationPath.IsFalling, false);
            _animator.SetBool(AssetsPath.AnimationPath.IsJump, false);
        }
        else
        {
            _animator.SetBool(AssetsPath.AnimationPath.IsFalling, true);
        }
    }

    private void Jump()
    {
        _animator.SetBool(AssetsPath.AnimationPath.IsJump, true);
    }
}