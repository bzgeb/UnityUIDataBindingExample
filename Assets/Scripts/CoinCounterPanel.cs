using UnityEngine;
using UnityEngine.UI;

public class CoinCounterPanel : MonoBehaviour
{
    GameViewModel _model;

    [SerializeField] Text _text;

    public void OnCreated(GameViewModel model)
    {
        _model = model;
        _model._coins.OnValueChanged += OnCoinCountChanged;
        OnCoinCountChanged(_model._coins.Value, _model._coins.Value);
    }

    void OnDestroy()
    {
        _model._coins.OnValueChanged -= OnCoinCountChanged;
    }

    void OnCoinCountChanged(int previous, int current)
    {
        _text.text = $"Coins: {current}";
    }
}