using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using UnityEngine.UI;
namespace Out
{
    public static class playerProfile
    {
        
        static public List<Ship> ships;
        static public int numberAct;
        static public int playerMoney=1000;
        static public bool ready = false;
        static playerProfile()
        {
            
            ships = new List<Ship>();
             
            PlayFabSettings.TitleId = "D7BA";
            //#if UNITY_ANDROID   
            //            Debug.Log("ANDROID");

            //            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            //            AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject>("currentActivity");
            //            AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
            //            AndroidJavaClass secure = new AndroidJavaClass("android.provider.Settings$Secure");
            //            string android_id = secure.CallStatic<string>("getString", contentResolver, "android_id");

            //            var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = android_id, CreateAccount=true};
            //            PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginSuccess, OnLoginFailure);
            //#endif
#if UNITY_EDITOR
       
            var request = new LoginWithCustomIDRequest { CustomId = "GettingStar213tedG123uide1", CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
          
#endif
           
        }

        static private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Congratulations, you made your first successful API call!");
            GetPlayerShipPlayFab();
           
        }

        static private void OnLoginFailure(PlayFabError error)
        {
            
            Debug.LogWarning("Something went wrong with your first API call.  :(");
            Debug.LogError("Here's some debug information:");
            Debug.LogError(error.GenerateErrorReport());
        }


        static private void getSomeShipFromServer()
        {
            ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest()
            {
                FunctionName = "getMeSomeShip", // Arbitrary function name (must exist in your uploaded cloud.js file)
                GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
            };
            PlayFabClientAPI.ExecuteCloudScript(request, OnGetSomeShip, OnErrorShared);

        }

        static private  void OnGetSomeShip(ExecuteCloudScriptResult result)
        {
            string ship = JsonWrapper.SerializeObject(result.FunctionResult);
            Debug.Log(ship);
        }

        static private void OnErrorShared(PlayFabError error)
        {
            Debug.Log("еррор");
        }

        static void SavePlayerProfilePlayFab(string jsonShip)
        {
            UpdateUserDataRequest request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>(){
      {"ship", jsonShip}, {"coin" , playerMoney.ToString() }

    }
            };

            PlayFabClientAPI.UpdateUserData(request, (result) =>
            {
                Debug.Log("Successfully updated user data");
            }, (error) =>
            {
                Debug.Log("Got error setting user data Ancestor to Arthur");
                Debug.Log(error.ErrorDetails);
            });
        }
        static void GetPlayerShipPlayFab()
        {
            //List<string> key = new List<string>(1);
            //key.Add("ship");
            GetUserDataRequest request = new GetUserDataRequest()
            {
                Keys = null 
            };

            PlayFabClientAPI.GetUserData(request, (result) => {
                Debug.Log("Got user data:");
                if ((result.Data == null) || (result.Data.Count == 0))
                {
                    Debug.Log("No user data available");
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        Debug.Log(item.Key+" "+  item.Value.Value);
                        if (item.Key == "coin")
                        {
                            playerMoney  = int.Parse(item.Value.Value);
                        }
                        if (item.Key == "ship")
                        {
                            string ship = item.Value.Value;
                            ships.Add(JsonUtility.FromJson<Ship>(ship));
                        }
                     
                    }
                }
            }, (error) => {
                Debug.Log("Got error retrieving user data:");
                Debug.Log(error.ErrorMessage);
            });
            ready = true;
        }

       

        static public void setActiveShip(int _n)
        {
            numberAct = _n;
        }
     
        static public void saveActiveShip(Ship _ship)
        {
            string s= JsonUtility.ToJson(ships[numberAct]);
           
            ships[numberAct] = _ship;
            SavePlayerProfilePlayFab(s);

        }
        static public Ship getActiveShip()
        {
            while (ships.Count != 3)
            {
                ships.Add(new Ship());
            }

            return ships[numberAct];
        }

    }
}