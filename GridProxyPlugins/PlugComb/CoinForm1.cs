﻿/*
 * Copyright (c) 2009,  Day Oh
 *All rights reserved.
 *
 *Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 *
    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
    * Neither the name of the  Day Oh nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

 *THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace PubCombN
{
    public partial class CoinForm1 : Form
    {
        private coin coin;

        public CoinForm1(coin coin)
        {
            this.coin = coin;
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CorrectImage();
        }

        private void CoinButton_Click_1(object sender, EventArgs e)
        {
            coin.state++;
            if (coin.state >= coin.CoinState.Count)
                coin.state = coin.CoinState.Heads;
            CorrectImage();
            if (coin.appearance != null)
                coin.frame.proxy.InjectPacket(coin.coinage(coin.appearance, new System.Net.IPEndPoint(0, 0)), GridProxy.Direction.Outgoing);

            if (coin.state == coin.CoinState.Lols)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }

        public void CorrectImage()
        {
            if (coin.state == coin.CoinState.Heads)
            {
                CoinButton.BackgroundImage = Properties.Resources.coin_heads;
            }
            else if (coin.state == coin.CoinState.Tails)
            {
                CoinButton.BackgroundImage = Properties.Resources.coin_tails;
            }
            else
            {
                CoinButton.BackgroundImage = Properties.Resources.LOST;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (coin.appearance != null)
                coin.frame.proxy.InjectPacket(coin.coinage(coin.appearance, new System.Net.IPEndPoint(0, 0)), GridProxy.Direction.Outgoing);
        }
    }
}
