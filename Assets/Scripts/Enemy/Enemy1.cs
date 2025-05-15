using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject destroyEffect;

    [SerializeField] private float pushTime;
    private float pushCounter;

    [SerializeField] private int experienceToGive;
    //[SerializeField] private float damagePtoE;
    [SerializeField] private float damageEtoP;
    [SerializeField] private float health;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerController.Instance.gameObject.activeSelf == true){
            //face the player
            if(PlayerController.Instance.transform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            //push back
            if (pushCounter > 0)
            {
                pushCounter -= Time.deltaTime;
                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed;
                }
                if(pushCounter <= 0)
                {
                    moveSpeed = Mathf.Abs(moveSpeed);
                }
            }

            // move towards the player
            moveSpeed = 1.0f;

            direction = (PlayerController.Instance.transform.position - transform.position).normalized;

            rb.linearVelocity= new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
        }else{
            rb.linearVelocity = Vector2.zero;
            
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            PlayerController.Instance.TakeDamage(damageEtoP);
            
        } 
    }


    public void TakeDamage(float damagePtoE){
        health -= damagePtoE;
        //DamageNumberController.Instance.CreateNumber(1,transform.position);
        DamageNumberController.Instance.CreateNumber(damagePtoE, transform.position);
        pushCounter = pushTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, transform.rotation);
            PlayerController.Instance.GetExperience(experienceToGive);
        }
    }
}
