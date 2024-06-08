using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable
{
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
    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
}