using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    public int weaponLevel;
    public List<WeaponStats> stats;
    public Sprite weaponImage;
    
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
        }
    }
}

[System.Serializable]
public class WeaponStats
{
    public float cooldown;
    public float duration;
    public float weaponDamage;
    public float weaponRange;
    public float weaponWaveSpeed;
    public string descrription;
}
