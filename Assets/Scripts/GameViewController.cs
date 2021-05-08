using UnityEngine;

public class GameViewController : MonoBehaviour
{
    [SerializeField] HealthPanel _playerHealthPanel;
    [SerializeField] CoinCounterPanel _coinCounterPanel;

    public void Start()
    {
        GameMain gameMain = FindObjectOfType<GameMain>();
        gameMain.InitializeGameViewController(this);
    }
    
    public void OnCreated(Health playerHealth, GameViewModel model)
    {
        _playerHealthPanel.OnCreated(playerHealth);
        _coinCounterPanel.OnCreated(model);
    }
}