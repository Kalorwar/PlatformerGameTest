using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlayerKeyCountUI player))
        {
            player.KeyCountChange();
            Destroy(gameObject);
        }
    }
}