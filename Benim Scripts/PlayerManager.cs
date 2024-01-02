using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Toplu �a��rma
    InputManager inputManager; // kal�t�m
   PlayerLocomotions playerLocomotions;
    animatorManager animatormanager;
    Animator animator;

    public bool isInteracting;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotions = GetComponent<PlayerLocomotions>();
        animatormanager = GetComponent<animatorManager>();
        animator = GetComponent<Animator>();

        
    }

    private void Update()
    {
        
        inputManager.HandleAllInputs();
       
    }
    private void FixedUpdate()
    {
        playerLocomotions.HandleAllMovement();
    }

    private void LateUpdate()
    {
        isInteracting = animator.GetBool("isInteracting");
       
      
    }

}
