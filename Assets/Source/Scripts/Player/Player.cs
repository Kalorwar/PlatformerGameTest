using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable, IGroundChecker
{
    public Action OnDie;
    private float _maxHealth;
    private PlayerHealthUI _playerHealthUI;
    
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
    public Rigidbody2D Rigidbody { get; private set; }
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _maxHealth = Health;
        _playerHealthUI = GetComponent<PlayerHealthUI>();
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

    public void Healing(float healingValue)
    {
        if (Health < _maxHealth)
            Health += healingValue;
        
        if (Health > _maxHealth)
            Health = _maxHealth;
        
        _playerHealthUI.HealthCountChange();
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

        if (Health < 0)
            Health = 0;
        
        _playerHealthUI.HealthCountChange();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}