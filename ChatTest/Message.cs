using System;

namespace ChatTest
{
    public class Message
    {

        public int Number { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $"{DateTime} From: {Number}\n {Text}";
        }
    }
}
