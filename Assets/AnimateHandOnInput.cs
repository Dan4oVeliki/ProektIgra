using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty PinchAnimationAction;
    public InputActionProperty GripAnimationAction;
    public Animator HandAnimator;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggervalue = PinchAnimationAction.action.ReadValue<float>();
        HandAnimator.SetFloat("Trigger", triggervalue);

        float gripValue = GripAnimationAction.action.ReadValue<float>();
        HandAnimator.SetFloat("Grip", gripValue);
    }
}
