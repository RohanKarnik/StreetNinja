using UnityEngine;
using System.Collections;

public class B1 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 2){
			
			if(player.aP >= (-1 * player.playerAbilities.sworddAbilities.BloodBlade.cost)){
				
				player.swordAbilityChosen = 1;
		
				player.TurnPhases = 0;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			}
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 2)
				player.lastAbilityChosen = 6;
	}
	
	void Update(){
		
	
		if(player.TurnPhases == 2){
			button.isEnabled = true;
			button.defaultColor = Color.white;
			
			//Do not player select what they can't afford
			if(player.aP < (-1 * player.playerAbilities.sworddAbilities.BloodBlade.cost))
			button.defaultColor = Color.grey;
			
		}
		else{
			button.defaultColor = Color.clear;
			button.isEnabled = false;
		}
		
	}
}
