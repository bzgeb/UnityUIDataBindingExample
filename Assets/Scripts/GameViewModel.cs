using UnityEngine;

[CreateAssetMenu(fileName = "NewGameViewModel", menuName = "Game View Model", order = 0)]
public class GameViewModel : ScriptableObject
{
    public ObservableVariable<int> _coins = new ObservableVariable<int>();
}