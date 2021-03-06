using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  public class ClickToSpawnPrefab : MonoBehaviour
  {
      public Camera nonVRCamera;
      public GameObject prefab;
      private GlobalPlayer globalPlayer;

     void Start()
    {
        //Get the Global Player Script
        globalPlayer = GameObject.Find("GlobalPlayer").GetComponent<GlobalPlayer>();

        
    }
 
      void Update()
      {
          if (Input.GetMouseButtonDown(0))
          {
              Debug.Log("Left mouse clicked");
              RaycastHit hit;
              Ray ray = nonVRCamera.ScreenPointToRay(Input.mousePosition);
  
              if (Physics.Raycast(ray, out hit))
              {
                  if (hit.transform.name == "floor" &&  globalPlayer.currentSelfCare > 10 && globalPlayer.currentPositiveEnergy > 10 && globalPlayer.currentPerseverance > 10)
                  {
                     Vector3 myVector = new Vector3(hit.point.x, hit.point.y + 10, hit.point.z);
                      Instantiate(prefab, myVector, Quaternion.identity);
                      print("My object is clicked by mouse");
                      globalPlayer.ChangePerseverance(-10);
                      globalPlayer.ChangePositiveEnergy(-10);
                      globalPlayer.ChangeSelfCare(-10);

                  }
              }
          }
      }
  }