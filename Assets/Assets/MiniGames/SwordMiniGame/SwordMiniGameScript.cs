using UnityEngine;
using System.Collections;

public class SwordMiniGameScript : MonoBehaviour {
	
	//public UIFilledSprite swordDial;
	public UIFilledSprite swordBar;
	public UIFilledSprite swordBarMask;
	
	public UIFilledSprite arrow;
	
	public UIButton clickScreenButton;
	
	//Icons for bar
	[System.Serializable]
	public class SwordBarIcons{
	
		public UIFilledSprite swordIcon1;
		public UIFilledSprite swordIcon2;
		public UIFilledSprite swordIcon3;
		public UIFilledSprite swordIcon4;
		public UIFilledSprite swordIcon5;
		
	}
	
	public SwordBarIcons swordBarIcons = new SwordBarIcons();
	
	
	public Player player;
	
	public int triesCounter;
	
	public int ArrowSpeed = 25;
	
	public float startTimer = 0;
	
	
	public float clickCounter = 0;
	
	public Vector3 initialPosition;
	public Vector3 currentPosition;
	
	public Vector3 stopPosition;
	
	public float distanceFromStart;

	
	public enum Attack{NoHit, Hit, Miss, HasHit}
	public Attack currentAttack;
	
	[System.Serializable]
	public class SwordMask{
		public Vector3 initialScale;
		
		public float scaleMultiplier;
		
		public float rangeMin;
		public float rangeMax;
		
		public bool isClicked;
	}
	
	public SwordMask hitMask;
	
	public void setBar(int swordAbilityChosen){
		
		arrow.color = Color.white;
		arrow.transform.localPosition = initialPosition;
		
		
		switch(swordAbilityChosen){
		case 0:
			swordBarIcons.swordIcon1.fillAmount = 1;
			swordBarIcons.swordIcon2.fillAmount = 0;
			swordBarIcons.swordIcon3.fillAmount = 0;
			swordBarIcons.swordIcon4.fillAmount = 0;
			swordBarIcons.swordIcon5.fillAmount = 0;
			break;
		case 1:
			swordBarIcons.swordIcon1.fillAmount = 0;
			swordBarIcons.swordIcon2.fillAmount = 1;
			swordBarIcons.swordIcon3.fillAmount = 0;
			swordBarIcons.swordIcon4.fillAmount = 0;
			swordBarIcons.swordIcon5.fillAmount = 0;
			break;
		case 2:
			swordBarIcons.swordIcon1.fillAmount = 0;
			swordBarIcons.swordIcon2.fillAmount = 0;
			swordBarIcons.swordIcon3.fillAmount = 1;
			swordBarIcons.swordIcon4.fillAmount = 0;
			swordBarIcons.swordIcon5.fillAmount = 0;
			break;
		case 3:
			swordBarIcons.swordIcon1.fillAmount = 0;
			swordBarIcons.swordIcon2.fillAmount = 0;
			swordBarIcons.swordIcon3.fillAmount = 0;
			swordBarIcons.swordIcon4.fillAmount = 1;
			swordBarIcons.swordIcon5.fillAmount = 0;
			break;
		case 4:
			swordBarIcons.swordIcon1.fillAmount = 0;
			swordBarIcons.swordIcon2.fillAmount = 0;
			swordBarIcons.swordIcon3.fillAmount = 0;
			swordBarIcons.swordIcon4.fillAmount = 0;
			swordBarIcons.swordIcon5.fillAmount = 1;
			break;
			
		}
	}
	
	public Attack didLand(Attack currentAttack){
		float stoppedSpot = stopPosition.x;
		
		if(stoppedSpot < hitMask.rangeMax &&
			stoppedSpot > hitMask.rangeMin){
			
			if(player.lastSwordHit == Player.LastSwordHit.NoHit)
				return Attack.Hit;
			else if(player.lastSwordHit == Player.LastSwordHit.HasHit)
				return Attack.Hit;
		}
		else
			return Attack.Miss;
		
		return Attack.NoHit;
		
	}
	
	void OnClick(){
		
		if(player.TurnPhases == 4){
			stopPosition = arrow.transform.localPosition;
		
			currentAttack = didLand(currentAttack);
		
			startTimer = Time.time + 1;
			
			if(currentAttack == Attack.Hit){
				arrow.transform.localPosition = initialPosition;
				triesCounter++;
				
				clickCounter++;
				player.clickCounter++;
			}
			
			player.lastSwordHit = (Player.LastSwordHit) currentAttack;
		}
		
	}
	
	// Use this for initialization
	void Start () {
		
		ArrowSpeed = 25;
		
		triesCounter = 0;
		
		initialPosition = arrow.transform.localPosition;
		//stopPosition = initialPosition;
		
		//Populate Mask
		hitMask.initialScale = new Vector3((swordBarMask.transform.localScale.x),
			swordBarMask.transform.localScale.y,
			swordBarMask.transform.localScale.z);
		hitMask.rangeMin = swordBarMask.transform.localPosition.x;
		hitMask.rangeMax = hitMask.rangeMin + hitMask.initialScale.x;
		hitMask.isClicked = false;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(player.TurnPhases == 4){
			
			//if(triesCounter >= 5)
				//player.clickCounter = player.clickMax;
			
			swordBarMask.fillAmount = 1;
			swordBar.fillAmount = 1;
			arrow.fillAmount = 1;
			
			
			if(clickScreenButton != null)
				clickScreenButton.isEnabled = true;
			
			if(player.isSwordSet == false){
				startTimer = Time.time + 1;
				
				setBar((player.swordAbilityChosen - 1));
				player.isSwordSet = true;	
			}
			
			//Move Arrow
			arrow.transform.localPosition = new Vector3((arrow.transform.localPosition.x + (ArrowSpeed * Time.deltaTime)),
				initialPosition.y,initialPosition.y);
		
			
			currentPosition = arrow.transform.localPosition;
			distanceFromStart = currentPosition.x - initialPosition.x;
			
			
			//Stop Minigame if Arrow makes the distance once
			if(startTimer != 0){
				if(Time.time >= startTimer){
					if(distanceFromStart >= 390){
						
						triesCounter++;
						
						//player.clickCounter = player.clickMax;
						arrow.transform.localPosition = initialPosition;
					}
				}
			}
			
		}
		
		else{
			clickCounter = 0;
			triesCounter = 0;
			
			//Hide Everything
			swordBarIcons.swordIcon1.fillAmount = 0;
			swordBarIcons.swordIcon2.fillAmount = 0;
			swordBarIcons.swordIcon3.fillAmount = 0;
			swordBarIcons.swordIcon4.fillAmount = 0;
			swordBarIcons.swordIcon5.fillAmount = 0;
			
			swordBar.fillAmount = 0;
			swordBarMask.fillAmount = 0;
			clickScreenButton.isEnabled = false;
				
			
			arrow.fillAmount = 0;
			
			arrow.transform.localPosition = initialPosition;
			arrow.transform.localRotation = new Quaternion(0,0,0,0);
			
		}
	
	}
}