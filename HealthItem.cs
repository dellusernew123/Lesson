using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private int _healthAdd = 50;

    protected override void Use()
    {
        Heal();
    }

    private void Heal()
    {
        _player.AddHealth(_healthAdd);
        ActivateParticle();
        _player.FreeArm();
        
        Destroy(gameObject, 1);
    }
}
