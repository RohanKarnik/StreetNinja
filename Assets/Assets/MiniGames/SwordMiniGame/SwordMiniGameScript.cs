using UnityEngine;
using System.Collections;

public class SwordMiniGameScript : MonoBehaviour {
	
	public UIFilledSprite swordDial;
	
	public UIFilledSprite swordDialMask;
	
	public UIFilledSprite arrow;
	
	public UIButton clickScreenButton;
	
	public Player player;
	
	
	public int ArrowSpeed = 25;
	
	public float startTimer = 0;
	
	
	public float clickCounter = 0;
	
	public Vector3 initialPosition;
	public Vector3 currentPosition;
	public Vector3 referenceRight;
	
	public Vector3 stopPosition;
	public float distanceFromCenter;
	public float attackDistanceFromCenter;
	
	public enum Attack{NoHit, Hit, Miss, HasHit}
	public Attack currentAttack;
	
	public Attack didLand(Attack currentAttack){
		float stoppedAngle = findAngle(initialPosition, stopPosition, referenceRight);
		
		if(stoppedAngle <= 10 ||
			stoppedAngle >= 350){
			
			if(player.lastSwordHit == Player.LastSwordHit.NoHit)
				return Attack.Hit;
			else if(player.lastSwordHit == Player.LastSwordHit.HasHit)
				return Attack.Hit;
		}
		else
			return Attack.Miss;
		
		return Attack.Miss;
		
	}
	
	void OnClick(){
		
		if(player.TurnPhases == 4){
			stopPosition = arrow.transform.localPosition;
		
			currentAttack = didLand(currentAttack);
		
			startTimer = Time.time + 1;

			clickCounter++;
			player.clickCounter++;
		
			player.lastSwordHit = (Player.LastSwordHit) currentAttack;
		}
	}
	
	// Use this for initialization
	void Start () {
		
		ArrowSpeed = 35;
		
		
		initialPosition = arrow.transform.localPosition;
		stopPosition = initialPosition;
		referenceRight = Vector3.Cross(Vector3.up, initialPosition);
		
		
		//Populate Mask
		swordDialMask.fillAmount = .0555f;
		swordDialMask.transform.eulerAngles = new Vector3(0,0,(-1 * ((360 * swordDialMask.fillAmount)/2)));
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(player.TurnPhases == 4){
			player.clickMax = 5;
			
			currentAttack = (Attack) player.lastSwordHit;
			
			swordDial.fillAmount = 1;
			swordDialMask.color = Color.red;
			arrow.fillAmount = 1;
			
			if(clickScreenButton != null)
				clickScreenButton.isEnabled = true;
			
			if(player.isSwordSet == false){
				startTimer = Time.time + 1;
				
				//setDial((player.gunAbilityChosen - 1));
				player.isSwordSet = true;	
			}
			
			//Move Arrow
			arrow.transform.RotateAround(swordDial.transform.position,
				Vector3.back, ArrowSpeed * Time.deltaTime);
		
		
		
			currentPosition = arrow.transform.localPosition;
		
		
			distanceFromCenter = findAngle(initialPosition, currentPosition, referenceRight);
			attackDistanceFromCenter = findAngle(initialPosition, stopPosition, referenceRight);
			
			//Stop Minigame if Arrow makes OneRotation and player does not click
			/*if(startTimer != 0){
				if(Time.time >= startTimer){
					if(distanceFromCenter <= 345 &&
						distanceFromCenter > 340){
						
						if(player.lastSwordHit != Player.LastSwordHit.HasHit)
							player.clickCounter = player.clickMax;
					}
					else
						player.lastSwordHit = Player.LastSwordHit.NoHit;
				}
			}*/
			
		}
		
		else{
			//Hide Everything
		
				swordDial.fillAmount = 0;
				swordDialMask.color = Color.clear;
				clickScreenButton.isEnabled = false;
				
			
				arrow.fillAmount = 0;
			
				arrow.transform.localPosition = initialPosition;
				arrow.transform.localRotation = new Quaternion(0,0,0,0);
			
		}
	
	}
	
	
	float findAngle(Vector3 initial, Vector3 current, Vector3 middle){
		
		float tempAngle = Vector3.Angle(initial, current);
		
		 if(AngleDir(initial, current, middle) == -1) {

        	return 360 - tempAngle;

		}
		else
			return tempAngle;
		
	}
	//From Forums
	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}
}