using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static event EventHandler<OnAnyCollectedEventArgs> OnAnyCollected;

    public class OnAnyCollectedEventArgs : EventArgs
    {
        public int collectableValue;
    }

    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnAnyCollected?.Invoke(this, new OnAnyCollectedEventArgs { collectableValue = value });
            Destroy(gameObject);
        }
    }
}
