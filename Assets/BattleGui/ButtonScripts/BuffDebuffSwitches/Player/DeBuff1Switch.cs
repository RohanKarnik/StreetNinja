using UnityEngine;
using System.Collections;

public class DeBuff1Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	void OnClick(){
		
		if(player.playerStatus.overTimeDeBuffs.doTCounter > 0){
			
			player.lastBuffDebuffClicked = 4;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.playerStatus.overTimeDeBuffs.doTCounter > 0){
			button.enabled = true;
			if(player.lastBuffDebuffClicked == 4)
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
