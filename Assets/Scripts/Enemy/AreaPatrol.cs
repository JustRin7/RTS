using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AreaPatrol : MonoBehaviour
{

    public enum AIBehaviour
    {
        Null,
        Patrool
    }


    public enum MovementType
    {
        Moveing,
        Lerping
    }


    [Header("Move")]
    [SerializeField] private MovementType Type;
    [SerializeField] private AIBehaviour mAIBehaviour;

    [SerializeField] private MovementPath MyPath;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;

    private IEnumerator<Transform> pointInPath;

    private Transform lookTarget;
    [SerializeField] private float rotationSpeed;


    [Header("Atack")]
    private Turret[] turrets;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float speedMultiplier;
    private AudioSource catchTargetSound;
    private Transform target = null;
    

    private void Start()
    {
        if (MyPath == null)
        {
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.transform.position;


        turrets = GetComponentsInChildren<Turret>();
        catchTargetSound = GetComponent<AudioSource>();
    }


    private void UpdateAI()
    {

        if (mAIBehaviour == AIBehaviour.Patrool)
        {
            UpdateBehaviourPatrool();
        }
    }


    private void UpdateBehaviourPatrool()
    {
        ActionFindNewMovePosition();
        Atack();
    }
   

    private void Atack()
    {        
        if (target)
        {
            
            /*if(Vector2.Distance(target.transform.position, transform.position) <= m_Radius)//если враг находитс€ в рендже тавера*/
            if (Vector3.Distance(target.transform.position, transform.position) <= radius)//то же, что и расчет Distance
            {
                foreach (var turret in turrets)
                {
                    lookTarget = target;

                    transform.LookAt(lookTarget);

                    if (Type == MovementType.Moveing)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, lookTarget.position, (speed * speedMultiplier) * Time.deltaTime);
                    }

                    if (Type == MovementType.Lerping)
                    {
                        transform.position = Vector3.Lerp(transform.position, lookTarget.position, (speed * speedMultiplier) * Time.deltaTime);
                    }

                    turret.Fire();
                }
            }

            else target = null;

        }

        else
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider coll in nearbyColliders)
            {
                if (coll.gameObject.tag == "Player")
                {
                    target = coll.GetComponent<Transform>();
                    //catchTarget.Play();
                }
            }
        }
    }


    private void ActionFindNewMovePosition()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if (Type == MovementType.Moveing)
        {
            lookTarget = pointInPath.Current;
            var moveDirection = lookTarget.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointInPath.Current.transform.position), speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.transform.position, speed * Time.deltaTime);
        }

        if (Type == MovementType.Lerping)
        {
            lookTarget = pointInPath.Current;
            var moveDirection = lookTarget.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);

            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointInPath.Current.transform.position), speed * Time.deltaTime);            
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.transform.position, speed * Time.deltaTime);
        }

        var distanceSquare = (transform.position - pointInPath.Current.transform.position).sqrMagnitude;

        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
    }


    private void Update()
    {
        UpdateAI();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
