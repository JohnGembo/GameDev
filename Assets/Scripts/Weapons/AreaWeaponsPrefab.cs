using System.Collections.Generic;
using UnityEngine;

public class AreaWeaponsPrefab : MonoBehaviour
{
    public AreaWeapon weapon1;
    private Vector3 targetSize;
    private float timer;
    public List<Enemy1> enemiesInRange;

    private float counter;

    void Start()
    {
        weapon1 = GameObject.Find("Area Weapon").GetComponent<AreaWeapon>();
        //Destroy(gameObject,weapon1.duration);
        targetSize = Vector3.one * weapon1.weaponRange;
        transform.localScale = Vector3.zero;
        timer = weapon1.duration;
    }


    void Update()
    {
        // grow and shrink towards targetSize
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, Time.deltaTime * 5);
        //shirnk
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            targetSize = Vector3.zero;
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject);
            }

        }
        //periodic damage
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            counter = weapon1.weaponWaveSpeed;
            for (int i=0; i< enemiesInRange.Count; i++)
            {
                enemiesInRange[i].TakeDamage(weapon1.weaponDamage);
            }   
        }

    }

    /*private void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag("Enemy")){
            Enemy1 enemy = collider.GetComponent<Enemy1>();
            if(enemy != null){
                enemy.TakeDamage(weapon1.weaponDamage);
            }

        }
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collider.GetComponent<Enemy1>());
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collider.GetComponent<Enemy1>());
        }

    }
}
