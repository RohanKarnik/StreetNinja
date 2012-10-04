using UnityEngine;
using System.Collections;

public class A2 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 0){
			player.aAbilityChosen = 2;
		
			//player.TurnPhases = 1;
			
			//Delay
			//player.gameTimer = Time.time + 3;
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 2;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
			if(player.aAbilityChosen == 2)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.aAbilityChosen != 2)
		else
				button.defaultColor = Color.yellow;
		//}
	}

}
