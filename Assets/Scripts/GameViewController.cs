using UnityEngine;

public class GameViewController : MonoBehaviour
{
    [SerializeField] HealthPanel _playerHealthPanel;
    [SerializeField] CoinCounterPanel _coinCounterPanel;
    
    public void OnCreated(Health playerHealth, GameViewModel model)
    {
        _playerHealthPanel.OnCreated(playerHealth);
        _coinCounterPanel.OnCreated(model);
    }
}