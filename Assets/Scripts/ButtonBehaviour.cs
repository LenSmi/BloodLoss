using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonState
    {
        DOOR,
        SEQUENCE,
        CHASE,
        ELEVATOR
    }

    public ButtonState state;
    public Renderer screenRenderer;
    public Light screenLight;
    public GameObject[] affectedObjects;
    public GameObject[] endPoint;
    public bool hasBeenPressed = false;
    public float doorTime;

    public int buttonsPressed;
    public int buttonTreshold;
    private List<Vector3> initialPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        hasBeenPressed = false;
        Reset.CallReset += ResetDoor;

        
        int i = 0;
        foreach (var item in affectedObjects)
        {
            if (affectedObjects[i] != null)
            {
                initialPositions.Add(affectedObjects[i].transform.position);
                i++;
            }
           
        }
    }

    public void Open()
    {
        hasBeenPressed = true;
        float timer = 0;
        int i = 0;
        foreach (var item in affectedObjects)
        {

            while (timer < doorTime)
            {

                item.transform.position = Vector3.Lerp(item.transform.position, endPoint[i].transform.position, timer);
                timer += Time.deltaTime;
            }
            timer = 0;
            i++;
        }
    }

    public void ResetDoor()
    {
        switch (state)
        {
            case ButtonState.DOOR:
                hasBeenPressed = false;
                LoopThroughObjects();
                break;
            case ButtonState.CHASE:
                hasBeenPressed = false;
                LoopThroughObjects();
                break;
            case ButtonState.SEQUENCE:
                hasBeenPressed = false;
                LoopThroughObjects();
                break;
            case ButtonState.ELEVATOR:
                hasBeenPressed = false;
                LoopThroughObjects();
                break;
        }

        screenRenderer.materials[2].SetColor("_EmissionColor", Color.green);

    }


    public void LoopThroughObjects()
    {
        int i = 0;
        foreach (var item in affectedObjects)
        {
            if (affectedObjects[i] != null)
            {
               affectedObjects[i].transform.position = initialPositions[i];
                i++;
            }
        }
    }
}
