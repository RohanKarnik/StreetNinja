using UnityEngine;
using System.Collections;

public class B2 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 1){
			
			if(player.aP >= player.playerAbilities.abilitiesB.b2aPCost){
				
				player.bAbilityChosen = 2;
		
				//player.TurnPhases = 3;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			}
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 7;
	}
	
	void Update(){
		
		//if(player.TurnPhases > 0){
		
			if(player.bAbilityChosen == 2)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.bAbilityChosen != 2)
		else
				button.defaultColor = Color.green;
		//}
		
		//Do not player select what they can't afford
		if(player.aP < player.playerAbilities.abilitiesB.b2aPCost)
			button.defaultColor = Color.grey;
		
		
	}
}
