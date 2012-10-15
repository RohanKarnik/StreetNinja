using UnityEngine;
using System.Collections;

public class EnemyDeBuff1Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	public Enemy enemy;
	
	void OnClick(){
		
		if(enemy.enemyStatus.doTCounter > 0){
			
			player.lastEnemyBuffDebuffClicked = 4;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.enemyStatus.doTCounter > 0){
			button.enabled = true;
			if(player.lastEnemyBuffDebuffClicked == 4)
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
