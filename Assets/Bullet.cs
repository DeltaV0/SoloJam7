using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool player;

    public GameObject enemytype;

    public int damage;

    public bool flaming;

	public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Vector3.Distance(transform.position, Player.player.PlayerPos.position) < 4){
		rb.AddForce((transform.position - Player.player.PlayerPos.position) * (Player.player.repellingForce * 0.1f));
		}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Wall") || collision.gameObject.tag.Equals("Respawn"))
        {
            Destroy(gameObject);
        }
        else if (player)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity += gameObject.GetComponent<Rigidbody2D>().velocity * 0.1f;
                collision.gameObject.GetComponent<Enemy>().health -= damage;
				collision.gameObject.GetComponent<Enemy>().hurt.Play();
                if (flaming) {
                    collision.gameObject.GetComponent<Enemy>().burning = true;
					collision.gameObject.GetComponent<Enemy>().Burning.Play();
                }
                Destroy(gameObject);
            }
        }
        else {
            if (collision.gameObject.name.Equals("Player"))
            {
				Player.player.aud[2].Play();
                collision.gameObject.GetComponent<Rigidbody2D>().velocity += gameObject.GetComponent<Rigidbody2D>().velocity * 0.1f;
                collision.gameObject.GetComponent<Player>().health -= damage;
                collision.gameObject.GetComponent<Player>().animator.SetTrigger("Hit");
                Destroy(gameObject);
            }
        }
    }
}
