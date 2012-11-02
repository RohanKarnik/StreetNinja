using UnityEngine;
using System.Collections;

public class GunAbilityButton : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	public UIFilledSprite gunAbilitySkin1;
	public UIFilledSprite gunAbilitySkin2;
	public UIFilledSprite gunAbilitySkin3;
	public UIFilledSprite gunAbilitySkin4;
	public UIFilledSprite gunAbilitySkin5;
	
	void OnClick(){
		
		if(player.TurnPhases >= 0 && player.TurnPhases < 4){
			player.lastAbilityChosen = 0;
			
			player.TurnPhases = 1;

		}
	}
	
	void Update(){
		
		//Update Ability Button Logo
		switch(player.gunAbilityChosen){
		case 1:			
			gunAbilitySkin1.color = Color.white;
			gunAbilitySkin2.color = Color.clear;
			gunAbilitySkin3.color = Color.clear;
			gunAbilitySkin4.color = Color.clear;
			gunAbilitySkin5.color = Color.clear;
			break;
		case 2:			
			gunAbilitySkin1.color = Color.clear;
			gunAbilitySkin2.color = Color.white;
			gunAbilitySkin3.color = Color.clear;
			gunAbilitySkin4.color = Color.clear;
			gunAbilitySkin5.color = Color.clear;
			break;
		case 3:			
			gunAbilitySkin1.color = Color.clear;
			gunAbilitySkin2.color = Color.clear;
			gunAbilitySkin3.color = Color.white;
			gunAbilitySkin4.color = Color.clear;
			gunAbilitySkin5.color = Color.clear;
			break;
		case 4:			
			gunAbilitySkin1.color = Color.clear;
			gunAbilitySkin2.color = Color.clear;
			gunAbilitySkin3.color = Color.clear;
			gunAbilitySkin4.color = Color.white;
			gunAbilitySkin5.color = Color.clear;
			break;
		case 5:			
			gunAbilitySkin1.color = Color.clear;
			gunAbilitySkin2.color = Color.clear;
			gunAbilitySkin3.color = Color.clear;
			gunAbilitySkin4.color = Color.clear;
			gunAbilitySkin5.color = Color.white;
			break;
		default:			
			gunAbilitySkin1.color = Color.clear;
			gunAbilitySkin2.color = Color.clear;
			gunAbilitySkin3.color = Color.clear;
			gunAbilitySkin4.color = Color.clear;
			gunAbilitySkin5.color = Color.clear;
			break;
		}
		
	}
		
}
