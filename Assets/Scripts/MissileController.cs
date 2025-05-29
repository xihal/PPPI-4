using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed;
    public float fuelTime;
    private float currentFuel;
    private Transform target;
    private bool isActive = false;
    private CharacterController controller;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentFuel = fuelTime;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameActive || !isActive) return;

        if (currentFuel > 0)
        {
            // ������������� �����
            Vector3 direction = (target.position - transform.position);
            // transform.position += direction * speed * Time.deltaTime;
            controller.Move(transform.forward * missileSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime);

            // ������� ��������
            currentFuel -= Time.deltaTime;
        }
        else
        {
            // ������ ��������� ������
            GameManager.Instance.MissileOutOfFuel();
            gameObject.SetActive(false);
            MainMenu.Instance.ViewMenu();
        }
        MainMenu.Instance.UpdateFuel(currentFuel, fuelTime);
    }

    // ��������� ������
    public void Launch()
    {
        currentFuel = fuelTime;
        isActive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ˳��� ��������
            GameManager.Instance.PlayerHit();
            gameObject.SetActive(false);
            MainMenu.Instance.ViewMenu();
        }
    }
   
}
