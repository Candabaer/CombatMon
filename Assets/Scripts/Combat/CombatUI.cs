using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
	[SerializeField]
	private HorizontalLayoutGroup ButtonLayout;
	[SerializeField]
	private Button Button;
	public List<Button> AttackButtons = new();
	private MonInstance currentMon;


	void Start()
	{
		this.gameObject.SetActive(false);
		EventManager.Instance.Subscribe<MonAbilityUIEvent>(Activate);
	}

	public void Activate(MonAbilityUIEvent SelectedMon)
	{

		var selectedMon = SelectedMon.MonInstance;
		if (currentMon == selectedMon)
			return;
		currentMon = selectedMon;

		this.gameObject.SetActive(true);

		if (selectedMon.Abilities.Count == AttackButtons.Count)
			return;
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
	internal void Deactivate()
	{ 
		this.gameObject.SetActive(false);
	}

	private void OnAttackButtonClicked(AbilityInstance selectedAbility)
	{
		EventManager.Instance.Raise(new AbilitySelectedEvent(selectedAbility));
	}


}
