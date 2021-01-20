using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{

    [SerializeField] private GameObject startRoomLights;
    [SerializeField] private GameObject firstRoomLights;
    [SerializeField] private GameObject secondRoomLights;
    [SerializeField] private GameObject thirdRoomLights;
    [SerializeField] private GameObject fourthRoomLights;
    [SerializeField] private GameObject fifthRoomLights;
    [SerializeField] private GameObject sixthRoomLights;
    [SerializeField] private GameObject seventhRoomLights;
    [SerializeField] private GameObject endRoomLights;

    private List<List<GameObject>> doorList = new List<List<GameObject>>(9);
    private List<GameObject> lightsList = new List<GameObject>(9);
    private List<Vector3> positionsList = new List<Vector3>(9);
    private List<Quaternion> rotationsList = new List<Quaternion>(9);

    [SerializeField] private List<GameObject> startRoomDoors;
    [SerializeField] private List<GameObject> firstRoomDoors;
    [SerializeField] private List<GameObject> secondRoomDoors;
    [SerializeField] private List<GameObject> thirdRoomDoors;
    [SerializeField] private List<GameObject> fourthRoomDoors;
    [SerializeField] private List<GameObject> fifthRoomDoors;
    [SerializeField] private List<GameObject> sixthRoomDoors;
    [SerializeField] private List<GameObject> seventhRoomDoors;
    [SerializeField] private List<GameObject> endRoomDoors;

    // player
    [SerializeField] private Transform player;

    void Start()
    {
        AddDoorsToList();
        AddLightsToList();
        AddPositions();
        AddRotations();
        LoadSaves();
    }

    void Update()
    {

    }

    private void LoadSaves()
    {
        bool firstOne = true;
        for(int i = 1; i < 10; i++)
        {
            string puzzleName = "puzzle" + i.ToString();
            int solved = PlayerPrefs.GetInt(puzzleName, 0);

            if(solved == 0 && firstOne)
            {
                if(i == 1)
                {
                    LockRoom(i - 1);
                    Debug.Log(puzzleName);
                }
                SwitchOnLights(i - 1);
                firstOne = false;
                player.rotation = rotationsList[i - 1];
                // player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                // player.eulerAngles = new Vector3(0f, -90f, 0f);
                player.position = positionsList[i - 1];

            }
            else if(solved == 0 && !firstOne)
            {
                LockRoom(i - 1);
                SwitchOnLights(i - 1);
            }else if(solved == 1 && i!=9)
            {
                LockRoom(i - 1);
                TurnLightsOff(i - 1);
            }else if(solved == 1 && i == 9)
            {
                LockRoom(i - 1);
                player.position = new Vector3(57.8f, 1.1f, -0.25f);
                player.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
        }
    }

    private void LockRoom(int i)
    {
        foreach(var door in doorList[i])
        {
            door.GetComponent<DoorOpeningHandler>().enabled = false;
            door.GetComponent<Animator>().enabled = false;
        }
    }

    private void UnLockRoom(int i)
    {
        foreach (var door in doorList[i])
        {
            door.GetComponent<Animator>().enabled = true;
            door.GetComponent<DoorOpeningHandler>().enabled = true;
        }
    }

    private void SwitchOnLights(int i)
    {
        lightsList[i].SetActive(true);
    }

    private void TurnLightsOff(int i)
    {
        lightsList[i].SetActive(false);
    }

    private void AddDoorsToList()
    {

        doorList.Add(startRoomDoors);
        doorList.Add(firstRoomDoors);
        doorList.Add(secondRoomDoors);
        doorList.Add(thirdRoomDoors);
        doorList.Add(fourthRoomDoors);
        doorList.Add(fifthRoomDoors);
        doorList.Add(sixthRoomDoors);
        doorList.Add(seventhRoomDoors);
        doorList.Add(endRoomDoors);

    }

    private void AddLightsToList()
    {

        lightsList.Add(startRoomLights);
        lightsList.Add(firstRoomLights);
        lightsList.Add(secondRoomLights);
        lightsList.Add(thirdRoomLights);
        lightsList.Add(fourthRoomLights);
        lightsList.Add(fifthRoomLights);
        lightsList.Add(sixthRoomLights);
        lightsList.Add(seventhRoomLights);
        lightsList.Add(endRoomLights);

    }

    private void AddPositions()
    {
        // start room position
        positionsList.Add(new Vector3(-176f, 1.1f, 0f));
        // room1 position
        positionsList.Add(new Vector3(-136f, 1.1f, 12f));
        // room2 position
        positionsList.Add(new Vector3(-90f, 1.1f, 24f));
        // room3 position
        positionsList.Add(new Vector3(-58f, 1.1f, 32f));
        // room4 position
        positionsList.Add(new Vector3(-20f, 1.1f, 36f));
        // room5 position
        positionsList.Add(new Vector3(-16f, 1.1f, -36f));
        // room6 position
        positionsList.Add(new Vector3(-57f, 1.1f, -23f));
        // room7 position
        positionsList.Add(new Vector3(-93f, 1.1f, -22f));
        // end room position
        positionsList.Add(new Vector3(40f, 1.1f, 0f));
    }

    private void AddRotations()
    {
        // start room rotation
        rotationsList.Add(Quaternion.Euler(0f, -90f, 0f));
        // room1 rotation
        rotationsList.Add(Quaternion.Euler(0f, 0f, 0f));
        // room2 rotation
        rotationsList.Add(Quaternion.Euler(0f, 90f, 0f));
        // room3 rotation
        rotationsList.Add(Quaternion.Euler(0f, 0f, 0f));
        // room4 rotation
        rotationsList.Add(Quaternion.Euler(0f, 0f, 0f));
        // room5 rotation
        rotationsList.Add(Quaternion.Euler(0f, 180f, 0f));
        // room6 rotation
        rotationsList.Add(Quaternion.Euler(0f, 0f, 0f));
        // room7 rotation
        rotationsList.Add(Quaternion.Euler(0f, 90f, 0f));
        // end room rotation
        rotationsList.Add(Quaternion.Euler(0f, 0f, 0f));
    }
    
}
