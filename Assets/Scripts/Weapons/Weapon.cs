using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public int weaponLevel;
    public List<WeaponStats> stats;
}

[System.Serializable]
public class WeaponStats
{
    public float cooldown;
    public float duration;
    public float weaponDamage;
    public float weaponRange;
    public float weaponWaveSpeed;
}
