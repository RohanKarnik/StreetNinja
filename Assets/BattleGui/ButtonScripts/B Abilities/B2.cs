using UnityEngine;
using System.Collections;

public class B2 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 2){
			
			if(player.aP >= (-1 * player.playerAbilities.sworddAbilities.DeathStrike.cost)){
				
				player.swordAbilityChosen = 2;
		
				player.TurnPhases = 0;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			}
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 2)
				player.lastAbilityChosen = 7;
	}
	
	void Update(){
		
		if(player.TurnPhases == 2){
			button.isEnabled = true;

		
			if(player.swordAbilityChosen == 2)
				button.defaultColor = Color.red;
			else
				button.defaultColor = Color.white;
			
			//Do not player select what they can't afford
			if(player.aP < (-1 * player.playerAbilities.sworddAbilities.DeathStrike.cost))
			button.defaultColor = Color.grey;
			
		}
		else{
			button.defaultColor = Color.clear;
			button.isEnabled = false;
		}
		
	}
}
