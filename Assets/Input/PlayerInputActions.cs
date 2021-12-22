// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""e957ddc2-7049-40eb-9cd6-c3b22fe477aa"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0b05fb87-cd75-49c3-a297-717c36773fcd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8c3c6a4a-6821-4dd0-8f42-785a571518f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""7a7cfe0c-2909-456f-b9ed-2c407b7b54df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e1db03d2-eed5-47ce-ad82-e03e95e8fc82"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""180083d3-e780-4be4-a712-b31c7ef584d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""890e7436-d551-4a87-8527-ac7b112106db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""cab38bfa-d193-4251-a504-0a404343cf93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""8e1e07b1-9958-4648-9ceb-6e3c4acbe6c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SaveGame"",
                    ""type"": ""Button"",
                    ""id"": ""42c36bfe-4ca8-4b0d-9440-956b72ac7116"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""LoadGame"",
                    ""type"": ""Button"",
                    ""id"": ""4eb2ed4b-1331-43a0-811e-f613aab1a4d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction"",
                    ""id"": ""c784f696-94b8-4982-823c-8a704ea235a3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1dc696ce-5a3b-424c-aaa3-1f07004f76c8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""52aca587-2229-4af5-bc52-7c5c35638a2d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""406241f6-54d4-462d-b7f9-bca67c350329"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2def3a66-a2c4-4e4f-93f8-d93ba1049387"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d45b5f1d-4239-45ae-9490-b4edf6f0691a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3895b89a-d00f-4cb7-b725-10e3b8263911"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0735793e-3462-4720-b952-6d098dff97e2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""551ea24c-5850-4d39-9c17-d748c8d380b8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e23a571-c6ee-4365-b8bd-18b63df10cc4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fca111a8-fa0d-4bc4-91d7-3f67000235a6"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e10ab89-2b2d-4a68-9e4d-5cace034d29c"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""840132c9-4394-463d-93df-34d48230a32d"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaveGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""953ae156-85da-41a0-82db-ca3245609864"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseActionMap"",
            ""id"": ""3e086b8c-0fda-408b-9013-cadaaede3eb5"",
            ""actions"": [
                {
                    ""name"": ""UnpauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""b3c6378d-b155-415a-9b19-dee4e7289cd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""a3e7200b-496a-499b-bcab-2abf6b90c8af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9984c02-fdad-4154-9018-0efefe47c993"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnpauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""460b81ca-ef86-495d-8174-fffb940df694"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Movement = m_PlayerActionMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerActionMap_Jump = m_PlayerActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActionMap_Run = m_PlayerActionMap.FindAction("Run", throwIfNotFound: true);
        m_PlayerActionMap_Look = m_PlayerActionMap.FindAction("Look", throwIfNotFound: true);
        m_PlayerActionMap_Fire = m_PlayerActionMap.FindAction("Fire", throwIfNotFound: true);
        m_PlayerActionMap_Reload = m_PlayerActionMap.FindAction("Reload", throwIfNotFound: true);
        m_PlayerActionMap_PauseGame = m_PlayerActionMap.FindAction("PauseGame", throwIfNotFound: true);
        m_PlayerActionMap_Inventory = m_PlayerActionMap.FindAction("Inventory", throwIfNotFound: true);
        m_PlayerActionMap_SaveGame = m_PlayerActionMap.FindAction("SaveGame", throwIfNotFound: true);
        m_PlayerActionMap_LoadGame = m_PlayerActionMap.FindAction("LoadGame", throwIfNotFound: true);
        // PauseActionMap
        m_PauseActionMap = asset.FindActionMap("PauseActionMap", throwIfNotFound: true);
        m_PauseActionMap_UnpauseGame = m_PauseActionMap.FindAction("UnpauseGame", throwIfNotFound: true);
        m_PauseActionMap_Inventory = m_PauseActionMap.FindAction("Inventory", throwIfNotFound: true);
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

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private IPlayerActionMapActions m_PlayerActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerActionMap_Movement;
    private readonly InputAction m_PlayerActionMap_Jump;
    private readonly InputAction m_PlayerActionMap_Run;
    private readonly InputAction m_PlayerActionMap_Look;
    private readonly InputAction m_PlayerActionMap_Fire;
    private readonly InputAction m_PlayerActionMap_Reload;
    private readonly InputAction m_PlayerActionMap_PauseGame;
    private readonly InputAction m_PlayerActionMap_Inventory;
    private readonly InputAction m_PlayerActionMap_SaveGame;
    private readonly InputAction m_PlayerActionMap_LoadGame;
    public struct PlayerActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerActionMap_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerActionMap_Jump;
        public InputAction @Run => m_Wrapper.m_PlayerActionMap_Run;
        public InputAction @Look => m_Wrapper.m_PlayerActionMap_Look;
        public InputAction @Fire => m_Wrapper.m_PlayerActionMap_Fire;
        public InputAction @Reload => m_Wrapper.m_PlayerActionMap_Reload;
        public InputAction @PauseGame => m_Wrapper.m_PlayerActionMap_PauseGame;
        public InputAction @Inventory => m_Wrapper.m_PlayerActionMap_Inventory;
        public InputAction @SaveGame => m_Wrapper.m_PlayerActionMap_SaveGame;
        public InputAction @LoadGame => m_Wrapper.m_PlayerActionMap_LoadGame;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRun;
                @Look.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLook;
                @Fire.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnReload;
                @PauseGame.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnPauseGame;
                @Inventory.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnInventory;
                @SaveGame.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnSaveGame;
                @SaveGame.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnSaveGame;
                @SaveGame.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnSaveGame;
                @LoadGame.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLoadGame;
                @LoadGame.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLoadGame;
                @LoadGame.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLoadGame;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @SaveGame.started += instance.OnSaveGame;
                @SaveGame.performed += instance.OnSaveGame;
                @SaveGame.canceled += instance.OnSaveGame;
                @LoadGame.started += instance.OnLoadGame;
                @LoadGame.performed += instance.OnLoadGame;
                @LoadGame.canceled += instance.OnLoadGame;
            }
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);

    // PauseActionMap
    private readonly InputActionMap m_PauseActionMap;
    private IPauseActionMapActions m_PauseActionMapActionsCallbackInterface;
    private readonly InputAction m_PauseActionMap_UnpauseGame;
    private readonly InputAction m_PauseActionMap_Inventory;
    public struct PauseActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PauseActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UnpauseGame => m_Wrapper.m_PauseActionMap_UnpauseGame;
        public InputAction @Inventory => m_Wrapper.m_PauseActionMap_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_PauseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActionMapActions instance)
        {
            if (m_Wrapper.m_PauseActionMapActionsCallbackInterface != null)
            {
                @UnpauseGame.started -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnpauseGame;
                @UnpauseGame.performed -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnpauseGame;
                @UnpauseGame.canceled -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnUnpauseGame;
                @Inventory.started -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PauseActionMapActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PauseActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UnpauseGame.started += instance.OnUnpauseGame;
                @UnpauseGame.performed += instance.OnUnpauseGame;
                @UnpauseGame.canceled += instance.OnUnpauseGame;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PauseActionMapActions @PauseActionMap => new PauseActionMapActions(this);
    public interface IPlayerActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnSaveGame(InputAction.CallbackContext context);
        void OnLoadGame(InputAction.CallbackContext context);
    }
    public interface IPauseActionMapActions
    {
        void OnUnpauseGame(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}
