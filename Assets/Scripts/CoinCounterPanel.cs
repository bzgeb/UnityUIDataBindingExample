using UnityEngine;
using UnityEngine.UI;

public class CoinCounterPanel : MonoBehaviour
{
    GameViewModel _model;

    [SerializeField] Text _text;

    public void OnCreated(GameViewModel model)
    {
        _model = model;
        _model.OnCoinsValueChanged += OnCoinCountChanged;
    }

    void OnDestroy()
    {
        _model.OnCoinsValueChanged -= OnCoinCountChanged;
    }

    void OnCoinCountChanged(int previous, int current)
    {
        _text.text = $"Coins: {current}";
    }
}