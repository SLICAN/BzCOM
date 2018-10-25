namespace ChatTest
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class XCTIPSMS
    {
        private XCTIPSMSRegister_REQ[] register_REQField;

        private XCTIPSMSUnregister_REQ[] unregister_REQField;

        private XCTIPSMSSend_REQ[] send_REQField;

        private XCTIPSMSReceive_EV[] receive_EVField;

        private XCTIPSMSAnswer[] answerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Register_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSMSRegister_REQ[] Register_REQ { get => register_REQField; set => register_REQField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Unregister_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSMSUnregister_REQ[] Unregister_REQ { get => unregister_REQField; set => unregister_REQField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Send_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSMSSend_REQ[] Send_REQ { get => send_REQField; set => send_REQField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Receive_EV", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSMSReceive_EV[] Receive_EV { get => receive_EVField; set => receive_EVField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Answer", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public XCTIPSMSAnswer[] Answer { get => answerField; set => answerField = value; }
        
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class XCTIPSMSRegister_REQ
    {
        private string cIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CId { get => cIdField; set => cIdField = value; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class XCTIPSMSUnregister_REQ
    {
        private string cIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CId { get => cIdField; set => cIdField = value; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class XCTIPSMSReceive_EV
    {
        private string recvTimeField;

        private string numberField;

        private string typeField;

        private string textField;

        private string userDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RecvTime", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string RecvTime { get => recvTimeField; set => recvTimeField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Number", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Number { get => numberField; set => numberField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Type", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type { get => typeField; set => typeField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Text", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Text { get => textField; set => textField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UserData", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UserData { get => userDataField; set => userDataField = value; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class XCTIPSMSSend_REQ
    {
        private string cIdField;

        private string sMSIdField;

        private string numberField;

        private string textField;

        private string typeField;

        private string dontBufferField;

        private string userDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CId { get => cIdField; set => cIdField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SMSId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SMSId { get => sMSIdField; set => sMSIdField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Number", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Number { get => numberField; set => numberField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Text", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Text { get => textField; set => textField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DontBuffer", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DontBuffer { get => dontBufferField; set => dontBufferField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UserData", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UserData { get => userDataField; set => userDataField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Type", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type { get => typeField; set => typeField = value; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class XCTIPSMSAnswer
    {
        private string cIdField;

        private string errorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CId { get => cIdField; set => cIdField = value; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Error", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Error { get => errorField; set => errorField = value; }
    }

}