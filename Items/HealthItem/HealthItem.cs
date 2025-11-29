using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private int _healthAdd = 50;

    private PlayerHealth _playerHealth;
    private PlayerExtra _playerExtra;

    public override void Use(GameObject player)
    {
        _playerExtra = player.GetComponent<PlayerExtra>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        Heal();
    }

    private void Heal()
    {
        _playerHealth.AddHealth(_healthAdd);
        ActivateSeparateParticle();
        
        Destroy(gameObject);
        _playerExtra.FreeArm();
        IsItemEquipped = false;
    }
}
