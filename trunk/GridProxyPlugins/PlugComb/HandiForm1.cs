﻿/*
 * Copyright (c) 2009,  Gregory Hendrickson (LordGregGreg Back) & Day Oh
 * 
 *All rights reserved
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PubComb
{
    public partial class HandiForm1 : Form
    {
        private HandicapPlugin handiPlug;
        private string brand = "Handicap";

        public HandiForm1(HandicapPlugin shad)
        {
            InitializeComponent();
            //webBrowser1.Navigate("about:blank");

            this.handiPlug = shad;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
        }
        public void setBox(bool a)
        {
            this.checkBox1enabled.Checked = a;
        }
        public bool getcheck()
        {
            return checkBox1enabled.Checked;
        }

        private void checkBox1enabled_CheckedChanged(object sender, EventArgs e)
        {
            saveData();
        }
        public void addDebugInfo(string d)
        {
            textBox1.Text += "\n" + d;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readData();
        }
        public void readData()
        {
            bool ena = true;
            if (File.Exists(this.brand + ".settings"))
            {
                StreamReader re = File.OpenText(this.brand + ".settings");
                ena  = bool.Parse(re.ReadLine().Trim());
                re.Close();
            }
            checkBox1enabled.Checked = ena;

        }

        private void saveData()
        {
            TextWriter tw = new StreamWriter(this.brand + ".settings");
            tw.WriteLine(checkBox1enabled.Checked);
            tw.Close();
        }

    }
}