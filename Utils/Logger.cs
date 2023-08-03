//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;
////using UnityExplorer;

//namespace SevenDTDMono
//{
//    public class Logger
//    {
//        public void InitializeLogger()
//        {
//            ExplorerStandalone.OnLog += HandleLogMessage;
//        }

//        private void HandleLogMessage(string logMessage, LogType logType)
//        {
//            // Handle the log message here
//            //Error,
//            //Assert,
//            //Warning,
//            //Log,
//            //Exception
//            // You can access the log message using the logMessage parameter
//            // You may log it to the console or a custom log file, for example.
//            Console.WriteLine($"UnityExplorer Log ({logType}): {logMessage}");
//        }

//        // Remember to unsubscribe from the event when you're done with it to avoid memory leaks.
//        public void UnsubscribeLogger()
//        {
//            ExplorerStandalone.OnLog -= HandleLogMessage;
//        }

//    }
//}
