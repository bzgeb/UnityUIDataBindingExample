using UnityEngine;

public class GameViewController : MonoBehaviour
{
    [SerializeField] HealthPanel _playerHealthPanel;
    [SerializeField] CoinCounterPanel _coinCounterPanel;

    public void OnCreated(GameMain gameMain)
    {
        _playerHealthPanel.OnCreated(gameMain.Player.Health);
        _coinCounterPanel.OnCreated(gameMain);
    }

    public void OnDestroyed()
    {
        _playerHealthPanel.OnDestroyed();
        _coinCounterPanel.OnDestroyed();
    }
}