using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagment;

public class GameController : MonoBehaviour
{
    [Header("Cube Object")]
    public GameObject currentCube;
    [Header("Last Cube Object")]
    public GameObject lastCube;
    [Header("Text object")]
    public Text text;
    [Header("Current Level")]
    public int Level;
    [Header("Boolean")]
    public bool Done;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewBlock()
    {

        if(lastCube != null)
        {
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x),
                currentCube.transform.position.y,
                Mathf.Round(currentCube.transform.position.z));
            
            currentCube.transform.localscale = new Vector3(lastCube.transform.localscale.x - Mathf.Abs(currentCube.transform.position.x - lastCube.transform.position.x),
                                                            lastCube.transform.localscale.y,
                                                           lastCube.transform.localscale.z - Mathf.Abs(currentCube.transform.position.z - lastCube.transform.position.z));
            
            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;

            if (currentCube.transform.localscale.x <= 0f ||
                currentCube.transform.localscale.z <= 0f)
                {
                    Done = true;
                    text.gameObject.SetActive(true);
                    text.text = "Final Score: " + Level;
                    StartCoroutine(X());
                    return;
                }
        }
    
    lastCube = currentCube;
    currentCube = Instantiate(lastCube);
    currentCube.name = Level + "";
    currentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}