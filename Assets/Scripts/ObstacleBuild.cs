using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuild : MonoBehaviour
{
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ˳��� ��������
            GameManager.Instance.PlayerHit();
            MainMenu.Instance.ViewMenu();
        }
    }
}
