using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    OyuncuKontrolleri playercontrols; //input aksiyonlar� i�in de�i�ken tan�mlad�m
    animatorManager animatormanager;
    public Vector2 MoveInput; //kullan�c� giri�ine g�re harekt vector'� tan�mlad�m
    public float MoveAmount;


    public float verticalInput; //W-S giri�leri
    public float HorizontalInput;//A-D giri�leri
    public bool b_input;
    PlayerLocomotions playerLocomotions;

    public bool jumpInput;
    public bool canJump = true;



    private void Awake()
    {
        animatormanager = GetComponent<animatorManager>();
        playerLocomotions = GetComponent<PlayerLocomotions>();
    }

    private void OnEnable()
    {

        if (playercontrols == null)
        {
            playercontrols = new OyuncuKontrolleri(); //yeni bir oyuncu kontrol� olu�turdum e�er hen�z olu�turulmam�� ise
            playercontrols.OyuncuHareketleri.Hareket.performed += i => MoveInput = i.ReadValue<Vector2>(); //tetikleyici
            playercontrols.OyuncuAksiyonlar�.B.performed += i => b_input = true;
            playercontrols.OyuncuAksiyonlar�.B.canceled += i => b_input = false;


            playercontrols.OyuncuAksiyonlar�.Jump.performed += i => jumpInput = true;
            playercontrols.OyuncuAksiyonlar�.Jump.canceled += i => jumpInput = false;

        }
        playercontrols.Enable(); //aktiflik sa�lad�m(kullan�labilir)
    }

    private void OnDisable()
    {
        playercontrols.Disable(); //bu scripts devre d��� b�rakr
    }
    public void HandleAllInputs()
    {
        HandleMoveInput();
        HandleSprintingInput();

        
        HandleJumpInput();

    }



    private void HandleMoveInput()
    {
        verticalInput = MoveInput.y;
        HorizontalInput = MoveInput.x;


        MoveAmount = Mathf.Clamp01(Mathf.Abs(HorizontalInput) + Mathf.Abs(verticalInput));
        animatormanager.UptadeAnimatorValues(0, MoveAmount, playerLocomotions.isspriting);
    }
    private void HandleSprintingInput()
    {
        if (b_input && MoveAmount > 0.5f)
        {
            playerLocomotions.isspriting = true;
        }
        else
        {
            playerLocomotions.isspriting = false;
        }
    }


    

    private void HandleJumpInput()
    {
        if (jumpInput)
        {
            canJump = true;
            playerLocomotions.HandleJumping();
           
        }


    }

}
