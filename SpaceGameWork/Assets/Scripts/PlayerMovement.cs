using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float startSpeed = 1.0f;
    float speed;
    [SerializeField]
    float horSpeed = 10.0f;
    [SerializeField]
    float vertSpeed = 10.0f;

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

        Rigidbody body = GetComponent<Rigidbody>();  // получаем компонент с объекта
        if (body != null)                // проверяем, существует ли этот компонент
            body.freezeRotation = true;  // разрешаем повороты у объекта



         Cursor.lockState = CursorLockMode.Locked;   // скрывает указатель мыши
         Cursor.visible = false;                     // в центре экрана  

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
                movement.z = startSpeed * speed * Time.deltaTime;
            else if (speed == 0)
                movement.z = startSpeed * Time.deltaTime;

            movement = transform.TransformDirection(movement);
            charController.Move(movement);
        }
    } 
}
