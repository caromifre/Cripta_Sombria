using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private PlayerAttack player;
    Game_manager _controller;
    private void Start()
    {
        _controller= Game_manager.Instance;

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
        if (other.tag == "Enemy_Boss") {
            Debug.Log("Matando el jefe");
            if (enemyHealth.health < 0) {
                Debug.Log("EL JEFE MURIO");
                _controller.jefe_muerto();
            }
        }
    }
}
