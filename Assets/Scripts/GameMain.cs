using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] GameViewController _gameViewController;

    GameViewModel _model;

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
        _gameViewController.OnCreated(_player.Health, _model);
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

    public void CollectCoin(Coin coin)
    {
        _model.Coins += 1;
        Destroy(coin.gameObject);
    }
}