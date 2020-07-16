using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public Transform BulletPref;
    //public Transform Pivot;
    //private Vector3 mousePosition;
    //public float moveSpeed = 2;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

    //    // Тот самый поворот
    //    // вычисляем разницу между текущим положением и положением мыши
    //    Vector3 difference = mousePosition - transform.position;
    //    difference.Normalize();
    //    // вычисляемый необходимый угол поворота
    //    float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    // Применяем поворот вокруг оси Z
    //    transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);



    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Instantiate(BulletPref, Pivot.position, Pivot.rotation);
    //    }
    //}

    public GameObject BulletPrefab;

    public float Power = 100;

    //public TrajectoryRendererAdvanced Trajectory;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);

        Vector3 speed = (mouseInWorld - transform.position) * Power;
        transform.rotation = Quaternion.LookRotation(speed);

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //bullet.AddForce(speed, ForceMode.VelocityChange);
            //Trajectory.AddBody(bullet);
        }
    }
}
