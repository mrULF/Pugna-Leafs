using UnityEngine;
using System;
using System.Collections;

public class GoblinAttackOneAnimationEvent : MonoBehaviour
{
    [SerializeField] private PlayerHealt playerHealthScript;
    [SerializeField] private NavMeshControl nav;
    public bool ishield;
    public bool DamageAnim = false;
    Animator animator;

    private void Start()
    {


        animator = GetComponent<Animator>();
        
        if (playerHealthScript == null)
        {
            Debug.LogError("PlayerHealt scripti yok.");
        }
        if (nav == null)
        {
            Debug.Log("navmesh scriptti yok");
        }
    }

    private void FixedUpdate()
    {
        if (DamageAnim)
        {
            animator.SetTrigger("Damage");
            StartCoroutine(damagewait());
        }
    }
    IEnumerator damagewait()
    {
        yield return new WaitForSeconds(0.5f);

    }

    
    public void OnGoblinAttackAnimationEvent()
    {
        
        if (playerHealthScript != null)
        {
      
            Invoke("TakeDamage", 0.85f);
        }
        else
        {
            Debug.LogError("PlayerHealt scripti atanmam��.");
        }
    }


    private void TakeDamage()
    {

        if (ishield)
        {
           
            playerHealthScript.PlayerHealthValue -= 0.1f;
           
        }

      
        playerHealthScript.PlayerHealthValue = Mathf.Clamp01(playerHealthScript.PlayerHealthValue);
       
        playerHealthScript.PlayerHealthImage.fillAmount = playerHealthScript.PlayerHealthValue;
       
    }
}
