using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {
  Transform player;
  Rigidbody2D rb;
  float speed = 400.0f;
  float direction = 1;

  // Use this for initialization
  void Start () {
    rb= GetComponent<Rigidbody2D>();
    player = GameObject.Find("Player").transform;

    if(player.localScale.x == -1){
      direction = -1;
    }
  }
  
  // Update is called once per frame
  void Update () {
    rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Enemy"){
      other.transform.localScale = new Vector2(1, -1);
      other.transform.GetComponent<BoxCollider2D>().enabled = false;

      Destroy(other.gameObject, 2.0f);
    }
    //remove/destroy the fireball
    Destroy(gameObject);
  }
}