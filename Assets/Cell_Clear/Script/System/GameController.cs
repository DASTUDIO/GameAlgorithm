using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{
    public class GameController : MonoBehaviour
    {

        public static Resource getResource()
        {
            return Resource.getResource();
        }
        
        public static void StartServer(string ip, int port)
        {
            //GameObject.FindGameObjectWithTag("Server").GetComponent<Server>().startServerService(ip, port);
        }
        public static void connectServer(string ip, int port)
        {
            //GameObject.FindGameObjectWithTag("Client").GetComponent<Client>().doConnectServer(ip, port);
        }
        
    }
}