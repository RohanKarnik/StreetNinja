using UnityEngine;
using System.Collections;

public class A1 : MonoBehaviour {
	
	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
			player.gunAbilityChosen = 1;
		
			//player.TurnPhases = 1;

			//Delay
			//player.gameTimer = Time.time + 3;
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 1;
	}
	
	void Update(){
	
		//if(player.TurnPhases > 0){
		
			if(player.gunAbilityChosen == 1)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.aAbilityChosen != 1)
		else
				button.defaultColor = Color.white;
		//}
		
		
	}
	
}
