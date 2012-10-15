using UnityEngine;
using System.Collections;

public class Buff3Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	void OnClick(){
		
		if(player.playerStatus.overTimeBuffs.StrDefUpBuffCounter > 0){
			
			player.lastBuffDebuffClicked = 2;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.playerStatus.overTimeBuffs.StrDefUpBuffCounter > 0){
			button.enabled = true;
			if(player.lastBuffDebuffClicked == 2)
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
