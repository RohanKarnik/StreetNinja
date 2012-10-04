using UnityEngine;
using System.Collections;

public class BattleGui : MonoBehaviour {
	
	public Player player;
	
	public Enemy enemy;
	
	public float gameTimer;
	
	public int screenCounter = 0;
	
	public int aAbility;
	
	
	//Keeps track of number of turns
	public int turns;
	
	//0 = Player chooses A Abilities
	//1 = Player chooses B Abilities
	//2 = Player chooses C Abilities
	//3 = Choose to execute or redo
	//4 = A abilities execute
	//5 = B abilities execute
	//6 = C abilities execute
	//7 = Enemey's Turn
	public int turnPhases;
	
	//Abilities Buttons
	public UIButton A1Button;
	public UIButton A2Button;
	public UIButton A3Button;
	public UIButton A4Button;
	public UIButton A5Button;
	public UIButton B1Button;
	public UIButton B2Button;
	public UIButton B3Button;
	public UIButton B4Button;
	public UIButton B5Button;
	public UIButton C1Button;
	public UIButton C2Button;
	public UIButton C3Button;
	public UIButton C4Button;
	public UIButton C5Button;
	
	//NGUI GUI
	public UILabel playerStatusBox;
	public UILabel battleInfoBox;
	
	public UIFilledSprite hPoTIcon;
	public UILabel hPoTTurnLabel;
	
	public UIFilledSprite aPoTIcon;
	public UILabel aPoTTurnLabel;
	
	public UILabel enemyStatusBox;
	
	public UILabel turnsLabel;
	
	public UIFilledSprite shieldIcon;
	public UILabel shieldLabel;
	
	//Enemy Icons
	public UIFilledSprite enemyHPoTIcon;
	public UILabel enemyHPoTIconLabel;
	
	public UIFilledSprite enemyDoTIcon;
	public UILabel enemyDoTIconLabel;
	
	public UIFilledSprite enemyCanCastIcon;
	public UILabel enemyCanCastLabel;
	
	//Shown Damage Icons
	public UILabel playerHpHealLabel;
	public UILabel playerHpDamageLabel;
	
	public UILabel playerApGenLabel;
	
	
	
	// Update is called once per frame
	void Update () {
		
		#region Update Buttons
		if(A1Button != null)
			A1Button.UpdateColor(true,true);
		if(A2Button != null)
			A2Button.UpdateColor(true,true);
		if(A3Button != null)
			A3Button.UpdateColor(true,true);
		if(A4Button != null)
			A4Button.UpdateColor(true,true);
		if(A5Button != null)
			A5Button.UpdateColor(true,true);
		if(B1Button != null)
			B1Button.UpdateColor(true,true);
		if(B2Button != null)
			B2Button.UpdateColor(true,true);
		if(B3Button != null)
			B3Button.UpdateColor(true,true);
		if(B4Button != null)
			B4Button.UpdateColor(true,true);
		if(B5Button != null)
			B5Button.UpdateColor(true,true);
		if(C1Button != null)
			C1Button.UpdateColor(true,true);
		if(C2Button != null)
			C2Button.UpdateColor(true,true);
		if(C3Button != null)
			C3Button.UpdateColor(true,true);
		if(C4Button != null)
			C4Button.UpdateColor(true,true);
		if(C5Button != null)
			C5Button.UpdateColor(true,true);
		#endregion
		
		
		string headingText = "";
		string abilityText = "No ability chosen";
		
		#region BattleUI
		playerStatusBox.text = "Player\nHP : " + player.hP + "\nAP : " + player.aP;
		
		if(enemyStatusBox != null)
			enemyStatusBox.text = "Enemy\nHP : " + enemy.hP;
		
		#region Player OverTime Icons
		//Hp over TimeBuff
		if(player.playerStatus.hPBuffCounter > 0){
			if(hPoTIcon != null)
				hPoTIcon.fillAmount = 1;
			if(hPoTTurnLabel != null)
				hPoTTurnLabel.text = "" + (player.playerStatus.hPBuffCounter);
		}
		else{
			if(hPoTIcon != null)
				hPoTIcon.fillAmount = 0;
			if(hPoTTurnLabel != null)
				hPoTTurnLabel.text = "";
		}
		
		//Ap over TimeBuff
		if(player.playerStatus.aPBuffCounter > 0){
			if(aPoTIcon != null)
				aPoTIcon.fillAmount = 1;
			if(aPoTTurnLabel != null)
				aPoTTurnLabel.text = "" + (player.playerStatus.aPBuffCounter);
		}
		else{
			if(aPoTIcon != null)
				aPoTIcon.fillAmount = 0;
			if(aPoTTurnLabel != null)
				aPoTTurnLabel.text = "";
		}
		
		//Shield Buff
		if(player.playerStatus.shieldBuffCounter > 0){
			if(shieldIcon != null)
				shieldIcon.fillAmount = 1;
			if(shieldLabel != null)
				shieldLabel.text = "" + player.playerStatus.shieldBuffCounter;
		}
		else{
			if(shieldIcon != null)
				shieldIcon.fillAmount = 0;
			if(shieldLabel != null)
				shieldLabel.text = "";
		}
		
		#endregion
		
		#region Enemy OverTime Icons
		//Hp over TimeBuff
		if(enemy.hPoTCounter > 0){
			if(enemyHPoTIcon != null)
				enemyHPoTIcon.fillAmount = 1;
			if(enemyHPoTIconLabel != null)
				enemyHPoTIconLabel.text = "" + enemy.hPoTCounter;
		}
		else{
			if(enemyHPoTIcon != null)
				enemyHPoTIcon.fillAmount = 0;
			if(enemyHPoTIconLabel != null)
				enemyHPoTIconLabel.text = "";
		}
		//
		
		//Dam over Time
		if(enemy.doTCounter > 0){
			if(enemyDoTIcon != null)
				enemyDoTIcon.fillAmount = 1;
			if(enemyDoTIconLabel != null)
				enemyDoTIconLabel.text = "" + enemy.doTCounter;
		}
		else{
			if(enemyDoTIcon != null)
				enemyDoTIcon.fillAmount = 0;
			if(enemyDoTIconLabel != null)
				enemyDoTIconLabel.text = "";
		}
		
		//CanCast Debuff
		if(enemy.canCastCounter > 0){
			if(enemyCanCastIcon != null)
				enemyCanCastIcon.fillAmount = 1;
			if(enemyCanCastLabel != null)
				enemyCanCastLabel.text = "" + enemy.canCastCounter;
		}
		else{
			if(enemyCanCastIcon != null)
				enemyCanCastIcon.fillAmount = 0;
			if(enemyCanCastLabel != null)
				enemyCanCastLabel.text = "";	
		}
		
		#endregion
		
		//Turns
		if(turnsLabel != null){
			if(player.TurnPhases < 8)
				turnsLabel.text = "Player's Turn";
			else
				turnsLabel.text = "Enemy's Turn";
				
		}
		
		#endregion
		
		
		//TODO:Amend for C Ability Buffs
		//Player chooses A Abilities
		if(player.TurnPhases == 0){
			
			//BattleInfo
			#region A Abilities
			if(player.lastAbilityChosen == 1){
			
				if(player.playerAbilities.abilitiesA.a1level == 1)
					abilityText = "Ability A1 Lvl l: Generates 20 AP.\nHeals you for 3% each turn for the next 2 turns";
			
				else if(player.playerAbilities.abilitiesA.a1level == 2)
					abilityText = "Ability A1 Lvl 2: Generates 20 AP.\nHeals you for 5% each turn for the next 2 turns";
			
				else if(player.playerAbilities.abilitiesA.a1level == 3)
					abilityText = "Ability A1 Lvl 3: Generates 30 AP.\nHeals you for 5% each turn for the next 3 turns";
	

			}
			else if(player.lastAbilityChosen == 2){
			
				if(player.playerAbilities.abilitiesA.a2level == 1)
					abilityText = "Ability A2 LvL 1: AP Swipes, 15%-20AP, 15%-25AP,\n35%-30AP,35%-35AP";
				else if(player.playerAbilities.abilitiesA.a2level == 2)
					abilityText = "Ability A2 LvL 2: AP Swipes, 10%-20AP, 10%-25AP,\n40%-30AP,40%-35AP";
				else if(player.playerAbilities.abilitiesA.a2level == 3)
					abilityText = "Ability A2 LvL 3: AP Swipes, 5%-20AP, 5%-25AP,\n45%-30AP,45%-35AP";

			}
			else if(player.lastAbilityChosen == 3){
				if(player.playerAbilities.abilitiesA.a3level == 1)
					abilityText = "Ability A3 LvL 1: Generates 15 AP.\nGenerates 10AP each turn for next 2 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 2)
					abilityText = "Ability A3 LvL 2: Generates 15 AP.\nGenerates 10AP each turn for next 3 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 3)
					abilityText = "Ability A3 LvL 3: Generates 15 AP.\nGenerates 15AP each turn for next 3 turns";
			
			}
			else if(player.lastAbilityChosen == 4){
				if(player.playerAbilities.abilitiesA.a4level == 1)
					abilityText = "Ability A4 LvL 1: Generates 25 AP.\nGenerates 5AP each turn for next 2 turns";
				else if (player.playerAbilities.abilitiesA.a4level == 2)
					abilityText = "Ability A4 LvL 2: Generates 25 AP.\nGenerates 5AP each turn for next 3 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 3)
					abilityText = "Ability A4 LvL 3: Generates 25 AP.\nGenerates 10AP each turn for next 3 turns";

			}
			else if(player.lastAbilityChosen == 5){
				if(player.playerAbilities.abilitiesA.a5level == 1)
					abilityText = "Ability A5 LvL 1: Generates 20 AP + 3 AP\n each turn for rest of battle";
				else if (player.playerAbilities.abilitiesA.a5level == 2)
					abilityText = "Ability A5 LvL 2: Generates 20 AP + 5 AP\n each turn for rest of battle";
				else if (player.playerAbilities.abilitiesA.a5level == 3)
					abilityText = "Ability A5 LvL 3: Generates 30 AP + 5 AP\n each turn for rest of battle";

			}
			#endregion
		
			#region B Abilities
			else if(player.lastAbilityChosen == 6){
				if(player.playerAbilities.abilitiesB.b1level == 1){
					abilityText = "Ability B1 LvL1: Costs " + player.playerAbilities.abilitiesB.b1aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL1 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b1level == 2){
					abilityText = "Ability B1 LvL2: Costs " + player.playerAbilities.abilitiesB.b1aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL2 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b1level == 3){
					abilityText = "Ability B1 LvL2: Costs " + player.playerAbilities.abilitiesB.b1aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL3 * 100) +
							"%HP";
				}
			}
			else if(player.lastAbilityChosen == 7){
				if(player.playerAbilities.abilitiesB.b2level == 1){
					abilityText = "Ability B2 LvL1: Costs " + player.playerAbilities.abilitiesB.b2aPCost +
						" AP\nDoes Mid-Dam (25hP) and DoT to ememy for " + player.playerAbilities.abilitiesB.b2doTTurnsLvL1 +
							" turns";
				}
				
				else if(player.playerAbilities.abilitiesB.b2level == 2){
					abilityText = "Ability B2 LvL2: Costs " + player.playerAbilities.abilitiesB.b2aPCost +
						" AP\nDoes High-Dam (50hP) and DoT to ememy for " + player.playerAbilities.abilitiesB.b2doTTurnsLvL2 +
							" turns";
				}
				
				else if(player.playerAbilities.abilitiesB.b2level == 2){
					abilityText = "Ability B2 LvL3: Costs " + player.playerAbilities.abilitiesB.b2aPCost +
						" AP\nDoes High-Dam (50hP) and DoT to ememy for  " + player.playerAbilities.abilitiesB.b2doTTurnsLvL3 +
							" turns";
				}
			}
			else if(player.lastAbilityChosen == 8){
				
				if(player.playerAbilities.abilitiesB.b3level == 1){
					abilityText = "Ability B3 LvL1: Costs " + player.playerAbilities.abilitiesB.b3aPCost +
						" AP\nDoes High-Dam (50hP) and dispells enemy's buffs";
				}
				
				else if(player.playerAbilities.abilitiesB.b3level == 2){
					abilityText = "Ability B3 LvL2: Costs " + player.playerAbilities.abilitiesB.b3aPCost +
						" AP\nDoes Higher-Dam (75hP) and dispells enemy's buffs";
				}
				
				else if(player.playerAbilities.abilitiesB.b3level == 3){
					abilityText = "Ability B3 LvL3: Costs " + player.playerAbilities.abilitiesB.b3aPCost +
						" AP\nDoes Higher-Dam (75hP) and prevents enemy from casting buffs";
				}
			}
			else if(player.lastAbilityChosen == 9){
				if(player.playerAbilities.abilitiesB.b4level == 1){
					abilityText = "Ability B4 LvL1: Costs " + player.playerAbilities.abilitiesB.b4aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL1 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b4level == 2){
					abilityText = "Ability B4 LvL2: Costs " + player.playerAbilities.abilitiesB.b4aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL2 * 100) +
							"%HP";
				}
				
				else if(player.playerAbilities.abilitiesB.b4level == 3){
					abilityText = "Ability B4 LvL3: Costs " + player.playerAbilities.abilitiesB.b4aPCost +
						" AP\nDoes Mid-Dam (25hP) and Heals " + (player.playerAbilities.abilitiesB.b1hPHealLvL3 * 100) +
							"%HP";
				}
			}
			else if(player.lastAbilityChosen == 10){
				if(player.playerAbilities.abilitiesB.b5level == 1){
					abilityText = "Ability B5 LvL1: Costs " + player.playerAbilities.abilitiesB.b5aPCost +
						" AP\nDoes Mega-Dam (100HP) and ups Crit Area";
				}
				
				else if(player.playerAbilities.abilitiesB.b5level == 2){
					abilityText = "Ability B5 LvL2: Costs " + player.playerAbilities.abilitiesB.b5aPCost +
						" AP\nDoes Mega-Dam (100HP) and is a guaranteed Crit";
				}
				
				else if(player.playerAbilities.abilitiesB.b5level == 3){
					abilityText = "Ability B5 LvL3: Costs " + player.playerAbilities.abilitiesB.b5aPCost +
						" AP\nDoes Mega-Dam (100HP) and casts Big DoT for 3 turns";
				}
			}
			#endregion
			
			#region C Abilities
			else if(player.lastAbilityChosen == 11){
				if(player.playerAbilities.abilitiesC.c1level == 1){
					abilityText = "Ability C1 LvL1 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c1ApDiscount + " less AP\n" +
						"But " + (100 * player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL1) + "% less effective" +
						" for " + player.playerAbilities.abilitiesC.c1DeBuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c1level == 2){
					abilityText = "Ability C1 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c1ApDiscount + " less AP\n" +
						"But " + (100 * player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL2) + "% less effective" +
						" for " + player.playerAbilities.abilitiesC.c1DeBuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c1level == 3){
					abilityText = "Ability C1 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c1ApDiscount + " less AP\n" +
						"But " + (100 * player.playerAbilities.abilitiesC.c1AbilityDeBuffLvL3) + "% less effective" +
						" for " + player.playerAbilities.abilitiesC.c1DeBuffTurns + " turns";
				}
			}
			else if(player.lastAbilityChosen == 12){
				if(player.playerAbilities.abilitiesC.c2level == 1){
					abilityText = "Ability C2 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c2ApTax + " more AP\n" +
						"But " + (100 * (player.playerAbilities.abilitiesC.c2AbilityBuffLvL1 - 1.0f)) + "% more effective" +
						" for " + player.playerAbilities.abilitiesC.c2BuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c2level == 2){
					abilityText = "Ability C2 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c2ApTax + " more AP\n" +
						"But " + (100 * (player.playerAbilities.abilitiesC.c2AbilityBuffLvL2 - 1.0f)) + "% more effective" +
						" for " + player.playerAbilities.abilitiesC.c2BuffTurns + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c2level == 3){
					abilityText = "Ability C2 LvL2 Costs: 0AP\n" +
						"B Abilities cost " + player.playerAbilities.abilitiesC.c2ApTax + " more AP\n" +
						"But " + (100 * (player.playerAbilities.abilitiesC.c2AbilityBuffLvL3 - 1.0f)) + "% more effective" +
						" for " + player.playerAbilities.abilitiesC.c2BuffTurns + " turns";
				}
			}
			else if(player.lastAbilityChosen == 13){
				if(player.playerAbilities.abilitiesC.c3level == 1){
					abilityText = "Ability C3 LvL1 Costs: " + player.playerAbilities.abilitiesC.c3ApCost + "AP" +
						"\nA Abilities base generation in increased by " + player.playerAbilities.abilitiesC.c3ApGenBuffLvL1 +
						"AP\nFor the next " + player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL1 +  " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c3level == 2){
					abilityText = "Ability C3 LvL1 Costs: " + player.playerAbilities.abilitiesC.c3ApCost + "AP" +
						"\nA Abilities base generation in increased by " + player.playerAbilities.abilitiesC.c3ApGenBuffLvL2 +
						"AP\nFor the next " + player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL2 +  " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c3level == 3){
					abilityText = "Ability C3 LvL1 Costs: " + player.playerAbilities.abilitiesC.c3ApCost + "AP" +
						"\nA Abilities base generation in increased by " + player.playerAbilities.abilitiesC.c3ApGenBuffLvL3 +
						"AP\nFor the next " + player.playerAbilities.abilitiesC.c3ApGenBuffTurnsLvL3 +  " turns";
				}
			}
			else if(player.lastAbilityChosen == 14){
				if(player.playerAbilities.abilitiesC.c4level == 1){
					abilityText = "Ability C4 LvL1 Costs: " + player.playerAbilities.abilitiesC.c4ApCost + "AP" +
						"\nCasts a shield on self that absorbs " + (100 * player.playerAbilities.abilitiesC.c4BubbleBuffLvL1) + "%" +
						" of total health\n" +
						"Fades away in 2 turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c4level == 2){
					abilityText = "Ability C4 LvL1 Costs: " + player.playerAbilities.abilitiesC.c4ApCost + "AP" +
						"\nCasts a shield on self that absorbs " + (100 * player.playerAbilities.abilitiesC.c4BubbleBuffLvL2) + "%" +
						" of total health\n" +
						"Fades away in 2 turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c4level == 3){
					abilityText = "Ability C4 LvL1 Costs: " + player.playerAbilities.abilitiesC.c4ApCost + "AP" +
						"\nCasts a shield on self that absorbs " + (100 * player.playerAbilities.abilitiesC.c4BubbleBuffLvL3) + "%" +
						" of total health\n" +
						"Fades away in 2 turns";
				}
			}
			else if(player.lastAbilityChosen == 15){
				if(player.playerAbilities.abilitiesC.c5level == 1){
					abilityText = "Ability C5 LvL1 Costs: " + player.playerAbilities.abilitiesC.c5ApCost + "AP" +
						"\nB abilities cost 10 less AP for next " + player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL1 + " turns\n" +
						"A abilities generate 10AP more for " + player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl1 + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c5level == 2){
					abilityText = "Ability C5 LvL1 Costs: " + player.playerAbilities.abilitiesC.c5ApCost + "AP" +
						"\nB abilities cost 10 less AP for next " + player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL2 + " turns\n" +
						"A abilities generate 10AP more for " + player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl2 + " turns";
				}
				
				else if(player.playerAbilities.abilitiesC.c5level == 3){
					abilityText = "Ability C5 LvL1 Costs: " + player.playerAbilities.abilitiesC.c5ApCost + "AP" +
						"\nB abilities cost 10 less AP for next " + player.playerAbilities.abilitiesC.c5AbilityBBuffTurnsLvL3 + " turns\n" +
						"A abilities generate 10AP more for " + player.playerAbilities.abilitiesC.c5AbilityABuffTurnsLvl3 + " turns";
				}
			}
			#endregion
			
			headingText = "Battle Update: Time to choose abilities\n" + abilityText;
		}
		
		
		
		//Execute B Abilities
		else if(player.TurnPhases == 4){
			
			if(player.bAbilityChosen == -1)
				headingText = "Battle Update: No Ability B Chosen";
				
			else
				headingText = "Battle Update: Executing Ability B" + player.bAbilityChosen + "\n";
		}
		
		//Execute A Abilities
		else if(player.TurnPhases == 5){
			
			if(player.aAbilityChosen == -1)
				headingText = "Battle Update: No Ability A Chosen";
			else
				headingText = "Battle Update: Executing Ability A" + player.aAbilityChosen + "\n";
			
		}
		
		//Execute C Abilities
		else if(player.TurnPhases == 6){
			
			if(player.cAbilityChosen == -1)
				headingText = "Battle Update: No Ability C Chosen";
			else
				headingText = "Battle Update: Executing Ability C" + player.cAbilityChosen + "\n";
		}
		
		//Apply OverTime Effects
		else if(player.TurnPhases == 7){
			
				headingText = "Battle Update: Applying OvertimeEffects" + player.aAbilityChosen + "\n";
			
		}
		
		//Enemy's turn
		else if(player.TurnPhases == 8){
			
			if(battleInfoBox != null)
				headingText = "Battle Update: Enemy's Turn\n" +
					"Enemy Attacking Player";
			
		}
		
		if(battleInfoBox != null)
			battleInfoBox.text = headingText;
		
	}
}
