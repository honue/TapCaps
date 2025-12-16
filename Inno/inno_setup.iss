#define MyAppName "Tap Caps"
#define MyAppVersion GetEnv("APP_VERSION")
#define MyAppPublisher "honue"
#define MyAppURL "https://github.com/honue/TapCaps"
#define MyAppExeName "TapCaps.exe"

[Setup]
AppId={{5D899D85-4249-4B77-A2F0-83FB8540DA74}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

; ✅ 用系统 Program Files（不要写死盘符）
DefaultDirName={autopf}\{#MyAppName}

UninstallDisplayIcon={app}\{#MyAppExeName}
DisableProgramGroupPage=yes
PrivilegesRequiredOverridesAllowed=dialog

OutputBaseFilename=TapCaps_Setup_{#MyAppVersion}

; ✅ 相对路径
SetupIconFile=..\TapCaps.ico

SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "chinesesimplified"; MessagesFile: ".\ChineseSimplified.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; ✅ CI 构建输出目录
Source: "..\Build\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
