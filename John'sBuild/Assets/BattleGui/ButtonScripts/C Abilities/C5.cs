using UnityEngine;
using System.Collections;

public class C5 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 0){
			
			if(player.aP >= player.playerAbilities.abilitiesC.c3ApCost){
			
				player.cAbilityChosen = 5;
		
				//player.TurnPhases = 4;
			
				//Delay
				//player.gameTimer = Time.time + 3;
				
			}
			
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 15;
	}
	
	
	void Update(){
		
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesC.c5ApCost)
			button.defaultColor = Color.grey;
	
		//if(player.TurnPhases > 0){
		
			if(player.cAbilityChosen == 5)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.cAbilityChosen != 5)
		else
				button.defaultColor = Color.blue;
		//}
		
				//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesC.c5ApCost)
			button.defaultColor = Color.grey;
	}
}
