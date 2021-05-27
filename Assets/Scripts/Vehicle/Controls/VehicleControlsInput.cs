// GENERATED AUTOMATICALLY FROM 'Assets/Input/VehicleControlsInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VehicleControlsInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VehicleControlsInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VehicleControlsInput"",
    ""maps"": [
        {
            ""name"": ""VehicleControls"",
            ""id"": ""1ec1506d-4a57-4a3f-af74-8909fb494fd0"",
            ""actions"": [
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""1eba09d7-d308-476c-8e76-8a8ced5635a6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraAxis"",
                    ""type"": ""Button"",
                    ""id"": ""d662534f-8998-4b9e-8989-6faedfd93ca9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AccelerateForward"",
                    ""type"": ""Value"",
                    ""id"": ""85bfaa76-af29-4ea4-b8e3-63e3a0907d0a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AccelerateBackward"",
                    ""type"": ""Value"",
                    ""id"": ""0d77a9eb-73c4-4e5f-b263-3b58bb467f84"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Handbrake"",
                    ""type"": ""Value"",
                    ""id"": ""25c64015-47b1-4837-9aa9-d334400d906a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horn"",
                    ""type"": ""Value"",
                    ""id"": ""46bfb9cf-b896-485a-bfba-6d7e90e62bc7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleLights"",
                    ""type"": ""Button"",
                    ""id"": ""fcf3c9b6-da1f-4d0e-ab53-3ae1b6328d4e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftBlinker"",
                    ""type"": ""Button"",
                    ""id"": ""3c4356b6-6276-478b-a24a-7c1e7babf60d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightBlinker"",
                    ""type"": ""Button"",
                    ""id"": ""1f647160-3e6a-4bb5-ab5c-55638fe8a062"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeCamera"",
                    ""type"": ""Button"",
                    ""id"": ""66c97a28-e3a3-4796-a015-6de3e94016c2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""91b904c3-9dce-4090-949e-eea6910d90c3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AccelerateForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0a976d3-c079-4024-adf0-f4b125a60b1d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AccelerateForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18ce2ef2-b10f-4a67-8879-8ddb00ed45c5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AccelerateBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36c7b1d1-8e56-40bf-b084-0c349397fd01"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AccelerateBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f5e09cd-9516-4835-9b24-df5d642147dd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16a700ba-3dd6-4e74-b184-0a5d20c634fc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""127dca46-67b7-42e8-9647-d55f0a24b58e"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85ebc8d6-de78-4eff-86ba-825c2092eb73"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Horn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4de69caa-fc6e-42b5-b978-4c760468091d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ToggleLights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82efca9f-d60c-4afd-8bdb-80b329951493"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ToggleLights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""A + Left Bumper [Gamepad]"",
                    ""id"": ""ae5e731a-587e-48d8-8110-ff90992bda0d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftBlinker"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""6ab70a3e-5929-4762-944f-fe4bc160d014"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftBlinker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""ef4f1fe3-8d0c-40eb-b925-f2355ebbb7b0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftBlinker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f58522c4-09d3-4cb8-817e-500e981a8810"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftBlinker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""A + Right Bumper [Gamepad]"",
                    ""id"": ""6015ede9-c3cc-4260-b327-6bafc21e1f20"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightBlinker"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7b3ae0a3-5d90-481e-9357-95cabe490420"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightBlinker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""173bec80-d145-4ff6-9170-dd897c7065ba"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightBlinker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""94eec33c-1e58-40a5-9447-80aba4867a3c"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightBlinker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8286b14b-9cf6-4f89-afd2-c8700ea63e4c"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee7ae815-c479-4183-855d-f594daa2e826"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4eec8e5-353a-4ff4-b86f-c5d695135ea9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c118aaaa-10ee-41f8-b308-7f651f4ee342"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""157d4733-8266-4b00-a2ae-324b2bd55632"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f58220b4-423c-47e7-bf23-a044d3a8850e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""92af73d4-cfdb-43bc-8b36-1c731c87e3f3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3c4b916d-c21a-4342-9dda-cf31a78dd507"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // VehicleControls
        m_VehicleControls = asset.FindActionMap("VehicleControls", throwIfNotFound: true);
        m_VehicleControls_Steer = m_VehicleControls.FindAction("Steer", throwIfNotFound: true);
        m_VehicleControls_CameraAxis = m_VehicleControls.FindAction("CameraAxis", throwIfNotFound: true);
        m_VehicleControls_AccelerateForward = m_VehicleControls.FindAction("AccelerateForward", throwIfNotFound: true);
        m_VehicleControls_AccelerateBackward = m_VehicleControls.FindAction("AccelerateBackward", throwIfNotFound: true);
        m_VehicleControls_Handbrake = m_VehicleControls.FindAction("Handbrake", throwIfNotFound: true);
        m_VehicleControls_Horn = m_VehicleControls.FindAction("Horn", throwIfNotFound: true);
        m_VehicleControls_ToggleLights = m_VehicleControls.FindAction("ToggleLights", throwIfNotFound: true);
        m_VehicleControls_LeftBlinker = m_VehicleControls.FindAction("LeftBlinker", throwIfNotFound: true);
        m_VehicleControls_RightBlinker = m_VehicleControls.FindAction("RightBlinker", throwIfNotFound: true);
        m_VehicleControls_ChangeCamera = m_VehicleControls.FindAction("ChangeCamera", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // VehicleControls
    private readonly InputActionMap m_VehicleControls;
    private IVehicleControlsActions m_VehicleControlsActionsCallbackInterface;
    private readonly InputAction m_VehicleControls_Steer;
    private readonly InputAction m_VehicleControls_CameraAxis;
    private readonly InputAction m_VehicleControls_AccelerateForward;
    private readonly InputAction m_VehicleControls_AccelerateBackward;
    private readonly InputAction m_VehicleControls_Handbrake;
    private readonly InputAction m_VehicleControls_Horn;
    private readonly InputAction m_VehicleControls_ToggleLights;
    private readonly InputAction m_VehicleControls_LeftBlinker;
    private readonly InputAction m_VehicleControls_RightBlinker;
    private readonly InputAction m_VehicleControls_ChangeCamera;
    public struct VehicleControlsActions
    {
        private @VehicleControlsInput m_Wrapper;
        public VehicleControlsActions(@VehicleControlsInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steer => m_Wrapper.m_VehicleControls_Steer;
        public InputAction @CameraAxis => m_Wrapper.m_VehicleControls_CameraAxis;
        public InputAction @AccelerateForward => m_Wrapper.m_VehicleControls_AccelerateForward;
        public InputAction @AccelerateBackward => m_Wrapper.m_VehicleControls_AccelerateBackward;
        public InputAction @Handbrake => m_Wrapper.m_VehicleControls_Handbrake;
        public InputAction @Horn => m_Wrapper.m_VehicleControls_Horn;
        public InputAction @ToggleLights => m_Wrapper.m_VehicleControls_ToggleLights;
        public InputAction @LeftBlinker => m_Wrapper.m_VehicleControls_LeftBlinker;
        public InputAction @RightBlinker => m_Wrapper.m_VehicleControls_RightBlinker;
        public InputAction @ChangeCamera => m_Wrapper.m_VehicleControls_ChangeCamera;
        public InputActionMap Get() { return m_Wrapper.m_VehicleControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VehicleControlsActions set) { return set.Get(); }
        public void SetCallbacks(IVehicleControlsActions instance)
        {
            if (m_Wrapper.m_VehicleControlsActionsCallbackInterface != null)
            {
                @Steer.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnSteer;
                @CameraAxis.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnCameraAxis;
                @CameraAxis.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnCameraAxis;
                @CameraAxis.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnCameraAxis;
                @AccelerateForward.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnAccelerateForward;
                @AccelerateForward.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnAccelerateForward;
                @AccelerateForward.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnAccelerateForward;
                @AccelerateBackward.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnAccelerateBackward;
                @AccelerateBackward.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnAccelerateBackward;
                @AccelerateBackward.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnAccelerateBackward;
                @Handbrake.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnHandbrake;
                @Handbrake.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnHandbrake;
                @Handbrake.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnHandbrake;
                @Horn.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnHorn;
                @Horn.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnHorn;
                @Horn.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnHorn;
                @ToggleLights.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnToggleLights;
                @ToggleLights.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnToggleLights;
                @ToggleLights.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnToggleLights;
                @LeftBlinker.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnLeftBlinker;
                @LeftBlinker.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnLeftBlinker;
                @LeftBlinker.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnLeftBlinker;
                @RightBlinker.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnRightBlinker;
                @RightBlinker.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnRightBlinker;
                @RightBlinker.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnRightBlinker;
                @ChangeCamera.started -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.performed -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.canceled -= m_Wrapper.m_VehicleControlsActionsCallbackInterface.OnChangeCamera;
            }
            m_Wrapper.m_VehicleControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @CameraAxis.started += instance.OnCameraAxis;
                @CameraAxis.performed += instance.OnCameraAxis;
                @CameraAxis.canceled += instance.OnCameraAxis;
                @AccelerateForward.started += instance.OnAccelerateForward;
                @AccelerateForward.performed += instance.OnAccelerateForward;
                @AccelerateForward.canceled += instance.OnAccelerateForward;
                @AccelerateBackward.started += instance.OnAccelerateBackward;
                @AccelerateBackward.performed += instance.OnAccelerateBackward;
                @AccelerateBackward.canceled += instance.OnAccelerateBackward;
                @Handbrake.started += instance.OnHandbrake;
                @Handbrake.performed += instance.OnHandbrake;
                @Handbrake.canceled += instance.OnHandbrake;
                @Horn.started += instance.OnHorn;
                @Horn.performed += instance.OnHorn;
                @Horn.canceled += instance.OnHorn;
                @ToggleLights.started += instance.OnToggleLights;
                @ToggleLights.performed += instance.OnToggleLights;
                @ToggleLights.canceled += instance.OnToggleLights;
                @LeftBlinker.started += instance.OnLeftBlinker;
                @LeftBlinker.performed += instance.OnLeftBlinker;
                @LeftBlinker.canceled += instance.OnLeftBlinker;
                @RightBlinker.started += instance.OnRightBlinker;
                @RightBlinker.performed += instance.OnRightBlinker;
                @RightBlinker.canceled += instance.OnRightBlinker;
                @ChangeCamera.started += instance.OnChangeCamera;
                @ChangeCamera.performed += instance.OnChangeCamera;
                @ChangeCamera.canceled += instance.OnChangeCamera;
            }
        }
    }
    public VehicleControlsActions @VehicleControls => new VehicleControlsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IVehicleControlsActions
    {
        void OnSteer(InputAction.CallbackContext context);
        void OnCameraAxis(InputAction.CallbackContext context);
        void OnAccelerateForward(InputAction.CallbackContext context);
        void OnAccelerateBackward(InputAction.CallbackContext context);
        void OnHandbrake(InputAction.CallbackContext context);
        void OnHorn(InputAction.CallbackContext context);
        void OnToggleLights(InputAction.CallbackContext context);
        void OnLeftBlinker(InputAction.CallbackContext context);
        void OnRightBlinker(InputAction.CallbackContext context);
        void OnChangeCamera(InputAction.CallbackContext context);
    }
}
