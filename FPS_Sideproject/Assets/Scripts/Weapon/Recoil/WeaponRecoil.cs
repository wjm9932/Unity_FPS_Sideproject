using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponRecoil : MonoBehaviour
{

    [Header("Speed")]
    [SerializeField] protected float positionalRecoilSpeed = 8f;
    [SerializeField] protected float rotationalRecoilSpeed = 8f;
    
    [Space()]
    [SerializeField] protected float positionalReturnSpeed = 18f;
    [SerializeField] protected float rotationalReturnSpeed = 38f;

    [Header("Amount Setting")]
    [SerializeField] protected Vector3 recoilRotation;
    [SerializeField] protected Vector3 recoilKickBack;

    protected Vector3 rotationalRecoil;
    protected Vector3 positionalRecoil;
    protected Vector3 rotation;
    protected Vector3 originPosition;
    protected Vector3 originRotation;

    private Transform recoilTransform;

    protected virtual void Awake()
    {
        recoilTransform = gameObject.transform.parent;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        originPosition = recoilTransform.localPosition;
        originRotation = recoilTransform.localPosition;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        positionalRecoil = Vector3.Lerp(positionalRecoil, originPosition, positionalReturnSpeed * Time.deltaTime);
        rotationalRecoil = Vector3.Slerp(rotationalRecoil, originRotation, rotationalReturnSpeed * Time.deltaTime);

        recoilTransform.localPosition = Vector3.Lerp(recoilTransform.localPosition, positionalRecoil, positionalRecoilSpeed * Time.deltaTime);
        
        rotation = Vector3.Slerp(rotation, rotationalRecoil, rotationalRecoilSpeed* Time.deltaTime);
        recoilTransform.localRotation = Quaternion.Euler(rotation);
    }

    public abstract void FireWeaponRecoil();
}