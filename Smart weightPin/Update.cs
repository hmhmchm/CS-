using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userUpdateA : MonoBehaviour
{
    // php 와 연결해주는 URL
    string URL = "http://localhost/mydatabase/userUpdateA.php";
    public string InputUsername, InputEmail, InputPassword, WhereField, WhereCondition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateUser(InputUsername, InputEmail, InputPassword, WhereField, WhereCondition);
        }
    }

    public void UpdateUser(string username, string email, string password, string wF, string wC)
    {
        WWWForm form = new WWWForm();
        form.AddField("editUsername", username);
        form.AddField("editEmail", email);
        form.AddField("editPassword", password);

        form.AddField("whereField", wF);
        form.AddField("whereCondition", wC);

        WWW www = new WWW(URL, form);
    }
}