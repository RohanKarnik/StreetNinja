using UnityEngine;
using System.Collections;

public class DeBuff2Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	void OnClick(){
		
		if(player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter > 0){
			
			player.lastBuffDebuffClicked = 5;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter > 0){
			button.enabled = true;
			if(player.lastBuffDebuffClicked == 5)
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
