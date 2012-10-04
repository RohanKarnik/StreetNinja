using UnityEngine;
using System.Collections;

public class C4 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 0){
				
			if(player.aP >= player.playerAbilities.abilitiesC.c4ApCost){
			
				player.cAbilityChosen = 4;
		
				//player.TurnPhases = 4;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			}
			
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 14;
	}
	
	void Update(){
		
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesC.c4ApCost)
			button.defaultColor = Color.grey;
	
		//if(player.TurnPhases > 0){
		
			if(player.cAbilityChosen == 4)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.cAbilityChosen != 4)
		else
				button.defaultColor = Color.blue;
		//}
		
			//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesC.c4ApCost)
			button.defaultColor = Color.grey;
	}
}
