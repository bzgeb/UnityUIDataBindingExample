using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Health _health;

    public void OnCreated()
    {
        _health.OnCreated();
    }
}