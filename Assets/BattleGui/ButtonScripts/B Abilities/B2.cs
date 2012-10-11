using UnityEngine;
using System.Collections;

public class B2 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
			
			if(player.aP >= (-1 * player.playerAbilities.sworddAbilities.DeathStrike.cost)){
				
				player.swordAbilityChosen = 2;
		
				//player.TurnPhases = 3;
			
				//Delay
				//player.gameTimer = Time.time + 3;
			}
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 7;
	}
	
	void Update(){
		
		//if(player.TurnPhases > 0){
		
			if(player.swordAbilityChosen == 2)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.bAbilityChosen != 2)
			else
				button.defaultColor = Color.white;
		//}
		
		//Do not player select what they can't afford
		if(player.playerAbilities != null){
			if(player.aP < (-1*player.playerAbilities.sworddAbilities.DeathStrike.cost))
			button.defaultColor = Color.grey;
		}
		
	}
}
