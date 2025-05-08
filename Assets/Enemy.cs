using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public int health;

	public int shots;

	public float scoremult;

    public Rigidbody2D rb;

    public GameObject packet;

	public GameObject deathParts;

	public GameObject CParts;

    private int shoottime;

    public int ShootMax;

    public float innacuracy = 5;

    public GameObject bulletPrefab;

    public float fireForce = 20f;

    public float moveSpeed;

    public int type;

    public bool spinny;

    public bool staticmover;

    public float rotMult;

    public bool burning;

    public int burningtime;

    public int damage;

	public ParticleSystem Burning;

	public int Burningtimeremaining;

	public AudioSource hurt;

	public bool DisableAI;

	public float ShootSpeedMult;
    //public bool sideStep;
    // Start is called before the first frame update
	void OnEnable()
    {
		health = (int)(health * ((Globals.wave * 0.05) + 1));
        agent.updateUpAxis = false;
        agent.updateRotation = false;

        if (!staticmover) {
            agent.updatePosition = false;
        }
        //health = 5;
		ShootMax = (int)(Random.Range(150, 300) * ShootSpeedMult);
        if (type == 0)
        {
			ShootMax = (int)(Random.Range(150, 300) * ShootSpeedMult);
        }
        else if (type == 2) {
			ShootMax = (int)(Random.Range(25, 50) * ShootSpeedMult);
        }
        shoottime = 50;
		burningtime = Player.player.burningSpeed;
		Burningtimeremaining = 250;
        //Globals.enemies++;
    }

    // Update is called once per frame
    void Update()
    {
		if(!DisableAI){
        agent.SetDestination(Player.player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (!spinny) {
        transform.LookAt(Player.player.transform.position, Vector3.up);
        transform.Rotate(0, 90, 90);
         }
		}
        if (burningtime == 0) {
            burningtime = Player.player.burningSpeed;
            health -= 1;
			hurt.Play();
        }
		if (Burningtimeremaining == 0) {
			Burningtimeremaining = 250;
			burning = false;
			Burning.Stop();
		}
		if(!DisableAI){
        if(type == 0 || type == 2) {
        if (shoottime <= 0) {
            shoottime = ShootMax;
					for(int i = 0; i < shots; i++){
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector2 aimDirection = new Vector2(Player.player.transform.position.x, Player.player.transform.position.y) - new Vector2(transform.position.x, transform.position.y);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));
				if(type == 0){
            bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;
				} else if (type == 2){
							bullet.GetComponent<Rigidbody2D>().rotation = rb.rotation + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));
				}

            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce), ForceMode2D.Impulse);
            bullet.GetComponent<Bullet>().player = false;
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().enemytype = gameObject;
					}
        }
        } else if(type == 1){

            if(Vector3.Distance(transform.position, Player.player.PlayerPos.position) < 1){
				Player.player.aud[2].Play();
			GameObject boom1 = (GameObject)Instantiate(CParts, transform.position/*a.transform.position*/, transform.rotation);
            Player.player.health -= damage;
            Globals.enemies--;
            Player.player.animator.SetTrigger("Hit");
            Destroy(gameObject);
        }
        }
		}


        if (health < 1)
        {
            GameObject boom1 = (GameObject)Instantiate(deathParts, transform.position/*a.transform.position*/, transform.rotation);
            //Global.enemys--;
            if(/*Random.Range(0, 1) == 0*/true) {
                GameObject boom = (GameObject)Instantiate(packet, transform.position, transform.rotation);
            }
			if(DisableAI){
				Static.score += (int)(Random.Range(1, 5) * scoremult);
			} else if(type == 0){
				Static.score += (int)(Random.Range(125, 175) * scoremult);
			} else if(type == 1){
				Static.score += (int)(Random.Range(25, 75) * scoremult);
			} else if(type == 2){
				Static.score += (int)(Random.Range(150, 200) * scoremult);
			}

            Globals.enemies--;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (spinny) {
       // rb.AddForce((transform.position - Player.player.PlayerPos.position) * -10f);
        rb.MoveRotation(rb.rotation + (rb.velocity.magnitude * rotMult) + 1f);
        }
        if (!staticmover) {
            rb.AddForce((transform.position - Player.player.PlayerPos.position) * (-1 * moveSpeed));
        }
        if (shoottime > 0)
        {
            shoottime--;
        }
        if(burning && burningtime > 0)
        {
            burningtime--;
        }
		if(burning && Burningtimeremaining > 0)
		{
			Burningtimeremaining--;
		}
    }
}
