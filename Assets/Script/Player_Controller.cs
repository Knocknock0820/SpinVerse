using UnityEngine;
using UnityEngine.InputSystem;


public class Player_Controller : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]private float _speed = 1f;

    void OnEnable(){
        
    }
    private void Awake(){

        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext ctx){
        _rigidbody.velocity = new Vector3(ctx.ReadValue<Vector2>().x,0,ctx.ReadValue<Vector2>().y) * _speed;
    }


}
