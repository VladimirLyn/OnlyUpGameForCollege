using UnityEngine;
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
    public int ButtonsActivatedNumber = 0;
    public int HP = 3;
    public GameObject Cube;
    Animator animator;
    bool win = false;
    public Material mat;
    public Material mat1;
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
                        other.gameObject.GetComponent<Renderer>().material = mat1;
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
                    {other.gameObject.GetComponent<Renderer>().material = mat1;
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
                    { other.gameObject.GetComponent<Renderer>().material = mat1;
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
                    {other.gameObject.GetComponent<Renderer>().material = mat1;
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
                    {other.gameObject.GetComponent<Renderer>().material = mat1;
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
                    {other.gameObject.GetComponent<Renderer>().material = mat1;
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
                        other.gameObject.GetComponent<Renderer>().material = mat1;
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
            ButtonsActivatedNumber = 0;
            First = false;
            Second = false;
            Third = false;
            Four = false;
            Five = false;
        }
      
    }
}
