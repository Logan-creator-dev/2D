using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float horizontalValue;

    [SerializeField] public float speed = 1;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move(horizontalValue);
    }

    private void Move(float dir)
    {
        float xVal = horizontalValue * speed * Time.deltaTime;

    private Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
    
    rb.velocity = targetVelocity;
}
    
    
    

}
