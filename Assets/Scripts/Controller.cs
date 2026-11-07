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

    void Start()
    {
        activeCanvas = canvas1;
        canvas2.enabled = false;
        canvas3.enabled = false;
        canvas4.enabled = false;
        actionSwitchNext.action.started += switchToNextScreen;
        actionSwitchPrev.action.started += switchToPrevScreen;
        actionSwitchToScreen1.action.started += switchToScreen1;
        actionSwitchToScreen2.action.started += switchToScreen2;
        actionSwitchToScreen3.action.started += switchToScreen3;
        actionSwitchToScreen4.action.started += switchToScreen4;
    }

    void OnDisable()
    {
        actionSwitchNext.action.started -= switchToNextScreen;
        actionSwitchPrev.action.started -= switchToPrevScreen;
        actionSwitchToScreen1.action.started -= switchToScreen1;
        actionSwitchToScreen2.action.started -= switchToScreen2;
        actionSwitchToScreen3.action.started -= switchToScreen3;
        actionSwitchToScreen4.action.started -= switchToScreen4;
    }

    void switchToScreen1(InputAction.CallbackContext context){switchCanvas(canvas1);}
    void switchToScreen2(InputAction.CallbackContext context){switchCanvas(canvas2);}
    void switchToScreen3(InputAction.CallbackContext context){switchCanvas(canvas3);}
    void switchToScreen4(InputAction.CallbackContext context){switchCanvas(canvas4);}

    public void switchCanvas(Canvas canvas)
    {
        if(canvas == activeCanvas) return;
        activeCanvas.enabled = false;
        activeCanvas = canvas;
        activeCanvas.enabled = true;
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
        switchCanvas(tmp);
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
        switchCanvas(tmp);
    }
}
