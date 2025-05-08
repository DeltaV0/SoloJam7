using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons : MonoBehaviour
{
	public bool deathmenu;

	public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(deathmenu){
			text.text = Static.score + " Points i guess (arbatrary value)\n" + Static.wave + " Rounds Survived\n" + Static.thingsbought + " Things Made"; 
		}
    }

	public void load(){
		Static.score = 0;
		Static.wave = 0;
		Static.thingsbought = 0;
		SceneManager.LoadSceneAsync("SampleScene");
	}

	public void menu(){
		Static.score = 0;
		Static.wave = 0;
		Static.thingsbought = 0;
		SceneManager.LoadSceneAsync("Title");
	}
}
