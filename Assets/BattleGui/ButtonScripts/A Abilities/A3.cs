using UnityEngine;
using System.Collections;

public class A3 : MonoBehaviour {
	
	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 1){
			player.gunAbilityChosen = 3;
		
			//player.TurnPhases = 1;
			
			//Delay
			//player.gameTimer = Time.time + 3;
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 1)
				player.lastAbilityChosen = 3;
	}
	
	void Update(){
	
		if(player.TurnPhases == 1){
			button.isEnabled = true;
		
			if(player.gunAbilityChosen == 3)
				button.defaultColor = Color.red;
			else
				button.defaultColor = Color.white;
		}
		
		else{
			button.defaultColor = Color.clear;
			button.isEnabled = false;
		}
	}
		
}
