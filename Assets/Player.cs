using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	
	Vector2 moveDir;
	Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float moveX = Input.GetAxisRaw ("Horizontal");
		float moveY = Input.GetAxisRaw ("Vertical");
		
		moveDir = new Vector2 (moveX, moveY).normalized;
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
    }

	void FixedUpdate(){
		Vector2 aimDirection = mousePos - rb.position;
		
		float aimAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = aimAngle;
		rb.velocity = new Vector2 (moveDir.x * moveSpeed, moveDir.y * moveSpeed);
	}
}
