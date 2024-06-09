using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Action OnWin;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlayerKeyCountUI player) && player.KeyAmount == 5)
        {
            OnWin?.Invoke();
        }
    }
}