using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public InputActionReference actionSwitchNext;
    public InputActionReference actionSwitchPrev;
    public InputActionReference actionSwitchToScreen1;
    public InputActionReference actionSwitchToScreen2;
    public InputActionReference actionSwitchToScreen3;
    public InputActionReference actionSwitchToScreen4;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    private Canvas activeCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeCanvas = canvas1;
        actionSwitchNext.action.started += switchToNextScreen;
        actionSwitchPrev.action.started += switchToPrevScreen;
        actionSwitchToScreen1.action.started += switchToScreen1;
        actionSwitchToScreen2.action.started += switchToScreen2;
        actionSwitchToScreen3.action.started += switchToScreen3;
        actionSwitchToScreen4.action.started += switchToScreen4;
    }

    void switchToNextScreen(InputAction.CallbackContext context)
    {
        Canvas tmp = activeCanvas;
        if (canvas1.isActiveAndEnabled)
            tmp = canvas2;
        else if (canvas2.isActiveAndEnabled)
            tmp = canvas3;
        else if (canvas3.isActiveAndEnabled)
            tmp = canvas4;
        else if (canvas4.isActiveAndEnabled)
            tmp = canvas1;
        activeCanvas.enabled = false;
        activeCanvas = tmp;
        activeCanvas.enabled = true;
    }
    void switchToPrevScreen(InputAction.CallbackContext context)
    {
        Canvas tmp = activeCanvas;
        if (canvas1.isActiveAndEnabled)
            tmp = canvas4;
        else if (canvas2.isActiveAndEnabled)
            tmp = canvas1;
        else if (canvas3.isActiveAndEnabled)
            tmp = canvas2;
        else if (canvas4.isActiveAndEnabled)
            tmp = canvas3;
        activeCanvas.enabled = false;
        activeCanvas = tmp;
        activeCanvas.enabled = true;
    }

    void switchToScreen1(InputAction.CallbackContext context)
    {
        activeCanvas.enabled = false;
        activeCanvas = canvas1;
        activeCanvas.enabled = true;
    }
    void switchToScreen2(InputAction.CallbackContext context)
    {
        activeCanvas.enabled = false;
        activeCanvas = canvas2;
        activeCanvas.enabled = true;
    }
    void switchToScreen3(InputAction.CallbackContext context)
    {
        activeCanvas.enabled = false;
        activeCanvas = canvas3;
        activeCanvas.enabled = true;
    }
    void switchToScreen4(InputAction.CallbackContext context)
    {
        activeCanvas.enabled = false;
        activeCanvas = canvas4;
        activeCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
