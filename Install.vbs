Dim oShell
Dim Quotes
Dim sScriptDir
Dim oShortcut
Dim desktopPath

' Double-quotes
Quotes = Chr(34)

Set oShell = CreateObject("WScript.Shell")


' Get script directory without trailing slash
sScriptDir = Left(WScript.ScriptFullName, InStrRev(WScript.ScriptFullName, "\")-1)

'If root of drive, strip trailing backslash
If Len(sScriptDir) = 3 Then sScriptDir = Left(sScriptDir, 2)

' Get Desktop folder path
desktopPath = oShell.SpecialFolders("Desktop")


Set oShortcut = oShell.CreateShortcut(desktopPath & "\New-ShortURL.lnk")
oShortcut.Arguments = Quotes & sScriptDir & "\Launch.vbs" & Quotes
oShortcut.Description = "https://github.com/Isaac-Duarte/ShortUrl"
oShortcut.HotKey = "CTRL+ALT+C"
oShortcut.IconLocation = "%SystemRoot%\System32\SHELL32.dll,14"
oShortcut.TargetPath = "%WINDIR%\System32\wscript.exe"
oShortcut.WindowStyle = 4
oShortcut.WorkingDirectory = sScriptDir
oShortcut.Save