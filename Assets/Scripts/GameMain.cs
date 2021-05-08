using System;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] GameViewController _gameViewController;

    [SerializeField] GameViewModel _model;

    public static event Action<GameViewController> OnGameViewControllerCreated;

    public struct GameInput
    {
        public float Horizontal;
        public float Vertical;
    };

    void Awake()
    {
        if (_model == null)
        {
            _model = ScriptableObject.CreateInstance<GameViewModel>();
        }

        _player.OnCreated(this);
        //_gameViewController.OnCreated(_player.Health, _model);
        OnGameViewControllerCreated += InitializeGameViewController;
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
        OnGameViewControllerCreated -= InitializeGameViewController;
    }

    public static void NotifyGameViewControllerWasCreated(GameViewController gameViewController)
    {
        OnGameViewControllerCreated?.Invoke(gameViewController);
    }

    void InitializeGameViewController(GameViewController gameViewController)
    {
        gameViewController.OnCreated(_player.Health, _model);
    }

    public void CollectCoin(Coin coin)
    {
        _model._coins.Value += 1;
        Destroy(coin.gameObject);
    }
}