using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    int xSpeed = 0;
    int zSpeed = 0;
    public GameObject playerModel;
    public int mSpeed = 4;
    Rigidbody physicsBody;
    public Camera camera;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;
    public GameObject cursorObject;
    public Ability[] abilities;
   


    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
    }

    // Use this for initialization
    void Start()
    {
        xSpeed = 0;
        zSpeed = 0;
        physicsBody = GetComponent<Rigidbody>();
        foreach (Ability item in abilities) {
            item.target = playerModel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        physicsBody.velocity = new Vector3(Input.GetAxis("Horizontal") * mSpeed, physicsBody.velocity.y, Input.GetAxis("Vertical") * mSpeed);

        turn();

        checkAbilityUse();
    }

     void turn(){
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - playerModel.transform.position;

            //Move cursor to point
            cursorObject.transform.position = floorHit.point;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerModel.transform.rotation = newRotation;
        }
    }

    void checkAbilityUse() {

        if (Input.GetButton("Fire2")) {
            UseAbility(0);
        }
    }

    void UseAbility(int index) {
        abilities[index].tryToCast();
    }
}
