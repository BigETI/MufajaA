// GENERATED AUTOMATICALLY FROM 'Assets/Mufaja'a/InputActions/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace MufajaA.InputActions
{
    public class @GameInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""GameActionMap"",
            ""id"": ""ca014acf-f32d-4397-b0f5-38c03ec27f4e"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0e0206ab-799f-44fc-b01e-5c3398924db0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LickLeft"",
                    ""type"": ""Button"",
                    ""id"": ""fca5a231-4380-4149-883f-df99db56ae80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LickRight"",
                    ""type"": ""Button"",
                    ""id"": ""2801fdde-f3ef-45f4-82b0-8167f2dd41a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Any"",
                    ""type"": ""Button"",
                    ""id"": ""ccdde507-9f10-4d8a-b6c7-a84e5b06e0f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a552aff2-de84-4535-8785-94345974b419"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66d7566b-93a8-4500-910b-d0e448c1bc8a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""LickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78148dfe-0f9b-4833-90c5-9d57c95f79d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""LickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""309e07d7-526c-4b81-aed2-0907ba6a2ff9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""LickLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""830a8edd-08eb-495c-b8c8-20ed28c76d4b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""LickRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2539b1ba-76e0-47f3-a1cf-f7ccd57f0e5e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""LickRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f469f01-c0ec-4a08-b9b7-79b1a768c089"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""LickRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c655984-8e11-4aff-bdd2-551695d66a1b"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""Any"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e02c22f-99f8-41f3-b329-b5fa7bc1688f"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""Any"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a0746de-5721-4317-b8de-5f4769f05d1d"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameInputActions"",
                    ""action"": ""Any"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GameInputActions"",
            ""bindingGroup"": ""GameInputActions"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // GameActionMap
            m_GameActionMap = asset.FindActionMap("GameActionMap", throwIfNotFound: true);
            m_GameActionMap_MousePosition = m_GameActionMap.FindAction("MousePosition", throwIfNotFound: true);
            m_GameActionMap_LickLeft = m_GameActionMap.FindAction("LickLeft", throwIfNotFound: true);
            m_GameActionMap_LickRight = m_GameActionMap.FindAction("LickRight", throwIfNotFound: true);
            m_GameActionMap_Any = m_GameActionMap.FindAction("Any", throwIfNotFound: true);
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

        // GameActionMap
        private readonly InputActionMap m_GameActionMap;
        private IGameActionMapActions m_GameActionMapActionsCallbackInterface;
        private readonly InputAction m_GameActionMap_MousePosition;
        private readonly InputAction m_GameActionMap_LickLeft;
        private readonly InputAction m_GameActionMap_LickRight;
        private readonly InputAction m_GameActionMap_Any;
        public struct GameActionMapActions
        {
            private @GameInputActions m_Wrapper;
            public GameActionMapActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_GameActionMap_MousePosition;
            public InputAction @LickLeft => m_Wrapper.m_GameActionMap_LickLeft;
            public InputAction @LickRight => m_Wrapper.m_GameActionMap_LickRight;
            public InputAction @Any => m_Wrapper.m_GameActionMap_Any;
            public InputActionMap Get() { return m_Wrapper.m_GameActionMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActionMapActions set) { return set.Get(); }
            public void SetCallbacks(IGameActionMapActions instance)
            {
                if (m_Wrapper.m_GameActionMapActionsCallbackInterface != null)
                {
                    @MousePosition.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnMousePosition;
                    @LickLeft.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLickLeft;
                    @LickLeft.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLickLeft;
                    @LickLeft.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLickLeft;
                    @LickRight.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLickRight;
                    @LickRight.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLickRight;
                    @LickRight.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnLickRight;
                    @Any.started -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnAny;
                    @Any.performed -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnAny;
                    @Any.canceled -= m_Wrapper.m_GameActionMapActionsCallbackInterface.OnAny;
                }
                m_Wrapper.m_GameActionMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @LickLeft.started += instance.OnLickLeft;
                    @LickLeft.performed += instance.OnLickLeft;
                    @LickLeft.canceled += instance.OnLickLeft;
                    @LickRight.started += instance.OnLickRight;
                    @LickRight.performed += instance.OnLickRight;
                    @LickRight.canceled += instance.OnLickRight;
                    @Any.started += instance.OnAny;
                    @Any.performed += instance.OnAny;
                    @Any.canceled += instance.OnAny;
                }
            }
        }
        public GameActionMapActions @GameActionMap => new GameActionMapActions(this);
        private int m_GameInputActionsSchemeIndex = -1;
        public InputControlScheme GameInputActionsScheme
        {
            get
            {
                if (m_GameInputActionsSchemeIndex == -1) m_GameInputActionsSchemeIndex = asset.FindControlSchemeIndex("GameInputActions");
                return asset.controlSchemes[m_GameInputActionsSchemeIndex];
            }
        }
        public interface IGameActionMapActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
            void OnLickLeft(InputAction.CallbackContext context);
            void OnLickRight(InputAction.CallbackContext context);
            void OnAny(InputAction.CallbackContext context);
        }
    }
}
