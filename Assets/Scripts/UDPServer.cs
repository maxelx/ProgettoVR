using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPServer : MonoBehaviour
{
    // Start is called before the first frame update
    private const int listenPort = 5500;
    UdpClient listener = new UdpClient(listenPort);
    static IPHostEntry host = Dns.Resolve(Dns.GetHostName());
    static IPAddress ip = host.AddressList[0];
    IPEndPoint groupEP = new IPEndPoint(ip, listenPort);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//c'è un interupt 
    {
        Console.WriteLine("Waiting for broadcast");
        byte[] bytes = listener.Receive(ref groupEP);

        Console.WriteLine($"Received broadcast from {groupEP} :");
        Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
        listener.Close();
    }
}
