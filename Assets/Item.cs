using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public int ID;
    public string namea;
    public string desc;

    public int cost;

    public float rarity;

    public TMP_Text t1;
    public TMP_Text t2;
    public TMP_Text t3;

    // Start is called before the first frame update
    void OnEnable()
    {
        cost = 1;
        for(int i = 0; i < Player.player.purchases.Count; i++)
        {
            if (Player.player.purchases[i] == ID) {
                cost++;
            }
        }
        cost = (int) (cost * rarity);
        cost = (int)(cost * (Globals.wave * 0.25) + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.player.PlayerPos.position, transform.position) < 1.25)
        {
            if (Player.thingies >= cost) {
                t1.text = "Buy? (E)";
                t3.text = "Amazing";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Player.thingies -= cost;
                    Upgrade();
                 }
            } else {
                t1.text = "Cant Afford :/";
                t3.text = "Need " + (cost - Player.thingies) + " More Things";
            }
            t2.text = cost + " T";
            
        }
        else {
            t1.text = namea;
            t3.text = desc;
            t2.text = "";
        }
    }

    public void Upgrade() {
        if (ID == 0) {
            Player.player.moveSpeed *= 1.25f;
        } else if (ID == 1) {
            Player.player.maxTimer = (int)(Player.player.maxTimer * 0.8f);
        } else if (ID == 2) {
            Player.player.shots++;
            Player.player.innacuracy += 5;
        } else if (ID == 3) {
            Player.player.maxHealth += 25;
            //Player.player.moveSpeed *= 0.95f;
        } else if (ID == 4) {
            Player.player.fireForce *= 1.25f;
            Player.player.damage = (int)(Player.player.damage * 1.1f);
        } else if (ID == 5) {
            //Player.player.fireForce *= 1.25f;
            Player.player.damage = (int)(Player.player.damage * 1.25f);
        } else if (ID == 6) {
            //Player.player.fireForce *= 1.25f;
            Player.player.innacuracy *= 0.75f;
        } else if (ID == 7) {
            //Player.player.fireForce *= 1.25f;
            Player.player.burningBullets = true;
            Player.player.burningSpeed = (int)(Player.player.burningSpeed * 0.8f);
            //Player.player.burningSpeed *= 0.8f;
        }

        Player.player.purchases.Add(ID);
        //get the upgrade from ID and do it
        //also make fancy particles
        //then destroy go
        Destroy(gameObject);
    }
}
