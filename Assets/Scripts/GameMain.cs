using System;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] GameViewController _gameViewController;

    public Player Player => _player;

    GameViewModel _model;
    public event Action<int, int> OnCoinValueChanged;

    public struct GameInput
    {
        public float Horizontal;
        public float Vertical;
    };

    void Start()
    {
        if (_model == null)
        {
            _model = ScriptableObject.CreateInstance<GameViewModel>();
        }

        _player.OnCreated(this);
        _gameViewController.OnCreated(this);
    }

    void Update()
    {
        GameInput input = new GameInput
        {
            Horizontal = Input.GetAxis("Horizontal") * Time.deltaTime,
            Vertical = Input.GetAxis("Vertical") * Time.deltaTime
        };

        _player.OnUpdate(input);
    }

    void OnDestroy()
    {
        DestroyViewController(_gameViewController);
    }

    public void CollectCoin(Coin coin)
    {
        int previous = _model.Coins;
        _model.Coins += 1;
        OnCoinValueChanged?.Invoke(previous, _model.Coins);
        Destroy(coin.gameObject);
    }

    public void DestroyViewController(GameViewController viewController)
    {
        viewController.OnDestroyed();
        Destroy(viewController.gameObject);
    }
}