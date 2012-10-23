using UnityEngine;
using System.Collections;


public class Abilities : MonoBehaviour{
	
	public class Clip{};
	public class Glyph{};
	
	public class Icon{};
	
	public class InteractionType{};
	
	[System.Serializable]
	public class Ability{
		
		public int damage;
		
		/*public float rangeMin;
		public float rangeMax;
		public int lastRangedDam;*/
		
		public int lastDamage;
		public int lastApBoost;
		
		public int cost;
		
		public float multiplier;
		
		public float xPToClip;
		
	}
	
	[System.Serializable]
	public class GunAbilities{
		
		/*1 tap
		DMG: STR  
		AP: +15 (15 total)
		Multiplier: 100%
		XP to Clips: 1*/
		public Ability ScarletShot = new Ability();
		
		/*2 taps
		DMG: STR * 1.75    
		AP: +5 (10 total)
		Multiplier: 100%
        XP to Clips: 1*/
		public Ability DarkBullet = new Ability();
		
		/*4 taps
		DMG: STR  
		AP: +3 (12 total)
		Multiplier: 150%
		XP to Clips: 1*/
		public Ability PlagueBlast = new Ability();
		
		/*5 taps
		DMG: STR * 1
		AP: +3 (15 total)
		Multiplier: 150%
		XP to Clips: 2*/
		public Ability BlitzBarrage = new Ability();
		
		/*6 taps
		DMG: STR * 1
		AP: +3 (18 total)
		Multiplier: 200%
		XP to Clips: 2*/
		public Ability ShadowflameShot = new Ability();
		
	}
	
	[System.Serializable]
	public class SwordAbilities{
		/*DMG: STR*4
			AP: -10
			Multiplier: 1.0
			XP to Glyph: 1*/
		public Ability BloodBlade = new Ability();
		
		/*DMG: STR*4.6
			AP: -20
			Multiplier: 1.3
			XP to Glyph: 1*/
		public Ability DeathStrike = new Ability();
		
		/*DMG: STR*4.6
			AP: -40
			Multiplier: 1.8
			XP to Glyph: 1*/
		public Ability ShadowFlameSlash = new Ability();
		
		/*DMG: STR*5.0
			AP: -40
			Multiplier: 1.6
			XP to Glyph: 2*/
		public Ability CrimsonCut = new Ability();
		
		/*DMG: STR*5
			AP: -80
			Multiplier: 3.0
			XP to Glyph: 3*/
		public Ability ShadowFury = new Ability();
	}
	
	[System.Serializable]
	public class Stances{
		
		//Increases damage done by 25% and damage taken by 25%. (Offensive)
		public bool StanceOfBloodlust;
		public float StanceOfBLOffensiveIncrease = 1.25f;
		public float StanceOfBLDefensiveDecrease = 1.25f;
		
		//Health Gains increased by 25% (Health Regen)
		public bool StanceOfMurder;
		public float StanceOfMHealthRegen = 1.25f;
		
		//Reduces Damage done by 25% and Reduces damage taken by 25% (Defensive)
		public bool StanceOfShadowsVengence;
		public float StanceOfSVOffensiveDecrease = .75f;
		public float StanceOfSVDeffensiveIncrease = .75f;
		
		//Increases AP generation by 25%
		public bool StanceOfDeath;
		public float StanceOfDApGenBoost = 1.25f;
			
		//reduces all DoT damage by 50%
		public bool StanceOfDarkProtection;
		public float StanceOfDPDoTReduction = .50f;
		
		
	}
	
	public GunAbilities gunAbilities;
	public SwordAbilities sworddAbilities;
	public Stances stances;
	
}