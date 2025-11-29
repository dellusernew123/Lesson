using UnityEngine;

public class ShootItem : Item
{
    [SerializeField] private float _throwingSpeed = 10;
    [SerializeField] private float _throwingObjectLivingDuration = 3;

    PlayerExtra _playerExtra;
    
    private bool _isMoving = false;
    private float _timer = 0;
    
    public override void Use(GameObject player)
    {
        _playerExtra = player.GetComponent<PlayerExtra>();
        Throw();
    }

    private void Update()
    {
        if (_isMoving == true)
            Move();
    }

    private void Throw()
    {
        transform.SetParent(null);
        transform.position = _playerExtra.transform.position;
        transform.rotation = _playerExtra.transform.rotation;
        _playerExtra.FreeArm();
        IsItemEquipped = false;

        ActivateParticle();

        _isMoving = true;
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _throwingSpeed * Time.deltaTime);

            if (_timer >= _throwingObjectLivingDuration)
            {
                _isMoving = false;
                _timer = 0;
                Destroy(gameObject);
                return;
            }

        _timer += Time.deltaTime;
    }
}
