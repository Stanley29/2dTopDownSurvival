using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject [] enemies;
    public float spawnTime = 5f;
    public Transform player;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        GameObject enemy = enemies[Random.Range(0, 2)];
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        var direction = Random.insideUnitCircle.normalized;
        var distance = Random.Range(7, 15); // for e.g 7 is min and 15 max
        var pos = direction * distance;

        GameObject plt = Instantiate(enemy);
        plt.transform.position = player.transform.position + new Vector3(pos.x, pos.y);
    }
}
