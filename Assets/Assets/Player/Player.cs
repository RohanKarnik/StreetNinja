using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
		public float hP;
		public float aP;
	
		public int battleTurn;
	
		//0 = Player chooses A Abilities
		//1 = Player chooses B Abilities
		//2 = Player chooses C Abilities
		//3 = Choose to execute or redo
		//4 = A abilities execute
		//5 = B abilities execute
		//6 = C abilities execute
		//7 = Enemey's Turn
		public int TurnPhases;
	
		//Player = 0, Enemy = 1
		public int lastTurn;
	
		public struct PlayerStatus{
		
		//Over Time Buff
			public float hPoT;
			public int hPBuffCounter;
		
			public float aPoT;
			public int aPBuffCounter;
		
			public int aAbilitiesBuff;
			public int aAbilitiesBuffCounter;
		
			public int bAbilitiesApDiscount;
			public int bAbilitiesApDiscountCounter;
		
			public int bAbilitiesApTax;
			public int bAbilitiesApTaxCounter;
		
			public float bAbilitiesBuff;
			public int bAbilitiesBuffCounter;
		
			public float bAbilitiesDeBuff;
			public int bAbilitiesDeBuffCounter;
		
			public float shieldBuff;
			public int shieldBuffCounter;
		
		
		//Over Time Dam
			public float doTDamage;
			public float doTCounter;
		
	}
	
		public PlayerStatus playerStatus;
		
		public Abilities playerAbilities;
	
		public int aAbilityChosen;
		public int bAbilityChosen;
		public int cAbilityChosen;
	
		//0-14, A1 = 1, A2 = 2..etc
		public int lastAbilityChosen;
	
		public float gameTimer;
	
	
		public void populateAbilities(Abilities abilities){
		#region A Abilities
		
		#region A1
		abilities.abilitiesA.a1level = 1;
		
		abilities.abilitiesA.a1ApBoost = 20;
		
		abilities.abilitiesA.a1hoTPercentLvL1 = .03f;
		abilities.abilitiesA.a1hoTPercentLvL2 = .05f;
		abilities.abilitiesA.a1hoTPercentLvL3 = .05f;
		
		
		abilities.abilitiesA.a1hoTTurnsLvL1 = 2;
		abilities.abilitiesA.a1hoTTurnsLvL2 = 2;
		abilities.abilitiesA.a1hoTTurnsLvL3 = 3;
		#endregion
		
		#region A2
		abilities.abilitiesA.a2level = 1;
		
		abilities.abilitiesA.a2aPBoostA = 20;
		abilities.abilitiesA.a2aPBoostB = 25;
		abilities.abilitiesA.a2aPBoostC = 30;
		abilities.abilitiesA.a2aPBoostD = 35;
		
		abilities.abilitiesA.a2APSwipesALvL1 = 15;
		abilities.abilitiesA.a2APSwipesBLvL1 = 15;
		abilities.abilitiesA.a2APSwipesCLvL1 = 35;
		abilities.abilitiesA.a2APSwipesDLvL1 = 35;
		
		abilities.abilitiesA.a2APSwipesALvL2 = 10;
		abilities.abilitiesA.a2APSwipesBLvL2 = 10;
		abilities.abilitiesA.a2APSwipesCLvL2 = 40;
		abilities.abilitiesA.a2APSwipesDLvL2 = 40;
		
		abilities.abilitiesA.a2APSwipesALvL3 = 5;
		abilities.abilitiesA.a2APSwipesBLvL3 = 5;
		abilities.abilitiesA.a2APSwipesCLvL3 = 5;
		abilities.abilitiesA.a2APSwipesDLvL3 = 5;
		#endregion
		
		#region A3
		abilities.abilitiesA.a3level = 1;
		
		abilities.abilitiesA.a3ApBoost = 15;
		
		abilities.abilitiesA.a3aoTBoostLvL1 = 10;
		abilities.abilitiesA.a3aoTBoostLvL2 = 10;
		abilities.abilitiesA.a3aoTBoostLvL3 = 10;
		
		
		abilities.abilitiesA.a3aoTTurnsLvL1 = 2;
		abilities.abilitiesA.a3aoTTurnsLvL2 = 3;
		abilities.abilitiesA.a3aoTTurnsLvL3 = 3;
		#endregion
		
		#region A4
		abilities.abilitiesA.a4level = 1;
		
		abilities.abilitiesA.a4ApBoost = 25;
		
		abilities.abilitiesA.a4aoTBoostLvL1 = 5;
		abilities.abilitiesA.a4aoTBoostLvL2 = 5;
		abilities.abilitiesA.a4aoTBoostLvL3 = 10;
		
		
		abilities.abilitiesA.a4aoTTurnsLvL1 = 2;
		abilities.abilitiesA.a4aoTTurnsLvL2 = 3;
		abilities.abilitiesA.a4aoTTurnsLvL3 = 3;
		#endregion
		
		#region A5
		abilities.abilitiesA.a5level = 1;
		
		abilities.abilitiesA.a5ApBoostLvl1 = 20;
		abilities.abilitiesA.a5ApBoostLvl2 = 20;
		abilities.abilitiesA.a5ApBoostLvl3 = 30;
		
		abilities.abilitiesA.a5aoTBoostLvL1 = 3;
		abilities.abilitiesA.a5aoTBoostLvL2 = 5;
		abilities.abilitiesA.a5aoTBoostLvL3 = 5;
		
		abilities.abilitiesA.a5aoTTurns = 100;
		#endregion
		
		#endregion
		
		#region B Abilities
		//TEMPORARY FIGURES based on emey hP: 500
		//Mid Dam = 25hP
		//High Dam = 50hP
		//Higher Dam = 75 hP
		//Mega Dam = 100hP
		
		//DoT = 50 Dam
		
		#region B-1
		abilities.abilitiesB.b1level = 1;
		
		abilities.abilitiesB.b1aPCost = 20;
		
		
		abilities.abilitiesB.b1Damage = 25;
		
		abilities.abilitiesB.b1hPHealLvL1 = .05f;
		abilities.abilitiesB.b1hPHealLvL2 = .10f;
		abilities.abilitiesB.b1hPHealLvL3 = .15f;
		#endregion
		
		#region B-2
		abilities.abilitiesB.b2level = 1;
		
		abilities.abilitiesB.b2aPCost = 35;
		
		abilities.abilitiesB.b2DamageLvL1 = 25;
		abilities.abilitiesB.b2DamageLvL2 = 50;
		abilities.abilitiesB.b2DamageLvL3 = 50;
		
		abilities.abilitiesB.b2doTLvL1 = 50;
		abilities.abilitiesB.b2doTLvL2 = 50;
		abilities.abilitiesB.b2doTLvL3 = 50;
		
		abilities.abilitiesB.b2doTTurnsLvL1 = 2;
		abilities.abilitiesB.b2doTTurnsLvL2 = 2;
		abilities.abilitiesB.b2doTTurnsLvL3 = 3;
		#endregion
		
		#region B-3
		abilities.abilitiesB.b3level = 1;
		
		abilities.abilitiesB.b3aPCost = 50;
		
		abilities.abilitiesB.b3DamageLvL1 = 50;
		abilities.abilitiesB.b3DamageLvL2 = 75;
		abilities.abilitiesB.b3DamageLvL3 = 75;
		#endregion
		
		#region B-4
		abilities.abilitiesB.b4level = 1;
		
		abilities.abilitiesB.b4aPCost = 70;
		
		abilities.abilitiesB.b4Damage = 25;
		
		abilities.abilitiesB.b4hPHealLvL1 = .50f;
		abilities.abilitiesB.b4hPHealLvL2 = .60f;
		abilities.abilitiesB.b4hPHealLvL3 = .70f;
		#endregion
		
		#region B-5
		abilities.abilitiesB.b5level = 1;
		
		abilities.abilitiesB.b5aPCost = 90;

		abilities.abilitiesB.b5Damage = 100;
		
		abilities.abilitiesB.b5doTLvL3 = 75;
		#endregion
		
		#endregion
		
		#region C Abilities
		
		#region C-1
		abilities.abilitiesC.c1level = 1;
		
		abilities.abilitiesC.c1ApDiscount = 10;
		abilities.abilitiesC.c1ApDiscountCounter = 0;
		
		abilities.abilitiesC.c1AbilityDeBuffLvL1 = .15f;
		abilities.abilitiesC.c1AbilityDeBuffLvL2 = .10f;
		abilities.abilitiesC.c1AbilityDeBuffLvL3 = .05f;
		
		abilities.abilitiesC.c1DeBuffTurns = 2;
		
		#endregion
		
		#region C-2
		abilities.abilitiesC.c2level = 1;
		
		abilities.abilitiesC.c2ApTax = 10;
		abilities.abilitiesC.c2ApTaxCounter = 0;
		
		abilities.abilitiesC.c2AbilityBuffLvL1 = 1.15f;
		abilities.abilitiesC.c2AbilityBuffLvL2 = 1.20f;
		abilities.abilitiesC.c2AbilityBuffLvL3 = .25f;
		
		abilities.abilitiesC.c2BuffTurns = 2;
		
		#endregion
		
		#region C-3
		abilities.abilitiesC.c3level = 1;
		
		abilities.abilitiesC.c3ApCost = 50;
		
		abilities.abilitiesC.c3ApGenBuffLvL1 = 5;
		abilities.abilitiesC.c3ApGenBuffLvL2 = 5;
		abilities.abilitiesC.c3ApGenBuffLvL3 = 10;
		
		abilities.abilitiesC.c3ApGenBuffTurnsLvL1 = 2;
		abilities.abilitiesC.c3ApGenBuffTurnsLvL2 = 2;
		abilities.abilitiesC.c3ApGenBuffTurnsLvL3 = 3;
		
		#endregion
		
		#region C-4
		abilities.abilitiesC.c4level = 1;
		
		abilities.abilitiesC.c4ApCost = 50;
		
		abilities.abilitiesC.c4BubbleBuffLvL1 = .10f;
		abilities.abilitiesC.c4BubbleBuffLvL2 = .20f;
		abilities.abilitiesC.c4BubbleBuffLvL3 = .30f;
		
		abilities.abilitiesC.c4BubbleBuffTurns = 2;
		
		#endregion
		
		#region C-5
		abilities.abilitiesC.c5level = 1;
		
		abilities.abilitiesC.c5ApCost = 70;
		
		abilities.abilitiesC.c5AbilityABuff = 10;
		abilities.abilitiesC.c5AbilityABuffTurnsLvl1 = 2;
		abilities.abilitiesC.c5AbilityABuffTurnsLvl2 = 3;
		abilities.abilitiesC.c5AbilityABuffTurnsLvl3 = 4;
		
		abilities.abilitiesC.c5AbilityBBuff = 10;
		abilities.abilitiesC.c5AbilityBBuffTurnsLvL1 = 2;
		abilities.abilitiesC.c5AbilityBBuffTurnsLvL2 = 3;
		abilities.abilitiesC.c5AbilityBBuffTurnsLvL3 = 4;
		#endregion
		
		#endregion
	}
	
		public void populatePlayerStatus(PlayerStatus tempPlayerStatus){
		
		tempPlayerStatus.hPoT = 0;
		tempPlayerStatus.hPBuffCounter = 0;
		
		tempPlayerStatus.aPoT = 0;
		tempPlayerStatus.aPBuffCounter = 0;
		
		tempPlayerStatus.aAbilitiesBuff = 0;
		tempPlayerStatus.aAbilitiesBuffCounter = 0;
		
		tempPlayerStatus.bAbilitiesApDiscount = 0;
		tempPlayerStatus.bAbilitiesApTax = 0;
		
		tempPlayerStatus.bAbilitiesBuff = 1.0f;
		tempPlayerStatus.bAbilitiesBuffCounter = 0;
		
		tempPlayerStatus.bAbilitiesDeBuff = 1.0f;
		tempPlayerStatus.bAbilitiesDeBuffCounter = 0;
		
		tempPlayerStatus.doTDamage = 0;
		tempPlayerStatus.doTCounter = 0;
		
		tempPlayerStatus.shieldBuff = 0.0f;
		tempPlayerStatus.shieldBuffCounter = 0;
	}
	
	// Use this for initialization
	void Start () {
	
		//Initial Stats
		hP = 1000;
		aP = 0;
		
		populateAbilities(playerAbilities);
		populatePlayerStatus(playerStatus);
		
		aAbilityChosen = -1;
		bAbilityChosen = -1;
		cAbilityChosen = -1;
		
		lastAbilityChosen = -1;
		
		
		battleTurn = 0;
		TurnPhases = 0;
		lastTurn = 1;
		
		gameTimer = 0;
		
	}
	
}
