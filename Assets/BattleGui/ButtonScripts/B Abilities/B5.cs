using UnityEngine;
using System.Collections;

public class B5 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 2){
			
			if(player.aP >= (-1 * player.playerAbilities.sworddAbilities.ShadowFury.cost)){
				player.swordAbilityChosen = 5;
		
				//player.TurnPhases = 2;
			
			
				//Delay
				//player.gameTimer = Time.time + 4;
			}
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 2)
				player.lastAbilityChosen = 10;
	}
	
	void Update(){
	
		if(player.TurnPhases == 2){
			button.isEnabled = true;
		
			if(player.swordAbilityChosen == 5)
				button.defaultColor = Color.red;
			else
				button.defaultColor = Color.white;
			
			//Do not player select what they can't afford
			if(player.aP < (-1 * player.playerAbilities.sworddAbilities.ShadowFury.cost))
			button.defaultColor = Color.grey;
			
		}
		else{
			button.defaultColor = Color.clear;
			button.isEnabled = false;
		}
		
	}
}
