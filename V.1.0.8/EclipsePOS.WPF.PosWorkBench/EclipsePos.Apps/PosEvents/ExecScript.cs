using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;	
using EclipsePos.Data;
using EclipsePos.Apps.Context;

using Microsoft.PointOfService;


namespace EclipsePos.Apps.PosEvents
{
    public class ExecScript:PosDialogEvent
    {
        private bool scriptAllreadyRunning = false;
 
        public override void Engage(int val)
        {

            //MessageBox.Show("*** Discount ***" + keyValue.ToString());
            //Check if employee role is authorized to this event
            //if (!PosContext.Instance.Employee.RolesEventNames.Contains("ExecScript"))
            //{
            //    PosError posError = new PosError(PosErrorCode.INSUFFICIENT_USER_AUTHORITY);
            //    posError.Engage(0);
            //    return;
            //}
            if (scriptAllreadyRunning)
            {
                PosEvent posEvent = PosEventStack.Instance.Peek() as PosEvent;
                if (ExecScript.ReferenceEquals(posEvent, this)) return;
            }

            this.scriptAllreadyRunning = true;

            int keyValue = (int) PosContext.Instance.PosKeyValue;
            
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
           // startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;


            switch (keyValue)
            {
                case 1:
                    startInfo.FileName = "Calc.exe";
                    break;

                case 2:
                    startInfo.FileName = "Notepad.exe";
                    break;
            
            }

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch(Exception e)
            {
                Logger.Error("ExecScript.cs", e.ToString());
            }

            this.scriptAllreadyRunning = false;
            PosContext.Instance.ClearInput();
            PosEventStack.Instance.ClearPending();
            PosEventStack.Instance.NextEvent();

            
            

        }

        public override void Clear()
        {
        }

        public override bool ValidTransition(string pEventName)
        {
            return true;
        }


    }

    
}
