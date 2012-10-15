using UnityEngine;
using System.Collections;

public class C4 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 3){
					
			player.stanceChosen = 4;
			
			player.stanceChanged = true;
				//player.TurnPhases = 4;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 3)
				player.lastAbilityChosen = 14;
	}
	
	void Update(){
		
		if(player.TurnPhases == 3){
			button.isEnabled = true;
		
			if(player.stanceChosen  == 4)
				button.defaultColor = Color.red;
			else
				button.defaultColor = Color.white;
		}
		else{
			button.isEnabled = false;
			button.defaultColor = Color.clear;
		}
		
	}
}
