using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

     public void LoadCellar()
    {
        SceneManager.LoadScene("Cellar");
    }
  public void LoadNursery()
    {
        SceneManager.LoadScene("Nursery");
    }
  public void LoadLivingRoom()
    {
        SceneManager.LoadScene("LivingRoom");
    }
  public void LoadHallway()
    {
        SceneManager.LoadScene("Hallway");
    }

      public void LoadParentsRoom()
    {
        SceneManager.LoadScene("Parent'sRoom");
    }
  public void LoadKidsRoom()
    {
        SceneManager.LoadScene("Kid'sRoom");
    }
      public void LoadBathroom()
    {
        SceneManager.LoadScene("Bathroom");
    }

    public void LoadPictureBack()
    {
        SceneManager.LoadScene("UpClosePictureBack");
    }

    public void LoadPictureFront()
    {
        SceneManager.LoadScene("UpClosePictureFront");
    }

    public void LoadLockBox()
    {
        SceneManager.LoadScene("UpCloseLockBox");
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Game is quitting..."); // For debugging during testing in the Editor
        Application.Quit();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
