using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISelectable
{
    Transform transform { get; }
    void MoveOrder(Vector3 targetPosition);
}


public class UnitSelector : MonoBehaviour
{
    private Camera _camera;
    private LayerMask _unitMask;
    private ISelectable _selected;


    void Awake()
    {
        _unitMask = LayerMask.GetMask("Unit");
        _camera = GetComponent<Camera>();
    }


    Vector3 point;


    void Update()
    {   
        if(Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            //print(Physics.Raycast(ray, out var hit, _unitMask));
            if( Physics.Raycast(ray, out var hit) &&
                hit.collider.TryGetComponent<ISelectable>(out var selected) )
            {
                //point = unit.transform.position;
                _selected = selected;
            }//если в кого-то попал луч и на нем есть скрипт Unit
        }


        if (Input.GetMouseButtonDown(1) && _selected != null)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if ( Physics.Raycast(ray, out var hit) )
            {
                    _selected.MoveOrder(hit.point);
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E) && _selected != null)
        {
            Turret turret = _selected.transform.GetComponentInChildren<Turret>();
            if (turret != null)
            {
                turret.Fire();

            }

        }


    }


    public void DeSelected()
    {
        _selected = null;
    }


    /*private void OnDrawGizmos()
    {
        Gizmos.DrawCube(point, Vector3.one * 2);
    }*/


}
