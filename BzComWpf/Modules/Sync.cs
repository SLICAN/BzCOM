/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSync
{
    private XCTIPSyncSync_REQ[] sync_REQField;

    private XCTIPSyncAnswer[] answerField;

    private XCTIPSyncRecords_ANS[] records_ANSField;

    private XCTIPSyncSendChange_REQ[] sendChange_REQField;

    private XCTIPSyncChange_EV[] change_EVField;

    private XCTIPSyncRecords_EV[] records_EVField;

    private XCTIPSyncAutoChange_REQ[] autoChange_REQField;

    private XCTIPSyncRegister_REQ[] register_REQField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Sync_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncSync_REQ[] Sync_REQ { get => sync_REQField; set => sync_REQField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Answer", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncAnswer[] Answer { get => answerField; set => answerField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Records_ANS", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRecords_ANS[] Records_ANS { get => records_ANSField; set => records_ANSField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendChange_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncSendChange_REQ[] SendChange_REQ { get => sendChange_REQField; set => sendChange_REQField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Change_EV", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncChange_EV[] Change_EV { get => change_EVField; set => change_EVField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AutoChange_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncAutoChange_REQ[] AutoChange_REQ { get => autoChange_REQField; set => autoChange_REQField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Register_REQ", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRegister_REQ[] Register_REQ { get => register_REQField; set => register_REQField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Records_EV", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRecords_EV[] Records_EV { get => records_EVField; set => records_EVField = value; }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRecords_EV
{
    private string idField;

    private XCTIPSyncRecords_ANSRow[] rowField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Id { get => idField; set => idField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Row", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRecords_ANSRow[] Row { get => rowField; set => rowField = value; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRegister_REQ
{
    private string cIdField;

    private string idField;

    private string syncTypeField;

    private string sendOnlineField;

    private string unreadNumField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId { get => cIdField; set => cIdField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Id { get => idField; set => idField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SyncType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SyncType { get => syncTypeField; set => syncTypeField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendOnline", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SendOnline { get => sendOnlineField; set => sendOnlineField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UnreadNum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string UnreadNum { get => unreadNumField; set => unreadNumField = value; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncChange_EV
{
    private string cIdField;

    private string idField;

    private string syncTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId { get => cIdField; set => cIdField = value; }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Id { get => idField; set => idField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SyncType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SyncType { get => syncTypeField; set => syncTypeField = value; }
    
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncAutoChange_REQ
{
    private string cIdField;

    private string syncTypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CId", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId { get => cIdField; set => cIdField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SyncType", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SyncType { get => syncTypeField; set => syncTypeField = value; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncSync_REQ
{
    private string cIdField;

    private string idField;

    private string markerField;

    private string syncTypeField;

    private string limitField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId { get => cIdField; set => cIdField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Id { get => idField; set => idField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Marker { get => markerField; set => markerField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SyncType { get => syncTypeField; set => syncTypeField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Limit { get => limitField; set => limitField = value; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncSendChange_REQ
{
    private string cIdField;

    private string idField;

    private XCTIPSyncRecords_ANSRow[] rowField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId
    {
        get
        {
            return this.cIdField;
        }
        set
        {
            this.cIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Row", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRecords_ANSRow[] Row
    {
        get
        {
            return this.rowField;
        }
        set
        {
            this.rowField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRecords_ANS
{

    private string cIdField;

    private string idField;

    private XCTIPSyncRecords_ANSRow[] rowField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId
    {
        get
        {
            return this.cIdField;
        }
        set
        {
            this.cIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Row", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRecords_ANSRow[] Row
    {
        get
        {
            return this.rowField;
        }
        set
        {
            this.rowField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRecords_ANSRow
{

    private string markerField;

    private string rowTypeField;

    private string syncTypeField;

    private XCTIPSyncRecords_ANSRowGroup[] groupField;

    private XCTIPSyncRecords_ANSRowCause[] causeField;

    private XCTIPSyncRecords_ANSRowContact[] contactField;

    private XCTIPSyncRecords_ANSRowHistoryMsg[] historyMsgField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Marker
    {
        get
        {
            return this.markerField;
        }
        set
        {
            this.markerField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string RowType
    {
        get
        {
            return this.rowTypeField;
        }
        set
        {
            this.rowTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SyncType
    {
        get
        {
            return this.syncTypeField;
        }
        set
        {
            this.syncTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Group", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public XCTIPSyncRecords_ANSRowGroup[] Group
    {
        get
        {
            return this.groupField;
        }
        set
        {
            this.groupField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Cause", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
    public XCTIPSyncRecords_ANSRowCause[] Cause
    {
        get
        {
            return this.causeField;
        }
        set
        {
            this.causeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Contact", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
    public XCTIPSyncRecords_ANSRowContact[] Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HistoryMsg", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
    public XCTIPSyncRecords_ANSRowHistoryMsg[] HistoryMsg { get => historyMsgField; set => historyMsgField = value; }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRecords_ANSRowHistoryMsg
{
    private string mIdField;

    private string dateField;

    private string typeField;

    private string unreadField;

    private string readDateField;

    private string sMSIdField;

    private string numberField;

    private string textField;

    private string uDataField;

    private string statusField;

    private string statusDateField;

    private string reportField;

    private string reportDateField;

    private string typeMsgField;

    private string displayedField;

    private string displayedDateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string MId { get => mIdField; set => mIdField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Date { get => dateField; set => dateField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Type { get => typeField; set => typeField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Unread { get => unreadField; set => unreadField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ReadDate { get => readDateField; set => readDateField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SMSId { get => sMSIdField; set => sMSIdField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Number { get => numberField; set => numberField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Text { get => textField; set => textField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string UData { get => uDataField; set => uDataField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Status { get => statusField; set => statusField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string StatusDate { get => statusDateField; set => statusDateField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Report { get => reportField; set => reportField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ReportDate { get => reportDateField; set => reportDateField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string TypeMsg { get => typeMsgField; set => typeMsgField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Displayed { get => displayedField; set => displayedField = value; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DisplayedDate { get => displayedDateField; set => displayedDateField = value; }
    
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRecords_ANSRowGroup
{

    private string groupIdField;

    private string nameField;

    private string favouriteField;

    private string privateField;

    private string departmentField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GroupId
    {
        get
        {
            return this.groupIdField;
        }
        set
        {
            this.groupIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Favourite
    {
        get
        {
            return this.favouriteField;
        }
        set
        {
            this.favouriteField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Private
    {
        get
        {
            return this.privateField;
        }
        set
        {
            this.privateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Department
    {
        get
        {
            return this.departmentField;
        }
        set
        {
            this.departmentField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncRecords_ANSRowCause
{

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class XCTIPSyncAnswer
{
    private string cIdField;

    private string errorField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CId
    {
        get
        {
            return this.cIdField;
        }
        set
        {
            this.cIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Error
    {
        get
        {
            return this.errorField;
        }
        set
        {
            this.errorField = value;
        }
    }
}
