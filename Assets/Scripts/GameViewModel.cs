using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameViewModel", menuName = "Game View Model", order = 0)]
public class GameViewModel : ScriptableObject
{
    [SerializeField] int _coins;

    public int Coins
    {
        get => _coins;
        set
        {
            int previous = _coins;
            _coins = value;
            OnCoinsValueChanged?.Invoke(previous, _coins);
        }
    }

    public event Action<int, int> OnCoinsValueChanged;
}