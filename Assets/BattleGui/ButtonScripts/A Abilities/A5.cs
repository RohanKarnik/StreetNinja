using UnityEngine;
using System.Collections;

public class A5 : MonoBehaviour {
	
	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 1){
			player.gunAbilityChosen = 5;
		
			player.TurnPhases = 0;
			
			//Test
			//player.gameTimer = Time.time + 3;
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 1)
				player.lastAbilityChosen = 5;
	}
	
	void Update(){
	
		if(player.TurnPhases == 1){
			button.isEnabled = true;
			
			button.defaultColor = Color.white;

		}
		
		else{
			button.defaultColor = Color.clear;
			button.isEnabled = false;
		}
	}
}
