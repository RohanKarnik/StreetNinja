using UnityEngine;
using System.Collections;

public class C5 : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	
	void OnClick(){
		
		if(player.TurnPhases == 0){
				
			player.stanceChosen = 5;
			
			player.stanceChanged = true;
				//player.TurnPhases = 4;
			
				//Delay
				//player.gameTimer = Time.time + 3;
				
			
		}
		
	}
	
	void OnHover(){
			if(player.TurnPhases == 0)
				player.lastAbilityChosen = 15;
	}
	
	
	void Update(){
		
		//if(player.TurnPhases > 0){
		
		if(player.stanceChosen  == 5)
				button.defaultColor = Color.red;
		//}
		
		//else if(player.TurnPhases == 0){
			//if(player.cAbilityChosen != 5)
		else
				button.defaultColor = Color.white;
		//}
		
	}
}
