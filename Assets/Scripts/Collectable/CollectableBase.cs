using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string player = "Player";
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(player))
        {
            Collect();
        }                
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {

    }
}
