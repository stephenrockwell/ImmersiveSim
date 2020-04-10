using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;
    public GameObject Sniper;
    public float scopedFOV = 15f;
    private float normalFOV = 60f;

    bool isScoped = false;

    void Update(){
        if(Sniper.activeInHierarchy){
            if(Input.GetButtonDown("Fire2")){
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);
            if(isScoped){
                StartCoroutine(OnScoped());
            }
            else{
                OnUnscoped();
            }
        }
        }
        else{
            StopCoroutine(OnScoped());
            OnUnscoped();
            scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCamera.fieldOfView = normalFOV;
        }
    }

    IEnumerator OnScoped(){
        yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }
    void OnUnscoped(){
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCamera.fieldOfView = normalFOV;
    }
}
