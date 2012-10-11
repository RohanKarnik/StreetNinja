using UnityEngine;
using System.Collections;

public class B4 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
			
			if(player.aP >= (-1 * player.playerAbilities.sworddAbilities.CrimsonCut.cost)){
				player.swordAbilityChosen = 4;
		
				//player.TurnPhases = 3;
			
			
				//Delay
				//player.gameTimer = Time.time + 4;
			}
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 9;
	}
	
	void Update(){
		
		//if(player.TurnPhases > 0){
		
			if(player.swordAbilityChosen == 4)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.bAbilityChosen != 4)
		else
				button.defaultColor = Color.white;
		//}
		
		//Do not player select what they can't afford
		if(player.aP < (-1 * player.playerAbilities.sworddAbilities.CrimsonCut.cost))
			button.defaultColor = Color.grey;
		
	}
}
