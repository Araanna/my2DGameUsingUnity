using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody2D enemyRB;
    float moveSpeeed = 1.0f;
    float attackRange = 5.0f;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            attack();
        }
    }
    void attack()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(3, 3, 1);
        }


        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeeed * Time.deltaTime);
    }

}