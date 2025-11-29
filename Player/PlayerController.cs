using System.Drawing;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _rotationSpeed;

    private float _speed;
    
    private CharacterController _characterController;
    private float _deadZone = 0.1f;

    private void Start()
    {
        _speed = _baseSpeed;
        
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));

        if (input.magnitude <= _deadZone)
            return;

        _characterController.Move(input.normalized * _speed * Time.deltaTime);
        RotateTowards(input.normalized);
    }

    private void RotateTowards(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookRotation, step);
    }

    public void MultiplySpeed(float speedMultiplier)
    {
        _speed = _baseSpeed * speedMultiplier;
    }
}
