using UnityEngine;
using System.Collections;

public class EnemyBuff4Switch : MonoBehaviour {

	public UIButton button;
	
	public Player player;
	
	public Enemy enemy;
	
	void OnClick(){
		
		if(enemy.enemyStatus.strDefUpBuffCounter > 0){
			
			player.lastEnemyBuffDebuffClicked = 3;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemy.enemyStatus.strDefUpBuffCounter > 0){
			button.enabled = true;
			if(player.lastEnemyBuffDebuffClicked == 3)
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
