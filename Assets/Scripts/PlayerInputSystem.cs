// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputSystem"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""dcd602e9-6605-466c-8758-9732822d7b9e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d8250283-bfb1-4cdd-a212-f003f9d86767"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ed37c48c-535b-4199-8bfa-77179e7c5c0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4b2dcee8-8475-4cbe-a39a-3f11d363adcc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb58d43f-3a1c-427a-b80b-80c2bbe16163"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard 1D Axis"",
                    ""id"": ""b0028f41-3ec2-4e0e-8977-e3dc490d3f50"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""70554f63-c09d-436e-a565-57e19efb198a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""375df274-5b7a-44d3-b5d3-4234df1e5888"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad 1D Axis"",
                    ""id"": ""585eeb86-8d54-4936-b691-20e1b548df70"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""113445c4-7b04-4dee-9d4f-447f9dbeabee"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f61b98e9-5bbb-4ee7-b47f-1c96890eafef"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""InputUI"",
            ""id"": ""7429e7e9-0d62-4373-b898-965cd9f8bf2b"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""29069a62-9850-44e1-b47f-c69a017e79b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuNavigation"",
                    ""type"": ""Value"",
                    ""id"": ""d726165f-04e2-44f9-b661-f17eb6838bc0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""06fcf7df-cc4c-4843-af6f-37c67482e233"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""e42be435-cc3e-45ba-8821-347542d958c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""55c86405-22cd-474b-9873-724bb3beaa2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9af8689-d1f0-4d3f-8f0a-80ae51243844"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75efa6bf-98a1-4f36-b7c7-ff867a0442d8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfaa7cf2-13b0-409b-9dd0-fdb7345b593c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a4f7413-6a3d-4302-a062-b9186816885b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard 2D Vector"",
                    ""id"": ""b0319d9b-845f-4eb8-b896-2629a074dd93"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""452b5952-90ba-4b51-bf8a-e27ce2c0986c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6130be25-2361-47db-a7c1-e7c960dd91d2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0284de45-08f2-4004-b7ba-2b3115799207"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6762b45c-f061-4324-bd7c-59865a5d43b6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad 2D Vector"",
                    ""id"": ""6ed0edd0-52b9-46f6-8793-4400f833e7be"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2b156ab7-8574-4d92-874e-10e7c2b53d11"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3cdebcee-895c-4653-9a99-a5c185b82691"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""43ed0489-6072-48e4-a441-339caf9ef77d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3151c818-98c1-441a-b439-c9c2079ae145"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b4ee7c16-fb51-4c18-afaa-bcabf30c4ec4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2097c39-087d-4e30-a25c-67668f2ee123"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_Movement = m_Input.FindAction("Movement", throwIfNotFound: true);
        m_Input_Jump = m_Input.FindAction("Jump", throwIfNotFound: true);
        // InputUI
        m_InputUI = asset.FindActionMap("InputUI", throwIfNotFound: true);
        m_InputUI_Pause = m_InputUI.FindAction("Pause", throwIfNotFound: true);
        m_InputUI_MenuNavigation = m_InputUI.FindAction("MenuNavigation", throwIfNotFound: true);
        m_InputUI_Select = m_InputUI.FindAction("Select", throwIfNotFound: true);
        m_InputUI_MousePosition = m_InputUI.FindAction("MousePosition", throwIfNotFound: true);
        m_InputUI_MouseLeftClick = m_InputUI.FindAction("MouseLeftClick", throwIfNotFound: true);
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

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_Movement;
    private readonly InputAction m_Input_Jump;
    public struct InputActions
    {
        private @PlayerInputSystem m_Wrapper;
        public InputActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Input_Movement;
        public InputAction @Jump => m_Wrapper.m_Input_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_InputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public InputActions @Input => new InputActions(this);

    // InputUI
    private readonly InputActionMap m_InputUI;
    private IInputUIActions m_InputUIActionsCallbackInterface;
    private readonly InputAction m_InputUI_Pause;
    private readonly InputAction m_InputUI_MenuNavigation;
    private readonly InputAction m_InputUI_Select;
    private readonly InputAction m_InputUI_MousePosition;
    private readonly InputAction m_InputUI_MouseLeftClick;
    public struct InputUIActions
    {
        private @PlayerInputSystem m_Wrapper;
        public InputUIActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_InputUI_Pause;
        public InputAction @MenuNavigation => m_Wrapper.m_InputUI_MenuNavigation;
        public InputAction @Select => m_Wrapper.m_InputUI_Select;
        public InputAction @MousePosition => m_Wrapper.m_InputUI_MousePosition;
        public InputAction @MouseLeftClick => m_Wrapper.m_InputUI_MouseLeftClick;
        public InputActionMap Get() { return m_Wrapper.m_InputUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputUIActions set) { return set.Get(); }
        public void SetCallbacks(IInputUIActions instance)
        {
            if (m_Wrapper.m_InputUIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_InputUIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_InputUIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_InputUIActionsCallbackInterface.OnPause;
                @MenuNavigation.started -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMenuNavigation;
                @MenuNavigation.performed -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMenuNavigation;
                @MenuNavigation.canceled -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMenuNavigation;
                @Select.started -= m_Wrapper.m_InputUIActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_InputUIActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_InputUIActionsCallbackInterface.OnSelect;
                @MousePosition.started -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMousePosition;
                @MouseLeftClick.started -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_InputUIActionsCallbackInterface.OnMouseLeftClick;
            }
            m_Wrapper.m_InputUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @MenuNavigation.started += instance.OnMenuNavigation;
                @MenuNavigation.performed += instance.OnMenuNavigation;
                @MenuNavigation.canceled += instance.OnMenuNavigation;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
            }
        }
    }
    public InputUIActions @InputUI => new InputUIActions(this);
    public interface IInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IInputUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnMenuNavigation(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseLeftClick(InputAction.CallbackContext context);
    }
}
