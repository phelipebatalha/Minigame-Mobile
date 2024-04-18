using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationStateController : MonoBehaviour
{
    Animator _animator;
    float _velocidadeX = 0.0f, _velocidadeZ = 0.0f;
    public float _acceleration = 3.0f, _deceleration = 3.0f;
    public float _maximumWalkVelocity = 3.0f, _maximumRunVelocity = 3.0f;
    public GameObject _particle;
    private bool _can_Cast, _frente, _tras, _esquerda, _direita, _corrida, _cast;

    int VelocityZHash, VelocityXHash;
    void Start()
    {
        _animator = GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
        _can_Cast = true;
    }
    void VariableAtribbution()
    {
        _frente = -Input.acceleration.x > 0.5;
        _tras = -Input.acceleration.x < -0.5;
        _esquerda = Input.acceleration.y < -0.5;
        _direita = Input.acceleration.y > 0.5;
        //_corrida = Input.GetKey(KeyCode.LeftShift);
        //_cast = Input.GetKey(KeyCode.Mouse0);
    }
    void ChangeVelocity(bool _frente, bool _tras, bool _esquerda, bool _direita, bool _corrida, float velocidademaxima)
    {
        //Accelerated
        if(_frente && _velocidadeZ < velocidademaxima)
        {
            _velocidadeZ += Time.deltaTime * _acceleration;
        }
        if(_tras && _velocidadeZ > -velocidademaxima)
        {
            _velocidadeZ -= Time.deltaTime * _acceleration;
        }
        if(_esquerda && _velocidadeX > -velocidademaxima)
        {
            _velocidadeX -= Time.deltaTime * _acceleration;
        }
        if(_direita && _velocidadeX < velocidademaxima)
        {
            _velocidadeX += Time.deltaTime * _acceleration;
        }
        

        //Decelerate
        if(!_frente && _velocidadeZ > 0.0f)
        {
            _velocidadeZ -= Time.deltaTime * _deceleration;
        }
        if(!_tras && _velocidadeZ < 0.0f)
        {
            _velocidadeZ += Time.deltaTime * _deceleration;
        }
        if(!_esquerda && _velocidadeX < 0.0f)
        {
            _velocidadeX += Time.deltaTime * _deceleration;
        }
        if(!_direita && _velocidadeX > 0.0f)
        {
            _velocidadeX -= Time.deltaTime * _deceleration;
        }

    }
    void LockResetVelocity(bool _frente, bool _tras, bool _esquerda, bool _direita, bool _corrida,  float velocidademaxima)
    {
        //reset Z
        if(!_frente && !_tras && _velocidadeZ != 0.0f && (_velocidadeZ > -0.05f && _velocidadeZ < 0.05f))
        {
            _velocidadeZ = 0.0f;
        }
        //reset X
        if(!_esquerda && !_direita && _velocidadeX != 0.0f && (_velocidadeX > -0.05f && _velocidadeX < 0.05f))
        {
            _velocidadeX = 0.0f;
        }
        //lock Foward
        if(_frente && _corrida && _velocidadeZ > velocidademaxima)
        {
            _velocidadeZ = velocidademaxima;
        }
        else if(_frente && _velocidadeZ > velocidademaxima)
        {
            _velocidadeZ -= Time.deltaTime * _deceleration;
            if(_velocidadeZ > velocidademaxima && _velocidadeZ < (velocidademaxima + 0.05f))
            {
                _velocidadeZ = velocidademaxima;
            }
        }
        else if(_frente && _velocidadeZ < velocidademaxima && _velocidadeZ > (velocidademaxima - 0.05f))
        {
            _velocidadeZ = velocidademaxima;
        }
        //lock Back
        if(_tras && _corrida && _velocidadeZ < -velocidademaxima)
        {
            _velocidadeZ = -velocidademaxima;
        }
        else if(_tras && _velocidadeZ < -velocidademaxima)
        {
            _velocidadeZ += Time.deltaTime * _deceleration;
            if(_velocidadeZ < -velocidademaxima && _velocidadeZ > (-velocidademaxima - 0.05f))
            {
                _velocidadeZ = -velocidademaxima;
            }
        }
        else if(_tras && _velocidadeZ > -velocidademaxima && _velocidadeZ < (-velocidademaxima + 0.05f))
        {
            _velocidadeZ = -velocidademaxima;
        }
        //lock Left
        if(_esquerda && _corrida && _velocidadeX < -velocidademaxima)
        {
            _velocidadeX = -velocidademaxima;
        }
        else if(_esquerda && _velocidadeX < -velocidademaxima)
        {
            _velocidadeX += Time.deltaTime * _deceleration;
            if(_velocidadeX < -velocidademaxima && _velocidadeX > (-velocidademaxima - 0.05f))
            {
                _velocidadeX = -velocidademaxima;
            }
        }
        else if(_esquerda && _velocidadeX > -velocidademaxima && _velocidadeX < (-velocidademaxima + 0.05f))
        {
            _velocidadeX = -velocidademaxima;
        }
        //lock Right
        if(_direita && _corrida && _velocidadeX > velocidademaxima)
        {
            _velocidadeX = velocidademaxima;
        }
        else if(_direita && _velocidadeX > velocidademaxima)
        {
            _velocidadeX -= Time.deltaTime * _deceleration;
            if(_velocidadeX > velocidademaxima && _velocidadeX < (velocidademaxima + 0.05f))
            {
                _velocidadeX = velocidademaxima;
            }
        }
        else if(_direita && _velocidadeX < velocidademaxima && _velocidadeX > (velocidademaxima - 0.05f))
        {
            _velocidadeX = velocidademaxima;
        }
    }
    void Attack(bool _cast)
    {
        if(_cast && _can_Cast)
        {
            _can_Cast = false;
            _animator.SetTrigger("isCasting");
        }
            //StartCoroutine(_Caster());
            _can_Cast = true;
    }
    void Update()
    {        
        VariableAtribbution();

        float velocidademaxima = _corrida ? _maximumRunVelocity : _maximumWalkVelocity;

        ChangeVelocity(_frente, _tras, _esquerda, _direita, _corrida, velocidademaxima);
        LockResetVelocity(_frente, _tras, _esquerda, _direita, _corrida, velocidademaxima);
        Attack(_cast);
        

        _animator.SetFloat(VelocityZHash, _velocidadeZ);
        _animator.SetFloat(VelocityXHash, _velocidadeX);
    }
    //IEnumerator _Caster()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    _particle.SetActive(true);
    //    yield return new WaitForSeconds(1.5f);
    //    _particle.SetActive(false);
    //}
}
