using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ScriptForCubeConstract : MonoBehaviour
{
    public bool First = false;
    public bool Second = false;
    public bool Third = false;
    public bool Four = false;
    public bool Five = false;
    public bool Six = false;
    public bool Seven = false;
    public GameObject[] cubes;
    public int ButtonsActivatedNumber = 0;
    public GameObject Cube;
    Animator animator;
    bool win = false;
    public Material mat;
    public Material mat1;
    public GameObject Action;
    public GameObject Menu;
    bool action = false;
    public GameObject Image;

    private void Start()
    {
        animator = Cube.GetComponent<Animator>();
    }
    
    
    

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "1":
                {
                    if (First == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        
                        First = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                      
                        break;
                    }
                }
            case "2":
                {
                    if (Second == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        Second = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            case "3":
                {
                    if (Third == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        Third = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            case "4":
                {
                    if (Four == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        Four = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            case "5":
                {
                    if (Five == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        Five = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            case "6":
                {
                    if (Six == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        Six = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            case "7":
                {
                    if (Seven == false)
                    {
                        other.gameObject.GetComponent<Renderer>().material = mat;
                        Seven = true;
                        ButtonsActivatedNumber++;
                        break;
                    }
                    else
                    {
                        
                        break;
                    }
                }
            default:
                {
                    break;
                }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
        {
            Action.SetActive(true);
            
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            
        }

        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.tag == "Form")
        {
            Action.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            Action.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.activeInHierarchy == false)
            {
                Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                
                Cursor.lockState = CursorLockMode.Locked;
                Menu.SetActive(false);
            }
        }
        
    }

    private void FixedUpdate()
    {
       
        if (ButtonsActivatedNumber == 3)
        {
            if (Second == true && Third == true && Five == true)
            {
                Debug.Log("Win");
                ButtonsActivatedNumber = 0;
                animator.Play("New Animation");
            }
            else
            {
                Debug.Log("Nope");
                ButtonsActivatedNumber = 0;
                StartCoroutine(False());
            }
            First = false;
            Second = false;
            Third = false;
            Four = false;
            Five = false;
            Six = false;
            Seven = false;
           
        }
        else if ( ButtonsActivatedNumber > 3 )
        {
            Debug.Log("Nope");
                ButtonsActivatedNumber = 0;
                StartCoroutine(False());
            First = false;
            Second = false;
            Third = false;
            Four = false;
            Five = false;
            Six = false;
            Seven = false;
        }
      
    }

    public  void Exit()
    {
        Application.Quit();
    }

    public IEnumerator False()
    {
        Image.SetActive(true);
        foreach (var V in cubes)
        {
            V.gameObject.GetComponent<Renderer>().material = mat1;
        }
        yield return new WaitForSeconds(1f);
        Image.SetActive(false);
       
        StopCoroutine(False());
    }
}
