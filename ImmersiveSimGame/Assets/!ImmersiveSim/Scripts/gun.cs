using System.Collections;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public AudioSource gunSound;
    public AudioSource gunReloadSound;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private float nextTimeToFire = 0f;
    void Start(){
        if(currentAmmo == 1)
            currentAmmo = maxAmmo;
    }
    void Update()
    {
        if(isReloading){
            return;
        }
        if(currentAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void OnEnable(){
        isReloading = false;
    }
    IEnumerator Reload(){
        isReloading = true;
        gunReloadSound.Play();
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot(){
        gunSound.Play();
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Health target = hit.transform.GetComponent<Health>();
            if(target != null){
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
