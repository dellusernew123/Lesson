using UnityEngine;

public class ShootItem : Item
{
    [SerializeField] private float _throwingSpeed = 10;
    [SerializeField] private float _throwingObjectLivingDuration = 3;
    
    private bool _isMoving = false;
    private float _timer = 0;
    
    protected override void Use()
    {
        Throw();
    }

    protected override void Update()
    {
        base.Update();

        if (_isMoving == true)
            Move();
    }

    private void Throw()
    {
        transform.SetParent(null);
        transform.position = _player.transform.position;
        transform.rotation = _player.transform.rotation;
        _player.FreeArm();
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
