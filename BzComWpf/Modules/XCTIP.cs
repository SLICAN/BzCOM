namespace BzCOMWpf
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class XCTIP
    {

        private XCTIPLog[] logItemsField;

        private XCTIPSync[] syncItemsField;

        private XCTIPGSM[] gsmItemsField;

        private XCTIPStatus[] statusItemsField;

        private XCTIPSMS[] sMSItemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Log", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPLog[] LogItems
        {
            get
            {
                return this.logItemsField;
            }
            set
            {
                this.logItemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Sync", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSync[] SyncItems
        {
            get
            {
                return this.syncItemsField;
            }
            set
            {
                this.syncItemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("GSM", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPGSM[] GSMItems
        {
            get
            {
                return this.gsmItemsField;
            }
            set
            {
                this.gsmItemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Status", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPStatus[] StatusItems
        {
            get
            {
                return this.statusItemsField;
            }
            set
            {
                this.statusItemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("SMS", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSMS[] SMSItems { get => sMSItemsField; set => sMSItemsField = value; }
    }


}
