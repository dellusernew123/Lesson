using UnityEngine;

public class SpeedBoosterItem : Item
{
    [SerializeField] private float _speedBoostTimeDuration = 10;
    [SerializeField] private float _speedMultiplier = 2;

    private bool _isSpeedBoostTimerWorking = false;
    private float _timer = 0;
    private PlayerController _playerController;
    private PlayerExtra _playerExtra;

    public override void Use(GameObject player)
    {
        _playerController = player.GetComponent<PlayerController>();
        _playerExtra = player.GetComponent<PlayerExtra>();

        ApplyBoost();
    }

    private void Update()
    {
        if (_isSpeedBoostTimerWorking == true)
            UpdateTimer();
    }

    private void ApplyBoost()
    {
        _playerController.MultiplySpeed(_speedMultiplier);
        _isSpeedBoostTimerWorking = true;

        ActivateParticle();
    }

    private void UpdateTimer()
    {
        if (_timer >= _speedBoostTimeDuration)
        {
            _isSpeedBoostTimerWorking = false;
            _playerController.MultiplySpeed(1);
            _playerExtra.FreeArm();
            IsItemEquipped = false;

            Destroy(gameObject);
        }

        _timer += Time.deltaTime;
    }
}
