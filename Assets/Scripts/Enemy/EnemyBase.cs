using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)

    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();
        
        if (health != null)
            //(collision.CompareTag("Enemy"))
        {
            health.Damage(damage);
        }
    }
}
