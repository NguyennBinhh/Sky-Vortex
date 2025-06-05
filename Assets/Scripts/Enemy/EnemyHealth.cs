using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagerable
{
    [SerializeField] private EnemyPlanrData _enemyData;

    private bool IsDie = false;
    public void TakeDamage(int amout)
    {
        if(this._enemyData.maxHP <= 0)
        {
            this.EnemyDie();
        }
        else
        {
            this._enemyData.maxHP -= amout;
        }
    }

    void EnemyDie()
    {
        if (this.IsDie) return;
        Debug.Log("HI");
        this.IsDie = true;
    }
        
        
}
