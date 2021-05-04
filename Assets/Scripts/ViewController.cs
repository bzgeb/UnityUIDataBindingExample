using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] HealthPanel _playerHealthPanel;
    
    public void OnCreated()
    {
        _playerHealthPanel.OnCreated();
    }
}
