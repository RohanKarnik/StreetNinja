using UnityEngine;
using System.Collections;

public class A5 : MonoBehaviour {
	
	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
			player.gunAbilityChosen = 5;
		
			//player.TurnPhases = 1;
			
			//Test
			//player.gameTimer = Time.time + 3;
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 5;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
			if(player.gunAbilityChosen == 5)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.aAbilityChosen != 2)
		else
				button.defaultColor = Color.white;
		//}
	}
}
