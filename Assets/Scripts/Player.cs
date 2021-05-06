using UnityEngine;

public class Player : MonoBehaviour
{
    GameMain _gameMain;

    [SerializeField] Health _health;
    public Health Health => _health;

    [SerializeField] CharacterController _characterController;

    [SerializeField] float _moveSpeed = 10f;

    public void OnCreated(GameMain gameMain)
    {
        _gameMain = gameMain;
        _health.OnCreated();
    }

    public void OnUpdate(GameMain.GameInput input)
    {
        _characterController.Move(new Vector3(input.Horizontal * _moveSpeed, 0f, input.Vertical * _moveSpeed));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHurtbox"))
        {
            _health.TakeDamage(10);
        }
        else if (other.CompareTag("Coin"))
        {
            if (other.TryGetComponent(out Coin coin))
            {
                _gameMain.CollectCoin(coin);
            }
        }
    }
}