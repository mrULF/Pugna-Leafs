using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButterflyMOvement : MonoBehaviour
{
    public Transform target; // Karakterinizin konumunu alacak transform
    public LayerMask layerMask; // Raycast ile kontrol edilecek katman
    public float moveSpeed = 5f; // Hareket h�z�

    private bool isMoving = false; // Hareket halinde olup olmad���n� kontrol etmek i�in bir bayrak
    private Vector3 holdPosition; // Nesnenin hareket edece�i tutma pozisyonu

    void Update()
    {
        
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                holdPosition = hit.point; // �sabet eden noktay� al
                isMoving = true; // Hareket ba�lad�
                Debug.Log(hit.transform.name);
            }
        }


        if (isMoving)
        {
            MoveTowardsTarget(); // Hedefe do�ru hareket et
        }
    }

    void MoveTowardsTarget()
    {
        // K�p�n mevcut konumunu, tutma pozisyonuna do�ru yumu�ak bir �ekilde hareket ettir
        transform.position = Vector3.Lerp(transform.position, holdPosition, moveSpeed * Time.deltaTime);
    }
}
