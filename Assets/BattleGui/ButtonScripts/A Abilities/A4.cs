using UnityEngine;
using System.Collections;

public class A4 : MonoBehaviour {
	
	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		//if(player.TurnPhases == 0){
			player.aAbilityChosen = 4;
		
			//player.TurnPhases = 1;
			
			//Delay
			//player.gameTimer = Time.time + 3;
		//}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 4;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
			if(player.aAbilityChosen == 4)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.aAbilityChosen != 2)
		else
				button.defaultColor = Color.yellow;
		//}
	}
		
}
