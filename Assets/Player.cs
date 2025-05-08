using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Image HealthCircle;
    public int health;

    public Animator animator;

    public int maxHealth;

	public float moveSpeed = 0.001f;
	public Rigidbody2D rb;

	public Transform PlayerPos;

	public static Player player;

    public float innacuracy = 5f;

    public GameObject bulletPrefab;

    public float fireForce = 20f;

    public int damage;

    public int timer;

    public int maxTimer;

    Vector2 moveDir;
	Vector2 mousePos;

    public static int thingies;

    public int shots;

    public bool burningBullets;

    public int burningSpeed;

	public float repellingForce;

    public List<int> purchases = new List<int>();

	public AudioSource[] aud;
    // Start is called before the first frame update
    void Start()
    {
		thingies = 0;
		burningSpeed = 25;
        shots = 1;
        maxTimer = 50;
        timer = maxTimer;
        maxHealth = 50;
        health = maxHealth;
        player = this;
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { 
			Static.wave = Globals.wave;
			SceneManager.LoadSceneAsync("Dead");
        }
        HealthCircle.fillAmount = (float)((float)health / maxHealth);
        float moveX = Input.GetAxisRaw ("Horizontal");
		float moveY = Input.GetAxisRaw ("Vertical");
		
		moveDir = new Vector2 (moveX, moveY).normalized;
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        if (Input.GetMouseButton(0) && timer <= 0)
        {
            timer = maxTimer;

            for (int i = 0; i < shots; i++) {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector2 aimDirection = new Vector2(transform.position.x, transform.position.y) - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));

            bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;


            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce), ForceMode2D.Impulse);
            bullet.GetComponent<Bullet>().player = true;
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().flaming = burningBullets;
            bullet.GetComponent<Bullet>().enemytype = gameObject;
			aud[0].pitch = Random.Range(1.9f, 2.1f);
			aud[0].Play();
            }

           
        }
    }

	void FixedUpdate(){
		Vector2 aimDirection = mousePos - rb.position;
		
		float aimAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = aimAngle;
        //rb.velocity = new Vector2 (moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        rb.AddForce(moveDir * moveSpeed, ForceMode2D.Impulse);

        if (timer > 0) {
            timer--;
        }
        /* if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
             float rot2 = (rb.rotation + (Input.GetKey(KeyCode.W) ? 90f : (Input.GetKey(KeyCode.A) ? 180f : (Input.GetKey(KeyCode.S) ? -90f : 0)))) * Mathf.Deg2Rad;
             rb.AddForce(new Vector2((Mathf.Cos(rot2)) * moveSpeed, (Mathf.Sin(rot2)) * moveSpeed), ForceMode2D.Impulse);
         } *///seqdyhhjhsxjjkelinmsknmn medjmnionjm msm,merddkmnsnnamkjs
    }
}
