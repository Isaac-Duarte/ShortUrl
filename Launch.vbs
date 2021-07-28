Dim Quotes
Dim oShell
Dim oShellApp
Dim oFSO
Dim sScriptDir
Dim sCmd

Set oShell = CreateObject("WScript.Shell")
Set oShellApp = CreateObject("Shell.Application")
Set oFSO = CreateObject("Scripting.FileSystemObject")

' Double-quotes
Quotes = Chr(34)

' Get script directory without trailing slash
sScriptDir = Left(WScript.ScriptFullName, InStrRev(WScript.ScriptFullName, "\")-1)
	
'If root of drive, strip trailing backslash
If Len(sScriptDir) = 3 Then sScriptDir = Left(sScriptDir, 2)

' %WINDIR%
sWinDir = oShellApp.NameSpace(36).Self.Path

' Build command line
sCmd = Quotes & sWinDir & "\System32\WindowsPowerShell\v1.0\powershell.exe" & Quotes & " -NoLogo -NonInteractive -NoProfile -File " & Quotes & sScriptDir & "\New-ShortURL.ps1" & Quotes

' Execute script
iRetVal = oShell.Run(sCmd,0,True) 