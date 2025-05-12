using UnityEngine;
using Unity.VisualScripting;

public class AreaWeapon : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private float spawnCounter;

    public float cooldown= 5f;
    public float duration= 3f;

    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0){
            spawnCounter = cooldown;
            Instantiate(prefab, transform.position, transform.rotation, transform);
        }
    }
}
