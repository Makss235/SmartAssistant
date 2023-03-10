namespace SmartAssistant.Data.LocalizationData
{
    public class LocObj
    {
        public MainWindowLoc MainWindowLoc { get; set; }
        public AddPEWindowLoc AddPEWindowLoc { get; set; }
        public TrayMenuLoc TrayMenuLoc { get; set; }
    }

    public class MainWindowLoc
    {
        public string TitleLoc { get; set; }
        public MainWindowTabsLoc MainWindowTabsLoc { get; set; }
        public MenuButtonsLoc MenuButtonsLoc { get; set; }
    }

    public class MainWindowTabsLoc
    {
        public VAChatTabLoc VAChatTabLoc { get; set; }
        public SettingsTabLoc SettingsTabLoc { get; set; }
        public AboutProgramTabLoc AboutProgramTabLoc { get; set; }
    }

    public class VAChatTabLoc
    {
        public string LabelWritingLoc { get; set; }
    }

    public class SettingsTabLoc
    {
        public string TitleLoc { get; set; }
        public ProgramSettingsLoc ProgramSettingsLoc { get; set; }
        public string WarningLoc { get; set; }
    }

    public class ProgramSettingsLoc
    {
        public string TitleLoc { get; set; }
        public DataGridColumnsLoc DataGridColumnsLoc { get; set; }
    }

    public class DataGridColumnsLoc
    {
        public string NameLoc { get; set; }
        public string CallingNamesLoc { get; set; }
        public string PathLoc { get; set; }
    }

    public class AboutProgramTabLoc
    {
        public string TitleLoc { get; set; }
        public string NameProgramLoc { get; set; }
        public string NameBuildLoc { get; set; }
        public string VersionLoc { get; set; }
        public AuthorsLoc AuthorsLoc { get; set; }
        public string DownloadLinkLoc { get; set; }
        public string GitHubLinkLoc { get; set; }
        public string WarningLoc { get; set; }
    }

    public class AuthorsLoc
    {
        public string TitleLoc { get; set; }
        public string MakssLoc { get; set; }
        public string MrVeserLoc { get; set; }
        public string FlowenyLoc { get; set; }
    }

    public class MenuButtonsLoc
    {
        public string VAChatButtonTitleLoc { get; set; }
        public string SettingsButtonTitleLoc { get; set; }
        public string AboutProgramButtonTitleLoc { get; set; }
    }

    public class AddPEWindowLoc
    {
        public AddPEWindowTabsLoc AddPEWindowTabsLoc { get; set; }
        public AddPEButtonsLoc AddPEButtonsLoc { get; set; }
    }

    public class AddPEWindowTabsLoc
    {
        public NavigationButtonsLoc NavigationButtonsLoc { get; set; }
        public AddNameTabLoc AddNameTabLoc { get; set; }
        public AddCallingNamesTabLoc AddCallingNamesTabLoc { get; set; }
        public AddPathTabLoc AddPathTabLoc { get; set; }
    }

    public class NavigationButtonsLoc
    {
        public string PreviousButtonLoc { get; set; }
        public string NextButtonLoc { get; set; }
        public string DoneButtonLoc { get; set; }
    }

    public class AddNameTabLoc
    {
        public string EnterNameLoc { get; set; }
    }
    
    public class AddCallingNamesTabLoc
    {
        public string EnterCallingNameLoc { get; set; }
    }
    
    public class AddPathTabLoc
    {
        public string EnterPathLoc { get; set; }
    }

    public class AddPEButtonsLoc
    {
        public string AddNameButtonLoc { get; set; }
        public string AddCallingNamesButtonLoc { get; set; }
        public string AddPathButtonLoc { get; set; }
    }

    public class TrayMenuLoc
    {
        public string TextLoc { get; set; }
        public StateLoc StateLoc { get; set; }
        public string CloseLoc { get; set; }
    }

    public class StateLoc
    {
        public string ShowLoc { get; set; }
        public string HideLoc { get; set; }
    }
}
