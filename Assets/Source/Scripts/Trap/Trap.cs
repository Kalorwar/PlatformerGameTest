using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private protected float _damage;

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}