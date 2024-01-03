using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public abstract class LifeBase : MonoBehaviour
{

    public int totalLife;
    private int currentLife;

    protected void Start()
    {
        currentLife = totalLife;
    }

    protected void Update()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
            OnDie();
    }

    public abstract void OnDamage();
    public abstract void OnDie();



}
