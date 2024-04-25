using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed;
    
    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = -Input.acceleration.x;
        dir.z = Input.acceleration.y;

        if(dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;

        transform.Translate(dir * _speed);
    }
}
