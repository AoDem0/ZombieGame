using UnityEngine;

public class upgradeInteract : MonoBehaviour
{
    [SerializeField] private Camera FPScamera;
    [SerializeField] private float range = 10f;
    [SerializeField] private LayerMask layerMask;

    private Canvas canvas;

    private bool isInTrigger = false;

    void Update()
    {
        if (isInTrigger)
        {
            RaycastHit hit;
            if (Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, range, layerMask))
            {
                Debug.Log("Raycast trafił: " + hit.collider.name);
                Debug.DrawRay(FPScamera.transform.position, FPScamera.transform.forward * range, Color.red);
                if (canvas != null)
                {
                    canvas.enabled = false;
                }
                canvas = hit.transform.GetComponentInChildren<Canvas>(true);
                if (canvas != null)
                {
                    canvas.enabled = true;
                    Debug.Log("Canvas włączony na: " + hit.transform.name);
                }
                else
                {

                    Debug.Log("Brak Canvas w dzieciach obiektu: " + hit.transform.name);
                }
            }
            else
            {
                if (canvas != null)
                {
                    canvas.enabled = false;
                 }
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Jestes w polu");
        if (collision.gameObject.layer == 9)
        {
            isInTrigger = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("Nie jestes juz w polu");
        if (collision.gameObject.layer == 9)
        {
            isInTrigger = false;
            canvas.enabled = false;
        }
    }
}
