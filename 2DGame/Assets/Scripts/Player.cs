using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float hp;

    private void FixedUpdate()
    {
        if (Input.GetKey("a") && transform.position.x >= -7)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("d") && transform.position.x <= 7)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (EnemySpawner.enemies.ContainsKey(obj))
        {
            hp -= EnemySpawner.enemies[obj].Attack;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
