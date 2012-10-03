using UnityEngine;
using System.Collections;

public class B5 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 1){
			
			if(player.aP >= player.playerAbilities.abilitiesB.b5aPCost){
				player.bAbilityChosen = 5;
		
				//player.TurnPhases = 2;
			
			
				//Delay
				//player.gameTimer = Time.time + 4;
			}
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 10;
	}
	
	void Update(){
	
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesB.b5aPCost)
			button.defaultColor = Color.grey;
		
		//if(player.TurnPhases > 0){
		
			if(player.bAbilityChosen == 5)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.bAbilityChosen != 5)
		else
				button.defaultColor = Color.green;
		//}
		
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesB.b5aPCost)
			button.defaultColor = Color.grey;
	}
}
