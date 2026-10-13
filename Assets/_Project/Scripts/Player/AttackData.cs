using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/AttackData")]
public class AttackData : ScriptableObject
{
    public GameObject projectilePrefab;
    public float duration = 0.6f;            // duración total de la acción
    public float fireTime = 0.25f;           // momento en que sale el proyectil
    public float moveSpeedMultiplier = 0.5f; // 1 = camina a velocidad normal
}
