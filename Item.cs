using Unity.Burst.Intrinsics;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected PlayerController _player;

    private ParticleSystem _particle;
    private Transform _arm;

    private bool _isItemEquipped = false;
    private bool _isButtonPressed = false;

    private void Start()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider playerCollider)
    {
        if (_isItemEquipped == true)
            return;

        FindPlayer(playerCollider);

        if (_player == null)
            return;

        if (IsArmFree() == true)
            Equip();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isItemEquipped == true && _isButtonPressed == false)
        {
            _isButtonPressed = true;
            Use();
        }
    }

    private void FindPlayer(Collider playerCollider)
    {
        PlayerController player = playerCollider.GetComponentInParent<PlayerController>();

        if (player == null)
            return;

        _player = player;
    }


    private void Equip()
    {
        transform.SetParent(_arm.transform, worldPositionStays: false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        _player.ReserveArm();
        _isItemEquipped = true;
    }

    private bool IsArmFree()
    {
        if (_player.IsArmReserved == true)
            return false;

        _arm = _player.transform.Find("Arm");

        return _arm != null;
    }

    protected abstract void Use();
    
    protected void ActivateParticle()
    {
        _particle.Play();
    }
}
