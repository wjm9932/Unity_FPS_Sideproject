using UnityEngine;

public class Recoil : MonoBehaviour
{
    //Rotation
    public Vector3 currentRotation { get; private set; }
    private Vector3 targetRotation;
    private PlayerInput input;

    [Header("HipFire")]
    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;

    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        input = transform.root.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.fixedDeltaTime);
    
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
    }

    public void FireCameraRecoil()
    {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), 0);
    }
}
