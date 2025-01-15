using System;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public static CollectablesManager Instance { get; private set; }

    public static event EventHandler<OnCollectedAmountChangedEventArgs> OnCollectedAmountChanged;
    public class OnCollectedAmountChangedEventArgs : EventArgs
    {
        public int oldAmount;
        public int newAmount;
    }
  
    private static int collectedAmount = 0;
    public static int CollectedAmount => collectedAmount;

    private void Awake()
    {
        InitializeSingleton();
        Collectable.OnAnyCollected += Collectable_OnAnyCollected;
    }

    private void Collectable_OnAnyCollected(object sender, Collectable.OnAnyCollectedEventArgs e)
    {
        int oldAmount = collectedAmount;
        collectedAmount += e.collectableValue;
        OnCollectedAmountChanged?.Invoke(this, new OnCollectedAmountChangedEventArgs { oldAmount = oldAmount, newAmount = collectedAmount });
    }

    private void InitializeSingleton()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one " + GetType().Name);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        Collectable.OnAnyCollected -= Collectable_OnAnyCollected;
    }
}
