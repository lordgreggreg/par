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
    
    
    public partial class TabItemGTK {
        
        private Gtk.UIManager UIManager;
        
        private Gtk.VBox vbox6;
        
        private Gtk.Notebook nbTabs;
        
        private Gtk.HBox hbox4;
        
        private Gtk.Image parLogo;
        
        private Gtk.Label lblCredit;
        
        private Gtk.Label lblAbout;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget PubComb.TabItemGTK
            this.UIManager = new Gtk.UIManager();
            Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
            this.UIManager.InsertActionGroup(w1, 0);
            this.AddAccelGroup(this.UIManager.AccelGroup);
            this.Name = "PubComb.TabItemGTK";
            this.Title = Mono.Unix.Catalog.GetString("PubComb Plugin Collection (for GTK)  - Protocol Awareness & Research");
            this.Icon = Gdk.Pixbuf.LoadFromResource("PubComb.partiny");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child PubComb.TabItemGTK.Gtk.Container+ContainerChild
            this.vbox6 = new Gtk.VBox();
            this.vbox6.Name = "vbox6";
            this.vbox6.Spacing = 6;
            // Container child vbox6.Gtk.Box+BoxChild
            this.nbTabs = new Gtk.Notebook();
            this.nbTabs.CanFocus = true;
            this.nbTabs.Name = "nbTabs";
            this.nbTabs.CurrentPage = 0;
            this.nbTabs.Scrollable = true;
            // Container child nbTabs.Gtk.Notebook+NotebookChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.parLogo = new Gtk.Image();
            this.parLogo.Name = "parLogo";
            this.parLogo.Pixbuf = Gdk.Pixbuf.LoadFromResource("PubComb.partiny");
            this.hbox4.Add(this.parLogo);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox4[this.parLogo]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.lblCredit = new Gtk.Label();
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.LabelProp = Mono.Unix.Catalog.GetString("<b>PAR - PubComb Plugin DLL (GTK GUI)</b>\n\nBy LordGregGreg Back, Day Oh, and Fred Rookstown.\n\nComplete GUI facelift by N3X15 (Fred Rookstown)");
            this.lblCredit.UseMarkup = true;
            this.hbox4.Add(this.lblCredit);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox4[this.lblCredit]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.nbTabs.Add(this.hbox4);
            // Notebook tab
            this.lblAbout = new Gtk.Label();
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.LabelProp = Mono.Unix.Catalog.GetString("About PAR");
            this.nbTabs.SetTabLabel(this.hbox4, this.lblAbout);
            this.lblAbout.ShowAll();
            this.vbox6.Add(this.nbTabs);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox6[this.nbTabs]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            this.Add(this.vbox6);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 657;
            this.DefaultHeight = 350;
            this.Show();
        }
    }
}
