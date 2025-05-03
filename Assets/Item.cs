using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public int ID;
    public string name;

    public int cost;

    public int rarity;

    public TMP_Text t1;
    public TMP_Text t2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.player.PlayerPos.position, transform.position) < 1.25)
        {
            if (Player.thingies >= cost) {
                t1.text = "Buy? (E)";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Player.thingies -= cost;
                    Upgrade();
                 }
            } else {
                t1.text = "Cant Afford :/";
            }
            t2.text = cost + " T";
            
        }
        else {
            t1.text = name;
            t2.text = "";
        }
    }

    public void Upgrade() {
        //get the upgrade from ID and do it
        //also make fancy particles
        //then destroy go
        Destroy(gameObject);
    }
}
