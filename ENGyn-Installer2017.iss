; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{B827E3D1-F82E-45B9-9352-53C8EF41399F}
AppName=ENG ENGyn 2017 Setup
AppVersion=0.1.4.5

AppPublisher=PRD
AppPublisherURL=-
AppSupportURL=-
AppUpdatesURL=-
DefaultDirName={pf}\ENGyn
DisableDirPage=yes
DefaultGroupName=ENGworks ENGyn 2017
DisableProgramGroupPage=yes
OutputBaseFilename=ENG ENGyn 2017 Setup 0.1.4.5
Compression=lzma
SolidCompression=yes
OutputManifestFile=Setup-Manifest.txt
OutputDir=bin\Install
[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Dirs]
Name: "{userappdata}\Autodesk Navisworks Manage 2017\Plugins\"
[InstallDelete]
Type: filesandordirs; Name: "{userappdata}\Autodesk Navisworks Manage 2017\Plugins\ENGyn\"
    

[Files]
Source: "bin\2017\*"; DestDir: "{userappdata}\Autodesk Navisworks Manage 2017\Plugins\ENGyn\"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Program Files\Autodesk\Navisworks Manage 2017\Dependencies\*"; DestDir: "{pf64}\Autodesk\Navisworks Manage 2017\Dependencies\"; Flags: ignoreversion recursesubdirs createallsubdirs

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

