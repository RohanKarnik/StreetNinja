using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {
	
	
	//Struct to hold the values changing through battle
	/*Possiblity: Ability class holding a TotalBonus figure to add to player's stats
	public struct abilityGroupCurrent{
		
		//A abilities
		
		//AddPopRockBonus
		
		//B abilities
		
		//AddPopRockBonus
		
		//C abilities
		
		//AddPopRockBonus
	}*/
	
	//Generates AP
	public struct AbilitiesA{
		
		//Effects Variables
		#region A-1
		/*[A-1]LvL 1 Generate 20 AP. Heals 3% for the next 2 turns. (HoT)
			2 Gen 20 AP. Heals 5% next 2 turns. (HoT)
			3 Gen 20 AP. Heals  5% the next 3 turns. (HoT)
			All nonstack*/
		public int a1level;
		
		public int a1ApBoost;
		
		public float a1hoTPercentLvL1;
		public float a1hoTPercentLvL2;
		public float a1hoTPercentLvL3;
		
		
		public int a1hoTTurnsLvL1;
		public int a1hoTTurnsLvL2;
		public int a1hoTTurnsLvL3;
		#endregion
		
		#region A-2
		/*[A-2] (Lvl1)15%, (Lvl2)10%, (Lvl3)5% chance to generate 20AP,
			15%, 10%, 5% chance to generate 25AP,
			35%, 40%, 45% chance to generate 30AP,
			35%, 40%, 45% chance to generate 35AP,
			*/
		public int a2level;
		
		public int a2aPBoostA;
		public int a2aPBoostB;
		public int a2aPBoostC;
		public int a2aPBoostD;
		
		public int a2APSwipesALvL1;
		public int a2APSwipesBLvL1;
		public int a2APSwipesCLvL1;
		public int a2APSwipesDLvL1;
		
		public int a2APSwipesALvL2;
		public int a2APSwipesBLvL2;
		public int a2APSwipesCLvL2;
		public int a2APSwipesDLvL2;
		
		public int a2APSwipesALvL3;
		public int a2APSwipesBLvL3;
		public int a2APSwipesCLvL3;
		public int a2APSwipesDLvL3;
		
		
		#endregion
		
		#region A-3
		/*[A-3]Lvl 1 Generate 15AP. Gen 10AP for next 2 turns. 
				2 Gen 15AP. Gen 10AP for next 3 turns.
				3 Gen 15AP. Gen 15AP for next 3 turns.
				All unstackable with self*/
		public int a3level;
		
		public int a3ApBoost;
		
		public int a3aoTBoostLvL1;
		public int a3aoTBoostLvL2;
		public int a3aoTBoostLvL3;
		
		
		public int a3aoTTurnsLvL1;
		public int a3aoTTurnsLvL2;
		public int a3aoTTurnsLvL3;
		#endregion
		
		#region A-4
		/*[A-4] Gen 25 AP. Gen 5AP for next 2 turns.
				Gen 25 AP. Gen 5AP for next 3 turns.
				Gen 25 AP. Gen 10AP for next 3 turns.
				All unstackable with self*/
		public int a4level;
		
		public float a4ApBoost;
		
		public int a4aoTBoostLvL1;
		public int a4aoTBoostLvL2;
		public int a4aoTBoostLvL3;
		
		
		public int a4aoTTurnsLvL1;
		public int a4aoTTurnsLvL2;
		public int a4aoTTurnsLvL3;
		
		#endregion
		
		#region A-5
		/*[A-5] Gen 20 AP + 3 AP each turn for rest of battle.
				Gen 20 AP + 5 AP each turn for rest of battle.
				Gen 30 AP + 5 AP each turn for rest of battle.
				All unstackable with self*/
		
		public int a5level;
		
		public int a5ApBoostLvl1;
		public int a5ApBoostLvl2;
		public int a5ApBoostLvl3;
		
		public int a5aoTBoostLvL1;
		public int a5aoTBoostLvL2;
		public int a5aoTBoostLvL3;
		
		public int a5aoTTurns;
		
		#endregion
		
	}
	
	public AbilitiesA abilitiesA;

	
	//Cost AP
	public struct AbilitiesB{
	
		//Effect variables
		#region B-1
		/*[B-1] Costs 20AP
				Mid Damage + 5% heal
				Mid Damage +10% heal
				Mid Damage + 15% heal*/
		public int b1level;
		
		public int b1aPCost;
		
		public int b1Damage;
		
		public float b1hPHealLvL1;
		public float b1hPHealLvL2;
		public float b1hPHealLvL3;
		#endregion
		
		#region B-2
		/*[B-2] Costs 35AP
				Mid damage + Cast a DoT on the enemy for next 2 turns
				High damage + Cast a DoT on the enemy for next 2 turns
				High damage + Cast a DoT on the enemy for next 3 turns*/
		public int b2level;
		
		public int b2aPCost;
		
		public int b2DamageLvL1;
		public int b2DamageLvL2;
		public int b2DamageLvL3;
		
		public int b2doTLvL1;
		public int b2doTLvL2;
		public int b2doTLvL3;
		
		public int b2doTTurnsLvL1;
		public int b2doTTurnsLvL2;
		public int b2doTTurnsLvL3;
		#endregion
		
		#region B-3
		/*B-3] Costs 50AP
				High damage + dispel all enemy buffs
				Higher damage + dispel all enemy buffs
				Higher Damage + prevent enemy from casting any buff*/
		
		public int b3level;
		
		public int b3aPCost;
		
		public int b3DamageLvL1;
		public int b3DamageLvL2;
		public int b3DamageLvL3;
		#endregion
		
		#region B-4
		/*B-4] Costs 70AP
				Mid Dmg + 50% heal
				Mid Damage + 60% heal
				Mid Damage +70% heal*/
		
		public int b4level;
		
		public int b4aPCost;
		
		public int b4Damage;
		
		public float b4hPHealLvL1;
		public float b4hPHealLvL2;
		public float b4hPHealLvL3;
		#endregion
		
		#region B-5
		//TODO: Crit Area, Critical Attack, DoT effect
		/*[B-5] Costs 90AP
				Mega Damage. Crit area is bigger than usual
				Mega Damage. Guaranteed Crit
				Mega Damage. Guaranteed Crit. Casts a powerful DoT on enemy for 3 turns.*/
		
		public int b5level;
		
		public int b5aPCost;

		public int b5Damage;
		
		public int b5doTLvL3;
		public int b5doTTurnsLvL3;
		
		//public var b5Effect;
		//public var Crit;
		//public var b5Dot;
		#endregion
		
	}
	
	public AbilitiesB abilitiesB;
	
	//Buff A and B
	public struct AbilitiesC{
		
		#region C-1
		/*[C-1] Free
				B abilities cost 10AP less but are 15% less effective for next 2 turns. C-2 negates
				B abilities cost 10AP less but are 10% less effective for next 2 turns. C-2 negates
				B abilities cost 10AP less but are 5% less effective for next 2 turns. C-2 negates*/
		public int c1level;
		
		public int c1ApDiscount;
		public int c1ApDiscountCounter;
		
		public float c1AbilityDeBuffLvL1;
		public float c1AbilityDeBuffLvL2;
		public float c1AbilityDeBuffLvL3;
		
		public int c1DeBuffTurns;
		
		#endregion
		
		#region C-2
		/*C-2] Free
			B Abilities cost 10 more AP but are 15% more effective for next 2 turns. C-1 Negates
			B Abilities cost 10 more AP but are 20% more effective for next 2 turns. C-1 Negates
			B Abilities cost 10 more AP but are 25% more effective for next 2 turns. C-1 Negates*/
		public int c2level;
		
		public int c2ApTax;
		public int c2ApTaxCounter;
		
		public float c2AbilityBuffLvL1;
		public float c2AbilityBuffLvL2;
		public float c2AbilityBuffLvL3;
		public int c2BuffTurns;
		
		#endregion
		
		#region C-3
		/*[C-3] Costs 50 AP
			A abilities base generation in increased by 5AP for next 2 turns. Affects APoT (A-3, A-4, A-5)
			A abilities base generation in increased by 10AP for next 2 turns. Affects APoT (A-3, A-4, A-5)
			A abilities base generation in increased by 10AP for next 3 turns. Affects APoT (A-3, A-4, A-5)*/
		public int c3level;
		
		public int c3ApCost;
		
		public int c3ApGenBuffLvL1;
		public int c3ApGenBuffLvL2;
		public int c3ApGenBuffLvL3;
		
		public int c3ApGenBuffTurnsLvL1;
		public int c3ApGenBuffTurnsLvL2;
		public int c3ApGenBuffTurnsLvL3;
		
		
		#endregion
		
		#region C-4
		/*C-4] Costs 50 AP
			Casts a protective shield on yourself that absorbs 10% of your total health. Fades away in 2 turns
			Casts a protective shield on yourself that absorbs 20% of your total health. Fades away in 2 turns
			Casts a protective shield on yourself that absorbs 30% of your total health. Fades away in 2 turns*/
		
		
		public int c4level;
		
		public int c4ApCost;
		
		public float c4BubbleBuffLvL1;
		public float c4BubbleBuffLvL2;
		public float c4BubbleBuffLvL3;
		
		public int c4BubbleBuffTurns;
		
		#endregion
		
		#region C-5
		/*[C-5] Costs 70AP
			B abilities cost 10 less AP for next 2 turns. A abilities generate 10AP more for 2 turns.
			B abilities cost 10 less AP for next 3 turns. A abilities generate 10AP more for 3 turns.
			B abilities cost 10 less AP for next 4 turns. A abilities generate 10AP more for 4 turns.*/
		public int c5level;
		
		public int c5ApCost;
		
		public int c5AbilityABuff;
		public int c5AbilityABuffTurnsLvl1;
		public int c5AbilityABuffTurnsLvl2;
		public int c5AbilityABuffTurnsLvl3;
		
		public int c5AbilityBBuff;
		public int c5AbilityBBuffTurnsLvL1;
		public int c5AbilityBBuffTurnsLvL2;
		public int c5AbilityBBuffTurnsLvL3;
		
		#endregion
		
	}
	
	public AbilitiesC abilitiesC;

	
	
	//public void AddPopRockBonus(){
		//TODO:Add pop rox bonus to most current Ability figure
	//}
	
}