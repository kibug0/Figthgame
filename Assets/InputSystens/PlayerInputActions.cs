//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystens/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""27bae5a3-9ad8-4d27-8026-449fd74f7a7d"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d02230bc-a9ff-46d1-888d-beeb46d74e07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Moviment"",
                    ""type"": ""Value"",
                    ""id"": ""ad55b7df-0306-456f-8d55-d345c347c9c0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""WeakPunch"",
                    ""type"": ""Button"",
                    ""id"": ""f4ff1c4c-0d87-453e-8e91-33ef59f02528"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WeakKick"",
                    ""type"": ""Button"",
                    ""id"": ""084c5ca3-d2f2-4bdf-a108-c0d607698b7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HeavyPunch"",
                    ""type"": ""Button"",
                    ""id"": ""199a348f-d0a8-467c-8bfe-59521f11567f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HeavyKick"",
                    ""type"": ""Button"",
                    ""id"": ""09fe4630-8ad1-45e3-914e-45c40beab0c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a68ae15e-f217-46d7-a442-f98e79f2c2db"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54161958-2ef3-4e58-a47d-c429692fbee5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e06110c-78ec-498b-9df3-cbc7cf2e27ca"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""377cf6d2-3032-44fa-b136-1a3feb390848"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""1c866003-62fc-43a2-b46a-e2ada362cf3f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f165d4ab-13e5-44de-811d-d572e12c4ed0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""52145c50-67e1-4f68-abcd-55d6427435cd"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""12a7f89d-2738-49ca-88de-ebf0899acd02"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""10659da9-65bc-4535-b075-2d35bf696575"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a6f7b5e7-9cc5-47de-b24b-c0cf048ff6f5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b8d4d762-b8f3-4588-8171-eb975dd446a0"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeakPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3dccfe8-cd53-4d59-9e1f-4bff23862470"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeakKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de1b1591-bbb7-4ee3-932d-55dfc2114d24"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce39fb47-68d1-4e25-b8e4-0ecc3e8e7f95"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
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
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Moviment = m_Player.FindAction("Moviment", throwIfNotFound: true);
        m_Player_WeakPunch = m_Player.FindAction("WeakPunch", throwIfNotFound: true);
        m_Player_WeakKick = m_Player.FindAction("WeakKick", throwIfNotFound: true);
        m_Player_HeavyPunch = m_Player.FindAction("HeavyPunch", throwIfNotFound: true);
        m_Player_HeavyKick = m_Player.FindAction("HeavyKick", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Moviment;
    private readonly InputAction m_Player_WeakPunch;
    private readonly InputAction m_Player_WeakKick;
    private readonly InputAction m_Player_HeavyPunch;
    private readonly InputAction m_Player_HeavyKick;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Moviment => m_Wrapper.m_Player_Moviment;
        public InputAction @WeakPunch => m_Wrapper.m_Player_WeakPunch;
        public InputAction @WeakKick => m_Wrapper.m_Player_WeakKick;
        public InputAction @HeavyPunch => m_Wrapper.m_Player_HeavyPunch;
        public InputAction @HeavyKick => m_Wrapper.m_Player_HeavyKick;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Moviment.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoviment;
                @Moviment.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoviment;
                @Moviment.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoviment;
                @WeakPunch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeakPunch;
                @WeakPunch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeakPunch;
                @WeakPunch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeakPunch;
                @WeakKick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeakKick;
                @WeakKick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeakKick;
                @WeakKick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeakKick;
                @HeavyPunch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeavyPunch;
                @HeavyPunch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeavyPunch;
                @HeavyPunch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeavyPunch;
                @HeavyKick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeavyKick;
                @HeavyKick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeavyKick;
                @HeavyKick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHeavyKick;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Moviment.started += instance.OnMoviment;
                @Moviment.performed += instance.OnMoviment;
                @Moviment.canceled += instance.OnMoviment;
                @WeakPunch.started += instance.OnWeakPunch;
                @WeakPunch.performed += instance.OnWeakPunch;
                @WeakPunch.canceled += instance.OnWeakPunch;
                @WeakKick.started += instance.OnWeakKick;
                @WeakKick.performed += instance.OnWeakKick;
                @WeakKick.canceled += instance.OnWeakKick;
                @HeavyPunch.started += instance.OnHeavyPunch;
                @HeavyPunch.performed += instance.OnHeavyPunch;
                @HeavyPunch.canceled += instance.OnHeavyPunch;
                @HeavyKick.started += instance.OnHeavyKick;
                @HeavyKick.performed += instance.OnHeavyKick;
                @HeavyKick.canceled += instance.OnHeavyKick;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMoviment(InputAction.CallbackContext context);
        void OnWeakPunch(InputAction.CallbackContext context);
        void OnWeakKick(InputAction.CallbackContext context);
        void OnHeavyPunch(InputAction.CallbackContext context);
        void OnHeavyKick(InputAction.CallbackContext context);
    }
}
