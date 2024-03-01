using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public string doorName;
    private Animator doorAnimator;

    void Start()
    {
        doorAnimator = GameObject.Find(doorName).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player")){
            doorAnimator.SetBool("startDoorAnim", true);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
