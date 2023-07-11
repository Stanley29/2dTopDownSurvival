using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        //float distance = Vector3.Distance(this.transform.position, player.position);
        //if (distance < 10.0f)
        //{
        //    if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //    {
        //        nav.SetDestination(player.position);
        //    }
        //    else
        //    {
        //        nav.enabled = false;
        //    }
        //}
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
        nav.SetDestination(player.position);
    }
}
