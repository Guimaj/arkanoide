using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed_base = 100f;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * speed_base;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Vector2 ballPosition = transform.position;
            Vector2 playerPosition = collision.transform.position;

            float dir_x = (ballPosition.x - playerPosition.x) / collision.collider.bounds.size.x;

            Vector2 dir = new Vector2(dir_x, 1).normalized;

            body.velocity = dir * speed_base;
        }
    }
}
