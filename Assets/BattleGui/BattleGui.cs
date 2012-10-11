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
	[System.Serializable]
	public class AbilitiesButtons{
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
	}
	
	public AbilitiesButtons abilitiesButtons;
	
	//NGUI GUI
	[System.Serializable]
	public class BattleInfo{
		public UILabel playerStatusBox;
		public UILabel battleInfoBox;
	
		public UILabel enemyStatusBox;
	
		public UILabel turnsLabel;
	
		//Shown Damage Icons
		public UILabel playerHpHealLabel;
		public UILabel playerHpDamageLabel;
	
		public UILabel playerApGenLabel;
	
		public UILabel turnTotalDamageLabel;
	
		public UILabel enemyHpDamageLabel;
		public UILabel enemyHpPlusLabel;
	}
	
	public BattleInfo battleInfo;
	
	[System.Serializable]
	public class TOP{
	
		public UISlider playerHealthSlider;
		public UILabel playerHpPercent;
		
		public UISlider playerAPSlider;
		public UILabel playerAP;
		
		public UILabel playerLevel;
		
		
		public UISlider enemyHealthSlider;
		public UILabel enemyHpPercent;
		
		public UILabel enemyLevel;
		
	}
	
	public TOP GuiTop;
	
	//PlayerOverTime Icons
	[System.Serializable]
	public class PlayerOverTimeIcons{
		//Buffs
		public UIFilledSprite hPoTIcon;
		public UILabel hPoTTurnLabel;
	
		public UIFilledSprite aPoTIcon;
		public UILabel aPoTTurnLabel;
	
		public UIFilledSprite strDefUpIcon;
		public UILabel strDefUpLabel;
		
		public UIFilledSprite shieldIcon;
		public UILabel shieldLabel;
		
		
		//Debuffs
		public UIFilledSprite doTIcon;
		public UILabel doTLabel;
		
		public UIFilledSprite aPCostUpIcon;
		public UILabel aPCostUpLabel;
		
		public UIFilledSprite aPGenDownIcon;
		public UILabel apGenDownLabel;
		
		public UIFilledSprite strDefDownIcon;
		public UILabel strDefDownLabel;
		
	}
	
	public PlayerOverTimeIcons playerOverTimeIcons;
	
	//EnemyOverTime Icons
	[System.Serializable]
	public class EnemyOverTimeIcons{
		//Buffs
		public UIFilledSprite enemyHPoTIcon;
		public UILabel enemyHPoTIconLabel;
		
		public UIFilledSprite strDefUpIcon;
		public UILabel strDefUpLabel;
		
		public UIFilledSprite shieldIcon;
		public UILabel shieldLabel;
		
		public UIFilledSprite enemySpecificIcon;
		public UILabel enemySpecificLabel;
	
		//Debuff
		public UIFilledSprite enemyDoTIcon;
		public UILabel enemyDoTIconLabel;
	
		public UIFilledSprite strDefDownIcon;
		public UILabel strDefDownLabel;
		
		public UIFilledSprite playerDebuff1Icon;
		public UILabel playerDebuff1Label;
		
		public UIFilledSprite playerDebuff2Icon;
		public UILabel playerDebuff2Label;
	}
	
	public EnemyOverTimeIcons enemyOverTimeIcons;
		
	
	// Update is called once per frame
	void Update () {
		
		//TOP
		#region Player
		//PlayerHP
		if(GuiTop.playerHealthSlider != null)
			GuiTop.playerHealthSlider.foreground.localScale = new Vector3((player.hP / player.hPMax) *
				423,
				GuiTop.playerHealthSlider.foreground.localScale.y,
				GuiTop.playerHealthSlider.foreground.localScale.z);
		if(GuiTop.playerHpPercent != null)
			GuiTop.playerHpPercent.text = "" + (int)(100 * (player.hP/player.hPMax)) + "%";
		
		
		//PlayerAP
		if(GuiTop.playerAPSlider != null)
			GuiTop.playerAPSlider.foreground.localScale = new Vector3((player.aP / 100) *
				338,
				GuiTop.playerAPSlider.foreground.localScale.y,
				GuiTop.playerAPSlider.foreground.localScale.z);
		if(GuiTop.playerAP != null)
			GuiTop.playerAP.text = "" + player.aP;
		
		//PlayerLevel
		if(GuiTop.playerLevel != null)
			GuiTop.playerLevel.text = "Level ~ " + player.level;
		#endregion
		
		#region Enemy
		//EnemyHP
		if(GuiTop.enemyHealthSlider != null)
			GuiTop.enemyHealthSlider.foreground.localScale = new Vector3((enemy.hP / enemy.hpMax) *
				423,
				GuiTop.enemyHealthSlider.foreground.localScale.y,
				GuiTop.enemyHealthSlider.foreground.localScale.z);
		if(GuiTop.enemyHpPercent != null)
			GuiTop.enemyHpPercent.text = "" + (int)(100 * (enemy.hP/enemy.hpMax)) + "%";
		
		//Enemy Level
		if(GuiTop.enemyLevel != null)
			GuiTop.enemyLevel.text = "Level ~ " + enemy.level;
		
		#endregion
		
		
		//Turn Damage
		if(battleInfo.turnTotalDamageLabel != null){
			if(player.TurnPhases >= 1 && player.TurnPhases < 8)
				battleInfo.turnTotalDamageLabel.text = "TurnDam: -" + player.turnDamage;
			else
				battleInfo.turnTotalDamageLabel.text = "";
		}

		
		//ShownDamage
		if(battleInfo.enemyHpDamageLabel != null)
			battleInfo.enemyHpPlusLabel.OnUpdate();
		
		if(player.TurnPhases == 0){
			if(battleInfo.playerHpHealLabel != false)
				battleInfo.playerHpHealLabel.enabled = false;
			if(battleInfo.playerHpDamageLabel != false)
				battleInfo.playerHpDamageLabel.enabled = false;
			if(battleInfo.playerApGenLabel != false)
				battleInfo.playerApGenLabel.enabled = false;
			
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.enabled = false;
			if(battleInfo.enemyHpPlusLabel != null)
				battleInfo.enemyHpPlusLabel.enabled = false;
		}
		
		#region Update Buttons
		if(abilitiesButtons.A1Button != null)
			abilitiesButtons.A1Button.UpdateColor(true,true);
		if(abilitiesButtons.A2Button != null)
			abilitiesButtons.A2Button.UpdateColor(true,true);
		if(abilitiesButtons.A3Button != null)
			abilitiesButtons.A3Button.UpdateColor(true,true);
		if(abilitiesButtons.A4Button != null)
			abilitiesButtons.A4Button.UpdateColor(true,true);
		if(abilitiesButtons.A5Button != null)
			abilitiesButtons.A5Button.UpdateColor(true,true);
		if(abilitiesButtons.B1Button != null)
			abilitiesButtons.B1Button.UpdateColor(true,true);
		if(abilitiesButtons.B2Button != null)
			abilitiesButtons.B2Button.UpdateColor(true,true);
		if(abilitiesButtons.B3Button != null)
			abilitiesButtons.B3Button.UpdateColor(true,true);
		if(abilitiesButtons.B4Button != null)
			abilitiesButtons.B4Button.UpdateColor(true,true);
		if(abilitiesButtons.B5Button != null)
			abilitiesButtons.B5Button.UpdateColor(true,true);
		if(abilitiesButtons.C1Button != null)
			abilitiesButtons.C1Button.UpdateColor(true,true);
		if(abilitiesButtons.C2Button != null)
			abilitiesButtons.C2Button.UpdateColor(true,true);
		if(abilitiesButtons.C3Button != null)
			abilitiesButtons.C3Button.UpdateColor(true,true);
		if(abilitiesButtons.C4Button != null)
			abilitiesButtons.C4Button.UpdateColor(true,true);
		if(abilitiesButtons.C5Button != null)
			abilitiesButtons.C5Button.UpdateColor(true,true);
		#endregion
		
		
		string headingText = "";
		string abilityText = "No ability chosen";
		
		#region BattleUI
		if(battleInfo.playerStatusBox != null)
			battleInfo.playerStatusBox.text = "Player\nHP : " + player.hP + "\nAP : " + player.aP;
		
		if(battleInfo.enemyStatusBox != null)
			battleInfo.enemyStatusBox.text = "Enemy\nHP : " + enemy.hP;
		
		#region Player OverTime Icons
		
		#region Buffs
		//Hp over TimeBuff
		if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0){
			if(playerOverTimeIcons.hPoTIcon != null)
				playerOverTimeIcons.hPoTIcon.fillAmount = 1;
			if(playerOverTimeIcons.hPoTTurnLabel != null)
				playerOverTimeIcons.hPoTTurnLabel.text = "" + (player.playerStatus.overTimeBuffs.hPBuffCounter);
		}
		else{
			if(playerOverTimeIcons.hPoTIcon != null)
				playerOverTimeIcons.hPoTIcon.fillAmount = 0;
			if(playerOverTimeIcons.hPoTTurnLabel != null)
				playerOverTimeIcons.hPoTTurnLabel.text = "";
		}
		
		//Ap over TimeBuff
		if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0){
			if(playerOverTimeIcons.aPoTIcon != null)
				playerOverTimeIcons.aPoTIcon.fillAmount = 1;
			if(playerOverTimeIcons.aPoTTurnLabel != null)
				playerOverTimeIcons.aPoTTurnLabel.text = "" + (player.playerStatus.overTimeBuffs.aPBuffCounter);
		}
		else{
			if(playerOverTimeIcons.aPoTIcon != null)
				playerOverTimeIcons.aPoTIcon.fillAmount = 0;
			if(playerOverTimeIcons.aPoTTurnLabel != null)
				playerOverTimeIcons.aPoTTurnLabel.text = "";
		}
		
		//StrDef Buff
		if(player.playerStatus.overTimeBuffs.StrDefUpBuffCounter > 0){
			if(playerOverTimeIcons.strDefUpIcon != null)
				playerOverTimeIcons.strDefUpIcon.fillAmount = 1;
			if(playerOverTimeIcons.strDefUpLabel != null)
				playerOverTimeIcons.strDefUpLabel.text = "" + (player.playerStatus.overTimeBuffs.StrDefUpBuffCounter);
			
		}
		else{
			if(playerOverTimeIcons.strDefUpIcon != null)
				playerOverTimeIcons.strDefUpIcon.fillAmount = 0;
			if(playerOverTimeIcons.strDefUpLabel != null)
				playerOverTimeIcons.strDefUpLabel.text = "";
		}
		
		//Shield Buff
		if(player.playerStatus.overTimeBuffs.shieldBuffCounter > 0){
			if(playerOverTimeIcons.shieldIcon != null)
				playerOverTimeIcons.shieldIcon.fillAmount = 1;
			if(playerOverTimeIcons.shieldLabel != null)
				playerOverTimeIcons.shieldLabel.text = "" + player.playerStatus.overTimeBuffs.shieldBuffCounter;
		}
		else{
			if(playerOverTimeIcons.shieldIcon != null)
				playerOverTimeIcons.shieldIcon.fillAmount = 0;
			if(playerOverTimeIcons.shieldLabel != null)
				playerOverTimeIcons.shieldLabel.text = "";
		}
		#endregion
		
		#region DeBuff
		
		//Damage over time
		if(player.playerStatus.overTimeDeBuffs.doTCounter > 0){
			if(playerOverTimeIcons.doTIcon != null)
				playerOverTimeIcons.doTIcon.fillAmount = 1;
			if(playerOverTimeIcons.doTLabel != null)
				playerOverTimeIcons.doTLabel.text = "" + player.playerStatus.overTimeDeBuffs.doTCounter;
		}
		else{
			if(playerOverTimeIcons.doTIcon != null)
				playerOverTimeIcons.doTIcon.fillAmount = 0;
			if(playerOverTimeIcons.doTLabel != null)
				playerOverTimeIcons.doTLabel.text = "";
		}
		
		//AP Tax
		if(player.playerStatus.overTimeDeBuffs.aPTaxCounter > 0){
			if(playerOverTimeIcons.aPCostUpIcon != null)
				playerOverTimeIcons.aPCostUpIcon.fillAmount = 1;
			if(playerOverTimeIcons.aPCostUpLabel != null)
				playerOverTimeIcons.aPCostUpLabel.text = "" + player.playerStatus.overTimeDeBuffs.aPTaxCounter;
		}
		else{
			if(playerOverTimeIcons.aPCostUpIcon != null)
				playerOverTimeIcons.aPCostUpIcon.fillAmount = 0;
			if(playerOverTimeIcons.aPCostUpLabel != null)
				playerOverTimeIcons.aPCostUpLabel.text = "";
		}
		
		//AP Gen Degrade
		if(player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter > 0){
			if(playerOverTimeIcons.aPGenDownIcon != null)
				playerOverTimeIcons.aPGenDownIcon.fillAmount = 1;
			if(playerOverTimeIcons.apGenDownLabel != null)
				playerOverTimeIcons.apGenDownLabel.text = "" + player.playerStatus.overTimeDeBuffs.aPGenDegradeCounter;
		}
		else{
			if(playerOverTimeIcons.aPGenDownIcon != null)
				playerOverTimeIcons.aPGenDownIcon.fillAmount = 0;
			if(playerOverTimeIcons.apGenDownLabel != null)
				playerOverTimeIcons.apGenDownLabel.text = "";
		}
		
		//StrDefDown Debuff
		if(player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter > 0){
			if(playerOverTimeIcons.strDefDownIcon != null)
				playerOverTimeIcons.strDefDownIcon.fillAmount = 1;
			if(playerOverTimeIcons.strDefDownLabel != null)
				playerOverTimeIcons.strDefDownLabel.text = "" + player.playerStatus.overTimeDeBuffs.StrDefDownDeBuffCounter;
		}
		else{
			if(playerOverTimeIcons.strDefDownIcon != null)
				playerOverTimeIcons.strDefDownIcon.fillAmount = 0;
			if(playerOverTimeIcons.strDefDownLabel != null)
				playerOverTimeIcons.strDefDownLabel.text = "";
		}
		
		#endregion
		
		#endregion
		
		#region Enemy OverTime Icons
		
		#region Buffs
		
		//DoT
		if(enemy.enemyStatus.hPoTCounter > 0){
			if(enemyOverTimeIcons.enemyHPoTIcon != null)
				enemyOverTimeIcons.enemyHPoTIcon.fillAmount = 1;
			if(enemyOverTimeIcons.enemyHPoTIconLabel != null)
				enemyOverTimeIcons.enemyHPoTIconLabel.text = "" + enemy.enemyStatus.hPoTCounter;
		}
		else{
			if(enemyOverTimeIcons.enemyHPoTIcon != null)
				enemyOverTimeIcons.enemyHPoTIcon.fillAmount = 0;
			if(enemyOverTimeIcons.enemyHPoTIconLabel != null)
				enemyOverTimeIcons.enemyHPoTIconLabel.text = "";
		}
		
		//SrtDefUp Buff
		if(enemy.enemyStatus.strDefUpBuffCounter > 0){
			if(enemyOverTimeIcons.strDefUpIcon != null)
				enemyOverTimeIcons.strDefUpIcon.fillAmount = 1;
			if(enemyOverTimeIcons.strDefUpLabel != null)
				enemyOverTimeIcons.strDefUpLabel.text = "" + enemy.enemyStatus.strDefUpBuffCounter;
		}
		else{
			if(enemyOverTimeIcons.strDefUpIcon != null)
				enemyOverTimeIcons.strDefUpIcon.fillAmount = 0;
			if(enemyOverTimeIcons.strDefUpLabel != null)
				enemyOverTimeIcons.strDefUpLabel.text = "";
		}
		
		//Shield Buff
		if(enemy.enemyStatus.shieldBuffCounter > 0){
			if(enemyOverTimeIcons.shieldIcon != null)
				enemyOverTimeIcons.shieldIcon.fillAmount = 1;
			if(enemyOverTimeIcons.shieldLabel != null)
				enemyOverTimeIcons.shieldLabel.text = "" + enemy.enemyStatus.shieldBuffCounter;
		}
		else{
			if(enemyOverTimeIcons.shieldIcon != null)
				enemyOverTimeIcons.shieldIcon.fillAmount = 0;
			if(enemyOverTimeIcons.shieldLabel != null)
				enemyOverTimeIcons.shieldLabel.text = "";
		}
		
		//EnemySpecific Buff
		if(enemy.enemyStatus.enemySpecificBuffCounter > 0){
			if(enemyOverTimeIcons.enemySpecificIcon != null)
				enemyOverTimeIcons.enemySpecificIcon.fillAmount = 1;
			if(enemyOverTimeIcons.enemySpecificLabel != null)
				enemyOverTimeIcons.enemySpecificLabel.text = "" + enemy.enemyStatus.enemySpecificBuffCounter;
		}
		else{
			if(enemyOverTimeIcons.enemySpecificIcon != null)
				enemyOverTimeIcons.enemySpecificIcon.fillAmount = 0;
			if(enemyOverTimeIcons.enemySpecificLabel != null)
				enemyOverTimeIcons.enemySpecificLabel.text = "";
		}
		
		#endregion
		
		#region Debuffs
		
		//DoT
		if(enemy.enemyStatus.doTCounter > 0){
			if(enemyOverTimeIcons.enemyDoTIcon != null)
				enemyOverTimeIcons.enemyDoTIcon.fillAmount = 1;
			if(enemyOverTimeIcons.enemyDoTIconLabel != null)
				enemyOverTimeIcons.enemyDoTIconLabel.text = "" + enemy.enemyStatus.doTCounter;
		}
		else{
			if(enemyOverTimeIcons.enemyDoTIcon != null)
				enemyOverTimeIcons.enemyDoTIcon.fillAmount = 0;
			if(enemyOverTimeIcons.enemyDoTIconLabel != null)
				enemyOverTimeIcons.enemyDoTIconLabel.text = "";
		}
		
		//StrDefDown Debuff
		if(enemy.enemyStatus.strDefDownDebuffCounter > 0){
			if(enemyOverTimeIcons.strDefDownIcon != null)
				enemyOverTimeIcons.strDefDownIcon.fillAmount = 1;
			if(enemyOverTimeIcons.strDefDownLabel != null)
				enemyOverTimeIcons.strDefDownLabel.text = "" + enemy.enemyStatus.strDefDownDebuffCounter;
		}
		else{
			if(enemyOverTimeIcons.strDefDownIcon != null)
				enemyOverTimeIcons.strDefDownIcon.fillAmount = 0;
			if(enemyOverTimeIcons.strDefDownLabel != null)
				enemyOverTimeIcons.strDefDownLabel.text = "";
		}
		
		//PlayerSpecific Debuff 1
		if(enemy.enemyStatus.playerSpecificDebuff1Counter > 0){
			if(enemyOverTimeIcons.playerDebuff1Icon != null)
				enemyOverTimeIcons.playerDebuff1Icon.fillAmount = 1;
			if(enemyOverTimeIcons.playerDebuff1Label != null)
				enemyOverTimeIcons.playerDebuff1Label.text = "" + enemy.enemyStatus.playerSpecificDebuff1Counter;
		}
		else{
			if(enemyOverTimeIcons.playerDebuff1Icon != null)
				enemyOverTimeIcons.playerDebuff1Icon.fillAmount = 0;
			if(enemyOverTimeIcons.playerDebuff1Label != null)
				enemyOverTimeIcons.playerDebuff1Label.text = "";
		}
		
		//PlayerSpecific Debuff 2
		if(enemy.enemyStatus.playerSpecificDebuff2Counter > 0){
			if(enemyOverTimeIcons.playerDebuff2Icon != null)
				enemyOverTimeIcons.playerDebuff2Icon.fillAmount = 1;
			if(enemyOverTimeIcons.playerDebuff2Label != null)
				enemyOverTimeIcons.playerDebuff2Label.text = "" + enemy.enemyStatus.playerSpecificDebuff2Counter;
		}
		else{
			if(enemyOverTimeIcons.playerDebuff2Icon != null)
				enemyOverTimeIcons.playerDebuff2Icon.fillAmount = 0;
			if(enemyOverTimeIcons.playerDebuff2Label != null)
				enemyOverTimeIcons.playerDebuff2Label.text = "";
		}
		#endregion
		
		
		#endregion
		
		//Turns
		if(battleInfo.turnsLabel != null){
			if(player.TurnPhases < 8)
				battleInfo.turnsLabel.text = "Player";
			else
				battleInfo.turnsLabel.text = "Enemy";
				
		}
		
		#endregion
		
		//Choose Abilities
		#region Choose Abilities
		//Player chooses Abilities
		if(player.TurnPhases == 0){
			
			//BattleInfo
			#region GunAbilities
			if(player.lastAbilityChosen == 1){
				
				abilityText = "Gun Ability ~ Scarlet Shot\n" +
					"DMG: " + player.playerAbilities.gunAbilities.ScarletShot.rangeMin + " - " +
						player.playerAbilities.gunAbilities.ScarletShot.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.ScarletShot.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.ScarletShot.multiplier);
			
				/*if(player.playerAbilities.abilitiesA.a1level == 1)
					abilityText = "Ability A1 Lvl l: Generates 20 AP.\nHeals you for 3% each turn for the next 2 turns";
			
				else if(player.playerAbilities.abilitiesA.a1level == 2)
					abilityText = "Ability A1 Lvl 2: Generates 20 AP.\nHeals you for 5% each turn for the next 2 turns";
			
				else if(player.playerAbilities.abilitiesA.a1level == 3)
					abilityText = "Ability A1 Lvl 3: Generates 30 AP.\nHeals you for 5% each turn for the next 3 turns";*/

	

			}
			else if(player.lastAbilityChosen == 2){
				
				abilityText = "Gun Ability ~ Dark Bullet\n" +
					"DMG: " + player.playerAbilities.gunAbilities.DarkBullet.rangeMin + " - " +
						player.playerAbilities.gunAbilities.DarkBullet.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.DarkBullet.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.DarkBullet.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a2level == 1)
					abilityText = "Ability A2 LvL 1: AP Swipes, 15%-20AP, 15%-25AP,\n35%-30AP,35%-35AP";
				else if(player.playerAbilities.abilitiesA.a2level == 2)
					abilityText = "Ability A2 LvL 2: AP Swipes, 10%-20AP, 10%-25AP,\n40%-30AP,40%-35AP";
				else if(player.playerAbilities.abilitiesA.a2level == 3)
					abilityText = "Ability A2 LvL 3: AP Swipes, 5%-20AP, 5%-25AP,\n45%-30AP,45%-35AP";*/

			}
			else if(player.lastAbilityChosen == 3){
				
				abilityText = "Gun Ability ~ Plague Blast\n" +
					"DMG: " + player.playerAbilities.gunAbilities.PlagueBlast.rangeMin + " - " +
						player.playerAbilities.gunAbilities.PlagueBlast.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.PlagueBlast.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.PlagueBlast.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a3level == 1)
					abilityText = "Ability A3 LvL 1: Generates 15 AP.\nGenerates 10AP each turn for next 2 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 2)
					abilityText = "Ability A3 LvL 2: Generates 15 AP.\nGenerates 10AP each turn for next 3 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 3)
					abilityText = "Ability A3 LvL 3: Generates 15 AP.\nGenerates 15AP each turn for next 3 turns";*/
			
			}
			else if(player.lastAbilityChosen == 4){
				
				abilityText = "Gun Ability ~ Blitz Barrage\n" +
					"DMG: " + player.playerAbilities.gunAbilities.BlitzBarrage.rangeMin + " - " +
						player.playerAbilities.gunAbilities.BlitzBarrage.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.BlitzBarrage.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.BlitzBarrage.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a4level == 1)
					abilityText = "Ability A4 LvL 1: Generates 25 AP.\nGenerates 5AP each turn for next 2 turns";
				else if (player.playerAbilities.abilitiesA.a4level == 2)
					abilityText = "Ability A4 LvL 2: Generates 25 AP.\nGenerates 5AP each turn for next 3 turns";
				else if (player.playerAbilities.abilitiesA.a3level == 3)
					abilityText = "Ability A4 LvL 3: Generates 25 AP.\nGenerates 10AP each turn for next 3 turns";*/

			}
			else if(player.lastAbilityChosen == 5){
				
				abilityText = "Gun Ability ~ Shadowflame Shot\n" +
					"DMG: " + player.playerAbilities.gunAbilities.ShadowflameShot.rangeMin + " - " +
						player.playerAbilities.gunAbilities.ShadowflameShot.rangeMax+ "\n" +
					"AP: +" + (-1*player.playerAbilities.gunAbilities.ShadowflameShot.cost) + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.gunAbilities.ShadowflameShot.multiplier);
				
				/*if(player.playerAbilities.abilitiesA.a5level == 1)
					abilityText = "Ability A5 LvL 1: Generates 20 AP + 3 AP\n each turn for rest of battle";
				else if (player.playerAbilities.abilitiesA.a5level == 2)
					abilityText = "Ability A5 LvL 2: Generates 20 AP + 5 AP\n each turn for rest of battle";
				else if (player.playerAbilities.abilitiesA.a5level == 3)
					abilityText = "Ability A5 LvL 3: Generates 30 AP + 5 AP\n each turn for rest of battle";*/

			}
			#endregion
		
			#region Sword Abilities
			else if(player.lastAbilityChosen == 6){
				
				abilityText = "Sword Ability ~ Blood Blade\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.BloodBlade.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.BloodBlade.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.BloodBlade.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b1level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 7){
				
				abilityText = "Sword Ability ~ Death Strike\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.DeathStrike.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.DeathStrike.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.DeathStrike.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b2level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 8){
				
				abilityText = "Sword Ability ~ Shadowflame Slash\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.ShadowFlameSlash.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.ShadowFlameSlash.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b3level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 9){
				
				abilityText = "Sword Ability ~ Crimson Cut\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.CrimsonCut.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.CrimsonCut.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.CrimsonCut.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b4level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 10){
				
				abilityText = "Sword Ability ~ Shadowfury\n" +
					"DMG: " + player.playerAbilities.sworddAbilities.ShadowFury.damage + "\n" +
					"AP: " + player.playerAbilities.sworddAbilities.ShadowFury.cost + "\n" +
					"Multiplier: " + (100 * player.playerAbilities.sworddAbilities.ShadowFury.multiplier);
				
				/*if(player.playerAbilities.abilitiesB.b5level == 1){
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
				}*/
			}
			#endregion
			
			#region Stances
			else if(player.lastAbilityChosen == 11){
				
				abilityText = "Stance ~ Shade of Bloodlust\n\n" +
					"Increases damage done by 25%\nAnd damage taken by 25% (Offensive)";
				
				/*if(player.playerAbilities.abilitiesC.c1level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 12){
				
				abilityText = "Stance ~ Shade of Murder\n\n\n" +
					"Health Gains increased by 25% (Health Regen)";
				
				/*if(player.playerAbilities.abilitiesC.c2level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 13){
				
				abilityText = "Stance ~ Shade of Ruthlessness\n\n" +
					"Reduces Damage done by 25%\nAnd Reduces damage taken by 25% (Defensive)";
				
				/*if(player.playerAbilities.abilitiesC.c3level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 14){
				
				abilityText = "Stance ~ Shade of Death\n\n\n" +
					"Increases AP generation by 25% (AP Regen)";
				
				/*if(player.playerAbilities.abilitiesC.c4level == 1){
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
				}*/
			}
			else if(player.lastAbilityChosen == 15){
				
				abilityText = "Stance ~ Shade of Dark Protection\n\n\n" +
					"Reduces all DoT damage by 50%";
				
				/*if(player.playerAbilities.abilitiesC.c5level == 1){
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
				}*/
			}
			#endregion
			
			headingText = "Battle Update: Time to choose abilities\n" + abilityText;
		}
		#endregion
		
		//Execute Sword Abilities
		#region Execute Sword Abilities
		else if(player.TurnPhases == 4){
			
			string tempPlayerApCostLabel = "";
			
			string tempEnemyDamLabel = "";
			
			if(player.swordAbilityChosen == -1)
				headingText = "Battle Update: No Sword Ability Chosen";
				
			//DamageShown
			else{
				if(player.swordAbilityChosen == 1)
					headingText = "Battle Update: Executing Blood Blade";
				else if(player.swordAbilityChosen == 2)
					headingText = "Battle Update: Executing Death Strike";
				else if(player.swordAbilityChosen == 3)
					headingText = "Battle Update: Executing Shadowflame Slash";
				else if(player.swordAbilityChosen == 4)
					headingText = "Battle Update: Executing Crimson Cut";
				else if(player.swordAbilityChosen == 5)
					headingText = "Battle Update: Executing Shadowfury";
					
			
				if(player.swordAbilityChosen == 1){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.BloodBlade.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b1level == 1)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL1) + "HP";
					else if(player.playerAbilities.abilitiesB.b1level == 2)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL2) + "HP";
					else if(player.playerAbilities.abilitiesB.b1level == 3)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b1hPHealLvL3) + "HP";*/
				}
				else if(player.swordAbilityChosen == 2){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.DeathStrike.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b2level == 1)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b2DamageLvL1 + "HP";
					else if(player.playerAbilities.abilitiesB.b2level == 2)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b2DamageLvL2 + "HP";
					else if(player.playerAbilities.abilitiesB.b2level == 3)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b2DamageLvL3 + "HP";*/
					
				}
				else if(player.swordAbilityChosen == 3){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.ShadowFlameSlash.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b3level == 1)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b3DamageLvL1 + "HP";
					else if(player.playerAbilities.abilitiesB.b3level == 2)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b3DamageLvL2 + "HP";
					else if(player.playerAbilities.abilitiesB.b3level == 3)
						tempEnemyDamLabel = "-" + player.playerAbilities.abilitiesB.b3DamageLvL3 + "HP";*/
				}
				else if(player.swordAbilityChosen == 4){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.CrimsonCut.damage + "HP";
					
					/*if(player.playerAbilities.abilitiesB.b4level == 1)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL1) + "HP";
					else if(player.playerAbilities.abilitiesB.b4level == 2)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL2) + "HP";
					else if(player.playerAbilities.abilitiesB.b4level == 3)
						tempPlayerHealLabel = "+" + (int)(player.hP * player.playerAbilities.abilitiesB.b4hPHealLvL3) + "HP";*/
					
					
				}
				else if(player.swordAbilityChosen == 5){
					tempEnemyDamLabel = "-" + player.playerAbilities.sworddAbilities.ShadowFury.damage + "HP";
				}
				
				
				if(battleInfo.playerApGenLabel != null){
					battleInfo.playerApGenLabel.text = tempPlayerApCostLabel;
					battleInfo.playerApGenLabel.enabled = true;	
				}
				
				if(battleInfo.enemyHpDamageLabel != null){
					battleInfo.enemyHpDamageLabel.text = tempEnemyDamLabel;
					battleInfo.enemyHpDamageLabel.enabled = true;
				}
				
			}
		}
		#endregion
		
		//Execute Gun Abilities
		#region Execute Gun Abilities
		else if(player.TurnPhases == 5){
			//Reset ShownIcons
			//if(enemyHpDamageLabel != null)
				//enemyHpDamageLabel.enabled = false;
			//if(playerApGenLabel != null)
				//playerApGenLabel.enabled = false;
			
			
			string tempEnemyDamLabel = "";
			
			string tempPlayerApBoost = "";
			
			
			if(player.gunAbilityChosen == -1)
				headingText = "Battle Update: No Gun Ability Chosen";
			
			else{
				if(player.gunAbilityChosen == 1)
					headingText = "Battle Update: Executing Scarlet Shot";
				else if(player.gunAbilityChosen == 2)
					headingText = "Battle Update: Executing Dark Bullet";
				else if(player.gunAbilityChosen == 3)
					headingText = "Battle Update: Executing Plague Blast";
				else if(player.gunAbilityChosen == 4)
					headingText = "Battle Update: Executing Blitz Barrage";
				else if(player.gunAbilityChosen == 5)
					headingText = "Battle Update: Executing Shadowflame Shot";
				
				if(player.gunAbilityChosen == 1){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.ScarletShot.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.ScarletShot.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.ScarletShot.cost) + "AP";
				}

				else if(player.gunAbilityChosen == 2){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.DarkBullet.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.DarkBullet.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.DarkBullet.cost) + "AP";
				}
				else if(player.gunAbilityChosen == 3){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.PlagueBlast.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.PlagueBlast.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.PlagueBlast.cost) + "AP";
				}
				else if(player.gunAbilityChosen== 4){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.BlitzBarrage.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.BlitzBarrage.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.BlitzBarrage.cost) + "AP";
				}
				else if(player.gunAbilityChosen == 5){
					tempEnemyDamLabel = "-" + player.playerAbilities.gunAbilities.ShadowflameShot.lastRangedDam + "HP";
					
					if(player.playerAbilities.stances.StanceOfDeath == true)
						tempPlayerApBoost = "+" + (int)(-1 * (player.playerAbilities.stances.StanceOfDApGenBoost
							* player.playerAbilities.gunAbilities.ShadowflameShot.cost)) + "AP";
					else
						tempPlayerApBoost = "+" + (-1 * player.playerAbilities.gunAbilities.ShadowflameShot.cost) + "AP";
					
					/*if(player.playerAbilities.abilitiesC.c5level == 1)
						tempPlayerApBoost = "+" + player.playerAbilities.abilitiesA.a5ApBoostLvl1 + "AP";
					else if(player.playerAbilities.abilitiesC.c5level == 2)
						tempPlayerApBoost = "+" + player.playerAbilities.abilitiesA.a5ApBoostLvl1 + "AP";	
					else if(player.playerAbilities.abilitiesC.c5level == 3)
						tempPlayerApBoost = "+" + player.playerAbilities.abilitiesA.a5ApBoostLvl1 + "AP";*/
				}
				
				if(battleInfo.enemyHpDamageLabel != null){
					battleInfo.enemyHpDamageLabel.text = tempEnemyDamLabel;
					battleInfo.enemyHpDamageLabel.enabled = true;
				}
				
				if(battleInfo.playerApGenLabel != null){
					battleInfo.playerApGenLabel.text = tempPlayerApBoost;
					battleInfo.playerApGenLabel.enabled = true;
				}
				
				
			}
			
		}
		#endregion
		
		//Execute StanceChange
		#region execute StanceChange
		else if(player.TurnPhases == 6){
			//Reset ShownIcons
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.enabled = false;
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.enabled = false;
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.enabled = false;
			
			
			if(player.stanceChosen == -1)
				headingText = "Battle Update: Stance Chosen";
			else{
				if(player.stanceChosen == 1)
					headingText = "Battle Update: Changing Stance to Shade of Bloodlust";
				else if(player.stanceChosen == 2)
					headingText = "Battle Update: Changing Stance to Shade of Murder";
				else if(player.stanceChosen == 3)
					headingText = "Battle Update: Changing Stance to Shade of Ruthlessness";
				else if(player.stanceChosen == 4)
					headingText = "Battle Update: Changing Stance to Shade of Death";
				else if(player.stanceChosen == 5)
					headingText = "Battle Update: Changing Stance to Shade of Dark Protection";
				
			}
		}
		#endregion
		
		//Apply OverTime Effects
		#region Apply AoverTimeEffects
		else if(player.TurnPhases == 7){
			//Reset ShownIcons
			//if(playerHpHealLabel != null)
				//playerHpHealLabel.enabled = false;
			//if(playerApGenLabel != null)
				//playerApGenLabel.enabled = false;
			//if(enemyHpDamageLabel != null)
				//enemyHpDamageLabel.enabled = false;
			
			string tempPlayerHpBoost = "";
			string tempPlayerApBoost = "";
			
			string tempEnemyDamLabel = "";
			
			
			if(player.playerStatus.overTimeBuffs.hPBuffCounter > 0)
				tempPlayerHpBoost = "+" + (int)(player.hP * player.playerStatus.overTimeBuffs.hPoT) + "HP";
			if(player.playerStatus.overTimeBuffs.aPBuffCounter > 0)
				tempPlayerApBoost = "+" + player.playerStatus.overTimeBuffs.aPoT + "AP";
			
			if(enemy.enemyStatus.doTCounter > 0)
				tempEnemyDamLabel = "-" + (int)(enemy.hP * enemy.enemyStatus.doT) + "HP";
			
			
			headingText = "Battle Update: Applying OvertimeEffects";
			
			
			//Show effects
			if(battleInfo.playerHpHealLabel != null){
				battleInfo.playerHpHealLabel.text = tempPlayerHpBoost;
				battleInfo.playerHpHealLabel.enabled = true;
			}
			if(battleInfo.playerApGenLabel != null){
				battleInfo.playerApGenLabel.text = tempPlayerApBoost;
				battleInfo.playerApGenLabel.enabled = true;
			}
			if(battleInfo.enemyHpDamageLabel !=null){
				battleInfo.enemyHpDamageLabel.text = tempEnemyDamLabel;
				battleInfo.enemyHpDamageLabel.enabled = true;
			}
			
		}
		#endregion
		
		//Enemy's turn
		#region Enemies Turn
		else if(player.TurnPhases == 8){
			//Reset ShownIcons
			if(battleInfo.playerHpHealLabel != null)
				battleInfo.playerHpHealLabel.enabled = false;
			if(battleInfo.playerApGenLabel != null)
				battleInfo.playerApGenLabel.enabled = false;
			if(battleInfo.enemyHpDamageLabel != null)
				battleInfo.enemyHpDamageLabel.enabled = false;
			
			
			
			if(battleInfo.battleInfoBox != null)
				headingText = "Battle Update: Enemy's Turn\n" +
					"Enemy Attacking Player";
			
			
			
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.text = "-" + enemy.enemyStatus.previousDam + "HP";	
			
			
			if(battleInfo.playerHpDamageLabel != null)
				battleInfo.playerHpDamageLabel.enabled = true;
			
		}
		#endregion
		
		if(battleInfo.battleInfoBox != null)
			battleInfo.battleInfoBox.text = headingText;
		
	}
}
