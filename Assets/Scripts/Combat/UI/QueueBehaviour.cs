using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{

	[SerializeField]
	private HorizontalLayoutGroup QueueLayout;
	[SerializeField]
	private Button ButtonTeamOne;
	[SerializeField]
	private Button ButtonTeamTwo;

	public void Start()
	{
		EventManager.Instance.Subscribe<ActionQueueAdd>(Add);
	}

	public void Add(ActionQueueAdd monAttackEvent)
	{
		var but = Instantiate(ButtonTeamOne, QueueLayout.transform);
		var text = but.GetComponentInChildren<TextMeshProUGUI>();

		text.SetText(monAttackEvent.ActionQueueEntry.ChosenAbility.Name);

		var buttonComponent = but.GetComponent<Button>();

	}
}
