using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
		public UIImageButton enemyIcon;
	
		public Player player;
	
		void OnClick(){
			if(player.TurnPhases == 0){
				isClicked = true;
			}
		}

		public int hP;
		
		//Attack Notes
		//Dam   10 hp        20 mp
		
		//Attack 1 = 0, Attack 2 = 1, Null -1
		public int previousAttack;
		
		public bool isClicked;
		
		//Over Time Buff
		public float hPoT;
		public int hPoTCounter;
	
		//Over Time Dam
		public float doT;
		public int doTCounter;
	
		//Status effects
		public bool canCast;
		public int canCastCounter;
	
	
	// Use this for initialization
	void Start () {
	
		hP = 1000;
		previousAttack = 0;
		
		isClicked = false;
		
		doTCounter = -1;
		
		//TODO: Populate enemyStatus struct
		hPoT = 1.0f;
		hPoTCounter = 0;
		
		doT = 1.0f;
		doTCounter = 0;
		
		canCast = true;
		canCastCounter = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
