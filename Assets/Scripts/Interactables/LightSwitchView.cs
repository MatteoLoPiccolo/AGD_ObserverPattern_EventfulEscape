using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;

    public delegate void LightSwitchDelegate();
    public LightSwitchDelegate lightSwitch;

    private void OnEnable()
    {
        lightSwitch = OnLightSwitchToggled;
        lightSwitch += OnLightSwitchSoundEffects;
    }

    private void Start() => currentState = SwitchState.Off;

    public void Interact()
    {
        //Todo - Implement Interaction
        lightSwitch.Invoke();
    }

    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void OnLightSwitchToggled()
    {
        toggleLights();
        GameService.Instance.GetInstructionView().HideInstruction();
        Debug.Log("OnLightSwitchToggled");
        //GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }

    private void OnLightSwitchSoundEffects()
    {
        //toggleLights();
        //GameService.Instance.GetInstructionView().HideInstruction();
        Debug.Log("OnLightSwitchSoundEffects");
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
}
