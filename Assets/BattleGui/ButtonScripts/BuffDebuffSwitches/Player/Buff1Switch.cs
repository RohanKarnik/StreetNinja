using UnityEngine;
using System.Collections;

public class Buff1Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	void OnClick(){
		
		if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0){
			
			player.lastBuffDebuffClicked = 0;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0){
			button.enabled = true;
			if(player.lastBuffDebuffClicked == 0)
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
