using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable, IGroundChecker, IHitable
{
    public event Action OnDie;
    
    [Inject]
    private void Constructor(PlayerConfig playerConfig)
    {
        Speed = playerConfig.Speed;
        JumpForce = playerConfig.JumpForce;
        Health = playerConfig.Health;
    }
    
    public float Speed { get; private set; }
    public float JumpForce { get; private set; }
    public float Health { get; private set; }
    public bool IsGround { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }


    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Ground ground))
            IsGround = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Ground ground))
        {
            IsGround = false;
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Health -= damage;
            if (Health <= 0)
                Die();
        }
        else
        {
            throw new ArgumentException("Damage must be positive");
        }
    }

    private void Die()
    {
        OnDie?.Invoke();
    }
}

public interface IHitable
{
    public void TakeDamage(float damage);
    public event Action OnDie;
}