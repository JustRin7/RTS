using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private float m_Velocity;
    [SerializeField] private float m_Lifetime;
    [SerializeField] private int m_Damage;
    [SerializeField] private ImpactEffect m_ImpactEffectPrefab;

    private float m_Timer;


    private void Start()
    {
        transform.Translate(0, 0, 3);
        GetComponent<Rigidbody>().velocity = m_Parent.transform.forward * m_Velocity;
    }

    private void Update()
    {
        
        float stepLenght = Time.deltaTime * m_Velocity;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, stepLenght))
        {
            Destructable des = hit.collider.transform.root.GetComponent<Destructable>();

            if (des != null && des != m_Parent)
            {
                //Destroy(hit.collider.gameObject);
                des.ApplyDamage(m_Damage);
            }

            Instantiate(m_ImpactEffectPrefab);
            OnProjectileLifeEnd(hit.collider, hit.point);
        }

        m_Timer += Time.deltaTime;

        if (m_Timer > m_Lifetime)
            Destroy(gameObject);
    }


    private void OnProjectileLifeEnd(Collider col, Vector3 pos)
    {
        Destroy(gameObject);
    }


    private Ship m_Parent;

    public void SetParentShooter(Ship parent)
    {
        m_Parent = parent;
    }


}
