using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickKnob;
    [Header(" Settings ")]
    [SerializeField] private float moveFactor;
    [SerializeField] private bool canControl;
    private Vector3 move;
    private Vector3 clickedPosition;
    // Start is called before the first frame update
    void Start()
    {
        HideJoystick();
    }

    // Update is called once per frame
    void Update()
    {
        if(canControl)
            ControlJoystick();
    }

    public void ClickedOnJoystickZone(){
        clickedPosition = Input.mousePosition;
        joystickOutline.position = clickedPosition;
       
        ShowJoystick(); 
    }

    void ShowJoystick(){
        joystickOutline.gameObject.SetActive(true);
        canControl = true;    
    }
    public void HideJoystick(){
        joystickOutline.gameObject.SetActive(false);
        canControl = false;

        move = Vector3.zero;
    }

    private void ControlJoystick(){
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - clickedPosition;
        
        float moveMagnitude = direction.magnitude * moveFactor / Screen.width; //responsive
        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width/4);

        move = direction.normalized * moveMagnitude;

        Vector3 targetPosition = clickedPosition + move;

        joystickKnob.position = targetPosition;     
    }

    public Vector3 GetMoveVector(){
        return move;
    }
}
