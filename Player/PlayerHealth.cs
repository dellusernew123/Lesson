using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _health;

    private void Start()
    {
        _health = _maxHealth;
    }
    
    public void AddHealth(int addedHealth)
    {
        int newHealth = _health + addedHealth;

        if (newHealth > _maxHealth)
            _health = _maxHealth;
        else
            _health = newHealth;
    }
}
