//==============================================================
// HealthSystem
// HealthSystem.Instance.TakeDamage (float Damage);
// HealthSystem.Instance.HealDamage (float Heal);
// HealthSystem.Instance.UseExperience (float exp);
// HealthSystem.Instance.RestoreExperience (float exp);
// Attach to the Hero.
//==============================================================

using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public static HealthSystem Instance;

	public Image currentHealthBar;
	public Text healthText;
	public float hitPoint = 100f;
	public float maxHitPoint = 100f;

	public Image currentExperienceBar;
	public Text ExperienceText;
	public float ExperiencePoint = 0f;
	public float maxExperiencePoint = 100f;
	public float level = 0f;

	public bool Regenerate = true;
	public float regen = 0.1f;
	private float timeleft = 0.0f;
	public float regenUpdateInterval = 1f;

	public bool GodMode;
	
	void Awake()
	{
		Instance = this;
	}
	
  	void Start()
	{
		UpdateGraphics();
		timeleft = regenUpdateInterval; 
	}
    
	void Update ()
	{
		if (Regenerate)
			Regen();
	}
	
	private void Regen()
	{
		timeleft -= Time.deltaTime;

		if (timeleft <= 0.0) 
		{
			// Debug mode
			if (GodMode)
			{
				HealDamage(maxHitPoint);
				RestoreExperience(5);
			}
			else
			{
				HealDamage(regen);
			}

			UpdateGraphics();

			timeleft = regenUpdateInterval;
		}
	}

	
	// Health Logic
	private void UpdateHealthBar()
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthBar.rectTransform.localPosition = new Vector3(currentHealthBar.rectTransform.rect.width * ratio - currentHealthBar.rectTransform.rect.width, 0, 0);
		healthText.text = hitPoint.ToString ("0") + "/" + maxHitPoint.ToString ("0");
	}

	public void TakeDamage(float Damage)
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;

		UpdateGraphics();

		// StartCoroutine(PlayerHurts());
	}

	public void HealDamage(float Heal)
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	public void SetMaxHealth(float max)
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);

		UpdateGraphics();
	}


	// Experience Logic
	private void UpdateExperienceBar()
	{
		float ratio = ExperiencePoint / maxExperiencePoint;
		currentExperienceBar.rectTransform.localPosition = new Vector3(currentExperienceBar.rectTransform.rect.width * ratio - currentExperienceBar.rectTransform.rect.width, 0, 0);
		ExperienceText.text =  "Level: " + level.ToString ("0");
	}

	public void UseExperience(float Experience)
	{
		ExperiencePoint -= Experience;
		if (ExperiencePoint < 1) 
			ExperiencePoint = 0;

		UpdateGraphics();
	}

	public void RestoreExperience(float Experience)
	{
		Debug.Log(ExperiencePoint + " "+level);
		ExperiencePoint += Experience;
		if (ExperiencePoint > maxExperiencePoint)
		{
			Debug.Log("Larger than 100");
			level += (int) (ExperiencePoint / maxExperiencePoint);
			ExperiencePoint -= maxExperiencePoint * ((int)(ExperiencePoint / maxExperiencePoint));
		}

		UpdateGraphics();
	}
	public void SetMaxExperience(float max)
	{
		maxExperiencePoint += (int)(maxExperiencePoint * max / 100);
		
		UpdateGraphics();
	}

	//==============================================================
	// Update all Bars & UI graphics
	//==============================================================
	private void UpdateGraphics()
	{
		UpdateHealthBar();
		UpdateExperienceBar();
	}

	//==============================================================
	// Coroutine Player Hurts
	//==============================================================
	// IEnumerator PlayerHurts()
	// {
	// 	// Player gets hurt. Do stuff.. play anim, sound..
	//
	// 	PopupText.Instance.Popup("Ouch!", 1f, 1f); // Demo stuff!
	//
	// 	if (hitPoint < 1) // Health is Zero!!
	// 	{
	// 		yield return StartCoroutine(PlayerDied()); // Hero is Dead
	// 	}
	//
	// 	else
	// 		yield return null;
	// }

	//==============================================================
	// Hero is dead
	//==============================================================
	// IEnumerator PlayerDied()
	// {
	// 	// Player is dead. Do stuff.. play anim, sound..
	// 	PopupText.Instance.Popup("You have died!", 1f, 1f); // Demo stuff!
	//
	// 	yield return null;
	// }
}
