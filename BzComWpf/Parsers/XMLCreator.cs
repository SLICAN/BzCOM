using System;

namespace BzCOMWpf
{
    public class XMLCreator
    {
        /// <summary>
        /// Liczba porządkowa komendy
        /// </summary>
        private static int id = 1;

        /// <summary>
        /// Zrób ramkę wyloguj
        /// </summary>
        /// <returns></returns>
        public string Logout()
        {
            XCTIP packet = new XCTIP();
            XCTIPLog xCTIPLog = new XCTIPLog();
            XCTIPLogLogout logout = new XCTIPLogLogout
            {
                CId = id++.ToString()
            };
            xCTIPLog.Logout = new XCTIPLogLogout[] { logout };
            packet.LogItems = new XCTIPLog[] { xCTIPLog };
            String xml = ServiceXML.GenericSerialize(packet, true);

            return xml;
        }

        /// <summary>
        /// Zrób ramkę zaloguj
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string MakeLog(string login, string pass, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPLog xCTIPLog = new XCTIPLog();
            XCTIPLogMakeLog makeLog = new XCTIPLogMakeLog
            {
                CId = id++.ToString(),
                Login = login,
                Pass = pass
            };
            xCTIPLog.MakeLog = new XCTIPLogMakeLog[] { makeLog };
            packet.LogItems = new XCTIPLog[] { xCTIPLog };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = makeLog.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę aktualizującą status i/lub opis
        /// </summary>
        /// <param name="status"></param>
        /// <param name="info"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string StatusUpdate_REQ(string status, string info, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPStatus xCTIPStatus = new XCTIPStatus();
            XCTIPStatusUpdate_REQ update = new XCTIPStatusUpdate_REQ
            {
                CId = id++.ToString(),
                AppState = status,
                AppInfo = info
            };
            xCTIPStatus.Update_REQ = new XCTIPStatusUpdate_REQ[] { update };
            packet.StatusItems = new XCTIPStatus[] { xCTIPStatus };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = update.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę rejestrującą do modułu Status
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string StatusRegister_REQ(out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPStatus xCTIPStatus = new XCTIPStatus();
            XCTIPStatusRegister_REQ reg = new XCTIPStatusRegister_REQ
            {
                CId = id++.ToString()
            };
            xCTIPStatus.Register_REQ = new XCTIPStatusRegister_REQ[] { reg };
            packet.StatusItems = new XCTIPStatus[] { xCTIPStatus };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = reg.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę z zapytaniem o dane synchronizacyjne książki telefonicznej
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rid"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public string Sync_REQ(string type, out string rid, string limit="10")
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncSync_REQ req = new XCTIPSyncSync_REQ
            {
                CId = id++.ToString(),
                SyncType = type,
                Limit = limit
            };
            xCTIPSync.Sync_REQ = new XCTIPSyncSync_REQ[] { req };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = req.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę z zapytaniem o automatyczne otrzymywanie informacji o zmianach
        /// </summary>
        /// <param name="type"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string SyncAutoChange_REQ(string type, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncAutoChange_REQ req = new XCTIPSyncAutoChange_REQ
            {
                CId = id++.ToString(),
                SyncType = type
            };
            xCTIPSync.AutoChange_REQ = new XCTIPSyncAutoChange_REQ[] { req };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = req.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę rejestrującą do modułu Sync
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string SyncRegister_REQ(out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncRegister_REQ register_REQ = new XCTIPSyncRegister_REQ
            {
                CId = id++.ToString(),
                SyncType = "HistoryMsg",
                SendOnline = ""
            };
            xCTIPSync.Register_REQ = new XCTIPSyncRegister_REQ[] { register_REQ };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = register_REQ.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę z danymi do edycji kontaktu
        /// </summary>
        /// <param name="number"></param>
        /// <param name="comment"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string EditContact(string number, string comment, string name, string id, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSync xCTIPSync = new XCTIPSync();
            XCTIPSyncSendChange_REQ sendChange_REQ = new XCTIPSyncSendChange_REQ();
            XCTIPSyncRecords_ANSRow row = new XCTIPSyncRecords_ANSRow();
            XCTIPSyncRecords_ANSRowContact contact = new XCTIPSyncRecords_ANSRowContact();
            ContactPhone phone = new ContactPhone();
            sendChange_REQ.CId = id;
            sendChange_REQ.Row = new XCTIPSyncRecords_ANSRow[] { row };
            row.RowType = "AddField";
            row.Contact = new XCTIPSyncRecords_ANSRowContact[] { contact };
            //phone.Number = textBox1.Text;
            phone.Number = number;
            //phone.Comment = textBox2.Text;
            phone.Comment = comment;
            phone.PhoneId = "1";
            contact.Phone = new ContactPhone[] { phone };
            //contact.Name = label3.Text;
            contact.Name = name;
            //contact.ContactId = contactId[label3.Text];
            // TODO: fix it
            //contact.ContactId = StaticFields.contactId[id];
            xCTIPSync.SendChange_REQ = new XCTIPSyncSendChange_REQ[] { sendChange_REQ };
            packet.SyncItems = new XCTIPSync[] { xCTIPSync };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = sendChange_REQ.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę rejestrującą do modułu SMS
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string SMSRegister_REQ(out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSMS xCTIPSMS = new XCTIPSMS();
            XCTIPSMSRegister_REQ register_REQ = new XCTIPSMSRegister_REQ
            {
                CId = id++.ToString()
            };
            xCTIPSMS.Register_REQ = new XCTIPSMSRegister_REQ[] { register_REQ };
            packet.SMSItems = new XCTIPSMS[] { xCTIPSMS };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = register_REQ.CId;
            return xml;
        }

        /// <summary>
        /// Zrób ramkę wyrejestrowującą z modułu SMS
        /// </summary>
        /// <returns></returns>
        public string SMSUnregister_REQ()
        {
            XCTIP packet = new XCTIP();
            XCTIPSMS xCTIPSMS = new XCTIPSMS();
            XCTIPSMSUnregister_REQ unregister_REQ = new XCTIPSMSUnregister_REQ
            {
                CId = id++.ToString()
            };
            xCTIPSMS.Unregister_REQ = new XCTIPSMSUnregister_REQ[] { unregister_REQ };
            packet.SMSItems = new XCTIPSMS[] { xCTIPSMS };
            String xml = ServiceXML.GenericSerialize(packet, true);

            return xml;
        }

        /// <summary>
        /// Zrób ramkę z smsem
        /// </summary>
        /// <param name="number"></param>
        /// <param name="smsId"></param>
        /// <param name="text"></param>
        /// <param name="dontBuffer"></param>
        /// <param name="userData"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        public string SMSSend_REQ(string number, string smsId, string text, string dontBuffer, string userData, out string rid)
        {
            XCTIP packet = new XCTIP();
            XCTIPSMS xCTIPSMS = new XCTIPSMS();
            XCTIPSMSSend_REQ send_REQ = new XCTIPSMSSend_REQ
            {
                CId = id++.ToString(),
                Number = number,
                SMSId = smsId,
                Type = "Internal",
                Text = text,
                DontBuffer = dontBuffer,
                UserData = userData
            };
            xCTIPSMS.Send_REQ = new XCTIPSMSSend_REQ[] { send_REQ };
            packet.SMSItems = new XCTIPSMS[] { xCTIPSMS };
            String xml = ServiceXML.GenericSerialize(packet, true);

            rid = send_REQ.CId;
            return xml;
        }
    }
}
