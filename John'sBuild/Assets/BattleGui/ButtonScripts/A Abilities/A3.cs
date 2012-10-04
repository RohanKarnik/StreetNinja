using UnityEngine;
using System.Collections;

public class A3 : MonoBehaviour {
	
	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 0){
			player.aAbilityChosen = 3;
		
			//player.TurnPhases = 1;
			
			//Delay
			//player.gameTimer = Time.time + 3;
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 3;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
			if(player.aAbilityChosen == 3)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.aAbilityChosen != 2)
		else
				button.defaultColor = Color.yellow;
		//}
	}
		
}
