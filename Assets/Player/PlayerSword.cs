using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private PlayerAttack player;

    private void Start()
    {

        player = GetComponentInParent<PlayerAttack>();
    }

    // Ataque
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(player.attacking);
        Enemy enemyHealth = other.GetComponentInParent<Enemy>();

        if (enemyHealth && player.attacking)
        {
            player.attacking = false;

            // Llamo al metodo del player para reastarle vida, segun el daño que genera el esqueleto
            enemyHealth.TakeDamage(player.damageGenerate);
        }
    }
}
