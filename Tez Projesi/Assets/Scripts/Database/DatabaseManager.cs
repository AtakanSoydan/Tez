//using Firebase.Database;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DatabaseManager : MonoBehaviour
//{
//    public InputField Name;
//    public InputField Gold;
    
//    private string userID;
//    private DatabaseReference dbReference;
//    void Start()
//    {
//        userID = SystemInfo.deviceUniqueIdentifier; 
//        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

//    }

//    private void CreateUser()
//    {
//        User newUser = new User(Name.text, int.Parse(Gold.text));
//        string json = JsonUtility.ToJson(newUser);

//        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
//    }
//}
