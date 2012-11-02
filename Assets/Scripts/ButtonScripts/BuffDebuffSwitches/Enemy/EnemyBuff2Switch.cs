using UnityEngine;
using System.Collections;

public class EnemyBuff2Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	public Enemy enemy;
	
	void OnClick(){
		
		if(enemy.enemyStatus.enemySpecificBuffCounter > 0){
			
			player.lastEnemyBuffDebuffClicked = 1;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.enemyStatus.enemySpecificBuffCounter > 0){
			button.enabled = true;
			if(player.lastEnemyBuffDebuffClicked == 1)
				button.defaultColor = Color.white;
			else
				button.defaultColor = Color.clear;
		}
		else{
			button.enabled = false;
			button.defaultColor = Color.clear;
		}
	}
}
