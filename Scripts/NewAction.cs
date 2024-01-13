using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewAction : MonoBehaviour
{
    public InputActionReference left_click;
    public InputActionReference right_click;
    public bool tek = true;

    public bool Left_click_attack;
    public bool Right_click_attack;

    private bool hasLeftClicked = false;
    private bool hasRightClicked = false;
    private bool hasSpawnedVFX = false;

    //vfx i�im girdiler
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public GameObject effectToSpawn;
    public float effectTimePlayAfter;
    public GameObject MyPlayerDeneme;

    private void Awake()
    {
        //mouse i�in sol t�k giri�i
        left_click.action.performed += i => Left_click_attack = true;
        left_click.action.canceled += i =>
        {
            Left_click_attack = false;
            hasSpawnedVFX = false; // Reset 
        };

        //mouse i�in sa� t�k giri�leri
        right_click.action.performed += i => Right_click_attack = true;
        right_click.action.canceled += i =>
        {
            Right_click_attack = false;
            hasSpawnedVFX = false; // Reset 
        };
    }

    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Left_click_attack && !hasSpawnedVFX)
        {
            Debug.Log("�al��t� sol");
            spawnVFX();
            hasSpawnedVFX = true; // bayrak 1
        }

        if (Right_click_attack && !hasSpawnedVFX)
        {
            Debug.Log("�al��t� sa�");
            spawnVFX();
            hasSpawnedVFX = true; // bayrak 2
        }
    }





    //vfx spawn noktas�
    public void spawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            //vfx instantiate oldu
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);

            Vector3 playerForward = MyPlayerDeneme.transform.forward;

            //oyuncunun bakt��� y�ne git
            vfx.transform.rotation = Quaternion.LookRotation(playerForward);
            vfx.transform.eulerAngles = new Vector3(0, vfx.transform.eulerAngles.y, 0);
       
        }
        else
        {
            Debug.Log("ates noktas� ekle");
           
        }

        
    }
}
