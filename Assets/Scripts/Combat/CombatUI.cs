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
	private Mon currentMon;

	public UnityEvent<Ability> OnSelected;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		this.gameObject.SetActive(false);
	}

	public void Activate(Mon selectedMon)
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

	private void OnAttackButtonClicked(Ability selectedAbility)
	{
		     OnSelected.Invoke(selectedAbility);
	}


	// Update is called once per frame
	void Update()
	{

	}
}
