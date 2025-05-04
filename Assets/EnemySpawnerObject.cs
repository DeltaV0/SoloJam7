using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerObject : MonoBehaviour
{
    public int timer;

    public int timermax;

    public GameObject[] enemyPf;

    public Transform progress;

    public Rigidbody2D Spinner;
    // Start is called before the first frame update
    void Start()
    {
        timermax = Random.Range(50, 250);
        timer = timermax;
        Globals.enemies++;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            GameObject bullet = (GameObject)Instantiate(enemyPf[Random.Range(0, enemyPf.Length)], transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        
        if (timer > 0) {
            Spinner.rotation = Mathf.Pow(((float)((float)timer / timermax)) * 5, 2)  * 45;
            //Spinner.MoveRotation(Spinner.rotation + 10);
            progress.localScale = new Vector3((1 - (float)((float)timer / timermax)) * 0.6f, (1 - (float)((float)timer / timermax)) * 0.6f, (1 - (float)((float)timer / timermax)) * 0.6f);
            timer--;
        }
    }
}
