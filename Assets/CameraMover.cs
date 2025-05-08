using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mover : MonoBehaviour
{
    public Transform trans;

    private float DT;
    // Start is called before the first frame update
    void Start()
    {
        DT = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Time.fixedDeltaTime = DT * Time.timeScale;

    }

    private void FixedUpdate()
    {
		transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(new Vector3(trans.position.x, trans.position.y, transform.position.z), Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.2f), 0.1f);
    }
}
