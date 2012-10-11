using UnityEngine;
using System.Collections;

public class B3 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
			
			if(player.aP >= (-1 * player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost)){
				player.swordAbilityChosen = 3;
		
			//player.TurnPhases = 3;
						
			//Delay
			//player.gameTimer = Time.time + 3;
			}
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 8;
	}
	
	void Update(){
		
		//if(player.TurnPhases > 0){
		
			if(player.swordAbilityChosen == 3)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.bAbilityChosen != 3)
		else
				button.defaultColor = Color.white;
		//}
		
		//Do not player select what they can't afford
		if(player.aP < (-1 * player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost))
			button.defaultColor = Color.grey;
		
	}
}
