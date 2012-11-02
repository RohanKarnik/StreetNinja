using UnityEngine;
using System.Collections;

public class Buff4Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	void OnClick(){
		
		if(player.playerStatus.overTimeBuffs.shieldBuffCounter > 0){
			
			player.lastBuffDebuffClicked = 3;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.playerStatus.overTimeBuffs.shieldBuffCounter > 0){
			button.enabled = true;
			if(player.lastBuffDebuffClicked == 3)
				button.defaultColor = Color.white;
			else
				button.defaultColor = Color.clear;
		}
		else{
			button.enabled = false;
			button.defaultColor = Color.clear;
		}
	}
}
