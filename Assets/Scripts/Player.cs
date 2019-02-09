using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    [SerializeField]
    private float maxHealth = 100f;

    [SyncVar]
    private float currHealth;

    public Texture2D crosshairImage;


    void Awake()
    {
        currHealth = maxHealth;
    }

    void Update()
    {
        if (currHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        if (currHealth != 0f)
        {
            currHealth -= damage;

            Debug.Log(transform.name + " have HP: " + currHealth);
        }
    }

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
        string _currHealth = currHealth.ToString();
        GUI.Label(new Rect(Screen.width / 2, 10, 100, 20), _currHealth);

    }
}