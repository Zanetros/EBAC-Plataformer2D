using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;

    public float delayToKill;

    private int _currentLife;

    private bool isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }

}
