using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    public void Map()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }

}

public class IKTargetFollowVRRig : MonoBehaviour
{
    [Range(0,1)]
    public float turnSmoothness = 0.1f;
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;
    public VRMap leftLeg;
    public VRMap rightLeg;
    public VRMap Torso;
    public Transform KOTVA;

    public Vector3 headBodyPositionOffset;
    public float headBodyYawOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = head.ikTarget.position + headBodyPositionOffset;
        float yaw = KOTVA.eulerAngles.y;
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(transform.eulerAngles.x, yaw, transform.eulerAngles.z),turnSmoothness);

        head.Map();
        leftHand.Map();
        rightHand.Map();
        leftLeg.Map();
        rightLeg.Map();
        float tyaw = Torso.vrTarget.eulerAngles.y;
		Torso.ikTarget.position = Torso.vrTarget.TransformPoint(Torso.trackingPositionOffset);
		Torso.ikTarget.rotation = Quaternion.Lerp(Torso.ikTarget.transform.rotation, Quaternion.Euler(Torso.ikTarget.transform.eulerAngles.x, tyaw, Torso.ikTarget.transform.eulerAngles.z), turnSmoothness);
	}
    
}
