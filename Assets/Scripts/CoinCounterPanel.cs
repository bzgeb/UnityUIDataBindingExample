using UnityEngine;
using UnityEngine.UI;

public class CoinCounterPanel : MonoBehaviour
{
    GameMain _gameMain;

    [SerializeField] Text _text;

    public void OnCreated(GameMain gameMain)
    {
        _gameMain = gameMain;
        _gameMain.OnCoinValueChanged += OnCoinCountChanged;
    }

    public void OnDestroyed()
    {
        _gameMain.OnCoinValueChanged -= OnCoinCountChanged;
    }

    void OnCoinCountChanged(int previous, int current)
    {
        _text.text = $"Coins: {current}";
    }
}