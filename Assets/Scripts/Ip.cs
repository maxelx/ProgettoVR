using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Object = System.Object;


public class Ip : MonoBehaviour
{
    public TextMesh tm;
    public TextMesh piedeLXD;
    public TextMesh piedeLYD;
    public TextMesh piedeRXD;
    public TextMesh piedeRYD;

    public GameObject piedeL;
    public GameObject piedeR;

    private const int listenPort = 5500;

    private String messaggio = "In attesa di messaggio";
    private String piedeLX = "";
    private String piedeLY = "";
    private String piedeRX = "";
    private String piedeRY = "";

    private String angleR = "";
    private String angleL = "";
    
    UdpClient udp;
    IPEndPoint _groupEP;

    private void Start()
    {
        //tm.text = GetLocalIPv4();
        udp = new UdpClient(listenPort);
        _groupEP = new IPEndPoint(IPAddress.Any, listenPort);
        
        Thread t = new Thread(new ThreadStart(ThreadProc));
        t.Start();
    }
    private void Update()
    {
        
        /*
         Debug values
         
        piedeLXD.text = piedeLX;
        piedeLYD.text = piedeLY;
        piedeRXD.text = piedeRX;
        piedeRYD.text = piedeRY;*/
        float pdX = scale(0, 1, 1,0 , float.Parse(piedeLX, System.Globalization.CultureInfo.InvariantCulture));
        float pdY = scale(0, 1, 1,0 , float.Parse(piedeLY, System.Globalization.CultureInfo.InvariantCulture));
        
        float psX = scale(0, 1, 1,0 , float.Parse(piedeRX, System.Globalization.CultureInfo.InvariantCulture));
        float psY = scale(0, 1, 1, 0, float.Parse(piedeRY, System.Globalization.CultureInfo.InvariantCulture));
        
        float pdR = float.Parse(angleL, System.Globalization.CultureInfo.InvariantCulture);
        float psR = float.Parse(angleR, System.Globalization.CultureInfo.InvariantCulture);
        pdR = scale(0, 1, 1,0 , pdR);
        psR = scale(0, 1, 1, 0, psR);

        piedeR.transform.position =  new Vector3((float)(pdX * 2.2 - 1), (float)(pdY + 0.2) , (float)0.692);
        piedeL.transform.position =  new Vector3((float)(psX * 2.2 - 1), (float)(psY + 0.2) , (float)0.692);
        
        piedeR.transform.rotation = Quaternion.Euler(0, pdR -180, 0);
        piedeL.transform.rotation = Quaternion.Euler(0, psR -180, 0);
    }
    
    void ThreadProc() {
        while (true) {
            var recvBuffer = udp.Receive(ref _groupEP);
            var mex  = System.Text.Encoding.UTF8.GetString(recvBuffer);
            messaggio = mex;
            piedeLX = mex.Split(' ')[0];
            piedeLY = mex.Split(' ')[1];
            piedeRX = mex.Split(' ')[2];
            piedeRY = mex.Split(' ')[3];

            angleL = mex.Split(' ')[4];
            angleR = mex.Split(' ')[5];


        }
    }

    //funzione di scala lineare
    public float scale(float min1, float max1, float min2, float max2, float val)
    {
        var range1 = max1 - min1;
        var range2 = max2 - min2;
        return  val*range2/range1 + min2;
    } 
    
    //debug class, presenta l'ip locale del device
    /*public string GetLocalIPv4()
    {
        return Dns.GetHostEntry(Dns.GetHostName())
            .AddressList.First(
                f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            .ToString();
    }*/

}