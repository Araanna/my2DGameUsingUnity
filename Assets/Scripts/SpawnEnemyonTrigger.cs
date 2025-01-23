using UnityEngine;

public class SpawnEnemyOnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign the Enemy prefab in the Inspector
    public Transform teleportPoint; // Assign a Transform for the teleport location

    private bool enemySpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemySpawned && collision.CompareTag("Player")) // Ensure the player triggered it
        {
            enemySpawned = true;

            // Spawn the enemy behind the player
            Vector3 spawnPosition = collision.transform.position + new Vector3(-1f, 0, 0); // Adjust -1f to control the distance behind the player
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Move the enemy to the teleport point when the player moves left
            StartCoroutine(HandleEnemyMovement(collision.gameObject, enemy));
        }
    }

    private System.Collections.IEnumerator HandleEnemyMovement(GameObject player, GameObject enemy)
    {
        while (enemy != null)
        {
            if (Input.GetAxis("Horizontal") < 0) // Check if the player moves left
            {
                enemy.transform.position = teleportPoint.position;
                break;
            }
            yield return null; // Wait for the next frame
        }
    }
}
