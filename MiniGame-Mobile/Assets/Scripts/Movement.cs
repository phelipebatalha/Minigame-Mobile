using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    
    void Update()
    {
        Vector3 dir = Vector3.zero;
        Vector3 rot = Vector3.zero;

        rot.y = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        if(dir.sqrMagnitude > 1)
            dir.Normalize();
        if (rot.sqrMagnitude > 1) 
            rot.Normalize();
        
        dir *= Time.deltaTime;
        rot *= Time.deltaTime;

        transform.Translate(dir * _speed);
        transform.Rotate(rot * _rotateSpeed);
    }
}
