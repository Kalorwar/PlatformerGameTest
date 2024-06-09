using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneService : MonoBehaviour
{
    private Player _player;
    private Finish _finish;

    [Inject]
    private void Constructor(Player player, Finish finish)
    {
        _player = player;
        _finish = finish;
    }

    private void OnEnable()
    {
        _player.OnDie += Restart;
        _finish.OnWin += Restart;
    }

    private void OnDisable()
    {
        _player.OnDie -= Restart;
        _finish.OnWin -= Restart;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}