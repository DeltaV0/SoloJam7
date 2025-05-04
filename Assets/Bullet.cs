using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool player;

    public GameObject enemytype;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            Destroy(gameObject);
        }
        else if (player)
        {
            if (collision.gameObject.name.Equals("Enemy(Clone)") || collision.gameObject.name.Equals("SuicEnemy(Clone)"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity += gameObject.GetComponent<Rigidbody2D>().velocity;
                collision.gameObject.GetComponent<Enemy>().health--;
                Destroy(gameObject);
            }
        }
        else {
            if (collision.gameObject.name.Equals("Player"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity += gameObject.GetComponent<Rigidbody2D>().velocity;
                collision.gameObject.GetComponent<Player>().health--;
                Destroy(gameObject);
            }
        }
    }
}
