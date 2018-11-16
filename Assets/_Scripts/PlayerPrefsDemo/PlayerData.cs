using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int StartLevel;
    public float Health;
    public string Name;
    string healthString = "Health";

    void OnEnable()
    {
        StartLevel = PlayerPrefs.GetInt("Start Level", StartLevel);
        Health = PlayerPrefs.GetFloat(healthString, Health);
        Name = PlayerPrefs.GetString("Name", Name);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Health -= 10f;
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            //Health -= 10f;
            PlayerPrefs.DeleteKey(healthString);
        }
    }

    void OnDisable()
    {
        //PlayerPrefs.SetInt("Start Level", StartLevel);
        //PlayerPrefs.SetFloat("Health", Health);
        //PlayerPrefs.SetString("Name", Name);
    }

}
