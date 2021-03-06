﻿/*
 * Copyright (c) 2009, Gregory Hendrickson (LordGregGreg Back)
 *All rights reserved.
 *
 *Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 *
    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
    * Neither the name of the  Gregory Hendrickson nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

 *THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
//using ManyMonkeysEncryptionUtils;
using ManyMonkeys.Cryptography;
using System.Drawing;
using System.Net;
using OpenMetaverse;
using OpenMetaverse.Packets;
using GridProxy;
using System.Threading;
using System.Windows.Forms;

namespace PubCombN
{
    public class ShadowPlugin:GTabPlug
    {
        public void LoadNow()
        {
            tabInfo t = getInfo();
            plugin.tabform.addATab(t.f, t.s);
        }
        public tabInfo getInfo()
        {
            form.readData();
            return new tabInfo(form, "Encryption");
            
        }
    
        private ProxyFrame frame;
        private Twofish fish;
        private System.IO.MemoryStream ms;
        private Proxy proxy;
        public static bool Enabled = false;
        //private Thread formthread;
        private ShadowForm1 form;
        private PubComb plugin;
        public string indicator, brand, trigger;


        public ShadowPlugin(PubComb plug)
        {
            plugin = plug;
            fish = new Twofish();
            fish.Mode = CipherMode.ECB;
            ms = new System.IO.MemoryStream();

            //formthread = new Thread(new ThreadStart(delegate()
            //{
                form = new ShadowForm1(this);
              //  Application.Run(form);
            //}));
            //formthread.SetApartmentState(ApartmentState.STA);
            //formthread.Start();


            this.frame = plugin.frame;
            this.proxy = frame.proxy;
            this.proxy.AddDelegate(PacketType.ScriptDialogReply, Direction.Outgoing, new PacketDelegate(OutDialogFromViewer));
            this.proxy.AddDelegate(PacketType.ChatFromViewer, Direction.Outgoing, new PacketDelegate(OutChatFromViewerHandler));
            this.proxy.AddDelegate(PacketType.ImprovedInstantMessage, Direction.Incoming, new PacketDelegate(RecivedIM));
            this.proxy.AddDelegate(PacketType.ImprovedInstantMessage, Direction.Outgoing, new PacketDelegate(SendingIM));
            this.proxy.AddDelegate(PacketType.ChatFromSimulator, Direction.Incoming, new PacketDelegate(InChatFromServerHandler));

        }
        
        private Packet OutDialogFromViewer(Packet packet, IPEndPoint sim)
        {
            ScriptDialogReplyPacket DialogFromViewer = (ScriptDialogReplyPacket)packet;
            string message = Utils.BytesToString(DialogFromViewer.Data.ButtonLabel).Trim().ToLower();
            if (message.Contains("s-"))
            {
                if(message.ToLower().Contains("on"))
                {
                    Enabled=true;
                    
                    frame.SendUserAlert("Encryption Enabled");
                }
                else if (message.ToLower().Contains("off"))
                {
                    Enabled = false;

                    frame.SendUserAlert("Encryption Disabled");
                }
                else if (message.ToLower().Contains("help"))
                {
                    frame.SayToUser("Thanks for using LordGregGreg's TwoFish Encryption for SecondLife"+
                    "\nTo use, you must enable it by click on the checkbox, or by saying \""+this.brand+"-on\"\n"+
                    "While enabled, all chat you send will be encrypted with the key in the box named \"Enter your key here\"\n"+
                    "For your chat to be decrypted correctly, both chats must have the same key, keep this secret!\n"+
                    "To set the key, either use the gui, or say \""+this.brand+"-key [your key]\" either in chat or IM\n"+
                    "If you wish to send a message not encrypted (while enabled) simple preceede your message with a backward slash \"\\\"\n"+
                    "To dissable, either use the checkbox, or say \""+this.brand+"-off\". The foreward slash will now encypt messages");
                }
                else if (message.ToLower().Contains("about"))
                {
                    frame.SayToUser("This program was made by LordGregGreg for the purpose of allowing\n" +
                              "Secure communications in an insecure world.  Messages sent with\n" +
                              "This plugin are encrypted BEFORE they are sent from your computer\n" +
                              "And decrypted AFTER the client computer recives them, (and before\n" +
                              "the client displays them).  This makes it impossible for chat\n" +
                              "interception on any level.");
                    frame.SayToUser("Special Thanks to \"Philip Linden\" (yeah, thats not his actual sl name)\n" +
                        "and the OpenMetaverse project, and all it's contributors.\n" +
                        "Also special thanks to ManyMonkeys for coding the TwoFish  and also the makers of TwoFish!");
                    
                }

                form.setBox(Enabled);
                return null;
            }
            return packet;
        }
        private Packet RecivedIM(Packet packet, IPEndPoint sim)
        {
            if (packet.Header.Resent) return packet;
            ImprovedInstantMessagePacket im = (ImprovedInstantMessagePacket)packet;
            
            if (true)
            {
                //Console.WriteLine(im.ToString());
                if (im.MessageBlock.Dialog == (byte)0)
                {
                    string message = Utils.BytesToString(im.MessageBlock.Message);
                    if (message.ToLower().Contains("typing"))
                    {
                        //ignoe
                    }
                    else if (message.ToLower().Contains("user not online"))
                    {
                    }
                    else if (im.AgentData.AgentID == frame.AgentID || im.AgentData.AgentID == UUID.Zero)
                    {
                        //ignore
                    }
                    else if (message.Length > 0)
                    {
                        if (message.StartsWith(this.brand))
                        {
                            form.log("we got a IM that needs decryption :" + message,Color.Orange);
                            im.MessageBlock.Message = Utils.StringToBytes(shadow_decrypt(message.Substring(this.brand.Length)));
                        }
                        

                    }
                }
            }
            return im;
        }
        private Packet SendingIM(Packet packet, IPEndPoint sim)
        {
            ImprovedInstantMessagePacket im = (ImprovedInstantMessagePacket)packet;
            string message = Utils.BytesToString(im.MessageBlock.Message);
            if (handeledViewerOutput(message) == "die")
            {
                return null;
            }
            if (Enabled)
            {
                if (!message.StartsWith(this.trigger))
                {
                    if (!message.ToLower().Contains("typing") && message.Length > 1)
                    {
                        form.log("We were guna send the IM with :" + message, Color.OrangeRed);
                        im.MessageBlock.Message = Utils.StringToBytes(this.brand+"" + shadow_encrypt(Utils.BytesToString(im.MessageBlock.Message)));
                    }
                }
                else
                {
                    im.MessageBlock.Message = Utils.StringToBytes(message.Substring(this.trigger.Length));
                }
            }
            else if (message.StartsWith(this.trigger))
            {
                message = message.Substring(this.trigger.Length);
                if (!message.ToLower().Contains("typing") && message.Length > 1)
                {
                    form.log("we were guna send the IM with :" + message, Color.OrangeRed);
                    im.MessageBlock.Message = Utils.StringToBytes(this.brand+"" + shadow_encrypt(Utils.BytesToString(im.MessageBlock.Message)));
                }
            }
            return im;
        }
        public string shadow_encrypt(string plainText)
        {
            fish = new Twofish();
            fish.Mode = CipherMode.ECB;
            ms = new System.IO.MemoryStream();
            //form.log("we were guna send the IM with " + plainText);
            byte [] plainBytes = Utils.StringToBytes(plainText);
            ICryptoTransform encode = new ToBase64Transform();
            ICryptoTransform encrypt = fish.CreateEncryptor(form.getKey(),plainBytes);
            CryptoStream cryptostream = new CryptoStream(new CryptoStream(ms,encode,CryptoStreamMode.Write),encrypt,CryptoStreamMode.Write);
            cryptostream.Write(plainBytes,0,plainBytes.Length);
			cryptostream.Close();
            byte[] bytOut = ms.ToArray();
            form.log("We encrypted "+plainText+" to "+Utils.BytesToString(bytOut),Color.DarkRed);
            return Utils.BytesToString(bytOut);
        }
        public string shadow_decrypt(string encyptedText)
        {
            fish = new Twofish();
            fish.Mode = CipherMode.ECB;
            ms = new System.IO.MemoryStream();

            //form.log("we were sent the IM with " + encyptedText);
            byte[] encyptedBytes = Utils.StringToBytes(encyptedText);

            ICryptoTransform decode = new FromBase64Transform();

            //create DES Decryptor from our des instance
            ICryptoTransform decrypt = fish.CreateDecryptor(form.getKey(), encyptedBytes);
            System.IO.MemoryStream msD = new System.IO.MemoryStream();
            CryptoStream cryptostreamDecode = new CryptoStream(new CryptoStream(msD,decrypt,CryptoStreamMode.Write),decode,CryptoStreamMode.Write);
            cryptostreamDecode.Write(encyptedBytes, 0, encyptedBytes.Length);
            cryptostreamDecode.Close();
            byte[] bytOutD = msD.ToArray(); // we should now have our plain text back	
            form.log("We decrypted "+encyptedText+" to " + Utils.BytesToString(bytOutD),Color.Red);
            return ""+this.indicator+""+Utils.BytesToString(bytOutD);
        }
        public string handeledViewerOutput(string mssage)
        {

            if (mssage.ToLower().Contains(this.brand.ToLower()+"-on"))
            {
                Enabled = true;
                form.setBox(Enabled);

                frame.SendUserAlert("Encryption Enabled");
                return "die";
            }
            else if (mssage.ToLower().Contains(this.brand.ToLower()+"-off"))
            {
                Enabled = false;

                frame.SendUserAlert("Encryption Disabled");
                form.setBox(Enabled);
                return "die";
            }
            else if (mssage.ToLower().Contains(this.brand.ToLower()+"-key"))
            {
                int offset = this.brand.Length + 4;
                form.setKey(mssage.Substring(mssage.ToLower().IndexOf(this.brand.ToLower()+"-key")+offset).Trim());
                frame.SendUserAlert("Key now set to " + mssage.Substring(mssage.ToLower().IndexOf(this.brand.ToLower()+"-key") + offset).Trim());
                return "die";
            }
            else if (mssage.ToLower().Contains(this.brand.ToLower()+"-"))
            {
                frame.SendUserDialog(this.brand+"", "Encryption", "Messenger", "What do you want me to do?", new string[] { "S-ON", "S-OFF", "S-HELP", "S-ABOUT" });
                return "die";
            }

            return "go";
        }
        private Packet OutChatFromViewerHandler(Packet packet, IPEndPoint sim)
        {
            ChatFromViewerPacket ChatFromViewer = (ChatFromViewerPacket)packet;
            string message = Utils.BytesToString(ChatFromViewer.ChatData.Message);
            if (handeledViewerOutput(message) == "die")
            {
                return null;
            }
            else if (Enabled)
            {
                if (!message.ToLower().StartsWith(this.trigger))
                {
                    if (!message.ToLower().Contains("typing"))
                    {
                        if (message.Trim().Length > 0)
                        {
                            form.log("We guna send a chat of " + message, Color.Yellow);
                            ChatFromViewer.ChatData.Message = Utils.StringToBytes(this.brand+"" + shadow_encrypt(message));

                        }

                    }
                }
                else
                {
                    ChatFromViewer.ChatData.Message = Utils.StringToBytes(message.Substring(this.trigger.Length));
                }
            }
            else if(message.ToLower().StartsWith(this.trigger))
            {
                message = message.Substring(this.trigger.Length);
                if (!message.ToLower().Contains("typing"))
                {
                    if (message.Trim().Length > 0)
                    {
                        form.log("We guna send a chat of " + message, Color.Yellow);
                        ChatFromViewer.ChatData.Message = Utils.StringToBytes(this.brand+"" + shadow_encrypt(message));

                    }

                }
            }
            return packet;

        }
        private Packet InChatFromServerHandler(Packet packet, IPEndPoint sim)
        {
            ChatFromSimulatorPacket chat = (ChatFromSimulatorPacket)packet;
            //if (chat.ChatData.OwnerID != this.frame.AgentID)
            //{
                string chatMsg = Utils.BytesToString(chat.ChatData.Message);
                //Console.WriteLine(chatMsg);
                if (chatMsg.StartsWith(this.brand))
                {
                    form.log("We got a chat with " + chatMsg, Color.GreenYellow);
                    chat.ChatData.Message = Utils.StringToBytes(shadow_decrypt(chatMsg.Substring(this.brand.Length)));
                }
            //}
            return chat;
        }
        public void setEnabled(bool en)
        {
            Enabled = en;
            if (Enabled)
            {
                frame.SendUserAlert("Encryption Enabled");
            }
            else
            {
                frame.SendUserAlert("Encryption Disabled");
            }
        }

    }
}