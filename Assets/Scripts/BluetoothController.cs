﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechTweaking.Bluetooth;

public class BluetoothController : MonoBehaviour
{
    private BluetoothDevice device;

    private static byte[] currentMessage;

    public static void SetMessage(byte[] message)
    {
        currentMessage = message;
    }

    public static byte[] GetMessage()
    {
        return currentMessage;
    }

    void Awake()
    {
        Debug.Log("start controller");
        BluetoothAdapter.enableBluetooth();//Force Enabling Bluetooth

        device = new BluetoothDevice();

        /*
		 * We need to identefy the device either by its MAC Adress or Name (NOT BOTH! it will use only one of them to identefy your device).
		 */
        device.Name = "HC-05";
        //device.MacAddress = "XX:XX:XX:XX:XX:XX";
        device.MacAddress = "B3:3B:18:05:98:92";



        /*
		 * 10 equals the char '\n' which is a "new Line" in Ascci representation, 
		 * so the read() method will retun a packet that was ended by the byte 10. simply read() will read lines.
		 */
        device.setEndByte(10);


        /*
		 * The ManageConnection Coroutine will start when the device is ready for reading.
		 */
        device.ReadingCoroutine = ManageConnection;


    }

    IEnumerator ManageConnection(BluetoothDevice device)
    {
        while (device.IsConnected && device.IsReading)
        {
            //byte[] message = { 130 };
            if (currentMessage != null)
            {
                Debug.Log("Device send");
                device.send(currentMessage);
            }
            //polll all available packets
            BtPackets packets = device.readAllPackets();

            if (packets != null)
            {

                /*
				 * parse packets, packets are ordered by indecies (0,1,2,3 ... N),
				 * where Nth packet is the latest packet and 0th is the oldest/first arrived packet.
				 * 
				 * Since this while loop is looping one time per frame, we only need the Nth(the latest potentiometer/joystick position in this frame).
				 * 
				 */
                int N = packets.Count - 1;
                //packets.Buffer contains all the needed packets plus a header of meta data (indecies and sizes) 
                //To get a packet we need the INDEX and SIZE of that packet.
                int indx = packets.get_packet_offset_index(N);
                int size = packets.get_packet_size(N);

                if (size == 4)
                {
                    // packets.Buffer[indx] equals lowByte(x1) and packets.Buffer[indx+1] equals highByte(x2)
                    int val1 = (packets.Buffer[indx + 1] << 8) | packets.Buffer[indx];
                    //Shift back 3 bits, because there was << 3 in Arduino
                    val1 = val1 >> 3;
                    int val2 = (packets.Buffer[indx + 3] << 8) | packets.Buffer[indx + 2];
                    //Shift back 3 bits, because there was << 3 in Arduino
                    val2 = val2 >> 3;

                    //#########Converting val1, val2 into something similar to Input.GetAxis (Which is from -1 to 1)#########
                    //since any val is from 0 to 1023
                    float Axis1 = ((float)val1 / 1023f) * 2f - 1f;
                    float Axis2 = ((float)val2 / 1023f) * 2f - 1f;

                    /*
					 * 
					 * Now Axis1 or Axis2  value will be in the range -1...1. Similar to Input.GetAxis
					 * Check out :
					 * 
					 * https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
					 * 
					 * https://unity3d.com/learn/tutorials/topics/scripting/getaxis
					 */

                }


            }

            yield return null;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMessage != null)
        {
            //Debug.Log("Device send");
            device.send(currentMessage);
        }
    }
}
