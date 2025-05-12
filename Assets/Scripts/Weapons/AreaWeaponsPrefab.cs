using UnityEngine;

public class AreaWeaponsPrefab : MonoBehaviour
{   
    public AreaWeapon weapon1;
    private Vector3 targetSize;
    private float timer;
    
    void Start()
    {
        weapon1 = GameObject.Find("Area Weapon").GetComponent<AreaWeapon>();
        //Destroy(gameObject,weapon1.duration);
        targetSize= Vector3.one;
        transform.localScale = Vector3.zero;
        timer = weapon1.duration;
    }

   
    void Update()
    {
        // grow and shrink towards targetSize
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, Time.deltaTime);
        //shirnk
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            targetSize = Vector3.zero;
            if(transform.localScale.x == 0f){
                Destroy(gameObject);
            }
            
        }
    }
}
