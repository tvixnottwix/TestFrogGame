using TMPro;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI valueText;

    private void Start()
    {
        CollectablesManager.OnCollectedAmountChanged += CollectablesManager_OnCollectedAmountChanged;
        valueText.text = CollectablesManager.CollectedAmount.ToString();
    }

    private void CollectablesManager_OnCollectedAmountChanged(object sender,
        CollectablesManager.OnCollectedAmountChangedEventArgs e)
    {
        valueText.text = e.newAmount.ToString();
    }

    private void OnDestroy()
    {
        CollectablesManager.OnCollectedAmountChanged -= CollectablesManager_OnCollectedAmountChanged;
    }
}
