using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindBookBot
{
    class BotAnswers
    {
        public static string CommandsInfo()
        {
            return String.Format
(@"List of commands:
/info - Shows information about this bot (like this message)
/createnote - creates a note which you can look at later
/createreminder - creates a remind which will be sent to you in particular time");
        }


        public static string InsertNoteName()=> $"What will be the name of your note?";


    }
}
