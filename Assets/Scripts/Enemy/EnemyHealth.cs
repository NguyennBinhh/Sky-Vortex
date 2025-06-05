using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagerable
{
    [SerializeField] private EnemyPlanrData _enemyData;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        this._animator = GetComponent<Animator>();
    }

    private bool IsDie = false;
    public void TakeDamage(int amout)
    {
        if(this._enemyData.maxHP <= 0)
        {
            if (!IsDie)
                StartCoroutine(this.EnemyDie());
        }
        else
        {
            
            this._enemyData.maxHP -= amout;
        }
    }

    IEnumerator EnemyDie()
    {
        this._animator.SetTrigger("EnemyDie");
        this.IsDie = true;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
        
        
}
