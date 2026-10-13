using UnityEngine;

public struct DamageInfo
{
    public float amount;
    public bool interruptsMovement;
    public bool interruptsAction;
    public Vector3 knockback;   // velocidad inicial del empuje; Vector3.zero si no hay
}
