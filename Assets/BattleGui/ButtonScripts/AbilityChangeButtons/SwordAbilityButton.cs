using UnityEngine;
using System.Collections;

public class SwordAbilityButton : MonoBehaviour {

	public Player player;
	
	public UIButton button;
	
	public UIFilledSprite swordAbilitySkin1;
	public UIFilledSprite swordAbilitySkin2;
	public UIFilledSprite swordAbilitySkin3;
	public UIFilledSprite swordAbilitySkin4;
	public UIFilledSprite swordAbilitySkin5;
	
	void OnClick(){
		
		if(player.TurnPhases >= 0 && player.TurnPhases < 4){
			player.lastAbilityChosen = 0;
			
			player.TurnPhases = 2;

		}
	}
	
	void Update(){
		
		switch(player.swordAbilityChosen)
		{
		case 1:
			button.defaultColor = Color.clear;
			
			swordAbilitySkin1.color = Color.white;
			swordAbilitySkin2.color = Color.clear;
			swordAbilitySkin3.color = Color.clear;
			swordAbilitySkin4.color = Color.clear;
			swordAbilitySkin5.color = Color.clear;
			break;
		case 2:
			button.defaultColor = Color.clear;
			
			swordAbilitySkin1.color = Color.clear;
			swordAbilitySkin2.color = Color.white;
			swordAbilitySkin3.color = Color.clear;
			swordAbilitySkin4.color = Color.clear;
			swordAbilitySkin5.color = Color.clear;
			break;
		case 3:
			button.defaultColor = Color.clear;
			
			swordAbilitySkin1.color = Color.clear;
			swordAbilitySkin2.color = Color.clear;
			swordAbilitySkin3.color = Color.white;
			swordAbilitySkin4.color = Color.clear;
			swordAbilitySkin5.color = Color.clear;
			break;
		case 4:
			button.defaultColor = Color.clear;
			
			swordAbilitySkin1.color = Color.clear;
			swordAbilitySkin2.color = Color.clear;
			swordAbilitySkin3.color = Color.clear;
			swordAbilitySkin4.color = Color.white;
			swordAbilitySkin5.color = Color.clear;
			break;
		case 5:
			button.defaultColor = Color.clear;
			
			swordAbilitySkin1.color = Color.clear;
			swordAbilitySkin2.color = Color.clear;
			swordAbilitySkin3.color = Color.clear;
			swordAbilitySkin4.color = Color.clear;
			swordAbilitySkin5.color = Color.white;
			break;
		default:
			button.defaultColor = Color.white;
			
			swordAbilitySkin1.color = Color.clear;
			swordAbilitySkin2.color = Color.clear;
			swordAbilitySkin3.color = Color.clear;
			swordAbilitySkin4.color = Color.clear;
			swordAbilitySkin5.color = Color.clear;
			break;
		}
	}
}
