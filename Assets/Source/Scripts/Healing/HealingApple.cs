using System;
using UnityEngine;

public class HealingApple : MonoBehaviour
{
    [SerializeField] private float _healingValue;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.Healing(_healingValue);
            Destroy(gameObject);
        }
    }
}