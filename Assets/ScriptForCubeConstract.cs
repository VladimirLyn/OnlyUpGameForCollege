using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptForCubeConstract : MonoBehaviour
{
    public bool First = false;
    public bool Second = false;
    public bool Third = false;
    public bool Four = false;
    public bool Five = false;
    public int ButtonsActivatedNumber = 0;
    public int HP = 3;
    public GameObject Cube;
    Animator animator;
    bool win = false;   
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
                        Five = true;
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

    private void FixedUpdate()
    {
        if (win == true)
        {
            HP = 100;
        }
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
                HP--;
                ButtonsActivatedNumber = 0;
            }
            First = false;
            Second = false;
            Third = false;
            Four = false;
            Five = false;
        }
        else if ( ButtonsActivatedNumber > 3 )
        {
            HP--;
            ButtonsActivatedNumber = 0;
            First = false;
            Second = false;
            Third = false;
            Four = false;
            Five = false;
        }
       

        if ( HP == 0 )
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
}
