// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace PubComb {
    
    
    public partial class RadarChatFormGTK {
        
        private Gtk.VBox vbox4;
        
        private Gtk.Label lblTitle;
        
        private Gtk.HSeparator hseparator5;
        
        private Gtk.CheckButton chkEnabled;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Label lblChannel;
        
        private Gtk.SpinButton spinChannel;
        
        private Gtk.Button cmdResetChan;
        
        private Gtk.HBox hbox4;
        
        private Gtk.Label lblDelimiter;
        
        private Gtk.Entry txtDelimiter;
        
        private Gtk.Notebook notebook1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.HBox hbox3;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.NodeView nodRadar;
        
        private Gtk.VButtonBox adminList;
        
        private Gtk.Button btnKick;
        
        private Gtk.Button btnBan;
        
        private Gtk.Button btnEjectnBan;
        
        private Gtk.Button btnTPHome;
        
        private Gtk.Button btnBanThisEstate;
        
        private Gtk.Button btnBanAllEstates;
        
        private Gtk.Button btnFreeze;
        
        private Gtk.Button btnUnfreeze;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Button cmdSend;
        
        private Gtk.Entry txtMessage;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget PubComb.RadarChatFormGTK
            this.Name = "PubComb.RadarChatFormGTK";
            this.Title = Mono.Unix.Catalog.GetString("RadarChat");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child PubComb.RadarChatFormGTK.Gtk.Container+ContainerChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.lblTitle = new Gtk.Label();
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.LabelProp = Mono.Unix.Catalog.GetString("Client-side radar\n\nPlugin by LGG.");
            this.lblTitle.Justify = ((Gtk.Justification)(2));
            this.vbox4.Add(this.lblTitle);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox4[this.lblTitle]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hseparator5 = new Gtk.HSeparator();
            this.hseparator5.Name = "hseparator5";
            this.vbox4.Add(this.hseparator5);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox4[this.hseparator5]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.chkEnabled = new Gtk.CheckButton();
            this.chkEnabled.CanFocus = true;
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Label = Mono.Unix.Catalog.GetString("Enable radar");
            this.chkEnabled.DrawIndicator = true;
            this.chkEnabled.UseUnderline = true;
            this.vbox4.Add(this.chkEnabled);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox4[this.chkEnabled]));
            w3.Position = 2;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.lblChannel = new Gtk.Label();
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.LabelProp = Mono.Unix.Catalog.GetString("Radar channel:");
            this.hbox2.Add(this.lblChannel);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.lblChannel]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.spinChannel = new Gtk.SpinButton(-2147483647, 2147483647, 1);
            this.spinChannel.CanFocus = true;
            this.spinChannel.Name = "spinChannel";
            this.spinChannel.Adjustment.PageIncrement = 10;
            this.spinChannel.ClimbRate = 1;
            this.spinChannel.Numeric = true;
            this.spinChannel.Value = -777777777;
            this.hbox2.Add(this.spinChannel);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.spinChannel]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.cmdResetChan = new Gtk.Button();
            this.cmdResetChan.CanFocus = true;
            this.cmdResetChan.Name = "cmdResetChan";
            this.cmdResetChan.UseUnderline = true;
            this.cmdResetChan.Label = Mono.Unix.Catalog.GetString("Default Channel");
            this.hbox2.Add(this.cmdResetChan);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox2[this.cmdResetChan]));
            w6.Position = 2;
            w6.Expand = false;
            w6.Fill = false;
            this.vbox4.Add(this.hbox2);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox4[this.hbox2]));
            w7.Position = 3;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.lblDelimiter = new Gtk.Label();
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.LabelProp = Mono.Unix.Catalog.GetString("Delimiter:");
            this.hbox4.Add(this.lblDelimiter);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.hbox4[this.lblDelimiter]));
            w8.Position = 0;
            w8.Expand = false;
            w8.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.txtDelimiter = new Gtk.Entry();
            this.txtDelimiter.CanFocus = true;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Text = Mono.Unix.Catalog.GetString(",");
            this.txtDelimiter.IsEditable = true;
            this.txtDelimiter.WidthChars = 5;
            this.txtDelimiter.InvisibleChar = '●';
            this.hbox4.Add(this.txtDelimiter);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox4[this.txtDelimiter]));
            w9.Position = 1;
            this.vbox4.Add(this.hbox4);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox4[this.hbox4]));
            w10.Position = 4;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 0;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.nodRadar = new Gtk.NodeView();
            this.nodRadar.CanFocus = true;
            this.nodRadar.Name = "nodRadar";
            this.nodRadar.Reorderable = true;
            this.GtkScrolledWindow.Add(this.nodRadar);
            this.hbox3.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox3[this.GtkScrolledWindow]));
            w12.Position = 0;
            // Container child hbox3.Gtk.Box+BoxChild
            this.adminList = new Gtk.VButtonBox();
            this.adminList.Name = "adminList";
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnKick = new Gtk.Button();
            this.btnKick.CanFocus = true;
            this.btnKick.Name = "btnKick";
            this.btnKick.UseUnderline = true;
            this.btnKick.Label = Mono.Unix.Catalog.GetString("Eject");
            this.adminList.Add(this.btnKick);
            Gtk.ButtonBox.ButtonBoxChild w13 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnKick]));
            w13.Expand = false;
            w13.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnBan = new Gtk.Button();
            this.btnBan.CanFocus = true;
            this.btnBan.Name = "btnBan";
            this.btnBan.UseUnderline = true;
            this.btnBan.Label = Mono.Unix.Catalog.GetString("Ban");
            this.adminList.Add(this.btnBan);
            Gtk.ButtonBox.ButtonBoxChild w14 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnBan]));
            w14.Position = 1;
            w14.Expand = false;
            w14.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnEjectnBan = new Gtk.Button();
            this.btnEjectnBan.CanFocus = true;
            this.btnEjectnBan.Name = "btnEjectnBan";
            this.btnEjectnBan.UseUnderline = true;
            this.btnEjectnBan.Label = Mono.Unix.Catalog.GetString("Eject & Ban");
            this.adminList.Add(this.btnEjectnBan);
            Gtk.ButtonBox.ButtonBoxChild w15 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnEjectnBan]));
            w15.Position = 2;
            w15.Expand = false;
            w15.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnTPHome = new Gtk.Button();
            this.btnTPHome.CanFocus = true;
            this.btnTPHome.Name = "btnTPHome";
            this.btnTPHome.UseUnderline = true;
            this.btnTPHome.Label = Mono.Unix.Catalog.GetString("TP Home (Kill)");
            this.adminList.Add(this.btnTPHome);
            Gtk.ButtonBox.ButtonBoxChild w16 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnTPHome]));
            w16.Position = 3;
            w16.Expand = false;
            w16.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnBanThisEstate = new Gtk.Button();
            this.btnBanThisEstate.CanFocus = true;
            this.btnBanThisEstate.Name = "btnBanThisEstate";
            this.btnBanThisEstate.UseUnderline = true;
            this.btnBanThisEstate.Label = Mono.Unix.Catalog.GetString("Ban on This Estate");
            this.adminList.Add(this.btnBanThisEstate);
            Gtk.ButtonBox.ButtonBoxChild w17 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnBanThisEstate]));
            w17.Position = 4;
            w17.Expand = false;
            w17.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnBanAllEstates = new Gtk.Button();
            this.btnBanAllEstates.CanFocus = true;
            this.btnBanAllEstates.Name = "btnBanAllEstates";
            this.btnBanAllEstates.UseUnderline = true;
            this.btnBanAllEstates.Label = Mono.Unix.Catalog.GetString("Ban on ALL Estates");
            this.adminList.Add(this.btnBanAllEstates);
            Gtk.ButtonBox.ButtonBoxChild w18 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnBanAllEstates]));
            w18.Position = 5;
            w18.Expand = false;
            w18.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnFreeze = new Gtk.Button();
            this.btnFreeze.CanFocus = true;
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.UseUnderline = true;
            this.btnFreeze.Label = Mono.Unix.Catalog.GetString("Freeze");
            this.adminList.Add(this.btnFreeze);
            Gtk.ButtonBox.ButtonBoxChild w19 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnFreeze]));
            w19.Position = 6;
            w19.Expand = false;
            w19.Fill = false;
            // Container child adminList.Gtk.ButtonBox+ButtonBoxChild
            this.btnUnfreeze = new Gtk.Button();
            this.btnUnfreeze.CanFocus = true;
            this.btnUnfreeze.Name = "btnUnfreeze";
            this.btnUnfreeze.UseUnderline = true;
            this.btnUnfreeze.Label = Mono.Unix.Catalog.GetString("Unfreeze");
            this.adminList.Add(this.btnUnfreeze);
            Gtk.ButtonBox.ButtonBoxChild w20 = ((Gtk.ButtonBox.ButtonBoxChild)(this.adminList[this.btnUnfreeze]));
            w20.Position = 7;
            w20.Expand = false;
            w20.Fill = false;
            this.hbox3.Add(this.adminList);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.hbox3[this.adminList]));
            w21.Position = 1;
            w21.Expand = false;
            w21.Fill = false;
            this.vbox2.Add(this.hbox3);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
            w22.Position = 0;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.cmdSend = new Gtk.Button();
            this.cmdSend.CanFocus = true;
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.UseUnderline = true;
            this.cmdSend.Label = Mono.Unix.Catalog.GetString("Send Message");
            this.hbox1.Add(this.cmdSend);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.hbox1[this.cmdSend]));
            w23.Position = 0;
            w23.Expand = false;
            w23.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.txtMessage = new Gtk.Entry();
            this.txtMessage.CanFocus = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.IsEditable = true;
            this.txtMessage.InvisibleChar = '●';
            this.hbox1.Add(this.txtMessage);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.hbox1[this.txtMessage]));
            w24.Position = 1;
            this.vbox2.Add(this.hbox1);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
            w25.Position = 1;
            w25.Expand = false;
            w25.Fill = false;
            this.notebook1.Add(this.vbox2);
            this.vbox4.Add(this.notebook1);
            Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.vbox4[this.notebook1]));
            w27.Position = 5;
            this.Add(this.vbox4);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 631;
            this.DefaultHeight = 455;
            this.Show();
            this.chkEnabled.Activated += new System.EventHandler(this.OnChkEnableActivated);
            this.spinChannel.Changed += new System.EventHandler(this.OnSpinChannelChanged);
            this.cmdResetChan.Activated += new System.EventHandler(this.OnCmdResetChanActivated);
            this.txtDelimiter.Changed += new System.EventHandler(this.OnTxtDelimiterChanged);
        }
    }
}