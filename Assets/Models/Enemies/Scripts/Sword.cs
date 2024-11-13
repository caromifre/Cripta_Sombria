using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    // Ataque
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enemy.attacking)
        {
            enemy.attacking = false;

            // Llamo al metodo del player para reastale vida, segun el daño que genera el esqueleto
            PlayerBehaviour playerHealth = other.gameObject.GetComponent<PlayerBehaviour>();
            //playerHealth.TakeDamage(enemy.damageGenerate);//deescomentar esto luego
        }
    }
}
