using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void HealthCountChange()
    {
        _healthbar.fillAmount = _player.Health / 100;
    }
}