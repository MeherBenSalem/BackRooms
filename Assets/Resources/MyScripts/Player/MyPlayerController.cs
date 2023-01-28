using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    public class MyPlayerController : MonoBehaviour
    {
        [Header("PlayerController")]
        [SerializeField] Transform Camera;
        [SerializeField, Range(1, 10)] float walkingSpeed = 3.0f;
        [Range(0.1f, 5)] float CroughSpeed = 1.0f;
        [SerializeField, Range(0, 20)] float jumpSpeed = 6.0f;
        [SerializeField, Range(0.5f, 10)] float lookSpeed = 2.0f;
        [SerializeField, Range(10, 120)] float lookXLimit = 80.0f;
        [Space(20)]
        [Header("Advance")]
        [SerializeField] float CroughHeight = 1.0f;
        [SerializeField] float gravity = 20.0f;
        [HideInInspector] public bool canMove = true;

        [Space(20)]
        [Header("Climbing")]
        [SerializeField] bool CanClimbing = true;
        [SerializeField, Range(1, 25)] float Speed = 2f;
        bool isClimbing = false;

        [Space(20)]
        [Header("Input")]
        [SerializeField] KeyCode CroughKey = KeyCode.LeftControl;
        [Space(20)]
        [Header("Sound")]
        [SerializeField] AudioSource footSteps;

        [HideInInspector] public CharacterController characterController;
        Vector3 moveDirection = Vector3.zero;
        float InstallCroughHeight;
        float rotationX = 0;
        Vector3 InstallCameraMovement;
        float InstallFOV;
        Camera cam;
        bool Moving;
        [HideInInspector] public float vertical;
        [HideInInspector] public float horizontal;
        [HideInInspector] public float Lookvertical;
        [HideInInspector] public float Lookhorizontal;
        bool isCrouch=false;
        private MyPlayerVitals myVitals;
        float installGravity;
        bool WallDistance;
        float WalkingValue;
        public static MyPlayerController instance;
        private void Awake()
        {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        }
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            cam = GetComponentInChildren<Camera>();
            myVitals = GetComponent<MyPlayerVitals>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            InstallCroughHeight = characterController.height;
            InstallCameraMovement = Camera.localPosition;
            InstallFOV = cam.fieldOfView;
            installGravity = gravity;
            WalkingValue = walkingSpeed;
        }

        void Update()
        {
            RaycastHit CroughCheck;

            if (!characterController.isGrounded && !isClimbing)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            vertical = canMove ? WalkingValue * Input.GetAxis("Vertical") : 0;
            horizontal = canMove ? WalkingValue * Input.GetAxis("Horizontal") : 0;
        
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * vertical) + (right * horizontal);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded && !isClimbing)
            {
                footSteps.Stop();
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            characterController.Move(moveDirection * Time.deltaTime);
            if (horizontal < 0 || vertical < 0 || horizontal > 0 || vertical > 0) {
                if(!footSteps.isPlaying&&!isCrouch) {
                footSteps.Play();
                }
              }else {
               footSteps.Stop();
            }
            if (Cursor.lockState == CursorLockMode.Locked && canMove)
            {
                Lookvertical = -Input.GetAxis("Mouse Y");
                Lookhorizontal = Input.GetAxis("Mouse X");

                rotationX += Lookvertical * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                Camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Lookhorizontal * lookSpeed, 0);
            }

            if (Input.GetKey(CroughKey))
            {
                isCrouch=true;
                float Height = Mathf.Lerp(characterController.height, CroughHeight, 5 * Time.deltaTime);
                characterController.height = Height;
                WalkingValue = Mathf.Lerp(WalkingValue, CroughSpeed, 6 * Time.deltaTime);

            }
            else if (!Physics.Raycast(GetComponentInChildren<Camera>().transform.position, transform.TransformDirection(Vector3.up), out CroughCheck, 0.8f, 1))
            {
                if (characterController.height != InstallCroughHeight)
                {
                    isCrouch=false;
                    float Height = Mathf.Lerp(characterController.height, InstallCroughHeight, 6 * Time.deltaTime);
                    characterController.height = Height;
                    WalkingValue = Mathf.Lerp(WalkingValue, walkingSpeed, 4 * Time.deltaTime);
                }
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Ladder" && CanClimbing)
            { 
                isClimbing = true;
                WalkingValue /= 2;
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Ladder" && CanClimbing)
            {
                moveDirection = new Vector3(0, Input.GetAxis("Vertical") * Speed * (-Camera.localRotation.x / 1.7f), 0);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Ladder" && CanClimbing)
            {
                isClimbing = false;
                WalkingValue *= 2;
            }
        }

    }