using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    
    [SerializeField] private float _moveSpeed = 5;
    //[SerializeField] private float _rotateSpeed = 5;
    
    
    private CharacterController _characterController;
    private Vector3 _move;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>(); 
    }

    private void Update() 
    { 
        Vector3 moveDirection = transform.TransformDirection(_move);
        moveDirection *= _moveSpeed;
    }


    private void OnLook(InputValue input)
    {
        Vector2 look = input.Get<Vector2>();
        _move.x = look.x;
        _move.y = look.y;
    }
}
