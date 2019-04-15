using System;

namespace BzCOMWpf
{
    public class Message
    {

        public int Number { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsMine { get; set; } //Sprawdza czy wiadomość była wysłana przez uzytkownika

        public override string ToString()
        {
            return $"{DateTime} From: {Number}\n {Text}";
        }
    }
}
