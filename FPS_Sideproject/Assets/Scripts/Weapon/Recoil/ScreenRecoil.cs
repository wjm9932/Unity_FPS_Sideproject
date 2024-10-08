using UnityEngine;

public abstract class ScreenRecoil : MonoBehaviour
{
    //Rotation
    public Vector3 currentRotation { get;  set; }
    protected Vector3 targetRotation;
    private PlayerInput input;

    [Header("HipFire")]
    [SerializeField] protected float recoilX;
    [SerializeField] protected float recoilY;
    [SerializeField] protected float recoilZ;
    
    [Space()]
    [SerializeField] protected float snappiness;
    [SerializeField] protected float returnSpeed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        input = transform.root.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {

        //targetRotation = Vector3.Slerp(targetRotation, Vector3.zero, returnSpeed * Time.fixedDeltaTime);

        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
    }

    public abstract void FireCameraRecoil();
}
