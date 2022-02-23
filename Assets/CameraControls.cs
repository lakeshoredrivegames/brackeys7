using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimCam;

    [SerializeField]
    private Transform arms;

    [SerializeField]
    private StarterAssetsInputs starterAssetsInput;

    [SerializeField]
    private float normalSensitivity;

    [SerializeField]
    private float aimSensitivity;

    [SerializeField]
    private LayerMask colliderLayerMask = new LayerMask();

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Camera cameraCam;

    [SerializeField]
    private RenderTexture photoTex;

    [SerializeField]
    private GameObject photoBoard;

    private FirstPersonController firstPersonController;

    [SerializeField] 
    public List<headlineText> texts;

    private void Awake()
    {
        starterAssetsInput = GetComponent<StarterAssetsInputs>();
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hitto, 999f, colliderLayerMask))
        {
            mouseWorldPosition = hitto.point;
            arms.LookAt(hitto.point);

        }
        if (starterAssetsInput.aim)
        {
            aimCam.gameObject.SetActive(true);
            firstPersonController.SetSensitivity(aimSensitivity);
            animator.SetBool("IsAiming", true);

            if (starterAssetsInput.snap)
            {
                print("yay");
                StartCoroutine(TakePicture(cameraCam));
                StartCoroutine(PrintHeadline());
                starterAssetsInput.snap = false;
            }
        }
        else
        {
            aimCam.gameObject.SetActive(false);
            firstPersonController.SetSensitivity(normalSensitivity);
            animator.SetBool("IsAiming", false);
        }
    }

    public IEnumerator PrintHeadline()
    {
        yield return new WaitForEndOfFrame();
        foreach (headlineText obj in texts)
        {
            Debug.Log("During a health inspection, a " + obj.headline + " was found!");
        }
    }
    
    public IEnumerator TakePicture(Camera camera)
    {
        yield return new WaitForEndOfFrame();
        RenderTexture CurrentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        camera.Render();

        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        RenderTexture.active = CurrentRT;
        photoTex = CurrentRT;
        photoBoard.GetComponent<Renderer>().material.SetTexture("_MainTex", image);
    }
}