
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy")]
public class EnemyPlanrData : ScriptableObject
{
    public string namePlane;
    public Sprite icon;
    public int maxHP;
    public float damage;
}
