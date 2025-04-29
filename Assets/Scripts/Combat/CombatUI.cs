using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
	[SerializeField]
	private HorizontalLayoutGroup ButtonLayout;
	[SerializeField]
	private Button Button;
	public List<Button> AttackButtons = new();
	private MonInstance currentMon;

	public UnityEvent<AbilityInstance> OnSelectedAttack;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		this.gameObject.SetActive(false);
	}

	public void Activate(MonInstance selectedMon)
	{
		if (currentMon == selectedMon)
		{
			Debug.Log("Gleicher Mon, nichts machen.");
			return;
		}
		currentMon = selectedMon;

		this.gameObject.SetActive(true);

		Debug.Log($"Geklcikt wurde: {selectedMon.Name}");

		foreach (var attack in selectedMon.Abilities)
		{
			var but = Instantiate(Button, ButtonLayout.transform);
			var text = but.GetComponentInChildren<TextMeshProUGUI>();

			text.SetText(attack.Name);
			text.color = Color.white;

			var buttonComponent = but.GetComponent<Button>();

			// Listener hinzufügen
			buttonComponent.onClick.AddListener(() => OnAttackButtonClicked(attack));

			AttackButtons.Add(but);
		}
	}

	private void OnAttackButtonClicked(AbilityInstance selectedAbility)
	{
		OnSelectedAttack.Invoke(selectedAbility);
	}
}
