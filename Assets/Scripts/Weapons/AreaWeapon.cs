using UnityEngine;
using Unity.VisualScripting;

public class AreaWeapon : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private float spawnCounter;

    public float cooldown= 5f;
    public float duration= 3f;
    public float weaponDamage= 1f;
    public float weaponRange= 0.7f;
    public float weaponWaveSpeed = 0.5f;

    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0){
            spawnCounter = cooldown;
            Instantiate(prefab, transform.position, transform.rotation, transform);
        }
    }
}
