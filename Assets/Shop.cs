using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Shop : MonoBehaviour
{
    public Transform[] spots;
    public GameObject[] options;

    public List<GameObject> active = new List<GameObject>();

    public static Shop shop;

    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        shop = this;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = Player.thingies + " Things";
    }

    public void ActivateShop() {
        for (int i = 0; i < spots.Length; i++) {
            GameObject Item = (GameObject)Instantiate(options[Random.Range(0, options.Length)], spots[i].position, spots[i].rotation);
            active.Add(Item);
        }
    }
    public void DeactivateShop() {
        for (int i = 0; i < active.Count; i++) {
            Destroy(active[i]);
        }
    }
}
