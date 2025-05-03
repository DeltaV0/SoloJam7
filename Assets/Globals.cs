using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static int enemies;

    public GameObject enemy;

    public static int wave;

    public static int timer;

    public static bool gamig;

    public GameObject[] Maps;

    public GameObject current;
    //public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        gamig = true;
        wave = 0;
        enemies = 0;
        timer = 250;
        current = (GameObject)Instantiate(Maps[Random.Range(0, Maps.Length)], transform.position, transform.rotation);
        //current = bullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 && gamig) {
            /*timer = 250;
            */
            gamig = false;
            Player.player.PlayerPos.position = new Vector3(50, 0, 0);
            timer = 250;
            Shop.shop.ActivateShop();
        }

        if (!gamig && Input.GetKeyDown(KeyCode.F)) {
            Destroy(current);
            current = null;
            gamig = true;
            Shop.shop.DeactivateShop();
            Player.player.PlayerPos.position = new Vector3(0, 0, 0);
            current = (GameObject)Instantiate(Maps[Random.Range(0, Maps.Length)], transform.position, transform.rotation);
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

        if (enemies <= 0 && timer > 0 && gamig)
        {
            timer--;
        }

    }
}
