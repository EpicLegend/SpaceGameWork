using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float startSpeed = 0.1f;
    float speed;
    [SerializeField]
    float horSpeed = 10.0f;
    [SerializeField]
    float vertSpeed = 10.0f;
    [SerializeField]
    GameObject forceFire;
    ParticleSystem pSystem;

    public float sensitivityHor = 9.0f;      // скорость вращения по вертикальной плоскости
    public float sensitivityVert = 9.0f;     // скорость вращения по горизонтальной плоскости 

    public float minimunVert = -45.0f;
    public float maxmunVert = 45.0f;

    private float _rotatiopnX = 0;      // угол поворота по вериткали

    CharacterController charController;
    Menu menu;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        pSystem = forceFire.GetComponent<ParticleSystem>();

        Rigidbody body = GetComponent<Rigidbody>();  
        if (body != null)                
            body.freezeRotation = true;  // разрешаем повороты у объекта



         Cursor.lockState = CursorLockMode.Locked;   
         Cursor.visible = false;                      

        menu = GetComponent<Menu>();
    }

    void Update()
    {
        if (!menu.isPaused)
        {
            speed = Input.GetAxis("Vertical");        

        
            Vector3 movement = Vector3.zero;
        
            if (Input.GetMouseButton(1))
            {
                _rotatiopnX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotatiopnX = Mathf.Clamp(_rotatiopnX, minimunVert, maxmunVert);

                // Приращение угла поворота через значение delta
                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                // delta - это величина изменения угла поворота
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotatiopnX, rotationY, 0);
                
            }

            if (speed > 0)
                movement.z = startSpeed * Time.deltaTime;      
            else if (speed == 0)
                movement.z = Time.deltaTime;
                
            
            movement = transform.TransformDirection(movement);
            charController.Move(movement);
            ParticleFire(movement.z);
        }
    } 

    void ParticleFire(float x)
    {
        // Здесь есть недочет
        // Когда отжимается W, то скорость уменьшается и меняется скорость партикла
        // Это выглядит будто пауза при работе частиц
        if ( x > Time.deltaTime)
        {
            pSystem.startLifetime = speed;
        }
        else
        {
            pSystem.startLifetime = 0.7f;
        }
    }
}
