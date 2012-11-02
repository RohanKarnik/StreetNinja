using UnityEngine;
using System.Collections;

public class DeBuff4Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	void OnClick(){
		
		if(player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter > 0){
			
			player.lastBuffDebuffClicked = 7;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter > 0){
			button.enabled = true;
			if(player.lastBuffDebuffClicked == 7)
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
