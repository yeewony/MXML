using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;

namespace aNewTool_For.NET_Framework
{
    class Powershell
    {
        static string root = Environment.CurrentDirectory;
        static string ScriptRoot = root + "\\bin\\Script";


        public static void GetSystemInfo()
        {
            Directory.CreateDirectory(ScriptRoot);

            string Ps1File = ScriptRoot + "Get-ComputerInfo.ps1";
            byte[] Ps1FileByte = Properties.Resources.Get_ComputerInfo; //스크립트랑 리소스 파일명 통일시키기
            using (FileStream stream = File.Create(ScriptRoot+"\\Get-ComputerInfo.ps1"))
            {
                stream.Write(Ps1FileByte, 0, Ps1FileByte.Length);
            }

            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            Command myCommand = new Command(Ps1File);
            pipeline.Commands.Add(myCommand);
            pipeline.Invoke();
        }
    }
}
