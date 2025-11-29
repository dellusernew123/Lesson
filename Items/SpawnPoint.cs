using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Item _item;

    public bool IsEmpty
    {
        get
        {
            if (_item == null)
                return true;

            if (_item.gameObject == null)
                return true;

            return false;
        }
    }

    public Vector3 Position => transform.position;

    public void Occupy(Item item)
    {
        _item = item;
    }
}
