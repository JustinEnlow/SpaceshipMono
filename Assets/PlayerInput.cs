// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""60ed7889-098f-40ef-966d-efb4a09ae1f9"",
            ""actions"": [
                {
                    ""name"": ""ToggleCamera"",
                    ""type"": ""Value"",
                    ""id"": ""1fa70cf5-7e18-4bb7-a6dd-f43191e21a00"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""46b2f99b-f761-4f55-bd2b-0b6385509208"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraVertical"",
                    ""type"": ""Button"",
                    ""id"": ""ee23716d-ac3e-4ea7-947d-9e67dec01beb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ResetCameraRotation"",
                    ""type"": ""Button"",
                    ""id"": ""e360cb82-43dc-4e29-898d-900a1b7a55c8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RecenterVr"",
                    ""type"": ""Button"",
                    ""id"": ""d097bd82-dc87-48e0-b793-2ee4513dceb4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractOption1"",
                    ""type"": ""Button"",
                    ""id"": ""700818a4-a0bb-42fd-abe1-fd08a506dfda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractOption2"",
                    ""type"": ""Button"",
                    ""id"": ""050f779b-0b1b-492b-b062-4278f5495d80"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40d78741-5547-4125-bd29-c41d50088d97"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa3e0f8a-5a6b-4e97-97e3-047a91a5411c"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8365ea65-2a95-41ba-883f-32dbfdb1f57d"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1434ad07-f6ee-4670-9031-0e3150482516"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetCameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f92cd326-57bb-4f52-97f8-e308c5af9f9f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RecenterVr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc9704da-d674-4f16-bd9d-7a41688cd6b0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractOption1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d965ebfb-fc77-406e-beaf-d1fed405b50f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractOption2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""3f0ff623-2bc7-48c4-8acd-8bdbbd4a9ce4"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Button"",
                    ""id"": ""c5372b81-4d3a-4618-a05f-579a27a8f3ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""e89b737b-2332-4b74-838a-17d8db9a04ac"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ee37cd9d-7da5-46ab-a5d2-038249c2cef8"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2fff6e9b-38ae-419c-9ff7-0a8ea0c21244"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b07b6771-1e57-4cae-9a52-800bf216d01a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2dfe213f-4283-4cba-8b15-f226cff3fe4b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a33a4b20-be90-481d-b95c-71248a0151d2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b7e9114a-89d2-4ed3-a6b1-9acfaa56e878"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Ship"",
            ""id"": ""50f59276-bdb3-43ee-b2bb-a25b603b2fd9"",
            ""actions"": [
                {
                    ""name"": ""TogglePower"",
                    ""type"": ""Button"",
                    ""id"": ""fc262350-645c-4423-8af1-4aa500fd2097"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleTranslationAssist"",
                    ""type"": ""Button"",
                    ""id"": ""c544e4db-e51f-419a-a31a-b9508937d865"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleRotationAssist"",
                    ""type"": ""Button"",
                    ""id"": ""196f033d-e8f5-4644-98fa-d1b9db65189e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LateralMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b53a13c6-9d41-47e8-973f-f2a6335a22a2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1fcebec-b5e7-454a-8dd2-1f523ae67527"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LongitudinalMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""07ef064f-b1bb-4cf4-b9c4-ee1783a50737"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pitch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dded5ff6-a1a4-492c-b17a-9066887b31c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3fff0b62-17cb-41c7-9a21-d2faa8fede79"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77a8c738-9358-4769-8ddb-8d15103dee9c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleMasterArm"",
                    ""type"": ""Button"",
                    ""id"": ""2bb7f33e-54bd-4c0c-847d-ab021337e64a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireShipWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""3a33f529-902e-4fb7-9451-e43149cfe2a8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleFloodLights"",
                    ""type"": ""Button"",
                    ""id"": ""abab8086-6cd1-4bc7-89df-d436139715da"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TogglePositionLights"",
                    ""type"": ""Button"",
                    ""id"": ""8c376a9e-94c7-481c-b661-13f4f1f38f68"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleStrobeLights"",
                    ""type"": ""Button"",
                    ""id"": ""9b715043-7d5f-4880-8f42-1a04069ac483"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningParameterUp"",
                    ""type"": ""Button"",
                    ""id"": ""138b0aa7-52a2-4ffa-a6f0-8507e4e71064"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningParameterDown"",
                    ""type"": ""Button"",
                    ""id"": ""abeeca4b-36bd-4a05-b492-7165042bb206"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningMainUp"",
                    ""type"": ""Button"",
                    ""id"": ""7da8aafd-6d1e-4775-bbfe-1b143022351f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningMainDown"",
                    ""type"": ""Button"",
                    ""id"": ""7e7cdaca-b627-4bfc-b5ed-f1cc906a5604"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningValueUp"",
                    ""type"": ""Button"",
                    ""id"": ""8563e13f-4cd9-466e-904d-a122f4ebe822"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningValueDown"",
                    ""type"": ""Button"",
                    ""id"": ""c1468412-7ff1-4bee-b80c-2e6f1cb74e85"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningIncrementUp"",
                    ""type"": ""Button"",
                    ""id"": ""fbf1a23a-1732-4489-88f8-7c4716394d38"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TuningIncrementDown"",
                    ""type"": ""Button"",
                    ""id"": ""57a84df8-ede4-4e2c-8626-4855d762a294"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a28fde8-092f-4d0e-85cf-178d9de590b4"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc349ea7-af65-4d1b-af33-86c575f39c2b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleTranslationAssist"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfc3cfde-cb1a-40fb-8abd-35e096b11573"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleRotationAssist"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14a0c0ed-5b73-4d26-a86c-1f0b2b7c7cf6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""efe9cc03-f0cf-4708-84ed-cf57071ad4b8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""255f529f-2706-4b2a-a668-02578cda010b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7283db08-aac0-4d9d-afcc-848c1714a6a4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LateralMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a6517fad-82ee-4bbb-85b2-9615777d28ca"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f3962fc6-2444-4be3-88f9-451ddf63bac1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e0a4ba16-5386-4cbf-b452-d6e25add5a69"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1e7658e5-2e55-412e-9914-cbe1e3894b99"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71cdce68-1d3e-4bc3-929e-b71da7ca968a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongitudinalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""da6e2c1f-ddc2-429c-ba8d-0de062efc679"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongitudinalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f4135ddb-c49e-4bc9-bfd3-7992666e481c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongitudinalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf38a76b-975f-45dc-aa3c-50e1ff11a5fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LongitudinalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f6473faf-b882-4704-be91-567be8dda9f7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""86367393-96ee-4882-9d81-d6aa34be2f61"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3116a9e8-ab27-4464-b6b9-5222ab029089"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""51f59028-bd74-4024-a530-829a2b7531c8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ffcc15da-69b0-4a5b-8d8d-10a84706f81a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ca785026-3348-445f-8db8-b34ec098c8a7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3556616f-bec2-4e67-9540-512f4334c009"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a9995584-9f42-4281-8e73-a335d1c8c424"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""15e9baba-f445-483d-9ac2-e51b82e43d8d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6af25ad2-29d4-4997-ac49-81a4b1ea3aba"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""44a8d2eb-e0c0-468b-8ba1-bac9ad129f9e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b4ddb54e-0ae7-4e68-a224-674ca095e2f6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5eeb3e66-13a3-4611-a44f-016441b1b393"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleMasterArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""405157f1-6df2-490b-b490-05f5091d13ce"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireShipWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2d958dc-b9fa-4d56-a5e7-e8952f726cbc"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleFloodLights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5606c5a-6b0b-4467-8fa5-94c2b64ad44c"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePositionLights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7c4ce30-d457-42d2-bf30-41c2b03aeb90"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleStrobeLights"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13bd4aff-4980-46b4-9a55-dcd4208c99a2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningParameterUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""770ac4c6-165e-418d-902c-c294bfcc4707"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningParameterDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c4b835a-7ae1-452e-b9ed-fa12395fdf9e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningMainUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8b623a4-ff9d-4512-869b-dff8fb0cd35d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningMainDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a54c857-907d-4765-91e7-fa4625349ea1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningValueUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""008da90c-d3be-4786-a692-9b4d783e4e31"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningValueDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59adf7b1-4089-4ca6-a1d7-aede1cd0b5f1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningIncrementUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ecbb645-cb6e-4002-8933-140d168206da"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TuningIncrementDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""System"",
            ""id"": ""a7e61208-775b-450f-85ad-87bd8dc83734"",
            ""actions"": [
                {
                    ""name"": ""GameMenuToggle"",
                    ""type"": ""Button"",
                    ""id"": ""d84d64d0-cdc5-4a78-a2a8-17b0d398bafd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e20eb465-6078-4e0e-9a0d-589979db7a24"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GameMenuToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ToggleCamera = m_Player.FindAction("ToggleCamera", throwIfNotFound: true);
        m_Player_CameraHorizontal = m_Player.FindAction("CameraHorizontal", throwIfNotFound: true);
        m_Player_CameraVertical = m_Player.FindAction("CameraVertical", throwIfNotFound: true);
        m_Player_ResetCameraRotation = m_Player.FindAction("ResetCameraRotation", throwIfNotFound: true);
        m_Player_RecenterVr = m_Player.FindAction("RecenterVr", throwIfNotFound: true);
        m_Player_InteractOption1 = m_Player.FindAction("InteractOption1", throwIfNotFound: true);
        m_Player_InteractOption2 = m_Player.FindAction("InteractOption2", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_TogglePower = m_Ship.FindAction("TogglePower", throwIfNotFound: true);
        m_Ship_ToggleTranslationAssist = m_Ship.FindAction("ToggleTranslationAssist", throwIfNotFound: true);
        m_Ship_ToggleRotationAssist = m_Ship.FindAction("ToggleRotationAssist", throwIfNotFound: true);
        m_Ship_LateralMovement = m_Ship.FindAction("LateralMovement", throwIfNotFound: true);
        m_Ship_VerticalMovement = m_Ship.FindAction("VerticalMovement", throwIfNotFound: true);
        m_Ship_LongitudinalMovement = m_Ship.FindAction("LongitudinalMovement", throwIfNotFound: true);
        m_Ship_Pitch = m_Ship.FindAction("Pitch", throwIfNotFound: true);
        m_Ship_Yaw = m_Ship.FindAction("Yaw", throwIfNotFound: true);
        m_Ship_Roll = m_Ship.FindAction("Roll", throwIfNotFound: true);
        m_Ship_ToggleMasterArm = m_Ship.FindAction("ToggleMasterArm", throwIfNotFound: true);
        m_Ship_FireShipWeapon = m_Ship.FindAction("FireShipWeapon", throwIfNotFound: true);
        m_Ship_ToggleFloodLights = m_Ship.FindAction("ToggleFloodLights", throwIfNotFound: true);
        m_Ship_TogglePositionLights = m_Ship.FindAction("TogglePositionLights", throwIfNotFound: true);
        m_Ship_ToggleStrobeLights = m_Ship.FindAction("ToggleStrobeLights", throwIfNotFound: true);
        m_Ship_TuningParameterUp = m_Ship.FindAction("TuningParameterUp", throwIfNotFound: true);
        m_Ship_TuningParameterDown = m_Ship.FindAction("TuningParameterDown", throwIfNotFound: true);
        m_Ship_TuningMainUp = m_Ship.FindAction("TuningMainUp", throwIfNotFound: true);
        m_Ship_TuningMainDown = m_Ship.FindAction("TuningMainDown", throwIfNotFound: true);
        m_Ship_TuningValueUp = m_Ship.FindAction("TuningValueUp", throwIfNotFound: true);
        m_Ship_TuningValueDown = m_Ship.FindAction("TuningValueDown", throwIfNotFound: true);
        m_Ship_TuningIncrementUp = m_Ship.FindAction("TuningIncrementUp", throwIfNotFound: true);
        m_Ship_TuningIncrementDown = m_Ship.FindAction("TuningIncrementDown", throwIfNotFound: true);
        // System
        m_System = asset.FindActionMap("System", throwIfNotFound: true);
        m_System_GameMenuToggle = m_System.FindAction("GameMenuToggle", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ToggleCamera;
    private readonly InputAction m_Player_CameraHorizontal;
    private readonly InputAction m_Player_CameraVertical;
    private readonly InputAction m_Player_ResetCameraRotation;
    private readonly InputAction m_Player_RecenterVr;
    private readonly InputAction m_Player_InteractOption1;
    private readonly InputAction m_Player_InteractOption2;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleCamera => m_Wrapper.m_Player_ToggleCamera;
        public InputAction @CameraHorizontal => m_Wrapper.m_Player_CameraHorizontal;
        public InputAction @CameraVertical => m_Wrapper.m_Player_CameraVertical;
        public InputAction @ResetCameraRotation => m_Wrapper.m_Player_ResetCameraRotation;
        public InputAction @RecenterVr => m_Wrapper.m_Player_RecenterVr;
        public InputAction @InteractOption1 => m_Wrapper.m_Player_InteractOption1;
        public InputAction @InteractOption2 => m_Wrapper.m_Player_InteractOption2;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ToggleCamera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCamera;
                @ToggleCamera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCamera;
                @ToggleCamera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleCamera;
                @CameraHorizontal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraHorizontal;
                @CameraHorizontal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraHorizontal;
                @CameraHorizontal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraHorizontal;
                @CameraVertical.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraVertical;
                @CameraVertical.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraVertical;
                @CameraVertical.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraVertical;
                @ResetCameraRotation.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetCameraRotation;
                @ResetCameraRotation.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetCameraRotation;
                @ResetCameraRotation.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnResetCameraRotation;
                @RecenterVr.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRecenterVr;
                @RecenterVr.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRecenterVr;
                @RecenterVr.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRecenterVr;
                @InteractOption1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractOption1;
                @InteractOption1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractOption1;
                @InteractOption1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractOption1;
                @InteractOption2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractOption2;
                @InteractOption2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractOption2;
                @InteractOption2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractOption2;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleCamera.started += instance.OnToggleCamera;
                @ToggleCamera.performed += instance.OnToggleCamera;
                @ToggleCamera.canceled += instance.OnToggleCamera;
                @CameraHorizontal.started += instance.OnCameraHorizontal;
                @CameraHorizontal.performed += instance.OnCameraHorizontal;
                @CameraHorizontal.canceled += instance.OnCameraHorizontal;
                @CameraVertical.started += instance.OnCameraVertical;
                @CameraVertical.performed += instance.OnCameraVertical;
                @CameraVertical.canceled += instance.OnCameraVertical;
                @ResetCameraRotation.started += instance.OnResetCameraRotation;
                @ResetCameraRotation.performed += instance.OnResetCameraRotation;
                @ResetCameraRotation.canceled += instance.OnResetCameraRotation;
                @RecenterVr.started += instance.OnRecenterVr;
                @RecenterVr.performed += instance.OnRecenterVr;
                @RecenterVr.canceled += instance.OnRecenterVr;
                @InteractOption1.started += instance.OnInteractOption1;
                @InteractOption1.performed += instance.OnInteractOption1;
                @InteractOption1.canceled += instance.OnInteractOption1;
                @InteractOption2.started += instance.OnInteractOption2;
                @InteractOption2.performed += instance.OnInteractOption2;
                @InteractOption2.canceled += instance.OnInteractOption2;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    public struct UIActions
    {
        private @PlayerInput m_Wrapper;
        public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_TogglePower;
    private readonly InputAction m_Ship_ToggleTranslationAssist;
    private readonly InputAction m_Ship_ToggleRotationAssist;
    private readonly InputAction m_Ship_LateralMovement;
    private readonly InputAction m_Ship_VerticalMovement;
    private readonly InputAction m_Ship_LongitudinalMovement;
    private readonly InputAction m_Ship_Pitch;
    private readonly InputAction m_Ship_Yaw;
    private readonly InputAction m_Ship_Roll;
    private readonly InputAction m_Ship_ToggleMasterArm;
    private readonly InputAction m_Ship_FireShipWeapon;
    private readonly InputAction m_Ship_ToggleFloodLights;
    private readonly InputAction m_Ship_TogglePositionLights;
    private readonly InputAction m_Ship_ToggleStrobeLights;
    private readonly InputAction m_Ship_TuningParameterUp;
    private readonly InputAction m_Ship_TuningParameterDown;
    private readonly InputAction m_Ship_TuningMainUp;
    private readonly InputAction m_Ship_TuningMainDown;
    private readonly InputAction m_Ship_TuningValueUp;
    private readonly InputAction m_Ship_TuningValueDown;
    private readonly InputAction m_Ship_TuningIncrementUp;
    private readonly InputAction m_Ship_TuningIncrementDown;
    public struct ShipActions
    {
        private @PlayerInput m_Wrapper;
        public ShipActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TogglePower => m_Wrapper.m_Ship_TogglePower;
        public InputAction @ToggleTranslationAssist => m_Wrapper.m_Ship_ToggleTranslationAssist;
        public InputAction @ToggleRotationAssist => m_Wrapper.m_Ship_ToggleRotationAssist;
        public InputAction @LateralMovement => m_Wrapper.m_Ship_LateralMovement;
        public InputAction @VerticalMovement => m_Wrapper.m_Ship_VerticalMovement;
        public InputAction @LongitudinalMovement => m_Wrapper.m_Ship_LongitudinalMovement;
        public InputAction @Pitch => m_Wrapper.m_Ship_Pitch;
        public InputAction @Yaw => m_Wrapper.m_Ship_Yaw;
        public InputAction @Roll => m_Wrapper.m_Ship_Roll;
        public InputAction @ToggleMasterArm => m_Wrapper.m_Ship_ToggleMasterArm;
        public InputAction @FireShipWeapon => m_Wrapper.m_Ship_FireShipWeapon;
        public InputAction @ToggleFloodLights => m_Wrapper.m_Ship_ToggleFloodLights;
        public InputAction @TogglePositionLights => m_Wrapper.m_Ship_TogglePositionLights;
        public InputAction @ToggleStrobeLights => m_Wrapper.m_Ship_ToggleStrobeLights;
        public InputAction @TuningParameterUp => m_Wrapper.m_Ship_TuningParameterUp;
        public InputAction @TuningParameterDown => m_Wrapper.m_Ship_TuningParameterDown;
        public InputAction @TuningMainUp => m_Wrapper.m_Ship_TuningMainUp;
        public InputAction @TuningMainDown => m_Wrapper.m_Ship_TuningMainDown;
        public InputAction @TuningValueUp => m_Wrapper.m_Ship_TuningValueUp;
        public InputAction @TuningValueDown => m_Wrapper.m_Ship_TuningValueDown;
        public InputAction @TuningIncrementUp => m_Wrapper.m_Ship_TuningIncrementUp;
        public InputAction @TuningIncrementDown => m_Wrapper.m_Ship_TuningIncrementDown;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @TogglePower.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTogglePower;
                @TogglePower.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTogglePower;
                @TogglePower.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTogglePower;
                @ToggleTranslationAssist.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleTranslationAssist;
                @ToggleTranslationAssist.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleTranslationAssist;
                @ToggleTranslationAssist.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleTranslationAssist;
                @ToggleRotationAssist.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleRotationAssist;
                @ToggleRotationAssist.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleRotationAssist;
                @ToggleRotationAssist.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleRotationAssist;
                @LateralMovement.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnLateralMovement;
                @LateralMovement.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnLateralMovement;
                @LateralMovement.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnLateralMovement;
                @VerticalMovement.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnVerticalMovement;
                @LongitudinalMovement.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnLongitudinalMovement;
                @LongitudinalMovement.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnLongitudinalMovement;
                @LongitudinalMovement.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnLongitudinalMovement;
                @Pitch.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnPitch;
                @Yaw.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnYaw;
                @Yaw.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnYaw;
                @Yaw.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnYaw;
                @Roll.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRoll;
                @ToggleMasterArm.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleMasterArm;
                @ToggleMasterArm.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleMasterArm;
                @ToggleMasterArm.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleMasterArm;
                @FireShipWeapon.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireShipWeapon;
                @FireShipWeapon.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireShipWeapon;
                @FireShipWeapon.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireShipWeapon;
                @ToggleFloodLights.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleFloodLights;
                @ToggleFloodLights.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleFloodLights;
                @ToggleFloodLights.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleFloodLights;
                @TogglePositionLights.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTogglePositionLights;
                @TogglePositionLights.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTogglePositionLights;
                @TogglePositionLights.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTogglePositionLights;
                @ToggleStrobeLights.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleStrobeLights;
                @ToggleStrobeLights.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleStrobeLights;
                @ToggleStrobeLights.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnToggleStrobeLights;
                @TuningParameterUp.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningParameterUp;
                @TuningParameterUp.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningParameterUp;
                @TuningParameterUp.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningParameterUp;
                @TuningParameterDown.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningParameterDown;
                @TuningParameterDown.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningParameterDown;
                @TuningParameterDown.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningParameterDown;
                @TuningMainUp.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningMainUp;
                @TuningMainUp.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningMainUp;
                @TuningMainUp.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningMainUp;
                @TuningMainDown.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningMainDown;
                @TuningMainDown.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningMainDown;
                @TuningMainDown.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningMainDown;
                @TuningValueUp.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningValueUp;
                @TuningValueUp.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningValueUp;
                @TuningValueUp.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningValueUp;
                @TuningValueDown.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningValueDown;
                @TuningValueDown.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningValueDown;
                @TuningValueDown.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningValueDown;
                @TuningIncrementUp.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningIncrementUp;
                @TuningIncrementUp.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningIncrementUp;
                @TuningIncrementUp.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningIncrementUp;
                @TuningIncrementDown.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningIncrementDown;
                @TuningIncrementDown.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningIncrementDown;
                @TuningIncrementDown.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnTuningIncrementDown;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TogglePower.started += instance.OnTogglePower;
                @TogglePower.performed += instance.OnTogglePower;
                @TogglePower.canceled += instance.OnTogglePower;
                @ToggleTranslationAssist.started += instance.OnToggleTranslationAssist;
                @ToggleTranslationAssist.performed += instance.OnToggleTranslationAssist;
                @ToggleTranslationAssist.canceled += instance.OnToggleTranslationAssist;
                @ToggleRotationAssist.started += instance.OnToggleRotationAssist;
                @ToggleRotationAssist.performed += instance.OnToggleRotationAssist;
                @ToggleRotationAssist.canceled += instance.OnToggleRotationAssist;
                @LateralMovement.started += instance.OnLateralMovement;
                @LateralMovement.performed += instance.OnLateralMovement;
                @LateralMovement.canceled += instance.OnLateralMovement;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
                @LongitudinalMovement.started += instance.OnLongitudinalMovement;
                @LongitudinalMovement.performed += instance.OnLongitudinalMovement;
                @LongitudinalMovement.canceled += instance.OnLongitudinalMovement;
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @Yaw.started += instance.OnYaw;
                @Yaw.performed += instance.OnYaw;
                @Yaw.canceled += instance.OnYaw;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @ToggleMasterArm.started += instance.OnToggleMasterArm;
                @ToggleMasterArm.performed += instance.OnToggleMasterArm;
                @ToggleMasterArm.canceled += instance.OnToggleMasterArm;
                @FireShipWeapon.started += instance.OnFireShipWeapon;
                @FireShipWeapon.performed += instance.OnFireShipWeapon;
                @FireShipWeapon.canceled += instance.OnFireShipWeapon;
                @ToggleFloodLights.started += instance.OnToggleFloodLights;
                @ToggleFloodLights.performed += instance.OnToggleFloodLights;
                @ToggleFloodLights.canceled += instance.OnToggleFloodLights;
                @TogglePositionLights.started += instance.OnTogglePositionLights;
                @TogglePositionLights.performed += instance.OnTogglePositionLights;
                @TogglePositionLights.canceled += instance.OnTogglePositionLights;
                @ToggleStrobeLights.started += instance.OnToggleStrobeLights;
                @ToggleStrobeLights.performed += instance.OnToggleStrobeLights;
                @ToggleStrobeLights.canceled += instance.OnToggleStrobeLights;
                @TuningParameterUp.started += instance.OnTuningParameterUp;
                @TuningParameterUp.performed += instance.OnTuningParameterUp;
                @TuningParameterUp.canceled += instance.OnTuningParameterUp;
                @TuningParameterDown.started += instance.OnTuningParameterDown;
                @TuningParameterDown.performed += instance.OnTuningParameterDown;
                @TuningParameterDown.canceled += instance.OnTuningParameterDown;
                @TuningMainUp.started += instance.OnTuningMainUp;
                @TuningMainUp.performed += instance.OnTuningMainUp;
                @TuningMainUp.canceled += instance.OnTuningMainUp;
                @TuningMainDown.started += instance.OnTuningMainDown;
                @TuningMainDown.performed += instance.OnTuningMainDown;
                @TuningMainDown.canceled += instance.OnTuningMainDown;
                @TuningValueUp.started += instance.OnTuningValueUp;
                @TuningValueUp.performed += instance.OnTuningValueUp;
                @TuningValueUp.canceled += instance.OnTuningValueUp;
                @TuningValueDown.started += instance.OnTuningValueDown;
                @TuningValueDown.performed += instance.OnTuningValueDown;
                @TuningValueDown.canceled += instance.OnTuningValueDown;
                @TuningIncrementUp.started += instance.OnTuningIncrementUp;
                @TuningIncrementUp.performed += instance.OnTuningIncrementUp;
                @TuningIncrementUp.canceled += instance.OnTuningIncrementUp;
                @TuningIncrementDown.started += instance.OnTuningIncrementDown;
                @TuningIncrementDown.performed += instance.OnTuningIncrementDown;
                @TuningIncrementDown.canceled += instance.OnTuningIncrementDown;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);

    // System
    private readonly InputActionMap m_System;
    private ISystemActions m_SystemActionsCallbackInterface;
    private readonly InputAction m_System_GameMenuToggle;
    public struct SystemActions
    {
        private @PlayerInput m_Wrapper;
        public SystemActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @GameMenuToggle => m_Wrapper.m_System_GameMenuToggle;
        public InputActionMap Get() { return m_Wrapper.m_System; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SystemActions set) { return set.Get(); }
        public void SetCallbacks(ISystemActions instance)
        {
            if (m_Wrapper.m_SystemActionsCallbackInterface != null)
            {
                @GameMenuToggle.started -= m_Wrapper.m_SystemActionsCallbackInterface.OnGameMenuToggle;
                @GameMenuToggle.performed -= m_Wrapper.m_SystemActionsCallbackInterface.OnGameMenuToggle;
                @GameMenuToggle.canceled -= m_Wrapper.m_SystemActionsCallbackInterface.OnGameMenuToggle;
            }
            m_Wrapper.m_SystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GameMenuToggle.started += instance.OnGameMenuToggle;
                @GameMenuToggle.performed += instance.OnGameMenuToggle;
                @GameMenuToggle.canceled += instance.OnGameMenuToggle;
            }
        }
    }
    public SystemActions @System => new SystemActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnToggleCamera(InputAction.CallbackContext context);
        void OnCameraHorizontal(InputAction.CallbackContext context);
        void OnCameraVertical(InputAction.CallbackContext context);
        void OnResetCameraRotation(InputAction.CallbackContext context);
        void OnRecenterVr(InputAction.CallbackContext context);
        void OnInteractOption1(InputAction.CallbackContext context);
        void OnInteractOption2(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IShipActions
    {
        void OnTogglePower(InputAction.CallbackContext context);
        void OnToggleTranslationAssist(InputAction.CallbackContext context);
        void OnToggleRotationAssist(InputAction.CallbackContext context);
        void OnLateralMovement(InputAction.CallbackContext context);
        void OnVerticalMovement(InputAction.CallbackContext context);
        void OnLongitudinalMovement(InputAction.CallbackContext context);
        void OnPitch(InputAction.CallbackContext context);
        void OnYaw(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnToggleMasterArm(InputAction.CallbackContext context);
        void OnFireShipWeapon(InputAction.CallbackContext context);
        void OnToggleFloodLights(InputAction.CallbackContext context);
        void OnTogglePositionLights(InputAction.CallbackContext context);
        void OnToggleStrobeLights(InputAction.CallbackContext context);
        void OnTuningParameterUp(InputAction.CallbackContext context);
        void OnTuningParameterDown(InputAction.CallbackContext context);
        void OnTuningMainUp(InputAction.CallbackContext context);
        void OnTuningMainDown(InputAction.CallbackContext context);
        void OnTuningValueUp(InputAction.CallbackContext context);
        void OnTuningValueDown(InputAction.CallbackContext context);
        void OnTuningIncrementUp(InputAction.CallbackContext context);
        void OnTuningIncrementDown(InputAction.CallbackContext context);
    }
    public interface ISystemActions
    {
        void OnGameMenuToggle(InputAction.CallbackContext context);
    }
}
