using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(CharacterStats))]

public class PlayerController : MonoBehaviour 
{
   
    public Interactable focus;
    public LayerMask movementMask;
    CharacterStats stats;
    
    Camera cam;
    [SerializeField] private PlayerMotor player;
    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        stats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //WALKING TO A POINT

        if (Input.GetMouseButtonDown(0))
        {
            Walk();
        }

        //DASHING TO A POINT

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
        {
            if (stats.currentStamina > 24)
            {
                Dash();
            }
        }

        //STAMINA REGENERATION

        if(stats.currentStamina < stats.maxStamina)
        {
            stats.currentStamina += 5f * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

      
    }
    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        //focus = newFocus;
        newFocus.OnFocused(transform);
        //motor.FollowTarget(newFocus);
    }
    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();
        focus = null; ;
        motor.StopFollowingTarget();
    }

    void Dash()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            motor.DashToPoint(hit.point);

            RemoveFocus();
            stats.currentStamina -= 20;
            
        }
        
    }

    void Walk()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            motor.MoveToPoint(hit.point);

            RemoveFocus();

        }
    }
}
