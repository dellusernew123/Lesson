using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _arm;
    private PlayerExtra _playerExtra;
    private Item _item;

    private bool _isButtonPressed = false;

    private void Start()
    {
        _playerExtra = GetComponent<PlayerExtra>();
    }

    private void OnTriggerEnter(Collider itemCollider)
    {
        Item newItem = itemCollider.GetComponent<Item>();

        if (newItem == null)
            return;

        if (_item != null && _item.IsItemEquipped == true)
            return;

        if (IsArmFree())
        {
            _item = newItem;
            Equip();
        };
    }

    private void Update()
    {
        if (_item != null)
            if (Input.GetKeyDown(KeyCode.F) && _item.IsItemEquipped == true && _isButtonPressed == false)
            {
                _isButtonPressed = true;
                _item.Use(gameObject);
            }
    }

    private bool IsArmFree()
    {
        if (_playerExtra.IsArmReserved == true)
            return false;

        return _arm != null;
    }

    private void Equip()
    {
        _item.transform.SetParent(_arm.transform, worldPositionStays: false);
        _item.transform.localPosition = Vector3.zero;
        _item.transform.localRotation = Quaternion.identity;
        _isButtonPressed = false;

        _playerExtra.ReserveArm();
        _item.EquipItem();
    }
}
