using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Plane")]
public class PlaneData : ScriptableObject
{
    public string namePlane;
    public GameObject prefabPlane;
    public Sprite icon;
    public int price;
    public int maxHP;
    public float damage;
    public float fireRate;
}
