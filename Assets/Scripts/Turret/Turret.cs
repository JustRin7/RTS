using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PauseAudioSource))]
[RequireComponent(typeof(AudioSource))]
public class Turret : MonoBehaviour
{


    [SerializeField] private TurretMode m_Mode;
    public TurretMode Mode => m_Mode;


    [SerializeField] private TurretProperties m_TurretProperties;

    private AudioSource shotSound;
    private float m_RefireTime;

    public bool CanFire => m_RefireTime <= 0;

    private Ship m_Ship;

    private void Start()
    {
        m_Ship = transform.root.GetComponent<Ship>();
        shotSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_RefireTime > 0)
            m_RefireTime -= Time.deltaTime;

    }

    //Publick API
    public void Fire()
    {
        if (m_TurretProperties == null) return;

        if (m_RefireTime > 0) return;



        /*
        if(m_Ship.DrawEneggy(m_TurretProperties.EnergyUsage) == false)
        {
            return;
        }


        if (m_Ship.DrawAmmo(m_TurretProperties.AmmoUsage) == false)
        {
            return;
        }*/







        Projectile projectile = Instantiate(m_TurretProperties.ProjectilePrefab).GetComponent<Projectile>();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        //projectile.transform.up = transform.up;

        projectile.SetParentShooter(m_Ship);

        m_RefireTime = m_TurretProperties.RateOfFire;

        {
            shotSound.PlayOneShot(m_TurretProperties.LaunchSFX); //SFX
        }








    }


    public void AssignLoadout(TurretProperties props)
    {
        if (m_Mode != props.Mode) return;

        m_RefireTime = 0;
        m_TurretProperties = props;
    }

}

