using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
	public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void FixedUpdate(){
		if(Vector3.Distance(transform.position, Player.player.PlayerPos.position) < 4){
			rb.AddForce((transform.position - Player.player.PlayerPos.position) * -10f);
			rb.MoveRotation(rb.rotation + (rb.velocity.magnitude * 3f));
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.name.Equals("Player")){
			Player.thingies++;
			Destroy(gameObject);
		}
	}
}
