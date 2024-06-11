using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    private Vector3 dir, rot;
    void Awake()
    {
        Vector3 dir = Vector3.zero;
        Vector3 rot = Vector3.zero;
    }
    void FixedUpdate(){
        //Debug.Log(dir);
        Debug.Log(rot);
    }
    void Update()
    {
        dir.z = -Input.acceleration.z; // frente e trás
        rot.y = Input.acceleration.x; //lados

        if(dir.sqrMagnitude > 1)
            dir.Normalize();
        if (rot.sqrMagnitude > 1)
            rot.Normalize();

        dir *= Time.deltaTime;
        rot *= Time.deltaTime;
        AjusteDir();

        transform.Translate(dir * _speed);
        transform.Rotate(rot * _rotateSpeed);
    }
    void AjusteDir()
    {
        if (dir.z > 0.001f)
            dir.z = 0.01f;
        else if (dir.z < 0.001f)
            dir.z = -0.01f;
        else dir.z = 0f;
    }
}
