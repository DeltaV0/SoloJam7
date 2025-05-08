using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Globals : MonoBehaviour
{
    public static int enemies;

    public GameObject enemy;

	public GameObject enemy2;

    public static int wave;

    public static int timer;

    public static bool gamig;

	public GameObject tutorialText;

    public PostProcessVolume Volume;

	public GameObject purchaseParts;

	public static Globals me;

	public AudioSource musik;

    //public VhsFX vsh;
    //public GameObject[] Maps;

    public GameObject current;

	public AudioSource wave1;
    //public Transform player;
    // Start is called before the first frame update
    void Start()
    {
		me = this;
        gamig = true;
        wave = 0;
        enemies = 0;
		wave1.Play();
		GameObject bullet = (GameObject)Instantiate(enemy2, new Vector3(0, 2, 0), transform.rotation);
        timer = 150;
        //current = (GameObject)Instantiate(Maps[Random.Range(0, Maps.Length)], transform.position, transform.rotation);
        //current = bullet;
    }

    // Update is called once per frame
    void Update()
    {
       // Volume.weight = 1 - (timer / 250.0f);
        //vsh.
        if (timer <= 0 && gamig) {
            /*timer = 250;
            */
			tutorialText.SetActive(false);
            gamig = false;
            Player.player.PlayerPos.position = new Vector3(50, 0, 0);
            timer = 150;
            Shop.shop.ActivateShop();
        }

        if (!gamig && Input.GetKeyDown(KeyCode.F)) {
            //Destroy(current);
            //current = null;
			wave1.Play();
            gamig = true;
            Shop.shop.DeactivateShop();
            Player.player.PlayerPos.position = new Vector3(0, 0, 0);
            Player.player.health = Player.player.maxHealth; //heal player to full for now
            //current = (GameObject)Instantiate(Maps[Random.Range(0, Maps.Length)], transform.position, transform.rotation);
            //current = bullet;
            wave++;
            for (int i = 0; i < wave; i++)
            {
                //replace this with generic enemy spawner that spawns an enemy after a moment and disappears
                GameObject bullet = (GameObject)Instantiate(enemy, Random.insideUnitCircle * 10, transform.rotation);
            }
        }
    }

    private void FixedUpdate()
    {
		if(!gamig){
			musik.volume = Mathf.Lerp(musik.volume, 0.0f, 0.03f);
		} else {
			musik.volume = Mathf.Lerp(musik.volume, 0.25f, 0.03f);
		}
        if (enemies <= 0 && timer > 0 && gamig)
        {
            timer--;
        }

    }
}
