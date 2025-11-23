using UnityEngine;

public class SpeedBoosterItem : Item
{
    [SerializeField] private float _speedBoostTimeDuration = 10;
    [SerializeField] private float _speedMultiplier = 2;

    private bool _isSpeedBoostTimerWorking = false;
    private float _timer = 0;

    protected override void Use()
    {
        ApplyBoost();
    }

    protected override void Update()
    {
        base.Update();

        if (_isSpeedBoostTimerWorking == true)
            UpdateTimer();
    }

    private void ApplyBoost()
    {
        _player.MultiplySpeed(_speedMultiplier);
        _isSpeedBoostTimerWorking = true;

        ActivateParticle();
    }

    private void UpdateTimer()
    {
        if (_timer >= _speedBoostTimeDuration)
        {
            _isSpeedBoostTimerWorking = false;
            _player.MultiplySpeed(1);
            _player.FreeArm();
            Destroy(gameObject);
        }

        _timer += Time.deltaTime;
    }
}
