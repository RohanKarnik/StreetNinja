using UnityEngine;
using System.Collections;

public class B4 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 1){
			
			if(player.aP >= player.playerAbilities.abilitiesB.b4aPCost){
				player.bAbilityChosen = 4;
		
				//player.TurnPhases = 3;
			
			
				//Delay
				//player.gameTimer = Time.time + 4;
			}
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 9;
	}
	
	void Update(){
		
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesB.b4aPCost)
			button.defaultColor = Color.grey;
	
		//if(player.TurnPhases > 0){
		
			if(player.bAbilityChosen == 4)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.bAbilityChosen != 4)
		else
				button.defaultColor = Color.green;
		//}
		
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesB.b4aPCost)
			button.defaultColor = Color.grey;
		
	}
}
