using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    Health _health;

    [SerializeField] Image _fillImage;

    public void OnCreated(Health health)
    {
        _health = health;
        _health.OnHealthChanged += OnHealthChanged;
    }

    void OnDestroy()
    {
        _health.OnHealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(int previous, int current)
    {
        float scale = current / (float) _health.MaxHealth;
        _fillImage.rectTransform.localScale = new Vector3(scale, 1f, 1f);
    }
}