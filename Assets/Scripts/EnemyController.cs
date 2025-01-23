using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRB;
    float moveSpeeed = 200.0f;
    [SerializeField] float direction;

    // Use this for initialization
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            transform.localScale = new Vector3(6, 5, 1); // Maintain orientation
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-6, 5, 1); // Flip orientation
        }
        enemyRB.velocity = new Vector2(direction * moveSpeeed * Time.deltaTime, enemyRB.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        direction *= -1;
    }

      private void OnTriggerEnter2D(Collider2D other) {
    direction *= -1;
  }




}
