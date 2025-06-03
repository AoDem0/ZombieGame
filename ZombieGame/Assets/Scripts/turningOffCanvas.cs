using UnityEngine;

public class turningOffCanvas : MonoBehaviour
{

    [SerializeField] private Canvas canvas1;
    [SerializeField] private Canvas canvas2;
    [SerializeField] private Canvas canvas3;
    void Start()
    {
        canvas1.enabled = false;
        canvas2.enabled = false;
        canvas3.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
