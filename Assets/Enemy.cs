using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public int health;

    public GameObject packet;

    private int shoottime;

    public int ShootMax;

    public float innacuracy = 5;

    public GameObject bulletPrefab;

    public float fireForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        health = 5;
        ShootMax = Random.Range(150, 300);
        shoottime = 50;
        //Globals.enemies++;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.LookAt(Player.player.transform.position, Vector3.up);
        transform.Rotate(0, 90, 90);

        if (shoottime <= 0) {
            shoottime = ShootMax;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector2 aimDirection = new Vector2(Player.player.transform.position.x, Player.player.transform.position.y) - new Vector2(transform.position.x, transform.position.y);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));

            bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;


            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce), ForceMode2D.Impulse);
            bullet.GetComponent<Bullet>().player = false;
            bullet.GetComponent<Bullet>().enemytype = gameObject;
        }


        if (health < 1)
        {
           // GameObject boom = (GameObject)Instantiate(DeathPf, transform.position/*a.transform.position*/, transform.rotation);
            //Global.enemys--;
            if(Random.Range(0, 2) == 0) {
                GameObject boom = (GameObject)Instantiate(packet, transform.position, transform.rotation);
            }
            Globals.enemies--;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {

        if (shoottime > 0)
        {
            shoottime--;
        }

    }
}
