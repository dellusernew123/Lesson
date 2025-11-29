using UnityEngine;

public class PlayerExtra : MonoBehaviour
{
    public bool IsArmReserved { get; private set; } = false;
    
    public void ReserveArm() => IsArmReserved = true;

    public void FreeArm() => IsArmReserved = false;
}
