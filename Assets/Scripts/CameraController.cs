using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    private Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - player.transform.position;
        addPhysicsRaycaster();
    }

    public void addPhysicsRaycaster()
    {
        PhysicsRaycaster raycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (raycaster != null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + camOffset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
