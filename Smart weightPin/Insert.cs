using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userInsertA : MonoBehaviour
{
    string URL = "http://localhost/mydatabase/userInsertA.php";
    public string InputUsername, InputEmail, InputPassword;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddUser(InputUsername, InputEmail, InputPassword);
        }
    }

    public void AddUser(string username, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("addUsername", username); // WWWForm 에대한 AddField 뜻은 AddField("네트워크변수이름", 입력받은값)
        form.AddField("addEmail", email);
        form.AddField("addPassword", password);

        WWW www = new WWW(URL, form);//
    }
}
