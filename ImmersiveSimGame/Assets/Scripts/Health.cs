using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 50f;
    public GameObject destroyedVersion;

    public void TakeDamage (float amount){
        health -= amount;
        if(health <= 0f){
            Die();
        }
    }
    void Die(){
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
