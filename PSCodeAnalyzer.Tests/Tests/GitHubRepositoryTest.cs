using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSCodeAnalyzer.Tests
{

    [TestClass]
    public class GitHubRepositoryTest
    {
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Init()
        {
            //Execution time is included in first test case?
            EditorImports.Initialize();
        }

     


        #region Github
        [TestMethod]
        public void GitHub_chocolatey_chocolatey()
        {
            var downloadUrl = "https://github.com/chocolatey/chocolatey";
            TestFiles("chocolatey_chocolatey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dahlbyk_posh_git()
        {
            var downloadUrl = "https://github.com/dahlbyk/posh-git";
            TestFiles("dahlbyk_posh-git", downloadUrl);
        }

        [TestMethod]
        public void GitHub_psake_psake()
        {
            var downloadUrl = "https://github.com/psake/psake";
            TestFiles("psake_psake", downloadUrl);
        }

        [TestMethod]
        public void GitHub_leddt_visualstudio_colors_solarized()
        {
            var downloadUrl = "https://github.com/leddt/visualstudio-colors-solarized";
            TestFiles("leddt_visualstudio-colors-solarized", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mattifestation_PowerSploit()
        {
            var downloadUrl = "https://github.com/mattifestation/PowerSploit";
            TestFiles("mattifestation_PowerSploit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_psget_psget()
        {
            var downloadUrl = "https://github.com/psget/psget";
            TestFiles("psget_psget", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pester_Pester()
        {
            var downloadUrl = "https://github.com/pester/Pester";
            TestFiles("pester_Pester", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JeremySkinner_posh_hg()
        {
            var downloadUrl = "https://github.com/JeremySkinner/posh-hg";
            TestFiles("JeremySkinner_posh-hg", downloadUrl);
        }

        [TestMethod]
        public void GitHub_psake_psake_contrib()
        {
            var downloadUrl = "https://github.com/psake/psake-contrib";
            TestFiles("psake_psake-contrib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ferventcoder_nugetpackages()
        {
            var downloadUrl = "https://github.com/ferventcoder/nugetpackages";
            TestFiles("ferventcoder_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Ang3lFir3_Chewie()
        {
            var downloadUrl = "https://github.com/Ang3lFir3/Chewie";
            TestFiles("Ang3lFir3_Chewie", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mitchellh_vagrant_installers()
        {
            var downloadUrl = "https://github.com/mitchellh/vagrant-installers";
            TestFiles("mitchellh_vagrant-installers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alanrenouf_vCheck_vSphere()
        {
            var downloadUrl = "https://github.com/alanrenouf/vCheck-vSphere";
            TestFiles("alanrenouf_vCheck-vSphere", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thomasvm_unfold()
        {
            var downloadUrl = "https://github.com/thomasvm/unfold";
            TestFiles("thomasvm_unfold", downloadUrl);
        }

        [TestMethod]
        public void GitHub_scottmuc_yari()
        {
            var downloadUrl = "https://github.com/scottmuc/yari";
            TestFiles("scottmuc_yari", downloadUrl);
        }

        [TestMethod]
        public void GitHub_splunk_splunk_reskit_powershell()
        {
            var downloadUrl = "https://github.com/splunk/splunk-reskit-powershell";
            TestFiles("splunk_splunk-reskit-powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PProvost_AssertEx()
        {
            var downloadUrl = "https://github.com/PProvost/AssertEx";
            TestFiles("PProvost_AssertEx", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adamdriscoll_PoshInternals()
        {
            var downloadUrl = "https://github.com/adamdriscoll/PoshInternals";
            TestFiles("adamdriscoll_PoshInternals", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WilbertOnGithub_TFS2GIT()
        {
            var downloadUrl = "https://github.com/WilbertOnGithub/TFS2GIT";
            TestFiles("WilbertOnGithub_TFS2GIT", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Wintellect_WintellectPowerShell()
        {
            var downloadUrl = "https://github.com/Wintellect/WintellectPowerShell";
            TestFiles("Wintellect_WintellectPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JeremySkinner_posh_svn()
        {
            var downloadUrl = "https://github.com/JeremySkinner/posh-svn";
            TestFiles("JeremySkinner_posh-svn", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sayedihashimi_package_web()
        {
            var downloadUrl = "https://github.com/sayedihashimi/package-web";
            TestFiles("sayedihashimi_package-web", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_azure_sdk_tools_samples()
        {
            var downloadUrl = "https://github.com/WindowsAzure/azure-sdk-tools-samples";
            TestFiles("WindowsAzure_azure-sdk-tools-samples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_clymb3r_PowerShell()
        {
            var downloadUrl = "https://github.com/clymb3r/PowerShell";
            TestFiles("clymb3r_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AffinityID_PowerUp()
        {
            var downloadUrl = "https://github.com/AffinityID/PowerUp";
            TestFiles("AffinityID_PowerUp", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adoprog_Sitecore_PowerCore()
        {
            var downloadUrl = "https://github.com/adoprog/Sitecore-PowerCore";
            TestFiles("adoprog_Sitecore-PowerCore", downloadUrl);
        }

        [TestMethod]
        public void GitHub_manojlds_YDeliver()
        {
            var downloadUrl = "https://github.com/manojlds/YDeliver";
            TestFiles("manojlds_YDeliver", downloadUrl);
        }

        [TestMethod]
        public void GitHub_konstantinvlasenko_PowerSlim()
        {
            var downloadUrl = "https://github.com/konstantinvlasenko/PowerSlim";
            TestFiles("konstantinvlasenko_PowerSlim", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonnii_BuildDeploySupport()
        {
            var downloadUrl = "https://github.com/jonnii/BuildDeploySupport";
            TestFiles("jonnii_BuildDeploySupport", downloadUrl);
        }

        [TestMethod]
        public void GitHub_darkoperator_Posh_SecMod()
        {
            var downloadUrl = "https://github.com/darkoperator/Posh-SecMod";
            TestFiles("darkoperator_Posh-SecMod", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kblooie_PSBuildModules()
        {
            var downloadUrl = "https://github.com/kblooie/PSBuildModules";
            TestFiles("kblooie_PSBuildModules", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lzybkr_TabExpansionPlusPlus()
        {
            var downloadUrl = "https://github.com/lzybkr/TabExpansionPlusPlus";
            TestFiles("lzybkr_TabExpansionPlusPlus", downloadUrl);
        }

        [TestMethod]
        public void GitHub_darkoperator_powershell_scripts()
        {
            var downloadUrl = "https://github.com/darkoperator/powershell_scripts";
            TestFiles("darkoperator_powershell_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cromwellryan_psgist()
        {
            var downloadUrl = "https://github.com/cromwellryan/psgist";
            TestFiles("cromwellryan_psgist", downloadUrl);
        }

        [TestMethod]
        public void GitHub_scottmuc_PowerYaml()
        {
            var downloadUrl = "https://github.com/scottmuc/PowerYaml";
            TestFiles("scottmuc_PowerYaml", downloadUrl);
        }

        [TestMethod]
        public void GitHub_marcusoftnet_ScriptsAndStuff()
        {
            var downloadUrl = "https://github.com/marcusoftnet/ScriptsAndStuff";
            TestFiles("marcusoftnet_ScriptsAndStuff", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Iristyle_Posh_GitHub()
        {
            var downloadUrl = "https://github.com/Iristyle/Posh-GitHub";
            TestFiles("Iristyle_Posh-GitHub", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chaliy_psurl()
        {
            var downloadUrl = "https://github.com/chaliy/psurl";
            TestFiles("chaliy_psurl", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Sitecore_PowerShell_Script_Library()
        {
            var downloadUrl = "https://github.com/Sitecore/PowerShell-Script-Library";
            TestFiles("Sitecore_PowerShell-Script-Library", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MrPowerScripts_PowerScripts()
        {
            var downloadUrl = "https://github.com/MrPowerScripts/PowerScripts";
            TestFiles("MrPowerScripts_PowerScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_drmohundro_ColorConverter()
        {
            var downloadUrl = "https://github.com/drmohundro/ColorConverter";
            TestFiles("drmohundro_ColorConverter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PSharp()
        {
            var downloadUrl = "https://github.com/dfinke/PSharp";
            TestFiles("dfinke_PSharp", downloadUrl);
        }

        [TestMethod]
        public void GitHub_manojlds_posz()
        {
            var downloadUrl = "https://github.com/manojlds/posz";
            TestFiles("manojlds_posz", downloadUrl);
        }

        [TestMethod]
        public void GitHub_drmohundro_Find_String()
        {
            var downloadUrl = "https://github.com/drmohundro/Find-String";
            TestFiles("drmohundro_Find-String", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joefitzgerald_packer_windows()
        {
            var downloadUrl = "https://github.com/joefitzgerald/packer-windows";
            TestFiles("joefitzgerald_packer-windows", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AnthonyMastrean_posh_flow()
        {
            var downloadUrl = "https://github.com/AnthonyMastrean/posh-flow";
            TestFiles("AnthonyMastrean_posh-flow", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ericmann_WP_PowerShell()
        {
            var downloadUrl = "https://github.com/ericmann/WP-PowerShell";
            TestFiles("ericmann_WP-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_manojlds_poshmarks()
        {
            var downloadUrl = "https://github.com/manojlds/poshmarks";
            TestFiles("manojlds_poshmarks", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thinkbeforecoding_PSEventStore()
        {
            var downloadUrl = "https://github.com/thinkbeforecoding/PSEventStore";
            TestFiles("thinkbeforecoding_PSEventStore", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Haemoglobin_GitHub_Source_Indexer()
        {
            var downloadUrl = "https://github.com/Haemoglobin/GitHub-Source-Indexer";
            TestFiles("Haemoglobin_GitHub-Source-Indexer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_endjin_TeamCityPowerShell()
        {
            var downloadUrl = "https://github.com/endjin/TeamCityPowerShell";
            TestFiles("endjin_TeamCityPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DefinitelyTyped_NugetAutomation()
        {
            var downloadUrl = "https://github.com/DefinitelyTyped/NugetAutomation";
            TestFiles("DefinitelyTyped_NugetAutomation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hartez_todo_txt_PowerShell()
        {
            var downloadUrl = "https://github.com/hartez/todo.txt-PowerShell";
            TestFiles("hartez_todo.txt-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_davidpeckham_powershell_tmbundle()
        {
            var downloadUrl = "https://github.com/davidpeckham/powershell.tmbundle";
            TestFiles("davidpeckham_powershell.tmbundle", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AppVeyor_AppRolla()
        {
            var downloadUrl = "https://github.com/AppVeyor/AppRolla";
            TestFiles("AppVeyor_AppRolla", downloadUrl);
        }

        [TestMethod]
        public void GitHub_skalinets_add_default_ignores()
        {
            var downloadUrl = "https://github.com/skalinets/add-default-ignores";
            TestFiles("skalinets_add-default-ignores", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dahlbyk_posh_tf()
        {
            var downloadUrl = "https://github.com/dahlbyk/posh-tf";
            TestFiles("dahlbyk_posh-tf", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_AutomatingVMManagementPS()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-AutomatingVMManagementPS";
            TestFiles("WindowsAzure-TrainingKit_HOL-AutomatingVMManagementPS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ferventcoder_chocolateyautomaticpackages()
        {
            var downloadUrl = "https://github.com/ferventcoder/chocolateyautomaticpackages";
            TestFiles("ferventcoder_chocolateyautomaticpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lholman_AutoBot()
        {
            var downloadUrl = "https://github.com/lholman/AutoBot";
            TestFiles("lholman_AutoBot", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Iristyle_Midori()
        {
            var downloadUrl = "https://github.com/Iristyle/Midori";
            TestFiles("Iristyle_Midori", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nightroman_Mdbc()
        {
            var downloadUrl = "https://github.com/nightroman/Mdbc";
            TestFiles("nightroman_Mdbc", downloadUrl);
        }

        [TestMethod]
        public void GitHub_staxmanade_Scripts()
        {
            var downloadUrl = "https://github.com/staxmanade/Scripts";
            TestFiles("staxmanade_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PProvost_dotfiles()
        {
            var downloadUrl = "https://github.com/PProvost/dotfiles";
            TestFiles("PProvost_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kamsar_Beaver()
        {
            var downloadUrl = "https://github.com/kamsar/Beaver";
            TestFiles("kamsar_Beaver", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smurawski_DSC_Contrib()
        {
            var downloadUrl = "https://github.com/smurawski/DSC-Contrib";
            TestFiles("smurawski_DSC-Contrib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ilude_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/ilude/WindowsPowerShell";
            TestFiles("ilude_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vip32_xtricate_build()
        {
            var downloadUrl = "https://github.com/vip32/xtricate.build";
            TestFiles("vip32_xtricate.build", downloadUrl);
        }

        [TestMethod]
        public void GitHub_riverar_playto_tools()
        {
            var downloadUrl = "https://github.com/riverar/playto-tools";
            TestFiles("riverar_playto-tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_drmmarsunited_rackspacecloud_powershell()
        {
            var downloadUrl = "https://github.com/drmmarsunited/rackspacecloud_powershell";
            TestFiles("drmmarsunited_rackspacecloud_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PoshSec_PoshSec()
        {
            var downloadUrl = "https://github.com/PoshSec/PoshSec";
            TestFiles("PoshSec_PoshSec", downloadUrl);
        }

        [TestMethod]
        public void GitHub_unfixed_Dell_Warranty_Lookup()
        {
            var downloadUrl = "https://github.com/unfixed/Dell-Warranty-Lookup";
            TestFiles("unfixed_Dell-Warranty-Lookup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Wintellect_Start_PowerShellPoint()
        {
            var downloadUrl = "https://github.com/Wintellect/Start-PowerShellPoint";
            TestFiles("Wintellect_Start-PowerShellPoint", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chocolatey_chocolateytemplates()
        {
            var downloadUrl = "https://github.com/chocolatey/chocolateytemplates";
            TestFiles("chocolatey_chocolateytemplates", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sushihangover_SushiHangover_AWS()
        {
            var downloadUrl = "https://github.com/sushihangover/SushiHangover-AWS";
            TestFiles("sushihangover_SushiHangover-AWS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PowerShellOrg_DSC()
        {
            var downloadUrl = "https://github.com/PowerShellOrg/DSC";
            TestFiles("PowerShellOrg_DSC", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yosoyadri_IIS_ARR_Zero_Downtime()
        {
            var downloadUrl = "https://github.com/yosoyadri/IIS-ARR-Zero-Downtime";
            TestFiles("yosoyadri_IIS-ARR-Zero-Downtime", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nightroman_SplitPipeline()
        {
            var downloadUrl = "https://github.com/nightroman/SplitPipeline";
            TestFiles("nightroman_SplitPipeline", downloadUrl);
        }

        [TestMethod]
        public void GitHub_andrebocchini_sccm_powershell_automation_module()
        {
            var downloadUrl = "https://github.com/andrebocchini/sccm-powershell-automation-module";
            TestFiles("andrebocchini_sccm-powershell-automation-module", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrwei_PowerCLIGoodies()
        {
            var downloadUrl = "https://github.com/chrwei/PowerCLIGoodies";
            TestFiles("chrwei_PowerCLIGoodies", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xiaodao_psbuild()
        {
            var downloadUrl = "https://github.com/xiaodao/psbuild";
            TestFiles("xiaodao_psbuild", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sapiens_DomainEventsToolkit()
        {
            var downloadUrl = "https://github.com/sapiens/DomainEventsToolkit";
            TestFiles("sapiens_DomainEventsToolkit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hunt3ri_Nant_Builder()
        {
            var downloadUrl = "https://github.com/hunt3ri/Nant.Builder";
            TestFiles("hunt3ri_Nant.Builder", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fdcastel_psunattended()
        {
            var downloadUrl = "https://github.com/fdcastel/psunattended";
            TestFiles("fdcastel_psunattended", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xcud_Psh()
        {
            var downloadUrl = "https://github.com/xcud/Psh";
            TestFiles("xcud_Psh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sushihangover_SushiHangover_PowerShell()
        {
            var downloadUrl = "https://github.com/sushihangover/SushiHangover-PowerShell";
            TestFiles("sushihangover_SushiHangover-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mattifestation_PIC_Bindshell()
        {
            var downloadUrl = "https://github.com/mattifestation/PIC_Bindshell";
            TestFiles("mattifestation_PIC_Bindshell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_endjin_Samples()
        {
            var downloadUrl = "https://github.com/endjin/Samples";
            TestFiles("endjin_Samples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_myget_NuGetPackages()
        {
            var downloadUrl = "https://github.com/myget/NuGetPackages";
            TestFiles("myget_NuGetPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nightroman_Invoke_Build()
        {
            var downloadUrl = "https://github.com/nightroman/Invoke-Build";
            TestFiles("nightroman_Invoke-Build", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mikhail_tsennykh_Chromium_Updater()
        {
            var downloadUrl = "https://github.com/mikhail-tsennykh/Chromium-Updater";
            TestFiles("mikhail-tsennykh_Chromium-Updater", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stephenjirvine_windevops()
        {
            var downloadUrl = "https://github.com/stephenjirvine/windevops";
            TestFiles("stephenjirvine_windevops", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cameronharp_Go_Shell()
        {
            var downloadUrl = "https://github.com/cameronharp/Go-Shell";
            TestFiles("cameronharp_Go-Shell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adminian_PowerKinect()
        {
            var downloadUrl = "https://github.com/adminian/PowerKinect";
            TestFiles("adminian_PowerKinect", downloadUrl);
        }

        [TestMethod]
        public void GitHub_NetSPI_PS_CC_Checker()
        {
            var downloadUrl = "https://github.com/NetSPI/PS_CC_Checker";
            TestFiles("NetSPI_PS_CC_Checker", downloadUrl);
        }

        [TestMethod]
        public void GitHub_justFen_NiniteSloth()
        {
            var downloadUrl = "https://github.com/justFen/NiniteSloth";
            TestFiles("justFen_NiniteSloth", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xpando_PortableConsole()
        {
            var downloadUrl = "https://github.com/xpando/PortableConsole";
            TestFiles("xpando_PortableConsole", downloadUrl);
        }

        [TestMethod]
        public void GitHub_J_rom_Shellit()
        {
            var downloadUrl = "https://github.com/J-rom/Shellit";
            TestFiles("J-rom_Shellit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cveira_social_media_scripting_framework()
        {
            var downloadUrl = "https://github.com/cveira/social-media-scripting-framework";
            TestFiles("cveira_social-media-scripting-framework", downloadUrl);
        }

        [TestMethod]
        public void GitHub_remotex_Scripts()
        {
            var downloadUrl = "https://github.com/remotex/Scripts";
            TestFiles("remotex_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ejb1123_autorip()
        {
            var downloadUrl = "https://github.com/ejb1123/autorip";
            TestFiles("ejb1123_autorip", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Iristyle_CroMagVersion()
        {
            var downloadUrl = "https://github.com/Iristyle/CroMagVersion";
            TestFiles("Iristyle_CroMagVersion", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dmohl_FSPowerPack_Community()
        {
            var downloadUrl = "https://github.com/dmohl/FSPowerPack.Community";
            TestFiles("dmohl_FSPowerPack.Community", downloadUrl);
        }

        [TestMethod]
        public void GitHub_whatcomtrans_Office365PowershellUtils()
        {
            var downloadUrl = "https://github.com/whatcomtrans/Office365PowershellUtils";
            TestFiles("whatcomtrans_Office365PowershellUtils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hmartiro_princeton_java_installers()
        {
            var downloadUrl = "https://github.com/hmartiro/princeton-java-installers";
            TestFiles("hmartiro_princeton-java-installers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_staxmanade_PowerShellPresentation()
        {
            var downloadUrl = "https://github.com/staxmanade/PowerShellPresentation";
            TestFiles("staxmanade_PowerShellPresentation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chaliy_psjson()
        {
            var downloadUrl = "https://github.com/chaliy/psjson";
            TestFiles("chaliy_psjson", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fschwiet_fschwiet_local_config()
        {
            var downloadUrl = "https://github.com/fschwiet/fschwiet-local-config";
            TestFiles("fschwiet_fschwiet-local-config", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aroben_winbootstrap()
        {
            var downloadUrl = "https://github.com/aroben/winbootstrap";
            TestFiles("aroben_winbootstrap", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Wintellect_WintellectVSCmdlets()
        {
            var downloadUrl = "https://github.com/Wintellect/WintellectVSCmdlets";
            TestFiles("Wintellect_WintellectVSCmdlets", downloadUrl);
        }


        [TestMethod]
        public void GitHub_0xakhil_Facebook_Bot()
        {
            var downloadUrl = "https://github.com/0xakhil/Facebook_Bot";
            TestFiles("0xakhil_Facebook_Bot", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mg_alfa_dev_Perseus()
        {
            var downloadUrl = "https://github.com/mg-alfa-dev/Perseus";
            TestFiles("mg-alfa-dev_Perseus", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PSBabushka_PSBabushka()
        {
            var downloadUrl = "https://github.com/PSBabushka/PSBabushka";
            TestFiles("PSBabushka_PSBabushka", downloadUrl);
        }

        [TestMethod]
        public void GitHub_julielerman_EF_and_Private_CTORs_n_Setters()
        {
            var downloadUrl = "https://github.com/julielerman/EF_and_Private_CTORs_n_Setters";
            TestFiles("julielerman_EF_and_Private_CTORs_n_Setters", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cromwellryan_ps_config()
        {
            var downloadUrl = "https://github.com/cromwellryan/ps-config";
            TestFiles("cromwellryan_ps-config", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fschwiet_PSUpdateXml()
        {
            var downloadUrl = "https://github.com/fschwiet/PSUpdateXml";
            TestFiles("fschwiet_PSUpdateXml", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sixfootdad_AWS_Glacier_SNS_PowerShell()
        {
            var downloadUrl = "https://github.com/sixfootdad/AWS-Glacier-SNS-PowerShell";
            TestFiles("sixfootdad_AWS-Glacier-SNS-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Jaykul_poshcode()
        {
            var downloadUrl = "https://github.com/Jaykul/poshcode";
            TestFiles("Jaykul_poshcode", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_NodejsAzureWebSites()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-NodejsAzureWebSites";
            TestFiles("WindowsAzure-TrainingKit_HOL-NodejsAzureWebSites", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rs_services_windows_tools()
        {
            var downloadUrl = "https://github.com/rs-services/windows_tools";
            TestFiles("rs-services_windows_tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_guangyang_azure_powershell_samples()
        {
            var downloadUrl = "https://github.com/guangyang/azure-powershell-samples";
            TestFiles("guangyang_azure-powershell-samples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jstangroome_PsTFS11()
        {
            var downloadUrl = "https://github.com/jstangroome/PsTFS11";
            TestFiles("jstangroome_PsTFS11", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MSOpenTech_posh_npm()
        {
            var downloadUrl = "https://github.com/MSOpenTech/posh-npm";
            TestFiles("MSOpenTech_posh-npm", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rdowner_winrm_tools()
        {
            var downloadUrl = "https://github.com/rdowner/winrm-tools";
            TestFiles("rdowner_winrm-tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bjd145_PSScripts()
        {
            var downloadUrl = "https://github.com/bjd145/PSScripts";
            TestFiles("bjd145_PSScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AmanDhally_OutlookTools()
        {
            var downloadUrl = "https://github.com/AmanDhally/OutlookTools";
            TestFiles("AmanDhally_OutlookTools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_turowicz_knockout_bluetable()
        {
            var downloadUrl = "https://github.com/turowicz/knockout-bluetable";
            TestFiles("turowicz_knockout-bluetable", downloadUrl);
        }

        [TestMethod]
        public void GitHub_edgesmash_RageFaceTheme()
        {
            var downloadUrl = "https://github.com/edgesmash/RageFaceTheme";
            TestFiles("edgesmash_RageFaceTheme", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JannesMeyer_z_ps()
        {
            var downloadUrl = "https://github.com/JannesMeyer/z.ps";
            TestFiles("JannesMeyer_z.ps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_staxmanade_DevMachineSetup()
        {
            var downloadUrl = "https://github.com/staxmanade/DevMachineSetup";
            TestFiles("staxmanade_DevMachineSetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jsikorski_Workspace_Scripts()
        {
            var downloadUrl = "https://github.com/jsikorski/Workspace-Scripts";
            TestFiles("jsikorski_Workspace-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_KjetilM_Send_SMS()
        {
            var downloadUrl = "https://github.com/KjetilM/Send_SMS";
            TestFiles("KjetilM_Send_SMS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fschwiet_PsakeViz()
        {
            var downloadUrl = "https://github.com/fschwiet/PsakeViz";
            TestFiles("fschwiet_PsakeViz", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonwagner_PSMock()
        {
            var downloadUrl = "https://github.com/jonwagner/PSMock";
            TestFiles("jonwagner_PSMock", downloadUrl);
        }



        [TestMethod]
        public void GitHub_JamesKovacs_scripts()
        {
            var downloadUrl = "https://github.com/JamesKovacs/scripts";
            TestFiles("JamesKovacs_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smichelotti_WebApi_Scaffolding()
        {
            var downloadUrl = "https://github.com/smichelotti/WebApi.Scaffolding";
            TestFiles("smichelotti_WebApi.Scaffolding", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_IsePester()
        {
            var downloadUrl = "https://github.com/dfinke/IsePester";
            TestFiles("dfinke_IsePester", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rarous_WebTools()
        {
            var downloadUrl = "https://github.com/rarous/WebTools";
            TestFiles("rarous_WebTools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_neo00_WSDL_Viz()
        {
            var downloadUrl = "https://github.com/neo00/WSDL-Viz";
            TestFiles("neo00_WSDL-Viz", downloadUrl);
        }

        [TestMethod]
        public void GitHub_octan3_img_clipboard_dump()
        {
            var downloadUrl = "https://github.com/octan3/img-clipboard-dump";
            TestFiles("octan3_img-clipboard-dump", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fschwiet_fschwiet_boxstarter()
        {
            var downloadUrl = "https://github.com/fschwiet/fschwiet-boxstarter";
            TestFiles("fschwiet_fschwiet-boxstarter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_trstringer_SQLSalt()
        {
            var downloadUrl = "https://github.com/trstringer/SQLSalt";
            TestFiles("trstringer_SQLSalt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kazunori_Kimura_MyPowerShellSnippet()
        {
            var downloadUrl = "https://github.com/Kazunori-Kimura/MyPowerShellSnippet";
            TestFiles("Kazunori-Kimura_MyPowerShellSnippet", downloadUrl);
        }


        [TestMethod]
        public void GitHub_dontjee_Powershell_Profile()
        {
            var downloadUrl = "https://github.com/dontjee/Powershell-Profile";
            TestFiles("dontjee_Powershell-Profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_erik_kallen_SaltarelleLoader()
        {
            var downloadUrl = "https://github.com/erik-kallen/SaltarelleLoader";
            TestFiles("erik-kallen_SaltarelleLoader", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jole78_TeamCity_SpecFlow_Reporting()
        {
            var downloadUrl = "https://github.com/jole78/TeamCity.SpecFlow.Reporting";
            TestFiles("jole78_TeamCity.SpecFlow.Reporting", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PowerShellMOFSchema()
        {
            var downloadUrl = "https://github.com/dfinke/PowerShellMOFSchema";
            TestFiles("dfinke_PowerShellMOFSchema", downloadUrl);
        }

        [TestMethod]
        public void GitHub_FerHenrique_PantheonRepository()
        {
            var downloadUrl = "https://github.com/FerHenrique/PantheonRepository";
            TestFiles("FerHenrique_PantheonRepository", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Aethylred_puppet_blank()
        {
            var downloadUrl = "https://github.com/Aethylred/puppet-blank";
            TestFiles("Aethylred_puppet-blank", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Pwdrkeg_honeyport()
        {
            var downloadUrl = "https://github.com/Pwdrkeg/honeyport";
            TestFiles("Pwdrkeg_honeyport", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PowerShellTools()
        {
            var downloadUrl = "https://github.com/dfinke/PowerShellTools";
            TestFiles("dfinke_PowerShellTools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xephon81_FOE()
        {
            var downloadUrl = "https://github.com/xephon81/FOE";
            TestFiles("xephon81_FOE", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tpks_group_tpks_net()
        {
            var downloadUrl = "https://github.com/tpks-group/tpks-net";
            TestFiles("tpks-group_tpks-net", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alexdresko_nAsana()
        {
            var downloadUrl = "https://github.com/alexdresko/nAsana";
            TestFiles("alexdresko_nAsana", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alexfalkowski_PExtend()
        {
            var downloadUrl = "https://github.com/alexfalkowski/PExtend";
            TestFiles("alexfalkowski_PExtend", downloadUrl);
        }

        [TestMethod]
        public void GitHub_knutkj_misc()
        {
            var downloadUrl = "https://github.com/knutkj/misc";
            TestFiles("knutkj_misc", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonwagner_PShould()
        {
            var downloadUrl = "https://github.com/jonwagner/PShould";
            TestFiles("jonwagner_PShould", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thinkbeforecoding_PSCompletion()
        {
            var downloadUrl = "https://github.com/thinkbeforecoding/PSCompletion";
            TestFiles("thinkbeforecoding_PSCompletion", downloadUrl);
        }

        [TestMethod]
        public void GitHub_idavis_prototype_ps()
        {
            var downloadUrl = "https://github.com/idavis/prototype.ps";
            TestFiles("idavis_prototype.ps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_perryofpeek_SqlToGraphite()
        {
            var downloadUrl = "https://github.com/perryofpeek/SqlToGraphite";
            TestFiles("perryofpeek_SqlToGraphite", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gpduck_DhcpServerDSC()
        {
            var downloadUrl = "https://github.com/gpduck/DhcpServerDSC";
            TestFiles("gpduck_DhcpServerDSC", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ryanchapman_vmware_scripts()
        {
            var downloadUrl = "https://github.com/ryanchapman/vmware_scripts";
            TestFiles("ryanchapman_vmware_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PowerShell_Roslyn_Code_Quoter()
        {
            var downloadUrl = "https://github.com/dfinke/PowerShell_Roslyn_Code_Quoter";
            TestFiles("dfinke_PowerShell_Roslyn_Code_Quoter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_darkoperator_VI_ToolBox()
        {
            var downloadUrl = "https://github.com/darkoperator/VI-ToolBox";
            TestFiles("darkoperator_VI-ToolBox", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chocolatey_chocolatey_communitypackages()
        {
            var downloadUrl = "https://github.com/chocolatey/chocolatey-communitypackages";
            TestFiles("chocolatey_chocolatey-communitypackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_oWretch_PowerShell_Deployment_Toolkit()
        {
            var downloadUrl = "https://github.com/oWretch/PowerShell-Deployment-Toolkit";
            TestFiles("oWretch_PowerShell-Deployment-Toolkit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_beefarino_studioshell_contrib()
        {
            var downloadUrl = "https://github.com/beefarino/studioshell-contrib";
            TestFiles("beefarino_studioshell-contrib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vipmike007_whql_powershell()
        {
            var downloadUrl = "https://github.com/vipmike007/whql_powershell";
            TestFiles("vipmike007_whql_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AnthonyMastrean_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/AnthonyMastrean/WindowsPowerShell";
            TestFiles("AnthonyMastrean_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tathamoddie_Repair_Environment_ps1()
        {
            var downloadUrl = "https://github.com/tathamoddie/Repair-Environment.ps1";
            TestFiles("tathamoddie_Repair-Environment.ps1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SQLServerIO_SQLDIY()
        {
            var downloadUrl = "https://github.com/SQLServerIO/SQLDIY";
            TestFiles("SQLServerIO_SQLDIY", downloadUrl);
        }

        [TestMethod]
        public void GitHub_libardo_ModularMvc()
        {
            var downloadUrl = "https://github.com/libardo/ModularMvc";
            TestFiles("libardo_ModularMvc", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nightroman_Helps()
        {
            var downloadUrl = "https://github.com/nightroman/Helps";
            TestFiles("nightroman_Helps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kanej_Posh_Cowsay()
        {
            var downloadUrl = "https://github.com/kanej/Posh-Cowsay";
            TestFiles("kanej_Posh-Cowsay", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Awesomeoman_get_ping_status()
        {
            var downloadUrl = "https://github.com/Awesomeoman/get-ping-status";
            TestFiles("Awesomeoman_get-ping-status", downloadUrl);
        }

        [TestMethod]
        public void GitHub_puc_canvas_uploader()
        {
            var downloadUrl = "https://github.com/puc/canvas-uploader";
            TestFiles("puc_canvas-uploader", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonwagner_PSate()
        {
            var downloadUrl = "https://github.com/jonwagner/PSate";
            TestFiles("jonwagner_PSate", downloadUrl);
        }

        [TestMethod]
        public void GitHub_liddellj_posh_jenkins()
        {
            var downloadUrl = "https://github.com/liddellj/posh-jenkins";
            TestFiles("liddellj_posh-jenkins", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_DeployingActiveDirectoryPS()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-DeployingActiveDirectoryPS";
            TestFiles("WindowsAzure-TrainingKit_HOL-DeployingActiveDirectoryPS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alexfalkowski_documentation()
        {
            var downloadUrl = "https://github.com/alexfalkowski/documentation";
            TestFiles("alexfalkowski_documentation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_robross_jenkinspowershell()
        {
            var downloadUrl = "https://github.com/robross/jenkinspowershell";
            TestFiles("robross_jenkinspowershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_robie1373_psadaudits()
        {
            var downloadUrl = "https://github.com/robie1373/psadaudits";
            TestFiles("robie1373_psadaudits", downloadUrl);
        }

        [TestMethod]
        public void GitHub_iSynaptic_iSynaptic_MvcBootstrap()
        {
            var downloadUrl = "https://github.com/iSynaptic/iSynaptic.MvcBootstrap";
            TestFiles("iSynaptic_iSynaptic.MvcBootstrap", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_DeploySharePointVMs()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-DeploySharePointVMs";
            TestFiles("WindowsAzure-TrainingKit_HOL-DeploySharePointVMs", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AndrewGaspar_Steam_Management_for_PowerShell()
        {
            var downloadUrl = "https://github.com/AndrewGaspar/Steam-Management-for-PowerShell";
            TestFiles("AndrewGaspar_Steam-Management-for-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ajotwani_win_flip()
        {
            var downloadUrl = "https://github.com/ajotwani/win-flip";
            TestFiles("ajotwani_win-flip", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stein97_Powershell()
        {
            var downloadUrl = "https://github.com/stein97/Powershell";
            TestFiles("stein97_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thomykay_PoshConfluence()
        {
            var downloadUrl = "https://github.com/thomykay/PoshConfluence";
            TestFiles("thomykay_PoshConfluence", downloadUrl);
        }

        [TestMethod]
        public void GitHub_enderandpeter_win_a2enmod()
        {
            var downloadUrl = "https://github.com/enderandpeter/win-a2enmod";
            TestFiles("enderandpeter_win-a2enmod", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gamepin126_OpenDataGrab()
        {
            var downloadUrl = "https://github.com/gamepin126/OpenDataGrab";
            TestFiles("gamepin126_OpenDataGrab", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ThorstenHans_AzureAutomation()
        {
            var downloadUrl = "https://github.com/ThorstenHans/AzureAutomation";
            TestFiles("ThorstenHans_AzureAutomation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joehack3r_powershell_statsd()
        {
            var downloadUrl = "https://github.com/joehack3r/powershell-statsd";
            TestFiles("joehack3r_powershell-statsd", downloadUrl);
        }

        [TestMethod]
        public void GitHub_reed_vmware_powervdi()
        {
            var downloadUrl = "https://github.com/reed/vmware-powervdi";
            TestFiles("reed_vmware-powervdi", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stinaq_brownies()
        {
            var downloadUrl = "https://github.com/stinaq/brownies";
            TestFiles("stinaq_brownies", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mlec_Get_SysInfo()
        {
            var downloadUrl = "https://github.com/mlec/Get-SysInfo";
            TestFiles("mlec_Get-SysInfo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fifthecho_CloudStack_PowerShell()
        {
            var downloadUrl = "https://github.com/fifthecho/CloudStack-PowerShell";
            TestFiles("fifthecho_CloudStack-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_monitisexchange_Monitis_Azure_Monitoring()
        {
            var downloadUrl = "https://github.com/monitisexchange/Monitis-Azure-Monitoring";
            TestFiles("monitisexchange_Monitis-Azure-Monitoring", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tbentropy_SCCM2012PowerShell()
        {
            var downloadUrl = "https://github.com/tbentropy/SCCM2012PowerShell";
            TestFiles("tbentropy_SCCM2012PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jabrown85_WindowsPowershell()
        {
            var downloadUrl = "https://github.com/jabrown85/WindowsPowershell";
            TestFiles("jabrown85_WindowsPowershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bstromquist_fIEsta()
        {
            var downloadUrl = "https://github.com/bstromquist/fIEsta";
            TestFiles("bstromquist_fIEsta", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Harmster_Compile_doc_light()
        {
            var downloadUrl = "https://github.com/Harmster/Compile-doc-light";
            TestFiles("Harmster_Compile-doc-light", downloadUrl);
        }

        [TestMethod]
        public void GitHub_manojlds_cdposh()
        {
            var downloadUrl = "https://github.com/manojlds/cdposh";
            TestFiles("manojlds_cdposh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gravejester_stposh()
        {
            var downloadUrl = "https://github.com/gravejester/stposh";
            TestFiles("gravejester_stposh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrisdee_Scripts()
        {
            var downloadUrl = "https://github.com/chrisdee/Scripts";
            TestFiles("chrisdee_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xiaoyvr_NScaffold()
        {
            var downloadUrl = "https://github.com/xiaoyvr/NScaffold";
            TestFiles("xiaoyvr_NScaffold", downloadUrl);
        }

        [TestMethod]
        public void GitHub_micahlmartin_nugetpackages()
        {
            var downloadUrl = "https://github.com/micahlmartin/nugetpackages";
            TestFiles("micahlmartin_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_derantell_LaunchyScripts()
        {
            var downloadUrl = "https://github.com/derantell/LaunchyScripts";
            TestFiles("derantell_LaunchyScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jivkok_Chocolatey_Packages()
        {
            var downloadUrl = "https://github.com/jivkok/Chocolatey-Packages";
            TestFiles("jivkok_Chocolatey-Packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chaliy_default_template()
        {
            var downloadUrl = "https://github.com/chaliy/default_template";
            TestFiles("chaliy_default_template", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Zazcallabah_Playlist_Downloader()
        {
            var downloadUrl = "https://github.com/Zazcallabah/Playlist_Downloader";
            TestFiles("Zazcallabah_Playlist_Downloader", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dwdii_PsMapRedux()
        {
            var downloadUrl = "https://github.com/dwdii/PsMapRedux";
            TestFiles("dwdii_PsMapRedux", downloadUrl);
        }

        [TestMethod]
        public void GitHub_scarytom_ovum()
        {
            var downloadUrl = "https://github.com/scarytom/ovum";
            TestFiles("scarytom_ovum", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stevetait_BaneScripts()
        {
            var downloadUrl = "https://github.com/stevetait/BaneScripts";
            TestFiles("stevetait_BaneScripts", downloadUrl);
        }


        [TestMethod]
        public void GitHub_philipproplesch_Visual_Studio_Templates()
        {
            var downloadUrl = "https://github.com/philipproplesch/Visual-Studio-Templates";
            TestFiles("philipproplesch_Visual-Studio-Templates", downloadUrl);
        }

        [TestMethod]
        public void GitHub_khebbie_Puard()
        {
            var downloadUrl = "https://github.com/khebbie/Puard";
            TestFiles("khebbie_Puard", downloadUrl);
        }

        [TestMethod]
        public void GitHub_victorwoo_Get_ThingsDone()
        {
            var downloadUrl = "https://github.com/victorwoo/Get-ThingsDone";
            TestFiles("victorwoo_Get-ThingsDone", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ctolkien_Posh_Sprintly()
        {
            var downloadUrl = "https://github.com/ctolkien/Posh-Sprintly";
            TestFiles("ctolkien_Posh-Sprintly", downloadUrl);
        }

        [TestMethod]
        public void GitHub_idavis_PowerShellSummit()
        {
            var downloadUrl = "https://github.com/idavis/PowerShellSummit";
            TestFiles("idavis_PowerShellSummit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Chatham_PsTeamCity()
        {
            var downloadUrl = "https://github.com/Chatham/PsTeamCity";
            TestFiles("Chatham_PsTeamCity", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pppontus_Powershell_Create_User()
        {
            var downloadUrl = "https://github.com/pppontus/Powershell-Create-User";
            TestFiles("pppontus_Powershell-Create-User", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tsugliani_vCloudScripts()
        {
            var downloadUrl = "https://github.com/tsugliani/vCloudScripts";
            TestFiles("tsugliani_vCloudScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rbellamy_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/rbellamy/WindowsPowerShell";
            TestFiles("rbellamy_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_taliesins_talifun_filewatcher()
        {
            var downloadUrl = "https://github.com/taliesins/talifun-filewatcher";
            TestFiles("taliesins_talifun-filewatcher", downloadUrl);
        }

        [TestMethod]
        public void GitHub_anurse_PS_VsVars()
        {
            var downloadUrl = "https://github.com/anurse/PS-VsVars";
            TestFiles("anurse_PS-VsVars", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vopendata_scripts()
        {
            var downloadUrl = "https://github.com/vopendata/scripts";
            TestFiles("vopendata_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_OSTC_php_perf()
        {
            var downloadUrl = "https://github.com/OSTC/php-perf";
            TestFiles("OSTC_php-perf", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SinFulNard_get_unc_folder_acls()
        {
            var downloadUrl = "https://github.com/SinFulNard/get-unc-folder-acls";
            TestFiles("SinFulNard_get-unc-folder-acls", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Yandex_PDD()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Yandex.PDD";
            TestFiles("sergey-s-betke_ITG.Yandex.PDD", downloadUrl);
        }

        [TestMethod]
        public void GitHub_writeameer_dme_helpers()
        {
            var downloadUrl = "https://github.com/writeameer/dme_helpers";
            TestFiles("writeameer_dme_helpers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonicis_TestLab()
        {
            var downloadUrl = "https://github.com/jonicis/TestLab";
            TestFiles("jonicis_TestLab", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sridharn_MongoWindows()
        {
            var downloadUrl = "https://github.com/sridharn/MongoWindows";
            TestFiles("sridharn_MongoWindows", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nuxlli_cygwin_bootstrap()
        {
            var downloadUrl = "https://github.com/nuxlli/cygwin-bootstrap";
            TestFiles("nuxlli_cygwin-bootstrap", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DHGMS_Solutions_posh_nuget()
        {
            var downloadUrl = "https://github.com/DHGMS-Solutions/posh-nuget";
            TestFiles("DHGMS-Solutions_posh-nuget", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alexfalkowski_PMock()
        {
            var downloadUrl = "https://github.com/alexfalkowski/PMock";
            TestFiles("alexfalkowski_PMock", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jackiesingh_Windows_Server_Information_Gathering()
        {
            var downloadUrl = "https://github.com/jackiesingh/Windows-Server-Information-Gathering";
            TestFiles("jackiesingh_Windows-Server-Information-Gathering", downloadUrl);
        }

        [TestMethod]
        public void GitHub_elvslv_ComputerNetworks()
        {
            var downloadUrl = "https://github.com/elvslv/ComputerNetworks";
            TestFiles("elvslv_ComputerNetworks", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rancomma_MdbCommand()
        {
            var downloadUrl = "https://github.com/rancomma/MdbCommand";
            TestFiles("rancomma_MdbCommand", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mdkerner_AwesomeMart()
        {
            var downloadUrl = "https://github.com/mdkerner/AwesomeMart";
            TestFiles("mdkerner_AwesomeMart", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_HadoopOnWindowsAzure()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-HadoopOnWindowsAzure";
            TestFiles("WindowsAzure-TrainingKit_HOL-HadoopOnWindowsAzure", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stevenaskwith_DacIESvcPS()
        {
            var downloadUrl = "https://github.com/stevenaskwith/DacIESvcPS";
            TestFiles("stevenaskwith_DacIESvcPS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PowerShellKV()
        {
            var downloadUrl = "https://github.com/dfinke/PowerShellKV";
            TestFiles("dfinke_PowerShellKV", downloadUrl);
        }

        [TestMethod]
        public void GitHub_miensol_powerkick()
        {
            var downloadUrl = "https://github.com/miensol/powerkick";
            TestFiles("miensol_powerkick", downloadUrl);
        }

        [TestMethod]
        public void GitHub_megaboich_PowerShellViewEngine()
        {
            var downloadUrl = "https://github.com/megaboich/PowerShellViewEngine";
            TestFiles("megaboich_PowerShellViewEngine", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yanjustino_EFActiveRecord()
        {
            var downloadUrl = "https://github.com/yanjustino/EFActiveRecord";
            TestFiles("yanjustino_EFActiveRecord", downloadUrl);
        }

        [TestMethod]
        public void GitHub_michfield_devbox_choco()
        {
            var downloadUrl = "https://github.com/michfield/devbox-choco";
            TestFiles("michfield_devbox-choco", downloadUrl);
        }

        [TestMethod]
        public void GitHub_edymtt_nugetstandalone()
        {
            var downloadUrl = "https://github.com/edymtt/nugetstandalone";
            TestFiles("edymtt_nugetstandalone", downloadUrl);
        }

        [TestMethod]
        public void GitHub_uberspot_WindowsImageCapturing()
        {
            var downloadUrl = "https://github.com/uberspot/WindowsImageCapturing";
            TestFiles("uberspot_WindowsImageCapturing", downloadUrl);
        }



        [TestMethod]
        public void GitHub_apprendistastregone_PowershellCode()
        {
            var downloadUrl = "https://github.com/apprendistastregone/PowershellCode";
            TestFiles("apprendistastregone_PowershellCode", downloadUrl);
        }

        [TestMethod]
        public void GitHub_CoilDomain_DSC()
        {
            var downloadUrl = "https://github.com/CoilDomain/DSC";
            TestFiles("CoilDomain_DSC", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cloudbirdnet_StatsDPerfMon()
        {
            var downloadUrl = "https://github.com/cloudbirdnet/StatsDPerfMon";
            TestFiles("cloudbirdnet_StatsDPerfMon", downloadUrl);
        }

        [TestMethod]
        public void GitHub_roylarsen_windows_tools()
        {
            var downloadUrl = "https://github.com/roylarsen/windows_tools";
            TestFiles("roylarsen_windows_tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_CopperEgg_copperegg_powershell()
        {
            var downloadUrl = "https://github.com/CopperEgg/copperegg-powershell";
            TestFiles("CopperEgg_copperegg-powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MaxMelcher_ChocolateySharePointPackages()
        {
            var downloadUrl = "https://github.com/MaxMelcher/ChocolateySharePointPackages";
            TestFiles("MaxMelcher_ChocolateySharePointPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_Windows8AndMobileServices()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-Windows8AndMobileServices";
            TestFiles("WindowsAzure-TrainingKit_HOL-Windows8AndMobileServices", downloadUrl);
        }

        [TestMethod]
        public void GitHub_FallenGameR_Unduplicator()
        {
            var downloadUrl = "https://github.com/FallenGameR/Unduplicator";
            TestFiles("FallenGameR_Unduplicator", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jptacek_PowerShellOnePrompt()
        {
            var downloadUrl = "https://github.com/jptacek/PowerShellOnePrompt";
            TestFiles("jptacek_PowerShellOnePrompt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jpoehls_psbuildtools()
        {
            var downloadUrl = "https://github.com/jpoehls/psbuildtools";
            TestFiles("jpoehls_psbuildtools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jimmyp_WindowsInstall()
        {
            var downloadUrl = "https://github.com/jimmyp/WindowsInstall";
            TestFiles("jimmyp_WindowsInstall", downloadUrl);
        }

        [TestMethod]
        public void GitHub_FarManager_FarManager_chocolateyPackages()
        {
            var downloadUrl = "https://github.com/FarManager/FarManager-chocolateyPackages";
            TestFiles("FarManager_FarManager-chocolateyPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bitcrazed_PowerRazzle()
        {
            var downloadUrl = "https://github.com/bitcrazed/PowerRazzle";
            TestFiles("bitcrazed_PowerRazzle", downloadUrl);
        }

        [TestMethod]
        public void GitHub_codesharp_work()
        {
            var downloadUrl = "https://github.com/codesharp/work";
            TestFiles("codesharp_work", downloadUrl);
        }



        [TestMethod]
        public void GitHub_tobiaszuercher_PowerDeploy()
        {
            var downloadUrl = "https://github.com/tobiaszuercher/PowerDeploy";
            TestFiles("tobiaszuercher_PowerDeploy", downloadUrl);
        }

        [TestMethod]
        public void GitHub_damianh_Owin_EmbeddedResources()
        {
            var downloadUrl = "https://github.com/damianh/Owin.EmbeddedResources";
            TestFiles("damianh_Owin.EmbeddedResources", downloadUrl);
        }



        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_DeployingSQLServerForSharePoint()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-DeployingSQLServerForSharePoint";
            TestFiles("WindowsAzure-TrainingKit_HOL-DeployingSQLServerForSharePoint", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lholman_hipchat_ps()
        {
            var downloadUrl = "https://github.com/lholman/hipchat-ps";
            TestFiles("lholman_hipchat-ps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stevedocious_mockuPS()
        {
            var downloadUrl = "https://github.com/stevedocious/mockuPS";
            TestFiles("stevedocious_mockuPS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gep13_ChocolateyPackages()
        {
            var downloadUrl = "https://github.com/gep13/ChocolateyPackages";
            TestFiles("gep13_ChocolateyPackages", downloadUrl);
        }


        [TestMethod]
        public void GitHub_secretGeek_crumbs()
        {
            var downloadUrl = "https://github.com/secretGeek/crumbs";
            TestFiles("secretGeek_crumbs", downloadUrl);
        }

        [TestMethod]
        public void GitHub_newrelic_nuget_azure_cloud_services()
        {
            var downloadUrl = "https://github.com/newrelic/nuget-azure-cloud-services";
            TestFiles("newrelic_nuget-azure-cloud-services", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zommarin_AzPosh()
        {
            var downloadUrl = "https://github.com/zommarin/AzPosh";
            TestFiles("zommarin_AzPosh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kfosaaen_EmailGenerator()
        {
            var downloadUrl = "https://github.com/kfosaaen/EmailGenerator";
            TestFiles("kfosaaen_EmailGenerator", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jakerobinson_vCloud_Powershell()
        {
            var downloadUrl = "https://github.com/jakerobinson/vCloud-Powershell";
            TestFiles("jakerobinson_vCloud-Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joelmartinez_PowerShell_Bits()
        {
            var downloadUrl = "https://github.com/joelmartinez/PowerShell-Bits";
            TestFiles("joelmartinez_PowerShell-Bits", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fabriceleal_Imagify()
        {
            var downloadUrl = "https://github.com/fabriceleal/Imagify";
            TestFiles("fabriceleal_Imagify", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stevenaskwith_Focal_Lengths()
        {
            var downloadUrl = "https://github.com/stevenaskwith/Focal-Lengths";
            TestFiles("stevenaskwith_Focal-Lengths", downloadUrl);
        }

        [TestMethod]
        public void GitHub_legigor_ImageSorter()
        {
            var downloadUrl = "https://github.com/legigor/ImageSorter";
            TestFiles("legigor_ImageSorter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JoakimMolin_Script_Library()
        {
            var downloadUrl = "https://github.com/JoakimMolin/Script_Library";
            TestFiles("JoakimMolin_Script_Library", downloadUrl);
        }

        [TestMethod]
        public void GitHub_topas_TweetsDotNet()
        {
            var downloadUrl = "https://github.com/topas/TweetsDotNet";
            TestFiles("topas_TweetsDotNet", downloadUrl);
        }

        [TestMethod]
        public void GitHub_senpost_Scripts()
        {
            var downloadUrl = "https://github.com/senpost/Scripts";
            TestFiles("senpost_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chadbernick_Work()
        {
            var downloadUrl = "https://github.com/chadbernick/Work";
            TestFiles("chadbernick_Work", downloadUrl);
        }

        [TestMethod]
        public void GitHub_verbosemode_nps_dts_radius_logparser()
        {
            var downloadUrl = "https://github.com/verbosemode/nps-dts-radius-logparser";
            TestFiles("verbosemode_nps-dts-radius-logparser", downloadUrl);
        }

        [TestMethod]
        public void GitHub_msneeden_QuickBaseAPI_Powershell()
        {
            var downloadUrl = "https://github.com/msneeden/QuickBaseAPI-Powershell";
            TestFiles("msneeden_QuickBaseAPI-Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chaliy_nuget_flagsprites()
        {
            var downloadUrl = "https://github.com/chaliy/nuget-flagsprites";
            TestFiles("chaliy_nuget-flagsprites", downloadUrl);
        }

        [TestMethod]
        public void GitHub_topas_VarintBitConverter()
        {
            var downloadUrl = "https://github.com/topas/VarintBitConverter";
            TestFiles("topas_VarintBitConverter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_i_e_b_GitBuildPlatform()
        {
            var downloadUrl = "https://github.com/i-e-b/GitBuildPlatform";
            TestFiles("i-e-b_GitBuildPlatform", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jden_ChocoPackages()
        {
            var downloadUrl = "https://github.com/jden/ChocoPackages";
            TestFiles("jden_ChocoPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gsantovena_sysadmin()
        {
            var downloadUrl = "https://github.com/gsantovena/sysadmin";
            TestFiles("gsantovena_sysadmin", downloadUrl);
        }

        [TestMethod]
        public void GitHub_evenkiel_pomm()
        {
            var downloadUrl = "https://github.com/evenkiel/pomm";
            TestFiles("evenkiel_pomm", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kvarv_Fagkveld_PowerShell()
        {
            var downloadUrl = "https://github.com/kvarv/Fagkveld_PowerShell";
            TestFiles("kvarv_Fagkveld_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Phil_Factor_Foreach_DatabaseInServers()
        {
            var downloadUrl = "https://github.com/Phil-Factor/Foreach-DatabaseInServers";
            TestFiles("Phil-Factor_Foreach-DatabaseInServers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stevenaskwith_PSAzureBlobDirCopy()
        {
            var downloadUrl = "https://github.com/stevenaskwith/PSAzureBlobDirCopy";
            TestFiles("stevenaskwith_PSAzureBlobDirCopy", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Originalme_Powershell_Tools()
        {
            var downloadUrl = "https://github.com/Originalme/Powershell-Tools";
            TestFiles("Originalme_Powershell-Tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Stijnc_poshSCCM2012()
        {
            var downloadUrl = "https://github.com/Stijnc/poshSCCM2012";
            TestFiles("Stijnc_poshSCCM2012", downloadUrl);
        }

        [TestMethod]
        public void GitHub_devhawk_setup_powershell()
        {
            var downloadUrl = "https://github.com/devhawk/setup-powershell";
            TestFiles("devhawk_setup-powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mark202_Badger()
        {
            var downloadUrl = "https://github.com/mark202/Badger";
            TestFiles("mark202_Badger", downloadUrl);
        }

        [TestMethod]
        public void GitHub_harlalkap_FunctionsInternalTracker_1()
        {
            var downloadUrl = "https://github.com/harlalkap/FunctionsInternalTracker-1";
            TestFiles("harlalkap_FunctionsInternalTracker-1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tuxmania_autolab()
        {
            var downloadUrl = "https://github.com/tuxmania/autolab";
            TestFiles("tuxmania_autolab", downloadUrl);
        }

        [TestMethod]
        public void GitHub_danstuken_PowershellThings()
        {
            var downloadUrl = "https://github.com/danstuken/PowershellThings";
            TestFiles("danstuken_PowershellThings", downloadUrl);
        }

        [TestMethod]
        public void GitHub_charleshepner_CompassBestPracticesAnalyzer()
        {
            var downloadUrl = "https://github.com/charleshepner/CompassBestPracticesAnalyzer";
            TestFiles("charleshepner_CompassBestPracticesAnalyzer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_davecowart_mason()
        {
            var downloadUrl = "https://github.com/davecowart/mason";
            TestFiles("davecowart_mason", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ThorstenHans_AzureTopicREST()
        {
            var downloadUrl = "https://github.com/ThorstenHans/AzureTopicREST";
            TestFiles("ThorstenHans_AzureTopicREST", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AsteriskSteve_SEPSylinkSetup()
        {
            var downloadUrl = "https://github.com/AsteriskSteve/SEPSylinkSetup";
            TestFiles("AsteriskSteve_SEPSylinkSetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gaffiere_powercli()
        {
            var downloadUrl = "https://github.com/gaffiere/powercli";
            TestFiles("gaffiere_powercli", downloadUrl);
        }

        [TestMethod]
        public void GitHub_charleshepner_Scripts()
        {
            var downloadUrl = "https://github.com/charleshepner/Scripts";
            TestFiles("charleshepner_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joshclark_dotfiles()
        {
            var downloadUrl = "https://github.com/joshclark/dotfiles";
            TestFiles("joshclark_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mdellanoce_chocolateypackages()
        {
            var downloadUrl = "https://github.com/mdellanoce/chocolateypackages";
            TestFiles("mdellanoce_chocolateypackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jammycakes_PsShortcuts()
        {
            var downloadUrl = "https://github.com/jammycakes/PsShortcuts";
            TestFiles("jammycakes_PsShortcuts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tiernano_TiernanOSharedScripts()
        {
            var downloadUrl = "https://github.com/tiernano/TiernanOSharedScripts";
            TestFiles("tiernano_TiernanOSharedScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TechHike_Cruiser()
        {
            var downloadUrl = "https://github.com/TechHike/Cruiser";
            TestFiles("TechHike_Cruiser", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Cecildt_SQL_Server_Scripts()
        {
            var downloadUrl = "https://github.com/Cecildt/SQL-Server-Scripts";
            TestFiles("Cecildt_SQL-Server-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adminian_PowerProfile()
        {
            var downloadUrl = "https://github.com/adminian/PowerProfile";
            TestFiles("adminian_PowerProfile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sangwizz_PSSyslog()
        {
            var downloadUrl = "https://github.com/sangwizz/PSSyslog";
            TestFiles("sangwizz_PSSyslog", downloadUrl);
        }

        [TestMethod]
        public void GitHub_shahwahed_vworld_scripts()
        {
            var downloadUrl = "https://github.com/shahwahed/vworld.scripts";
            TestFiles("shahwahed_vworld.scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_asyncsrc_Backup_Parser()
        {
            var downloadUrl = "https://github.com/asyncsrc/Backup-Parser";
            TestFiles("asyncsrc_Backup-Parser", downloadUrl);
        }

        [TestMethod]
        public void GitHub_asyncsrc_MSMQ_Monitor()
        {
            var downloadUrl = "https://github.com/asyncsrc/MSMQ-Monitor";
            TestFiles("asyncsrc_MSMQ-Monitor", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wishstudio_AquaTestSuite()
        {
            var downloadUrl = "https://github.com/wishstudio/AquaTestSuite";
            TestFiles("wishstudio_AquaTestSuite", downloadUrl);
        }

        [TestMethod]
        public void GitHub_red_stronghold_SubstituteApp_EPiServer()
        {
            var downloadUrl = "https://github.com/red-stronghold/SubstituteApp.EPiServer";
            TestFiles("red-stronghold_SubstituteApp.EPiServer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ebh_SQLRefreshEnviroment()
        {
            var downloadUrl = "https://github.com/ebh/SQLRefreshEnviroment";
            TestFiles("ebh_SQLRefreshEnviroment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Avkash_AzurePowershellmenu()
        {
            var downloadUrl = "https://github.com/Avkash/AzurePowershellmenu";
            TestFiles("Avkash_AzurePowershellmenu", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mnaoumov_githooks()
        {
            var downloadUrl = "https://github.com/mnaoumov/githooks";
            TestFiles("mnaoumov_githooks", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adeel1_Powershell()
        {
            var downloadUrl = "https://github.com/adeel1/Powershell";
            TestFiles("adeel1_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_davecowart_posh_files()
        {
            var downloadUrl = "https://github.com/davecowart/posh-files";
            TestFiles("davecowart_posh-files", downloadUrl);
        }

        [TestMethod]
        public void GitHub_myappleguy_Scripts()
        {
            var downloadUrl = "https://github.com/myappleguy/Scripts";
            TestFiles("myappleguy_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_caevyn_luaChocolatey()
        {
            var downloadUrl = "https://github.com/caevyn/luaChocolatey";
            TestFiles("caevyn_luaChocolatey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_glombard_Scripts()
        {
            var downloadUrl = "https://github.com/glombard/Scripts";
            TestFiles("glombard_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Evoroth_Powershell()
        {
            var downloadUrl = "https://github.com/Evoroth/Powershell";
            TestFiles("Evoroth_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tugberkugurlu_WindowsAzureScripts()
        {
            var downloadUrl = "https://github.com/tugberkugurlu/WindowsAzureScripts";
            TestFiles("tugberkugurlu_WindowsAzureScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ralish_winfiles()
        {
            var downloadUrl = "https://github.com/ralish/winfiles";
            TestFiles("ralish_winfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kieranties_PSSitecoreItemWebApi()
        {
            var downloadUrl = "https://github.com/Kieranties/PSSitecoreItemWebApi";
            TestFiles("Kieranties_PSSitecoreItemWebApi", downloadUrl);
        }

        [TestMethod]
        public void GitHub_linus123_DatabaseVersion()
        {
            var downloadUrl = "https://github.com/linus123/DatabaseVersion";
            TestFiles("linus123_DatabaseVersion", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mintsoft_MintSSID_Script()
        {
            var downloadUrl = "https://github.com/mintsoft/MintSSID_Script";
            TestFiles("mintsoft_MintSSID_Script", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tquizzle_PowerCLI()
        {
            var downloadUrl = "https://github.com/tquizzle/PowerCLI";
            TestFiles("tquizzle_PowerCLI", downloadUrl);
        }

        [TestMethod]
        public void GitHub_albertomoss_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/albertomoss/chocolatey-packages";
            TestFiles("albertomoss_chocolatey-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TimGThomas_PowerShell_Profile()
        {
            var downloadUrl = "https://github.com/TimGThomas/PowerShell-Profile";
            TestFiles("TimGThomas_PowerShell-Profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sbussinger_chocolatey()
        {
            var downloadUrl = "https://github.com/sbussinger/chocolatey";
            TestFiles("sbussinger_chocolatey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dcjulian29_nuget_packages()
        {
            var downloadUrl = "https://github.com/dcjulian29/nuget-packages";
            TestFiles("dcjulian29_nuget-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SneWs_PowerShell_Helpers()
        {
            var downloadUrl = "https://github.com/SneWs/PowerShell-Helpers";
            TestFiles("SneWs_PowerShell-Helpers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Iristyle_Posh_VsVars()
        {
            var downloadUrl = "https://github.com/Iristyle/Posh-VsVars";
            TestFiles("Iristyle_Posh-VsVars", downloadUrl);
        }

        [TestMethod]
        public void GitHub_eddiegroves_dotfiles()
        {
            var downloadUrl = "https://github.com/eddiegroves/dotfiles";
            TestFiles("eddiegroves_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jacobq_PowerShellDDNS()
        {
            var downloadUrl = "https://github.com/jacobq/PowerShellDDNS";
            TestFiles("jacobq_PowerShellDDNS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alanrenouf_vCheck_vCDAudit()
        {
            var downloadUrl = "https://github.com/alanrenouf/vCheck-vCDAudit";
            TestFiles("alanrenouf_vCheck-vCDAudit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jtuttas_PowershellMusterloesungen()
        {
            var downloadUrl = "https://github.com/jtuttas/PowershellMusterloesungen";
            TestFiles("jtuttas_PowershellMusterloesungen", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jole78_wdp()
        {
            var downloadUrl = "https://github.com/jole78/wdp";
            TestFiles("jole78_wdp", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ralbu_config()
        {
            var downloadUrl = "https://github.com/ralbu/config";
            TestFiles("ralbu_config", downloadUrl);
        }

        [TestMethod]
        public void GitHub_powareverb_AutoSPInstaller()
        {
            var downloadUrl = "https://github.com/powareverb/AutoSPInstaller";
            TestFiles("powareverb_AutoSPInstaller", downloadUrl);
        }

        [TestMethod]
        public void GitHub_BretFisher_AutoSPInstaller_User_Creator()
        {
            var downloadUrl = "https://github.com/BretFisher/AutoSPInstaller-User-Creator";
            TestFiles("BretFisher_AutoSPInstaller-User-Creator", downloadUrl);
        }

        [TestMethod]
        public void GitHub_doblak_ps_clean()
        {
            var downloadUrl = "https://github.com/doblak/ps-clean";
            TestFiles("doblak_ps-clean", downloadUrl);
        }

        [TestMethod]
        public void GitHub_recklesswaltz_PowerShell_Minify()
        {
            var downloadUrl = "https://github.com/recklesswaltz/PowerShell-Minify";
            TestFiles("recklesswaltz_PowerShell-Minify", downloadUrl);
        }

        [TestMethod]
        public void GitHub_itfishingpole_PowerShell()
        {
            var downloadUrl = "https://github.com/itfishingpole/PowerShell";
            TestFiles("itfishingpole_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_eakron_ChocolateyPackages()
        {
            var downloadUrl = "https://github.com/eakron/ChocolateyPackages";
            TestFiles("eakron_ChocolateyPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_k2workflow_K2PowershellLibaries()
        {
            var downloadUrl = "https://github.com/k2workflow/K2PowershellLibaries";
            TestFiles("k2workflow_K2PowershellLibaries", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gwaldo_dotfiles()
        {
            var downloadUrl = "https://github.com/gwaldo/dotfiles";
            TestFiles("gwaldo_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mastoj_OctoWebSetup()
        {
            var downloadUrl = "https://github.com/mastoj/OctoWebSetup";
            TestFiles("mastoj_OctoWebSetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kyzog_dot_files()
        {
            var downloadUrl = "https://github.com/Kyzog/dot-files";
            TestFiles("Kyzog_dot-files", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bbuchalter_powercli_cloner()
        {
            var downloadUrl = "https://github.com/bbuchalter/powercli_cloner";
            TestFiles("bbuchalter_powercli_cloner", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bkeegan_PowershellBoilerplate()
        {
            var downloadUrl = "https://github.com/bkeegan/PowershellBoilerplate";
            TestFiles("bkeegan_PowershellBoilerplate", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Yandex()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Yandex";
            TestFiles("sergey-s-betke_ITG.Yandex", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tkmtmkt_WindowsHome()
        {
            var downloadUrl = "https://github.com/tkmtmkt/WindowsHome";
            TestFiles("tkmtmkt_WindowsHome", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adamclerk_FunWithPowershell2012()
        {
            var downloadUrl = "https://github.com/adamclerk/FunWithPowershell2012";
            TestFiles("adamclerk_FunWithPowershell2012", downloadUrl);
        }

        [TestMethod]
        public void GitHub_falkenmire_MicrosoftUC()
        {
            var downloadUrl = "https://github.com/falkenmire/MicrosoftUC";
            TestFiles("falkenmire_MicrosoftUC", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gsherman_powershell()
        {
            var downloadUrl = "https://github.com/gsherman/powershell";
            TestFiles("gsherman_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonicis_TestTutorial()
        {
            var downloadUrl = "https://github.com/jonicis/TestTutorial";
            TestFiles("jonicis_TestTutorial", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Jaa_c_bc_thesis()
        {
            var downloadUrl = "https://github.com/Jaa-c/bc-thesis";
            TestFiles("Jaa-c_bc-thesis", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dettogni_BackUp_Powershell()
        {
            var downloadUrl = "https://github.com/dettogni/BackUp-Powershell";
            TestFiles("dettogni_BackUp-Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_uncas_PesterDemo()
        {
            var downloadUrl = "https://github.com/uncas/PesterDemo";
            TestFiles("uncas_PesterDemo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nippe_PowerShell_snippets()
        {
            var downloadUrl = "https://github.com/nippe/PowerShell-snippets";
            TestFiles("nippe_PowerShell-snippets", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jftuga_Windows()
        {
            var downloadUrl = "https://github.com/jftuga/Windows";
            TestFiles("jftuga_Windows", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kintar_powershell()
        {
            var downloadUrl = "https://github.com/Kintar/powershell";
            TestFiles("Kintar_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Iristyle_Tahiti()
        {
            var downloadUrl = "https://github.com/Iristyle/Tahiti";
            TestFiles("Iristyle_Tahiti", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jzablocki_node_ps()
        {
            var downloadUrl = "https://github.com/jzablocki/node-ps";
            TestFiles("jzablocki_node-ps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_robrodi_SmallStuff()
        {
            var downloadUrl = "https://github.com/robrodi/SmallStuff";
            TestFiles("robrodi_SmallStuff", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jimmyp_OSXInstall()
        {
            var downloadUrl = "https://github.com/jimmyp/OSXInstall";
            TestFiles("jimmyp_OSXInstall", downloadUrl);
        }

        [TestMethod]
        public void GitHub_keizer619_practical01()
        {
            var downloadUrl = "https://github.com/keizer619/practical01";
            TestFiles("keizer619_practical01", downloadUrl);
        }

        [TestMethod]
        public void GitHub_samirkseth_WindowsPowershell()
        {
            var downloadUrl = "https://github.com/samirkseth/WindowsPowershell";
            TestFiles("samirkseth_WindowsPowershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TimGThomas_mvc_app_cache()
        {
            var downloadUrl = "https://github.com/TimGThomas/mvc-app-cache";
            TestFiles("TimGThomas_mvc-app-cache", downloadUrl);
        }

        [TestMethod]
        public void GitHub_melarenigma_powershell()
        {
            var downloadUrl = "https://github.com/melarenigma/powershell";
            TestFiles("melarenigma_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_naeemkhedarun_psclass()
        {
            var downloadUrl = "https://github.com/naeemkhedarun/psclass";
            TestFiles("naeemkhedarun_psclass", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zombietech_irontech()
        {
            var downloadUrl = "https://github.com/zombietech/irontech";
            TestFiles("zombietech_irontech", downloadUrl);
        }

        [TestMethod]
        public void GitHub_guesshoo_build_tools()
        {
            var downloadUrl = "https://github.com/guesshoo/build.tools";
            TestFiles("guesshoo_build.tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pppontus_Email_Password_Reminder()
        {
            var downloadUrl = "https://github.com/pppontus/Email-Password-Reminder";
            TestFiles("pppontus_Email-Password-Reminder", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DamianReeves_pstachio()
        {
            var downloadUrl = "https://github.com/DamianReeves/pstachio";
            TestFiles("DamianReeves_pstachio", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jimmah_ps_files()
        {
            var downloadUrl = "https://github.com/jimmah/ps-files";
            TestFiles("jimmah_ps-files", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WimAtIHomer_GenericRepository()
        {
            var downloadUrl = "https://github.com/WimAtIHomer/GenericRepository";
            TestFiles("WimAtIHomer_GenericRepository", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vicentedealencar_powershell_backup_script()
        {
            var downloadUrl = "https://github.com/vicentedealencar/powershell-backup-script";
            TestFiles("vicentedealencar_powershell-backup-script", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fabiano_NHBinder()
        {
            var downloadUrl = "https://github.com/fabiano/NHBinder";
            TestFiles("fabiano_NHBinder", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mastoj_OctoPack_MigratorDotnet()
        {
            var downloadUrl = "https://github.com/mastoj/OctoPack.MigratorDotnet";
            TestFiles("mastoj_OctoPack.MigratorDotnet", downloadUrl);
        }

        [TestMethod]
        public void GitHub_brianaddicks_PowerShell()
        {
            var downloadUrl = "https://github.com/brianaddicks/PowerShell";
            TestFiles("brianaddicks_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AndrewGail_Powershell()
        {
            var downloadUrl = "https://github.com/AndrewGail/Powershell";
            TestFiles("AndrewGail_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fuhoi_ps_auto_console()
        {
            var downloadUrl = "https://github.com/fuhoi/ps-auto-console";
            TestFiles("fuhoi_ps-auto-console", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bennettp123_dns_he_net_updater()
        {
            var downloadUrl = "https://github.com/bennettp123/dns.he.net-updater";
            TestFiles("bennettp123_dns.he.net-updater", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ganesha8shiva_timesheet()
        {
            var downloadUrl = "https://github.com/ganesha8shiva/timesheet";
            TestFiles("ganesha8shiva_timesheet", downloadUrl);
        }

        [TestMethod]
        public void GitHub_klumsy_Quick_and_Dirty_PowerShell_Unit_Test()
        {
            var downloadUrl = "https://github.com/klumsy/Quick-and-Dirty-PowerShell-Unit-Test";
            TestFiles("klumsy_Quick-and-Dirty-PowerShell-Unit-Test", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adrianosepe_mobi_curso1()
        {
            var downloadUrl = "https://github.com/adrianosepe/mobi-curso1";
            TestFiles("adrianosepe_mobi-curso1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jkodroff_UnderSharp()
        {
            var downloadUrl = "https://github.com/jkodroff/UnderSharp";
            TestFiles("jkodroff_UnderSharp", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Durgaprasad_Budhwani_Net_Migrater_v4_5()
        {
            var downloadUrl = "https://github.com/Durgaprasad-Budhwani/Net-Migrater-v4.5";
            TestFiles("Durgaprasad-Budhwani_Net-Migrater-v4.5", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dmcliver_TrafficInfo()
        {
            var downloadUrl = "https://github.com/dmcliver/TrafficInfo";
            TestFiles("dmcliver_TrafficInfo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fabriceleal_fs_lang_template()
        {
            var downloadUrl = "https://github.com/fabriceleal/fs-lang-template";
            TestFiles("fabriceleal_fs-lang-template", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jeffhandley_JeffHandley_NuGetPS()
        {
            var downloadUrl = "https://github.com/jeffhandley/JeffHandley.NuGetPS";
            TestFiles("jeffhandley_JeffHandley.NuGetPS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_david_mclean_Powershell()
        {
            var downloadUrl = "https://github.com/david-mclean/Powershell";
            TestFiles("david-mclean_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bgriffin20_Audit_AD()
        {
            var downloadUrl = "https://github.com/bgriffin20/Audit-AD";
            TestFiles("bgriffin20_Audit-AD", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ThorstenHans_DocAve_and_PowerShell_Webinar()
        {
            var downloadUrl = "https://github.com/ThorstenHans/DocAve-and-PowerShell-Webinar";
            TestFiles("ThorstenHans_DocAve-and-PowerShell-Webinar", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mschinz_powershell()
        {
            var downloadUrl = "https://github.com/mschinz/powershell";
            TestFiles("mschinz_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_danjellz_VMwareScripts()
        {
            var downloadUrl = "https://github.com/danjellz/VMwareScripts";
            TestFiles("danjellz_VMwareScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jen20_build_woftam()
        {
            var downloadUrl = "https://github.com/jen20/build-woftam";
            TestFiles("jen20_build-woftam", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pmcgrath_powershellprofile()
        {
            var downloadUrl = "https://github.com/pmcgrath/powershellprofile";
            TestFiles("pmcgrath_powershellprofile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WarrenDB_NancyEFScaffolder()
        {
            var downloadUrl = "https://github.com/WarrenDB/NancyEFScaffolder";
            TestFiles("WarrenDB_NancyEFScaffolder", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kkhanusat_TestApplication()
        {
            var downloadUrl = "https://github.com/kkhanusat/TestApplication";
            TestFiles("kkhanusat_TestApplication", downloadUrl);
        }

        [TestMethod]
        public void GitHub_d4n13_ripple_ps_websocket()
        {
            var downloadUrl = "https://github.com/d4n13/ripple-ps-websocket";
            TestFiles("d4n13_ripple-ps-websocket", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jstangroome_Tfs2012ProcessUpgrade()
        {
            var downloadUrl = "https://github.com/jstangroome/Tfs2012ProcessUpgrade";
            TestFiles("jstangroome_Tfs2012ProcessUpgrade", downloadUrl);
        }

        [TestMethod]
        public void GitHub_whatcomtrans_PermissionGroups()
        {
            var downloadUrl = "https://github.com/whatcomtrans/PermissionGroups";
            TestFiles("whatcomtrans_PermissionGroups", downloadUrl);
        }

        [TestMethod]
        public void GitHub_keithbloom_powershell_profile()
        {
            var downloadUrl = "https://github.com/keithbloom/powershell-profile";
            TestFiles("keithbloom_powershell-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WinSec_PSScripts()
        {
            var downloadUrl = "https://github.com/WinSec/PSScripts";
            TestFiles("WinSec_PSScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cajones_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/cajones/WindowsPowerShell";
            TestFiles("cajones_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_shank8_RSS_Horoscopes()
        {
            var downloadUrl = "https://github.com/shank8/RSS-Horoscopes";
            TestFiles("shank8_RSS-Horoscopes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kfosaaen_PS_MultiCrack_kf_branch()
        {
            var downloadUrl = "https://github.com/kfosaaen/PS_MultiCrack_kf_branch";
            TestFiles("kfosaaen_PS_MultiCrack_kf_branch", downloadUrl);
        }

        [TestMethod]
        public void GitHub_e11it_powershell()
        {
            var downloadUrl = "https://github.com/e11it/powershell";
            TestFiles("e11it_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_shirp_dotfiles()
        {
            var downloadUrl = "https://github.com/shirp/dotfiles";
            TestFiles("shirp_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_appetiteoven_badass()
        {
            var downloadUrl = "https://github.com/appetiteoven/badass";
            TestFiles("appetiteoven_badass", downloadUrl);
        }

        [TestMethod]
        public void GitHub_asyncsrc_ADFS_2_0_add_relyingpartytrust()
        {
            var downloadUrl = "https://github.com/asyncsrc/ADFS-2.0-add-relyingpartytrust";
            TestFiles("asyncsrc_ADFS-2.0-add-relyingpartytrust", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mrxinu_solarwinds()
        {
            var downloadUrl = "https://github.com/mrxinu/solarwinds";
            TestFiles("mrxinu_solarwinds", downloadUrl);
        }

        [TestMethod]
        public void GitHub_EugeneKha_Scripts()
        {
            var downloadUrl = "https://github.com/EugeneKha/Scripts";
            TestFiles("EugeneKha_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jjrdk_ScriptCs_Metrics()
        {
            var downloadUrl = "https://github.com/jjrdk/ScriptCs.Metrics";
            TestFiles("jjrdk_ScriptCs.Metrics", downloadUrl);
        }

        [TestMethod]
        public void GitHub_NetSPI_PS_MultiCrack()
        {
            var downloadUrl = "https://github.com/NetSPI/PS_MultiCrack";
            TestFiles("NetSPI_PS_MultiCrack", downloadUrl);
        }

        [TestMethod]
        public void GitHub_anurse_SkyBox()
        {
            var downloadUrl = "https://github.com/anurse/SkyBox";
            TestFiles("anurse_SkyBox", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chocolatey_puppet_chocolatey_handsonlab()
        {
            var downloadUrl = "https://github.com/chocolatey/puppet-chocolatey-handsonlab";
            TestFiles("chocolatey_puppet-chocolatey-handsonlab", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jennings_PsMisc()
        {
            var downloadUrl = "https://github.com/jennings/PsMisc";
            TestFiles("jennings_PsMisc", downloadUrl);
        }

        [TestMethod]
        public void GitHub_naasir_sugar_ps()
        {
            var downloadUrl = "https://github.com/naasir/sugar.ps";
            TestFiles("naasir_sugar.ps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ohtake_spl_greeting()
        {
            var downloadUrl = "https://github.com/ohtake/spl-greeting";
            TestFiles("ohtake_spl-greeting", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lukesampson_scoop()
        {
            var downloadUrl = "https://github.com/lukesampson/scoop";
            TestFiles("lukesampson_scoop", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xjlittle_itmta()
        {
            var downloadUrl = "https://github.com/xjlittle/itmta";
            TestFiles("xjlittle_itmta", downloadUrl);
        }

        [TestMethod]
        public void GitHub_corners_Powershell_Tools()
        {
            var downloadUrl = "https://github.com/corners/Powershell-Tools";
            TestFiles("corners_Powershell-Tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fabriceleal_PsWebServer()
        {
            var downloadUrl = "https://github.com/fabriceleal/PsWebServer";
            TestFiles("fabriceleal_PsWebServer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_EKibort_test()
        {
            var downloadUrl = "https://github.com/EKibort/test";
            TestFiles("EKibort_test", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DetectiveEric_PowerShell_ETL_SQL_Server()
        {
            var downloadUrl = "https://github.com/DetectiveEric/PowerShell-ETL-SQL-Server";
            TestFiles("DetectiveEric_PowerShell-ETL-SQL-Server", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lholman_AutoBot_Scripts()
        {
            var downloadUrl = "https://github.com/lholman/AutoBot-Scripts";
            TestFiles("lholman_AutoBot-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ctgswallow_vmware_powershell()
        {
            var downloadUrl = "https://github.com/ctgswallow/vmware-powershell";
            TestFiles("ctgswallow_vmware-powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jbuedel_project_commands()
        {
            var downloadUrl = "https://github.com/jbuedel/project-commands";
            TestFiles("jbuedel_project-commands", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jrolstad_Rolstad_co()
        {
            var downloadUrl = "https://github.com/jrolstad/Rolstad.co";
            TestFiles("jrolstad_Rolstad.co", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bwunder_EHAdmin()
        {
            var downloadUrl = "https://github.com/bwunder/EHAdmin";
            TestFiles("bwunder_EHAdmin", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ejreynolds_powershell_prompt()
        {
            var downloadUrl = "https://github.com/ejreynolds/powershell-prompt";
            TestFiles("ejreynolds_powershell-prompt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rancomma_VBModule()
        {
            var downloadUrl = "https://github.com/rancomma/VBModule";
            TestFiles("rancomma_VBModule", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chaliy_pswheels()
        {
            var downloadUrl = "https://github.com/chaliy/pswheels";
            TestFiles("chaliy_pswheels", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mbergal_resume()
        {
            var downloadUrl = "https://github.com/mbergal/resume";
            TestFiles("mbergal_resume", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pagebrooks_PowerShell_Profile()
        {
            var downloadUrl = "https://github.com/pagebrooks/PowerShell-Profile";
            TestFiles("pagebrooks_PowerShell-Profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jcenglish_ITAuto_KillAV()
        {
            var downloadUrl = "https://github.com/jcenglish/ITAuto-KillAV";
            TestFiles("jcenglish_ITAuto-KillAV", downloadUrl);
        }

        [TestMethod]
        public void GitHub_redacted_inc_minecraft_tools()
        {
            var downloadUrl = "https://github.com/redacted-inc/minecraft-tools";
            TestFiles("redacted-inc_minecraft-tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_davidhrbac_vmware_scripts()
        {
            var downloadUrl = "https://github.com/davidhrbac/vmware-scripts";
            TestFiles("davidhrbac_vmware-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wanion_GroupPolicy()
        {
            var downloadUrl = "https://github.com/wanion/GroupPolicy";
            TestFiles("wanion_GroupPolicy", downloadUrl);
        }

        [TestMethod]
        public void GitHub_codito_configs_win()
        {
            var downloadUrl = "https://github.com/codito/configs-win";
            TestFiles("codito_configs-win", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hansraj316_Windows_8_Apps()
        {
            var downloadUrl = "https://github.com/hansraj316/Windows-8-Apps";
            TestFiles("hansraj316_Windows-8-Apps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jmreicha_lyncuserimport()
        {
            var downloadUrl = "https://github.com/jmreicha/lyncuserimport";
            TestFiles("jmreicha_lyncuserimport", downloadUrl);
        }

        [TestMethod]
        public void GitHub_anweiss_SC2012PowerShellScripts()
        {
            var downloadUrl = "https://github.com/anweiss/SC2012PowerShellScripts";
            TestFiles("anweiss_SC2012PowerShellScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Outlook()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Outlook";
            TestFiles("sergey-s-betke_ITG.Outlook", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mklstffn_backup_syncer()
        {
            var downloadUrl = "https://github.com/mklstffn/backup-syncer";
            TestFiles("mklstffn_backup-syncer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WouterSpaans_PowerShell_Script_Library()
        {
            var downloadUrl = "https://github.com/WouterSpaans/PowerShell-Script-Library";
            TestFiles("WouterSpaans_PowerShell-Script-Library", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mbergmann_Pustache()
        {
            var downloadUrl = "https://github.com/mbergmann/Pustache";
            TestFiles("mbergmann_Pustache", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SinFulNard_get_LUN_space()
        {
            var downloadUrl = "https://github.com/SinFulNard/get-LUN-space";
            TestFiles("SinFulNard_get-LUN-space", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dldorsey_cas_odyssey()
        {
            var downloadUrl = "https://github.com/dldorsey/cas-odyssey";
            TestFiles("dldorsey_cas-odyssey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hunt3ri_AzureCdn_Me_Nant()
        {
            var downloadUrl = "https://github.com/hunt3ri/AzureCdn.Me.Nant";
            TestFiles("hunt3ri_AzureCdn.Me.Nant", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mfrew_hermes()
        {
            var downloadUrl = "https://github.com/mfrew/hermes";
            TestFiles("mfrew_hermes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_awithy_AzureServiceBusExample()
        {
            var downloadUrl = "https://github.com/awithy/AzureServiceBusExample";
            TestFiles("awithy_AzureServiceBusExample", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jblondeau2_powershell_config()
        {
            var downloadUrl = "https://github.com/jblondeau2/powershell-config";
            TestFiles("jblondeau2_powershell-config", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Utils()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Utils";
            TestFiles("sergey-s-betke_ITG.Utils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sbanwart_biztalk_scripts()
        {
            var downloadUrl = "https://github.com/sbanwart/biztalk-scripts";
            TestFiles("sbanwart_biztalk-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JamesDunne_DeployPS1()
        {
            var downloadUrl = "https://github.com/JamesDunne/DeployPS1";
            TestFiles("JamesDunne_DeployPS1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JuanKRuiz_jkRssReader()
        {
            var downloadUrl = "https://github.com/JuanKRuiz/jkRssReader";
            TestFiles("JuanKRuiz_jkRssReader", downloadUrl);
        }

        [TestMethod]
        public void GitHub_opentable_powershelltransformation()
        {
            var downloadUrl = "https://github.com/opentable/powershelltransformation";
            TestFiles("opentable_powershelltransformation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_psget_psget_kit()
        {
            var downloadUrl = "https://github.com/psget/psget_kit";
            TestFiles("psget_psget_kit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_matthewskelton_Psychal()
        {
            var downloadUrl = "https://github.com/matthewskelton/Psychal";
            TestFiles("matthewskelton_Psychal", downloadUrl);
        }

        [TestMethod]
        public void GitHub_haiduc32_EF_Fake()
        {
            var downloadUrl = "https://github.com/haiduc32/EF.Fake";
            TestFiles("haiduc32_EF.Fake", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lancehunt_Dev_Setup()
        {
            var downloadUrl = "https://github.com/lancehunt/Dev.Setup";
            TestFiles("lancehunt_Dev.Setup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mbcrute_dotfiles()
        {
            var downloadUrl = "https://github.com/mbcrute/dotfiles";
            TestFiles("mbcrute_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dotCypress_ps_git_ignores()
        {
            var downloadUrl = "https://github.com/dotCypress/ps-git-ignores";
            TestFiles("dotCypress_ps-git-ignores", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TaoK_PS_Snippets()
        {
            var downloadUrl = "https://github.com/TaoK/PS-Snippets";
            TestFiles("TaoK_PS-Snippets", downloadUrl);
        }

        [TestMethod]
        public void GitHub_awanrky_powershell_profile()
        {
            var downloadUrl = "https://github.com/awanrky/powershell-profile";
            TestFiles("awanrky_powershell-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_spawnlabs_iscsi_control()
        {
            var downloadUrl = "https://github.com/spawnlabs/iscsi-control";
            TestFiles("spawnlabs_iscsi-control", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PProvost_PowerTab()
        {
            var downloadUrl = "https://github.com/PProvost/PowerTab";
            TestFiles("PProvost_PowerTab", downloadUrl);
        }

        [TestMethod]
        public void GitHub_codeimpossible_powershell_profile()
        {
            var downloadUrl = "https://github.com/codeimpossible/powershell-profile";
            TestFiles("codeimpossible_powershell-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Conde_Nast_Digital_GitDeploy_SysScripts()
        {
            var downloadUrl = "https://github.com/Conde-Nast-Digital/GitDeploy-SysScripts";
            TestFiles("Conde-Nast-Digital_GitDeploy-SysScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AnthonyMastrean_nugetpackages()
        {
            var downloadUrl = "https://github.com/AnthonyMastrean/nugetpackages";
            TestFiles("AnthonyMastrean_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thenexustv_tntv_backup()
        {
            var downloadUrl = "https://github.com/thenexustv/tntv-backup";
            TestFiles("thenexustv_tntv-backup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_Windows8AndMobileServicesJS()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-Windows8AndMobileServicesJS";
            TestFiles("WindowsAzure-TrainingKit_HOL-Windows8AndMobileServicesJS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jbuedel_posh_josh()
        {
            var downloadUrl = "https://github.com/jbuedel/posh-josh";
            TestFiles("jbuedel_posh-josh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rismoney_chocolatey_git()
        {
            var downloadUrl = "https://github.com/rismoney/chocolatey-git";
            TestFiles("rismoney_chocolatey-git", downloadUrl);
        }

        [TestMethod]
        public void GitHub_robertwilczynski_pUtils()
        {
            var downloadUrl = "https://github.com/robertwilczynski/pUtils";
            TestFiles("robertwilczynski_pUtils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_segilbert_nuget_packages()
        {
            var downloadUrl = "https://github.com/segilbert/nuget.packages";
            TestFiles("segilbert_nuget.packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pekkah_Autofac_Conventions()
        {
            var downloadUrl = "https://github.com/pekkah/Autofac.Conventions";
            TestFiles("pekkah_Autofac.Conventions", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stejan_CQ_Modules()
        {
            var downloadUrl = "https://github.com/stejan/CQ-Modules";
            TestFiles("stejan_CQ-Modules", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sandrinodimattia_WindowsAzure_EnableRemotePowerShellForVM()
        {
            var downloadUrl = "https://github.com/sandrinodimattia/WindowsAzure-EnableRemotePowerShellForVM";
            TestFiles("sandrinodimattia_WindowsAzure-EnableRemotePowerShellForVM", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WhatIfWeDigDeeper_TekPubContrib()
        {
            var downloadUrl = "https://github.com/WhatIfWeDigDeeper/TekPubContrib";
            TestFiles("WhatIfWeDigDeeper_TekPubContrib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lukesampson_psutils()
        {
            var downloadUrl = "https://github.com/lukesampson/psutils";
            TestFiles("lukesampson_psutils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_artribou_PowerRecord()
        {
            var downloadUrl = "https://github.com/artribou/PowerRecord";
            TestFiles("artribou_PowerRecord", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sethhoward1988_windows_info_aggregator()
        {
            var downloadUrl = "https://github.com/sethhoward1988/windows-info-aggregator";
            TestFiles("sethhoward1988_windows-info-aggregator", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kazunori_Kimura_AutoDownloader()
        {
            var downloadUrl = "https://github.com/Kazunori-Kimura/AutoDownloader";
            TestFiles("Kazunori-Kimura_AutoDownloader", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aadje_elmah_gac_powershell()
        {
            var downloadUrl = "https://github.com/aadje/elmah.gac.powershell";
            TestFiles("aadje_elmah.gac.powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_anchor_twingle()
        {
            var downloadUrl = "https://github.com/anchor/twingle";
            TestFiles("anchor_twingle", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AsteriskLabs_SEPSylinkSetup()
        {
            var downloadUrl = "https://github.com/AsteriskLabs/SEPSylinkSetup";
            TestFiles("AsteriskLabs_SEPSylinkSetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_brianmego_Chocolatey()
        {
            var downloadUrl = "https://github.com/brianmego/Chocolatey";
            TestFiles("brianmego_Chocolatey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AppVeyor_Deployment()
        {
            var downloadUrl = "https://github.com/AppVeyor/Deployment";
            TestFiles("AppVeyor_Deployment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jbuedel_dotfiles()
        {
            var downloadUrl = "https://github.com/jbuedel/dotfiles";
            TestFiles("jbuedel_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mishkinf_PowerShellDev()
        {
            var downloadUrl = "https://github.com/mishkinf/PowerShellDev";
            TestFiles("mishkinf_PowerShellDev", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Translit()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Translit";
            TestFiles("sergey-s-betke_ITG.Translit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_asyncsrc_Asterisk_Queue_Mgmt()
        {
            var downloadUrl = "https://github.com/asyncsrc/Asterisk-Queue-Mgmt";
            TestFiles("asyncsrc_Asterisk-Queue-Mgmt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_asyncsrc_Password_Expiration()
        {
            var downloadUrl = "https://github.com/asyncsrc/Password-Expiration";
            TestFiles("asyncsrc_Password-Expiration", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wishstudio_VaporTestSuite()
        {
            var downloadUrl = "https://github.com/wishstudio/VaporTestSuite";
            TestFiles("wishstudio_VaporTestSuite", downloadUrl);
        }

        [TestMethod]
        public void GitHub_naveensky_GAS_Extensions()
        {
            var downloadUrl = "https://github.com/naveensky/GAS-Extensions";
            TestFiles("naveensky_GAS-Extensions", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lhaig_pslogreader()
        {
            var downloadUrl = "https://github.com/lhaig/pslogreader";
            TestFiles("lhaig_pslogreader", downloadUrl);
        }

        [TestMethod]
        public void GitHub_johnweldon_WindowsPowershell()
        {
            var downloadUrl = "https://github.com/johnweldon/WindowsPowershell";
            TestFiles("johnweldon_WindowsPowershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mikecole_EntityFrameworkIncludes()
        {
            var downloadUrl = "https://github.com/mikecole/EntityFrameworkIncludes";
            TestFiles("mikecole_EntityFrameworkIncludes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_meredithannfry_Scripts()
        {
            var downloadUrl = "https://github.com/meredithannfry/Scripts";
            TestFiles("meredithannfry_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mockmyberet_PowerShell()
        {
            var downloadUrl = "https://github.com/mockmyberet/PowerShell";
            TestFiles("mockmyberet_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Yandex_DnsServer()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Yandex.DnsServer";
            TestFiles("sergey-s-betke_ITG.Yandex.DnsServer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_ProvisioningAWindowsAzureVMPS()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-ProvisioningAWindowsAzureVMPS";
            TestFiles("WindowsAzure-TrainingKit_HOL-ProvisioningAWindowsAzureVMPS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MarkRobertJohnson_ChocolateyPackages()
        {
            var downloadUrl = "https://github.com/MarkRobertJohnson/ChocolateyPackages";
            TestFiles("MarkRobertJohnson_ChocolateyPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SinFulNard_get_orphan_drives()
        {
            var downloadUrl = "https://github.com/SinFulNard/get-orphan-drives";
            TestFiles("SinFulNard_get-orphan-drives", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sitUboo_tc_install()
        {
            var downloadUrl = "https://github.com/sitUboo/tc_install";
            TestFiles("sitUboo_tc_install", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MRCollective_DotNETContinuousDeploymentScripts()
        {
            var downloadUrl = "https://github.com/MRCollective/DotNETContinuousDeploymentScripts";
            TestFiles("MRCollective_DotNETContinuousDeploymentScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_janikvonrotz_Powershell_Profile()
        {
            var downloadUrl = "https://github.com/janikvonrotz/Powershell-Profile";
            TestFiles("janikvonrotz_Powershell-Profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_seas_computing_windows_cloud_init()
        {
            var downloadUrl = "https://github.com/seas-computing/windows-cloud-init";
            TestFiles("seas-computing_windows-cloud-init", downloadUrl);
        }

        [TestMethod]
        public void GitHub_guitarrapc_PowerShellUtil()
        {
            var downloadUrl = "https://github.com/guitarrapc/PowerShellUtil";
            TestFiles("guitarrapc_PowerShellUtil", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joethemongoose_Powershell()
        {
            var downloadUrl = "https://github.com/joethemongoose/Powershell";
            TestFiles("joethemongoose_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_i_e_b_PoshMSpec()
        {
            var downloadUrl = "https://github.com/i-e-b/PoshMSpec";
            TestFiles("i-e-b_PoshMSpec", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ShareTheCodez_PowerShell()
        {
            var downloadUrl = "https://github.com/ShareTheCodez/PowerShell";
            TestFiles("ShareTheCodez_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jrolstad_PoshAWS()
        {
            var downloadUrl = "https://github.com/jrolstad/PoshAWS";
            TestFiles("jrolstad_PoshAWS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_southworks_qa_Demo1Test()
        {
            var downloadUrl = "https://github.com/southworks-qa/Demo1Test";
            TestFiles("southworks-qa_Demo1Test", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tditiecher_tattoo()
        {
            var downloadUrl = "https://github.com/tditiecher/tattoo";
            TestFiles("tditiecher_tattoo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_krishagel_Educational_Data_and_Account_Generation_Engine()
        {
            var downloadUrl = "https://github.com/krishagel/Educational-Data-and-Account-Generation-Engine";
            TestFiles("krishagel_Educational-Data-and-Account-Generation-Engine", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kolesnick_hg_power()
        {
            var downloadUrl = "https://github.com/kolesnick/hg-power";
            TestFiles("kolesnick_hg-power", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mmuell_Scripts()
        {
            var downloadUrl = "https://github.com/mmuell/Scripts";
            TestFiles("mmuell_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_GlennS_MathsScripts()
        {
            var downloadUrl = "https://github.com/GlennS/MathsScripts";
            TestFiles("GlennS_MathsScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_EFJoseph_My_Powershell_Profile()
        {
            var downloadUrl = "https://github.com/EFJoseph/My-Powershell-Profile";
            TestFiles("EFJoseph_My-Powershell-Profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_paulomouat_devsetup()
        {
            var downloadUrl = "https://github.com/paulomouat/devsetup";
            TestFiles("paulomouat_devsetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nickfloyd_winfo()
        {
            var downloadUrl = "https://github.com/nickfloyd/winfo";
            TestFiles("nickfloyd_winfo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_khebbie_Hollywood_CCnet()
        {
            var downloadUrl = "https://github.com/khebbie/Hollywood-CCnet";
            TestFiles("khebbie_Hollywood-CCnet", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mick_shaw_LogMonitor()
        {
            var downloadUrl = "https://github.com/mick-shaw/LogMonitor";
            TestFiles("mick-shaw_LogMonitor", downloadUrl);
        }

        [TestMethod]
        public void GitHub_matthewjstanford_sqlslayer()
        {
            var downloadUrl = "https://github.com/matthewjstanford/sqlslayer";
            TestFiles("matthewjstanford_sqlslayer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rancomma_MongoCommand()
        {
            var downloadUrl = "https://github.com/rancomma/MongoCommand";
            TestFiles("rancomma_MongoCommand", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rorywoods_my_dotfiles()
        {
            var downloadUrl = "https://github.com/rorywoods/my-dotfiles";
            TestFiles("rorywoods_my-dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_awmckinley_psScripts()
        {
            var downloadUrl = "https://github.com/awmckinley/psScripts";
            TestFiles("awmckinley_psScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_clockfort_image_resequencer()
        {
            var downloadUrl = "https://github.com/clockfort/image-resequencer";
            TestFiles("clockfort_image-resequencer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dbunn_PowerShell()
        {
            var downloadUrl = "https://github.com/dbunn/PowerShell";
            TestFiles("dbunn_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DevNambi_WindowsUtilities()
        {
            var downloadUrl = "https://github.com/DevNambi/WindowsUtilities";
            TestFiles("DevNambi_WindowsUtilities", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jbake_Powershell_scripts()
        {
            var downloadUrl = "https://github.com/jbake/Powershell_scripts";
            TestFiles("jbake_Powershell_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mrcaron_PcConfig()
        {
            var downloadUrl = "https://github.com/mrcaron/PcConfig";
            TestFiles("mrcaron_PcConfig", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bone187_PowerShell_Whois()
        {
            var downloadUrl = "https://github.com/bone187/PowerShell-Whois";
            TestFiles("bone187_PowerShell-Whois", downloadUrl);
        }

        [TestMethod]
        public void GitHub_josiahruddell_DependencyManagement()
        {
            var downloadUrl = "https://github.com/josiahruddell/DependencyManagement";
            TestFiles("josiahruddell_DependencyManagement", downloadUrl);
        }

        [TestMethod]
        public void GitHub_elPerstin_DriveSnapshot_Powershell()
        {
            var downloadUrl = "https://github.com/elPerstin/DriveSnapshot-Powershell";
            TestFiles("elPerstin_DriveSnapshot-Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_drmartin1998_ps_profiles()
        {
            var downloadUrl = "https://github.com/drmartin1998/ps-profiles";
            TestFiles("drmartin1998_ps-profiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nakaji_PowerShellScript()
        {
            var downloadUrl = "https://github.com/nakaji/PowerShellScript";
            TestFiles("nakaji_PowerShellScript", downloadUrl);
        }

        [TestMethod]
        public void GitHub_andsowouldi_WCDAPI()
        {
            var downloadUrl = "https://github.com/andsowouldi/WCDAPI";
            TestFiles("andsowouldi_WCDAPI", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ajkochanowicz_Kickstrap_LESS_Compiler()
        {
            var downloadUrl = "https://github.com/ajkochanowicz/Kickstrap-LESS-Compiler";
            TestFiles("ajkochanowicz_Kickstrap-LESS-Compiler", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MarkJungman_dotfiles()
        {
            var downloadUrl = "https://github.com/MarkJungman/dotfiles";
            TestFiles("MarkJungman_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_Users()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/Users";
            TestFiles("sergey-s-betke_Users", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_WinAPI_User32()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.WinAPI.User32";
            TestFiles("sergey-s-betke_ITG.WinAPI.User32", downloadUrl);
        }

        [TestMethod]
        public void GitHub_konstantindenerz_code_snippets()
        {
            var downloadUrl = "https://github.com/konstantindenerz/code-snippets";
            TestFiles("konstantindenerz_code-snippets", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cryogenx_power_prowl()
        {
            var downloadUrl = "https://github.com/cryogenx/power-prowl";
            TestFiles("cryogenx_power-prowl", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mikeplavsky_pt_export()
        {
            var downloadUrl = "https://github.com/mikeplavsky/pt-export";
            TestFiles("mikeplavsky_pt-export", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stillru_PersonalPakage()
        {
            var downloadUrl = "https://github.com/stillru/PersonalPakage";
            TestFiles("stillru_PersonalPakage", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zvickery_general()
        {
            var downloadUrl = "https://github.com/zvickery/general";
            TestFiles("zvickery_general", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dbarsam__ps1()
        {
            var downloadUrl = "https://github.com/dbarsam/.ps1";
            TestFiles("dbarsam_.ps1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Vaporise_CodingforWork()
        {
            var downloadUrl = "https://github.com/Vaporise/CodingforWork";
            TestFiles("Vaporise_CodingforWork", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dkiessling_ps_profile()
        {
            var downloadUrl = "https://github.com/dkiessling/ps-profile";
            TestFiles("dkiessling_ps-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PowerShellTranslate()
        {
            var downloadUrl = "https://github.com/dfinke/PowerShellTranslate";
            TestFiles("dfinke_PowerShellTranslate", downloadUrl);
        }

        [TestMethod]
        public void GitHub_colinbowern_Spikes()
        {
            var downloadUrl = "https://github.com/colinbowern/Spikes";
            TestFiles("colinbowern_Spikes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Tulpep_vTul()
        {
            var downloadUrl = "https://github.com/Tulpep/vTul";
            TestFiles("Tulpep_vTul", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joethemongoose_PowerCLI()
        {
            var downloadUrl = "https://github.com/joethemongoose/PowerCLI";
            TestFiles("joethemongoose_PowerCLI", downloadUrl);
        }

        [TestMethod]
        public void GitHub_realtechjp_controllingSAP()
        {
            var downloadUrl = "https://github.com/realtechjp/controllingSAP";
            TestFiles("realtechjp_controllingSAP", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tipsotto_GAM_Controller()
        {
            var downloadUrl = "https://github.com/tipsotto/GAM-Controller";
            TestFiles("tipsotto_GAM-Controller", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nepsoft_friendly_fire()
        {
            var downloadUrl = "https://github.com/nepsoft/friendly-fire";
            TestFiles("nepsoft_friendly-fire", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AndyPowerShell_PowerGIT()
        {
            var downloadUrl = "https://github.com/AndyPowerShell/PowerGIT";
            TestFiles("AndyPowerShell_PowerGIT", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MrOggy85_Poker_Blinds_Timer()
        {
            var downloadUrl = "https://github.com/MrOggy85/Poker_Blinds_Timer";
            TestFiles("MrOggy85_Poker_Blinds_Timer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pdxcat_PowerShell_Graphite()
        {
            var downloadUrl = "https://github.com/pdxcat/PowerShell-Graphite";
            TestFiles("pdxcat_PowerShell-Graphite", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jgc128_Serelex4Win()
        {
            var downloadUrl = "https://github.com/jgc128/Serelex4Win";
            TestFiles("jgc128_Serelex4Win", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tynen_WindowsPrintModule()
        {
            var downloadUrl = "https://github.com/tynen/WindowsPrintModule";
            TestFiles("tynen_WindowsPrintModule", downloadUrl);
        }

        [TestMethod]
        public void GitHub_k3nnyfr_TICE_create_users()
        {
            var downloadUrl = "https://github.com/k3nnyfr/TICE-create-users";
            TestFiles("k3nnyfr_TICE-create-users", downloadUrl);
        }

        [TestMethod]
        public void GitHub_infotron_Tiger()
        {
            var downloadUrl = "https://github.com/infotron/Tiger";
            TestFiles("infotron_Tiger", downloadUrl);
        }

        [TestMethod]
        public void GitHub_achalddave_Desktop_Cleanup()
        {
            var downloadUrl = "https://github.com/achalddave/Desktop-Cleanup";
            TestFiles("achalddave_Desktop-Cleanup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zachbonham_AppGet()
        {
            var downloadUrl = "https://github.com/zachbonham/AppGet";
            TestFiles("zachbonham_AppGet", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jrolstad_Pscx()
        {
            var downloadUrl = "https://github.com/jrolstad/Pscx";
            TestFiles("jrolstad_Pscx", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Ben0xA_wauscripts()
        {
            var downloadUrl = "https://github.com/Ben0xA/wauscripts";
            TestFiles("Ben0xA_wauscripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jonwagner_BuildTools_NET()
        {
            var downloadUrl = "https://github.com/jonwagner/BuildTools.NET";
            TestFiles("jonwagner_BuildTools.NET", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jsnape_posh_gwen()
        {
            var downloadUrl = "https://github.com/jsnape/posh-gwen";
            TestFiles("jsnape_posh-gwen", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jrich523_NimblePowerShell()
        {
            var downloadUrl = "https://github.com/jrich523/NimblePowerShell";
            TestFiles("jrich523_NimblePowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_uncas_psen()
        {
            var downloadUrl = "https://github.com/uncas/psen";
            TestFiles("uncas_psen", downloadUrl);
        }

        [TestMethod]
        public void GitHub_asyncsrc_EFax()
        {
            var downloadUrl = "https://github.com/asyncsrc/EFax";
            TestFiles("asyncsrc_EFax", downloadUrl);
        }

        [TestMethod]
        public void GitHub_msneeden_SifterAPI_Powershell()
        {
            var downloadUrl = "https://github.com/msneeden/SifterAPI-Powershell";
            TestFiles("msneeden_SifterAPI-Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_trstringer_FirewallCapture()
        {
            var downloadUrl = "https://github.com/trstringer/FirewallCapture";
            TestFiles("trstringer_FirewallCapture", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alanrenouf_vCheck_vCD()
        {
            var downloadUrl = "https://github.com/alanrenouf/vCheck-vCD";
            TestFiles("alanrenouf_vCheck-vCD", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wallybh_psScripts()
        {
            var downloadUrl = "https://github.com/wallybh/psScripts";
            TestFiles("wallybh_psScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_andreaskoch_PowerShell_Workshop()
        {
            var downloadUrl = "https://github.com/andreaskoch/PowerShell-Workshop";
            TestFiles("andreaskoch_PowerShell-Workshop", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AppliedIS_sp_azure_iaas()
        {
            var downloadUrl = "https://github.com/AppliedIS/sp-azure-iaas";
            TestFiles("AppliedIS_sp-azure-iaas", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AppliedIS_AWS_SP_WF()
        {
            var downloadUrl = "https://github.com/AppliedIS/AWS-SP-WF";
            TestFiles("AppliedIS_AWS-SP-WF", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DimiG_myWINscripts()
        {
            var downloadUrl = "https://github.com/DimiG/myWINscripts";
            TestFiles("DimiG_myWINscripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Priezt_Personal()
        {
            var downloadUrl = "https://github.com/Priezt/Personal";
            TestFiles("Priezt_Personal", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nathanlocke_chocolatey()
        {
            var downloadUrl = "https://github.com/nathanlocke/chocolatey";
            TestFiles("nathanlocke_chocolatey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_PowerShell_Show_Me_How()
        {
            var downloadUrl = "https://github.com/dfinke/PowerShell_Show_Me_How";
            TestFiles("dfinke_PowerShell_Show_Me_How", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yjia_ops_setup()
        {
            var downloadUrl = "https://github.com/yjia/ops.setup";
            TestFiles("yjia_ops.setup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mjlmo_PSMSSQL()
        {
            var downloadUrl = "https://github.com/mjlmo/PSMSSQL";
            TestFiles("mjlmo_PSMSSQL", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jstangroome_PSThycoticSecretServer()
        {
            var downloadUrl = "https://github.com/jstangroome/PSThycoticSecretServer";
            TestFiles("jstangroome_PSThycoticSecretServer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smerchek_nugetpackages()
        {
            var downloadUrl = "https://github.com/smerchek/nugetpackages";
            TestFiles("smerchek_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_udooz_powerplay()
        {
            var downloadUrl = "https://github.com/udooz/powerplay";
            TestFiles("udooz_powerplay", downloadUrl);
        }

        [TestMethod]
        public void GitHub_haidong_mssqlps()
        {
            var downloadUrl = "https://github.com/haidong/mssqlps";
            TestFiles("haidong_mssqlps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_andydukey_automation()
        {
            var downloadUrl = "https://github.com/andydukey/automation";
            TestFiles("andydukey_automation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jrich523_PSVA()
        {
            var downloadUrl = "https://github.com/jrich523/PSVA";
            TestFiles("jrich523_PSVA", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rasmus_CiPsLib()
        {
            var downloadUrl = "https://github.com/rasmus/CiPsLib";
            TestFiles("rasmus_CiPsLib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rismoney_forthewin()
        {
            var downloadUrl = "https://github.com/rismoney/forthewin";
            TestFiles("rismoney_forthewin", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ritasker_Chocolatey_Install_Enviroment()
        {
            var downloadUrl = "https://github.com/ritasker/Chocolatey-Install-Enviroment";
            TestFiles("ritasker_Chocolatey-Install-Enviroment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mmessano_PowerShell()
        {
            var downloadUrl = "https://github.com/mmessano/PowerShell";
            TestFiles("mmessano_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Readme()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Readme";
            TestFiles("sergey-s-betke_ITG.Readme", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_FederatedAuthWebRole()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-FederatedAuthWebRole";
            TestFiles("WindowsAzure-TrainingKit_HOL-FederatedAuthWebRole", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ohtake_test_calsync()
        {
            var downloadUrl = "https://github.com/ohtake/test-calsync";
            TestFiles("ohtake_test-calsync", downloadUrl);
        }

        [TestMethod]
        public void GitHub_secretGeek_markjump()
        {
            var downloadUrl = "https://github.com/secretGeek/markjump";
            TestFiles("secretGeek_markjump", downloadUrl);
        }

        [TestMethod]
        public void GitHub_webpilot_PS1()
        {
            var downloadUrl = "https://github.com/webpilot/PS1";
            TestFiles("webpilot_PS1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_calvinmm_MarkdownNotes()
        {
            var downloadUrl = "https://github.com/calvinmm/MarkdownNotes";
            TestFiles("calvinmm_MarkdownNotes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smartorg_PSastroAPI()
        {
            var downloadUrl = "https://github.com/smartorg/PSastroAPI";
            TestFiles("smartorg_PSastroAPI", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pedroreys_powershell()
        {
            var downloadUrl = "https://github.com/pedroreys/powershell";
            TestFiles("pedroreys_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kyzog_posh_vm_manager()
        {
            var downloadUrl = "https://github.com/Kyzog/posh-vm-manager";
            TestFiles("Kyzog_posh-vm-manager", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ruidfigueiredo_rememberme()
        {
            var downloadUrl = "https://github.com/ruidfigueiredo/rememberme";
            TestFiles("ruidfigueiredo_rememberme", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TonyWu_SQL_BI_ETL_Framework()
        {
            var downloadUrl = "https://github.com/TonyWu/SQL-BI-ETL-Framework";
            TestFiles("TonyWu_SQL-BI-ETL-Framework", downloadUrl);
        }

        [TestMethod]
        public void GitHub_giseongeom_GitTesting()
        {
            var downloadUrl = "https://github.com/giseongeom/GitTesting";
            TestFiles("giseongeom_GitTesting", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smakhtin_VVVV_Chocolatey_Packages()
        {
            var downloadUrl = "https://github.com/smakhtin/VVVV-Chocolatey-Packages";
            TestFiles("smakhtin_VVVV-Chocolatey-Packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fyidoctors_pake()
        {
            var downloadUrl = "https://github.com/fyidoctors/pake";
            TestFiles("fyidoctors_pake", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_WinAPI_UrlMon()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.WinAPI.UrlMon";
            TestFiles("sergey-s-betke_ITG.WinAPI.UrlMon", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adampresley_sqlBackupRestorePS()
        {
            var downloadUrl = "https://github.com/adampresley/sqlBackupRestorePS";
            TestFiles("adampresley_sqlBackupRestorePS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wushaobo_InitWindowsNode()
        {
            var downloadUrl = "https://github.com/wushaobo/InitWindowsNode";
            TestFiles("wushaobo_InitWindowsNode", downloadUrl);
        }

        [TestMethod]
        public void GitHub_writeameer_PsakeTest()
        {
            var downloadUrl = "https://github.com/writeameer/PsakeTest";
            TestFiles("writeameer_PsakeTest", downloadUrl);
        }

        [TestMethod]
        public void GitHub_msetzer_utils()
        {
            var downloadUrl = "https://github.com/msetzer/utils";
            TestFiles("msetzer_utils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_brettswift_ToolRegistry()
        {
            var downloadUrl = "https://github.com/brettswift/ToolRegistry";
            TestFiles("brettswift_ToolRegistry", downloadUrl);
        }

        [TestMethod]
        public void GitHub_OpCode1300_Powershell()
        {
            var downloadUrl = "https://github.com/OpCode1300/Powershell";
            TestFiles("OpCode1300_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bschwinger_SNMP_Radio_Shutdown()
        {
            var downloadUrl = "https://github.com/bschwinger/SNMP-Radio-Shutdown";
            TestFiles("bschwinger_SNMP-Radio-Shutdown", downloadUrl);
        }

        [TestMethod]
        public void GitHub_red_stronghold_SubstituteApp_Robots()
        {
            var downloadUrl = "https://github.com/red-stronghold/SubstituteApp.Robots";
            TestFiles("red-stronghold_SubstituteApp.Robots", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stekkanbla_GitHub()
        {
            var downloadUrl = "https://github.com/stekkanbla/GitHub";
            TestFiles("stekkanbla_GitHub", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adminian_PowerShellToDo_Txt()
        {
            var downloadUrl = "https://github.com/adminian/PowerShellToDo.Txt";
            TestFiles("adminian_PowerShellToDo.Txt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cajones_Primer_DSL()
        {
            var downloadUrl = "https://github.com/cajones/Primer-DSL";
            TestFiles("cajones_Primer-DSL", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ryanmcmichael_psaketest()
        {
            var downloadUrl = "https://github.com/ryanmcmichael/psaketest";
            TestFiles("ryanmcmichael_psaketest", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aadje_powershell_koans()
        {
            var downloadUrl = "https://github.com/aadje/powershell-koans";
            TestFiles("aadje_powershell-koans", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thomykay_PoshJira()
        {
            var downloadUrl = "https://github.com/thomykay/PoshJira";
            TestFiles("thomykay_PoshJira", downloadUrl);
        }

        [TestMethod]
        public void GitHub_StealFocus_Build()
        {
            var downloadUrl = "https://github.com/StealFocus/Build";
            TestFiles("StealFocus_Build", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jc74_openkanban()
        {
            var downloadUrl = "https://github.com/jc74/openkanban";
            TestFiles("jc74_openkanban", downloadUrl);
        }

        [TestMethod]
        public void GitHub_derekerdmann_ps_profile()
        {
            var downloadUrl = "https://github.com/derekerdmann/ps-profile";
            TestFiles("derekerdmann_ps-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_eviltobz_Config()
        {
            var downloadUrl = "https://github.com/eviltobz/Config";
            TestFiles("eviltobz_Config", downloadUrl);
        }

        [TestMethod]
        public void GitHub_abhishekkr_power_shell_ing()
        {
            var downloadUrl = "https://github.com/abhishekkr/power.shell.ing";
            TestFiles("abhishekkr_power.shell.ing", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aaubry_VsPowershellLib()
        {
            var downloadUrl = "https://github.com/aaubry/VsPowershellLib";
            TestFiles("aaubry_VsPowershellLib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bevzuk_ProperTests()
        {
            var downloadUrl = "https://github.com/bevzuk/ProperTests";
            TestFiles("bevzuk_ProperTests", downloadUrl);
        }

        [TestMethod]
        public void GitHub_elmundio87_VboxManagePS()
        {
            var downloadUrl = "https://github.com/elmundio87/VboxManagePS";
            TestFiles("elmundio87_VboxManagePS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_webcoyote_win_setup()
        {
            var downloadUrl = "https://github.com/webcoyote/win-setup";
            TestFiles("webcoyote_win-setup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_derekmurawsky_ChocolateySQLMaintenanceSolution()
        {
            var downloadUrl = "https://github.com/derekmurawsky/ChocolateySQLMaintenanceSolution";
            TestFiles("derekmurawsky_ChocolateySQLMaintenanceSolution", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sheenaustin_SendToXBMC()
        {
            var downloadUrl = "https://github.com/sheenaustin/SendToXBMC";
            TestFiles("sheenaustin_SendToXBMC", downloadUrl);
        }

        [TestMethod]
        public void GitHub_stanleystl_EntLib5ODP_NET()
        {
            var downloadUrl = "https://github.com/stanleystl/EntLib5ODP.NET";
            TestFiles("stanleystl_EntLib5ODP.NET", downloadUrl);
        }

        [TestMethod]
        public void GitHub_basbossink_basbossink_chocolatey_utilities()
        {
            var downloadUrl = "https://github.com/basbossink/basbossink.chocolatey.utilities";
            TestFiles("basbossink_basbossink.chocolatey.utilities", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Zloy_tesseract_training()
        {
            var downloadUrl = "https://github.com/Zloy/tesseract-training";
            TestFiles("Zloy_tesseract-training", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AndyPowerShell_PowerShellSummit()
        {
            var downloadUrl = "https://github.com/AndyPowerShell/PowerShellSummit";
            TestFiles("AndyPowerShell_PowerShellSummit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SinFulNard_Set_target_printer_driver()
        {
            var downloadUrl = "https://github.com/SinFulNard/Set-target-printer-driver";
            TestFiles("SinFulNard_Set-target-printer-driver", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Doct0rZ_groupEnum()
        {
            var downloadUrl = "https://github.com/Doct0rZ/groupEnum";
            TestFiles("Doct0rZ_groupEnum", downloadUrl);
        }

        [TestMethod]
        public void GitHub_janarve_janarves_personal()
        {
            var downloadUrl = "https://github.com/janarve/janarves-personal";
            TestFiles("janarve_janarves-personal", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Adobe_CloudOps_Adobe_Chef()
        {
            var downloadUrl = "https://github.com/Adobe-CloudOps/Adobe-Chef";
            TestFiles("Adobe-CloudOps_Adobe-Chef", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xinmyname_Home()
        {
            var downloadUrl = "https://github.com/xinmyname/Home";
            TestFiles("xinmyname_Home", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rghwang_AppDevBook()
        {
            var downloadUrl = "https://github.com/rghwang/AppDevBook";
            TestFiles("rghwang_AppDevBook", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Rutix_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/Rutix/WindowsPowerShell";
            TestFiles("Rutix_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vicentedealencar_dotfiles()
        {
            var downloadUrl = "https://github.com/vicentedealencar/dotfiles";
            TestFiles("vicentedealencar_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_togakangaroo_resume()
        {
            var downloadUrl = "https://github.com/togakangaroo/resume";
            TestFiles("togakangaroo_resume", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chipolux_Multi_Minecraft()
        {
            var downloadUrl = "https://github.com/chipolux/Multi_Minecraft";
            TestFiles("chipolux_Multi_Minecraft", downloadUrl);
        }

        [TestMethod]
        public void GitHub_salty1308_psadm()
        {
            var downloadUrl = "https://github.com/salty1308/psadm";
            TestFiles("salty1308_psadm", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrisdee_Solutions()
        {
            var downloadUrl = "https://github.com/chrisdee/Solutions";
            TestFiles("chrisdee_Solutions", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cajones_Mocha_browser_template()
        {
            var downloadUrl = "https://github.com/cajones/Mocha-browser-template";
            TestFiles("cajones_Mocha-browser-template", downloadUrl);
        }

        [TestMethod]
        public void GitHub_glasnt_wail2ban()
        {
            var downloadUrl = "https://github.com/glasnt/wail2ban";
            TestFiles("glasnt_wail2ban", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hsmalley_Powershell()
        {
            var downloadUrl = "https://github.com/hsmalley/Powershell";
            TestFiles("hsmalley_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_HOL_UnderstandingVMImagingWithCapturePS()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/HOL-UnderstandingVMImagingWithCapturePS";
            TestFiles("WindowsAzure-TrainingKit_HOL-UnderstandingVMImagingWithCapturePS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cdhunt_PoshModules()
        {
            var downloadUrl = "https://github.com/cdhunt/PoshModules";
            TestFiles("cdhunt_PoshModules", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fifthecho_CloudStack_PowerShell_Reports()
        {
            var downloadUrl = "https://github.com/fifthecho/CloudStack-PowerShell-Reports";
            TestFiles("fifthecho_CloudStack-PowerShell-Reports", downloadUrl);
        }

        [TestMethod]
        public void GitHub_divayht_DeployProject()
        {
            var downloadUrl = "https://github.com/divayht/DeployProject";
            TestFiles("divayht_DeployProject", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sandrinodimattia_WindowsAzure_PassiveFTPinVM()
        {
            var downloadUrl = "https://github.com/sandrinodimattia/WindowsAzure-PassiveFTPinVM";
            TestFiles("sandrinodimattia_WindowsAzure-PassiveFTPinVM", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chuchu_audiobookcreator()
        {
            var downloadUrl = "https://github.com/chuchu/audiobookcreator";
            TestFiles("chuchu_audiobookcreator", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ColinCarson_Scratch()
        {
            var downloadUrl = "https://github.com/ColinCarson/Scratch";
            TestFiles("ColinCarson_Scratch", downloadUrl);
        }

        [TestMethod]
        public void GitHub_greygoose_PowerTool()
        {
            var downloadUrl = "https://github.com/greygoose/PowerTool";
            TestFiles("greygoose_PowerTool", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alanrenouf_vCheck_Exchange()
        {
            var downloadUrl = "https://github.com/alanrenouf/vCheck-Exchange";
            TestFiles("alanrenouf_vCheck-Exchange", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jstangroome_PsTFS2010()
        {
            var downloadUrl = "https://github.com/jstangroome/PsTFS2010";
            TestFiles("jstangroome_PsTFS2010", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jstangroome_Tfs11ProcessUpgrade()
        {
            var downloadUrl = "https://github.com/jstangroome/Tfs11ProcessUpgrade";
            TestFiles("jstangroome_Tfs11ProcessUpgrade", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Vtec9k_Generate_ComplexPassword()
        {
            var downloadUrl = "https://github.com/Vtec9k/Generate-ComplexPassword";
            TestFiles("Vtec9k_Generate-ComplexPassword", downloadUrl);
        }

        [TestMethod]
        public void GitHub_neilpa_dotfiles()
        {
            var downloadUrl = "https://github.com/neilpa/dotfiles";
            TestFiles("neilpa_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_saadware_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/saadware/WindowsPowerShell";
            TestFiles("saadware_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ntwb_posh_monokai()
        {
            var downloadUrl = "https://github.com/ntwb/posh-monokai";
            TestFiles("ntwb_posh-monokai", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alex_feng_AzurePowerShellSamples()
        {
            var downloadUrl = "https://github.com/alex-feng/AzurePowerShellSamples";
            TestFiles("alex-feng_AzurePowerShellSamples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adorepump_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/adorepump/chocolatey-packages";
            TestFiles("adorepump_chocolatey-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fschwiet_repave()
        {
            var downloadUrl = "https://github.com/fschwiet/repave";
            TestFiles("fschwiet_repave", downloadUrl);
        }

        [TestMethod]
        public void GitHub_NotMyself_development_environment()
        {
            var downloadUrl = "https://github.com/NotMyself/development_environment";
            TestFiles("NotMyself_development_environment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_awright18_nugetpackages()
        {
            var downloadUrl = "https://github.com/awright18/nugetpackages";
            TestFiles("awright18_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rickbassham_ef_change_notify()
        {
            var downloadUrl = "https://github.com/rickbassham/ef-change-notify";
            TestFiles("rickbassham_ef-change-notify", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rlipscombe_PSBouncyCastle()
        {
            var downloadUrl = "https://github.com/rlipscombe/PSBouncyCastle";
            TestFiles("rlipscombe_PSBouncyCastle", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nightroman_PowerShelf()
        {
            var downloadUrl = "https://github.com/nightroman/PowerShelf";
            TestFiles("nightroman_PowerShelf", downloadUrl);
        }

        [TestMethod]
        public void GitHub_newrelic_nuget_azure_web_sites()
        {
            var downloadUrl = "https://github.com/newrelic/nuget-azure-web-sites";
            TestFiles("newrelic_nuget-azure-web-sites", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lukesampson_concfg()
        {
            var downloadUrl = "https://github.com/lukesampson/concfg";
            TestFiles("lukesampson_concfg", downloadUrl);
        }

        [TestMethod]
        public void GitHub_josiahruddell_NugetDependencyManagement()
        {
            var downloadUrl = "https://github.com/josiahruddell/NugetDependencyManagement";
            TestFiles("josiahruddell_NugetDependencyManagement", downloadUrl);
        }

        [TestMethod]
        public void GitHub_peet_posh_ant()
        {
            var downloadUrl = "https://github.com/peet/posh-ant";
            TestFiles("peet_posh-ant", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adminian_PowerDNSimple()
        {
            var downloadUrl = "https://github.com/adminian/PowerDNSimple";
            TestFiles("adminian_PowerDNSimple", downloadUrl);
        }

        [TestMethod]
        public void GitHub_webcoyote_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/webcoyote/chocolatey-packages";
            TestFiles("webcoyote_chocolatey-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_i_e_b_PoshNUnit()
        {
            var downloadUrl = "https://github.com/i-e-b/PoshNUnit";
            TestFiles("i-e-b_PoshNUnit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jdnow_ZabbixFiles()
        {
            var downloadUrl = "https://github.com/jdnow/ZabbixFiles";
            TestFiles("jdnow_ZabbixFiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_D3M80L_SharpProject()
        {
            var downloadUrl = "https://github.com/D3M80L/SharpProject";
            TestFiles("D3M80L_SharpProject", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fzed51_Format_Text()
        {
            var downloadUrl = "https://github.com/fzed51/Format-Text";
            TestFiles("fzed51_Format-Text", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_StartPowerShellDemo()
        {
            var downloadUrl = "https://github.com/dfinke/StartPowerShellDemo";
            TestFiles("dfinke_StartPowerShellDemo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hyakuhei_ADCS_Notify()
        {
            var downloadUrl = "https://github.com/hyakuhei/ADCS-Notify";
            TestFiles("hyakuhei_ADCS-Notify", downloadUrl);
        }

        [TestMethod]
        public void GitHub_CloudNinja_GitSetup()
        {
            var downloadUrl = "https://github.com/CloudNinja/GitSetup";
            TestFiles("CloudNinja_GitSetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_twreid_MediaManager()
        {
            var downloadUrl = "https://github.com/twreid/MediaManager";
            TestFiles("twreid_MediaManager", downloadUrl);
        }

        [TestMethod]
        public void GitHub_borekb_Scripts()
        {
            var downloadUrl = "https://github.com/borekb/Scripts";
            TestFiles("borekb_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jcattone_profdev()
        {
            var downloadUrl = "https://github.com/jcattone/profdev";
            TestFiles("jcattone_profdev", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bcoover_powershell_scripts()
        {
            var downloadUrl = "https://github.com/bcoover/powershell-scripts";
            TestFiles("bcoover_powershell-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_LogParser()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.LogParser";
            TestFiles("sergey-s-betke_ITG.LogParser", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_Imaging()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.Imaging";
            TestFiles("sergey-s-betke_ITG.Imaging", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MrXcitement_Info_ZIP_chocolateyPackages()
        {
            var downloadUrl = "https://github.com/MrXcitement/Info-ZIP-chocolateyPackages";
            TestFiles("MrXcitement_Info-ZIP-chocolateyPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_trulstveoy_PowerGadgets()
        {
            var downloadUrl = "https://github.com/trulstveoy/PowerGadgets";
            TestFiles("trulstveoy_PowerGadgets", downloadUrl);
        }


        [TestMethod]
        public void GitHub_ComFreek_Nexus4Tester()
        {
            var downloadUrl = "https://github.com/ComFreek/Nexus4Tester";
            TestFiles("ComFreek_Nexus4Tester", downloadUrl);
        }

        [TestMethod]
        public void GitHub_remotex_testaculartestacular()
        {
            var downloadUrl = "https://github.com/remotex/testaculartestacular";
            TestFiles("remotex_testaculartestacular", downloadUrl);
        }

        [TestMethod]
        public void GitHub_katmpb_NATIVE_DLL_FROM_VisualStudio_TO_OTHER_IDE()
        {
            var downloadUrl = "https://github.com/katmpb/NATIVE_DLL_FROM_VisualStudio_TO_OTHER_IDE";
            TestFiles("katmpb_NATIVE_DLL_FROM_VisualStudio_TO_OTHER_IDE", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alvarezdaniel_PPT()
        {
            var downloadUrl = "https://github.com/alvarezdaniel/PPT";
            TestFiles("alvarezdaniel_PPT", downloadUrl);
        }

        [TestMethod]
        public void GitHub_isaachan_skylight()
        {
            var downloadUrl = "https://github.com/isaachan/skylight";
            TestFiles("isaachan_skylight", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kx499_Misc_Scripts()
        {
            var downloadUrl = "https://github.com/kx499/Misc_Scripts";
            TestFiles("kx499_Misc_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_expanditdk_db_deployment()
        {
            var downloadUrl = "https://github.com/expanditdk/db-deployment";
            TestFiles("expanditdk_db-deployment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_MTS_AA()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.MTS.AA";
            TestFiles("sergey-s-betke_ITG.MTS.AA", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vijayjt_SecureTransportScripts()
        {
            var downloadUrl = "https://github.com/vijayjt/SecureTransportScripts";
            TestFiles("vijayjt_SecureTransportScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Grimace1975_KinectHaus()
        {
            var downloadUrl = "https://github.com/Grimace1975/KinectHaus";
            TestFiles("Grimace1975_KinectHaus", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tmmtsmith_Powershell()
        {
            var downloadUrl = "https://github.com/tmmtsmith/Powershell";
            TestFiles("tmmtsmith_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ccpowell_ccnet()
        {
            var downloadUrl = "https://github.com/ccpowell/ccnet";
            TestFiles("ccpowell_ccnet", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zagnut999_GitTest()
        {
            var downloadUrl = "https://github.com/zagnut999/GitTest";
            TestFiles("zagnut999_GitTest", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Segaso_Experiments()
        {
            var downloadUrl = "https://github.com/Segaso/Experiments";
            TestFiles("Segaso_Experiments", downloadUrl);
        }



        [TestMethod]
        public void GitHub_pieterjd_GS_CheckDNS()
        {
            var downloadUrl = "https://github.com/pieterjd/GS-CheckDNS";
            TestFiles("pieterjd_GS-CheckDNS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ComFreek_Tsac()
        {
            var downloadUrl = "https://github.com/ComFreek/Tsac";
            TestFiles("ComFreek_Tsac", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ZWin8_MetroGit()
        {
            var downloadUrl = "https://github.com/ZWin8/MetroGit";
            TestFiles("ZWin8_MetroGit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Corwinian_cons_scripts()
        {
            var downloadUrl = "https://github.com/Corwinian/cons-scripts";
            TestFiles("Corwinian_cons-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mwrock_BringIt()
        {
            var downloadUrl = "https://github.com/mwrock/BringIt";
            TestFiles("mwrock_BringIt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ZWin8_EventHandling()
        {
            var downloadUrl = "https://github.com/ZWin8/EventHandling";
            TestFiles("ZWin8_EventHandling", downloadUrl);
        }

        [TestMethod]
        public void GitHub_esckey_Scripts()
        {
            var downloadUrl = "https://github.com/esckey/Scripts";
            TestFiles("esckey_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_distantcam_Analects_Versioning()
        {
            var downloadUrl = "https://github.com/distantcam/Analects.Versioning";
            TestFiles("distantcam_Analects.Versioning", downloadUrl);
        }

        [TestMethod]
        public void GitHub_metaphysix_Powershell()
        {
            var downloadUrl = "https://github.com/metaphysix/Powershell";
            TestFiles("metaphysix_Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vishm_OddsAndSodds()
        {
            var downloadUrl = "https://github.com/vishm/OddsAndSodds";
            TestFiles("vishm_OddsAndSodds", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sasabrkic_domino_backup_to_s3()
        {
            var downloadUrl = "https://github.com/sasabrkic/domino-backup-to-s3";
            TestFiles("sasabrkic_domino-backup-to-s3", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xenolinguist_PowerShellSdkEnvironment()
        {
            var downloadUrl = "https://github.com/xenolinguist/PowerShellSdkEnvironment";
            TestFiles("xenolinguist_PowerShellSdkEnvironment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ohyecloudy_saved_game_files()
        {
            var downloadUrl = "https://github.com/ohyecloudy/saved-game-files";
            TestFiles("ohyecloudy_saved-game-files", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hisataka_powerShellSamples()
        {
            var downloadUrl = "https://github.com/hisataka/powerShellSamples";
            TestFiles("hisataka_powerShellSamples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrisortman_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/chrisortman/WindowsPowerShell";
            TestFiles("chrisortman_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fluffysquirrels_home()
        {
            var downloadUrl = "https://github.com/fluffysquirrels/home";
            TestFiles("fluffysquirrels_home", downloadUrl);
        }

        [TestMethod]
        public void GitHub_duffkitty_AtechASN()
        {
            var downloadUrl = "https://github.com/duffkitty/AtechASN";
            TestFiles("duffkitty_AtechASN", downloadUrl);
        }

        [TestMethod]
        public void GitHub_amatashkin_dotfiles()
        {
            var downloadUrl = "https://github.com/amatashkin/dotfiles";
            TestFiles("amatashkin_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cptBuggy_DeployLinuxVM()
        {
            var downloadUrl = "https://github.com/cptBuggy/DeployLinuxVM";
            TestFiles("cptBuggy_DeployLinuxVM", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cosmond_Scripts()
        {
            var downloadUrl = "https://github.com/cosmond/Scripts";
            TestFiles("cosmond_Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_alexanderashe_EatOut_Southport()
        {
            var downloadUrl = "https://github.com/alexanderashe/EatOut_Southport";
            TestFiles("alexanderashe_EatOut_Southport", downloadUrl);
        }

        [TestMethod]
        public void GitHub_iceclow_TutorialEntityFrameworkCodeMigrations()
        {
            var downloadUrl = "https://github.com/iceclow/TutorialEntityFrameworkCodeMigrations";
            TestFiles("iceclow_TutorialEntityFrameworkCodeMigrations", downloadUrl);
        }

        [TestMethod]
        public void GitHub_drewburlingame_setup_windows()
        {
            var downloadUrl = "https://github.com/drewburlingame/setup-windows";
            TestFiles("drewburlingame_setup-windows", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pbmattsson_origin()
        {
            var downloadUrl = "https://github.com/pbmattsson/origin";
            TestFiles("pbmattsson_origin", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aaronc_win_config()
        {
            var downloadUrl = "https://github.com/aaronc/win-config";
            TestFiles("aaronc_win-config", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gatepoet_Itera_Demo_SqlTrigger()
        {
            var downloadUrl = "https://github.com/gatepoet/Itera.Demo.SqlTrigger";
            TestFiles("gatepoet_Itera.Demo.SqlTrigger", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kieranties_PS_Pushover()
        {
            var downloadUrl = "https://github.com/Kieranties/PS-Pushover";
            TestFiles("Kieranties_PS-Pushover", downloadUrl);
        }

        [TestMethod]
        public void GitHub_organicit_2013ScriptingGames()
        {
            var downloadUrl = "https://github.com/organicit/2013ScriptingGames";
            TestFiles("organicit_2013ScriptingGames", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ericgentry_Write_HelloWorld()
        {
            var downloadUrl = "https://github.com/ericgentry/Write-HelloWorld";
            TestFiles("ericgentry_Write-HelloWorld", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bronaghs_DR_Script()
        {
            var downloadUrl = "https://github.com/bronaghs/DR-Script";
            TestFiles("bronaghs_DR-Script", downloadUrl);
        }

        [TestMethod]
        public void GitHub_francisrosado_ServicoDeEmail()
        {
            var downloadUrl = "https://github.com/francisrosado/ServicoDeEmail";
            TestFiles("francisrosado_ServicoDeEmail", downloadUrl);
        }

        [TestMethod]
        public void GitHub_idoru78_what_to_play()
        {
            var downloadUrl = "https://github.com/idoru78/what-to-play";
            TestFiles("idoru78_what-to-play", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Andre_Schuiki_test123()
        {
            var downloadUrl = "https://github.com/Andre-Schuiki/test123";
            TestFiles("Andre-Schuiki_test123", downloadUrl);
        }

        [TestMethod]
        public void GitHub_socaldavis_PowerShell()
        {
            var downloadUrl = "https://github.com/socaldavis/PowerShell";
            TestFiles("socaldavis_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joakes_ExtensibleWebFeatures()
        {
            var downloadUrl = "https://github.com/joakes/ExtensibleWebFeatures";
            TestFiles("joakes_ExtensibleWebFeatures", downloadUrl);
        }

        [TestMethod]
        public void GitHub_abowen_PowerShell()
        {
            var downloadUrl = "https://github.com/abowen/PowerShell";
            TestFiles("abowen_PowerShell", downloadUrl);
        }


        [TestMethod]
        public void GitHub_dannykansas_winutils()
        {
            var downloadUrl = "https://github.com/dannykansas/winutils";
            TestFiles("dannykansas_winutils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dfinke_BladePS()
        {
            var downloadUrl = "https://github.com/dfinke/BladePS";
            TestFiles("dfinke_BladePS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SasankaMorska_Work()
        {
            var downloadUrl = "https://github.com/SasankaMorska/Work";
            TestFiles("SasankaMorska_Work", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tschuxxi_nagios_veeam()
        {
            var downloadUrl = "https://github.com/tschuxxi/nagios-veeam";
            TestFiles("tschuxxi_nagios-veeam", downloadUrl);
        }

        [TestMethod]
        public void GitHub_codeimpossible_psh_backup()
        {
            var downloadUrl = "https://github.com/codeimpossible/psh_backup";
            TestFiles("codeimpossible_psh_backup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lboening_install_python()
        {
            var downloadUrl = "https://github.com/lboening/install_python";
            TestFiles("lboening_install_python", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Sergievskiy_HL7Port()
        {
            var downloadUrl = "https://github.com/Sergievskiy/HL7Port";
            TestFiles("Sergievskiy_HL7Port", downloadUrl);
        }

        [TestMethod]
        public void GitHub_shank8_NewTweetMaps()
        {
            var downloadUrl = "https://github.com/shank8/NewTweetMaps";
            TestFiles("shank8_NewTweetMaps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rattfieldnz_in719_sys_admin()
        {
            var downloadUrl = "https://github.com/rattfieldnz/in719_sys_admin";
            TestFiles("rattfieldnz_in719_sys_admin", downloadUrl);
        }

        [TestMethod]
        public void GitHub_johandry_ATK()
        {
            var downloadUrl = "https://github.com/johandry/ATK";
            TestFiles("johandry_ATK", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bahrens_posh_semver()
        {
            var downloadUrl = "https://github.com/bahrens/posh-semver";
            TestFiles("bahrens_posh-semver", downloadUrl);
        }



        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_DEMO_ScaleUpDown()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/DEMO-ScaleUpDown";
            TestFiles("WindowsAzure-TrainingKit_DEMO-ScaleUpDown", downloadUrl);
        }

        [TestMethod]
        public void GitHub_itsananderson_plex_scripts()
        {
            var downloadUrl = "https://github.com/itsananderson/plex-scripts";
            TestFiles("itsananderson_plex-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jmreicha_poshprofile()
        {
            var downloadUrl = "https://github.com/jmreicha/poshprofile";
            TestFiles("jmreicha_poshprofile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_michaeljacobdavis_SolarizedVS2012_Custom()
        {
            var downloadUrl = "https://github.com/michaeljacobdavis/SolarizedVS2012-Custom";
            TestFiles("michaeljacobdavis_SolarizedVS2012-Custom", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chaliy_gnuplot_chocolatey()
        {
            var downloadUrl = "https://github.com/chaliy/gnuplot-chocolatey";
            TestFiles("chaliy_gnuplot-chocolatey", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Bolwind_Powershell_Scripts()
        {
            var downloadUrl = "https://github.com/Bolwind/Powershell-Scripts";
            TestFiles("Bolwind_Powershell-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bacc_svm()
        {
            var downloadUrl = "https://github.com/bacc/svm";
            TestFiles("bacc_svm", downloadUrl);
        }

        [TestMethod]
        public void GitHub_julienlepine_AWS_PS_CmdLets()
        {
            var downloadUrl = "https://github.com/julienlepine/AWS-PS-CmdLets";
            TestFiles("julienlepine_AWS-PS-CmdLets", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mrdragg_Mail()
        {
            var downloadUrl = "https://github.com/mrdragg/Mail";
            TestFiles("mrdragg_Mail", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wayllen_BuildCopyScript()
        {
            var downloadUrl = "https://github.com/wayllen/BuildCopyScript";
            TestFiles("wayllen_BuildCopyScript", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Pro_battery_monitor()
        {
            var downloadUrl = "https://github.com/Pro/battery-monitor";
            TestFiles("Pro_battery-monitor", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jaygrossman_SftpPowershellModule()
        {
            var downloadUrl = "https://github.com/jaygrossman/SftpPowershellModule";
            TestFiles("jaygrossman_SftpPowershellModule", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nwvdnug_nwvdnugwin8()
        {
            var downloadUrl = "https://github.com/nwvdnug/nwvdnugwin8";
            TestFiles("nwvdnug_nwvdnugwin8", downloadUrl);
        }

        [TestMethod]
        public void GitHub_RevChas_zshdots()
        {
            var downloadUrl = "https://github.com/RevChas/zshdots";
            TestFiles("RevChas_zshdots", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bswinnerton_SetACL()
        {
            var downloadUrl = "https://github.com/bswinnerton/SetACL";
            TestFiles("bswinnerton_SetACL", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JamesDawson_PoshDscExtensions()
        {
            var downloadUrl = "https://github.com/JamesDawson/PoshDscExtensions";
            TestFiles("JamesDawson_PoshDscExtensions", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adbre_Malin()
        {
            var downloadUrl = "https://github.com/adbre/Malin";
            TestFiles("adbre_Malin", downloadUrl);
        }


        [TestMethod]
        public void GitHub_davliu_Wordsearch()
        {
            var downloadUrl = "https://github.com/davliu/Wordsearch";
            TestFiles("davliu_Wordsearch", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aynsof_powershell()
        {
            var downloadUrl = "https://github.com/aynsof/powershell";
            TestFiles("aynsof_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_masonm12_PSProfile()
        {
            var downloadUrl = "https://github.com/masonm12/PSProfile";
            TestFiles("masonm12_PSProfile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_m0rg0t_Bashorg_comics()
        {
            var downloadUrl = "https://github.com/m0rg0t/Bashorg_comics";
            TestFiles("m0rg0t_Bashorg_comics", downloadUrl);
        }

        [TestMethod]
        public void GitHub_michaellwest_SystemAdministratorTool()
        {
            var downloadUrl = "https://github.com/michaellwest/SystemAdministratorTool";
            TestFiles("michaellwest_SystemAdministratorTool", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lwblackledge_DbObjectReferenceChecker()
        {
            var downloadUrl = "https://github.com/lwblackledge/DbObjectReferenceChecker";
            TestFiles("lwblackledge_DbObjectReferenceChecker", downloadUrl);
        }

        [TestMethod]
        public void GitHub_roycoutts_simplemagic()
        {
            var downloadUrl = "https://github.com/roycoutts/simplemagic";
            TestFiles("roycoutts_simplemagic", downloadUrl);
        }

        [TestMethod]
        public void GitHub_andy_c_jones_PowerShellMinesweeperKata()
        {
            var downloadUrl = "https://github.com/andy-c-jones/PowerShellMinesweeperKata";
            TestFiles("andy-c-jones_PowerShellMinesweeperKata", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AlexanderNovikov_PowerShellScripts()
        {
            var downloadUrl = "https://github.com/AlexanderNovikov/PowerShellScripts";
            TestFiles("AlexanderNovikov_PowerShellScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cardwookie_StringManip()
        {
            var downloadUrl = "https://github.com/cardwookie/StringManip";
            TestFiles("cardwookie_StringManip", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rajadain_ps_log_collector()
        {
            var downloadUrl = "https://github.com/rajadain/ps-log-collector";
            TestFiles("rajadain_ps-log-collector", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joshuarmclean_Deployment_Toolkit_PS()
        {
            var downloadUrl = "https://github.com/joshuarmclean/Deployment-Toolkit-PS";
            TestFiles("joshuarmclean_Deployment-Toolkit-PS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DeCode88_Storm()
        {
            var downloadUrl = "https://github.com/DeCode88/Storm";
            TestFiles("DeCode88_Storm", downloadUrl);
        }

        [TestMethod]
        public void GitHub_twistedstream_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/twistedstream/chocolatey-packages";
            TestFiles("twistedstream_chocolatey-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wagnerandrade_Watchtower()
        {
            var downloadUrl = "https://github.com/wagnerandrade/Watchtower";
            TestFiles("wagnerandrade_Watchtower", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vacmf_powershell_scripts()
        {
            var downloadUrl = "https://github.com/vacmf/powershell-scripts";
            TestFiles("vacmf_powershell-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kbeckman_Scripts_Settings()
        {
            var downloadUrl = "https://github.com/kbeckman/Scripts-Settings";
            TestFiles("kbeckman_Scripts-Settings", downloadUrl);
        }

        [TestMethod]
        public void GitHub_madhatter00_SystemsUpTime()
        {
            var downloadUrl = "https://github.com/madhatter00/SystemsUpTime";
            TestFiles("madhatter00_SystemsUpTime", downloadUrl);
        }

        [TestMethod]
        public void GitHub_KoHHeKT_Utils()
        {
            var downloadUrl = "https://github.com/KoHHeKT/Utils";
            TestFiles("KoHHeKT_Utils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AcmeCorp_SimpleBuildSample()
        {
            var downloadUrl = "https://github.com/AcmeCorp/SimpleBuildSample";
            TestFiles("AcmeCorp_SimpleBuildSample", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dpvreony_posh_gittfs()
        {
            var downloadUrl = "https://github.com/dpvreony/posh-gittfs";
            TestFiles("dpvreony_posh-gittfs", downloadUrl);
        }

        [TestMethod]
        public void GitHub_KriNiTo_MarkFolderGitRepo()
        {
            var downloadUrl = "https://github.com/KriNiTo/MarkFolderGitRepo";
            TestFiles("KriNiTo_MarkFolderGitRepo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_piotrgo_power_sh_xs()
        {
            var downloadUrl = "https://github.com/piotrgo/power_sh_xs";
            TestFiles("piotrgo_power_sh_xs", downloadUrl);
        }

        [TestMethod]
        public void GitHub_paulduran_rarcleaner()
        {
            var downloadUrl = "https://github.com/paulduran/rarcleaner";
            TestFiles("paulduran_rarcleaner", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jzabroski_OrchardBootstrap()
        {
            var downloadUrl = "https://github.com/jzabroski/OrchardBootstrap";
            TestFiles("jzabroski_OrchardBootstrap", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mac2000_add2path()
        {
            var downloadUrl = "https://github.com/mac2000/add2path";
            TestFiles("mac2000_add2path", downloadUrl);
        }

        [TestMethod]
        public void GitHub_markdrichter_infra()
        {
            var downloadUrl = "https://github.com/markdrichter/infra";
            TestFiles("markdrichter_infra", downloadUrl);
        }

        [TestMethod]
        public void GitHub_awcoleman_setLyncSkype()
        {
            var downloadUrl = "https://github.com/awcoleman/setLyncSkype";
            TestFiles("awcoleman_setLyncSkype", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SimonHFrost_Play_Unwatched_Video()
        {
            var downloadUrl = "https://github.com/SimonHFrost/Play_Unwatched_Video";
            TestFiles("SimonHFrost_Play_Unwatched_Video", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sysadmin_groupj_scripts()
        {
            var downloadUrl = "https://github.com/sysadmin-groupj/scripts";
            TestFiles("sysadmin-groupj_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_glasnt_hackfest()
        {
            var downloadUrl = "https://github.com/glasnt/hackfest";
            TestFiles("glasnt_hackfest", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jeggelke_Dev()
        {
            var downloadUrl = "https://github.com/jeggelke/Dev";
            TestFiles("jeggelke_Dev", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ericdorsey_ADquery()
        {
            var downloadUrl = "https://github.com/ericdorsey/ADquery";
            TestFiles("ericdorsey_ADquery", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bogdanvarlamov_gadderstock()
        {
            var downloadUrl = "https://github.com/bogdanvarlamov/gadderstock";
            TestFiles("bogdanvarlamov_gadderstock", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jimmy0628_ImageBuilder()
        {
            var downloadUrl = "https://github.com/jimmy0628/ImageBuilder";
            TestFiles("jimmy0628_ImageBuilder", downloadUrl);
        }

        [TestMethod]
        public void GitHub_6megle_PowerShell2chViewer()
        {
            var downloadUrl = "https://github.com/6megle/PowerShell2chViewer";
            TestFiles("6megle_PowerShell2chViewer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Nemo157_PsBundle()
        {
            var downloadUrl = "https://github.com/Nemo157/PsBundle";
            TestFiles("Nemo157_PsBundle", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mattboston_s3pushpull()
        {
            var downloadUrl = "https://github.com/mattboston/s3pushpull";
            TestFiles("mattboston_s3pushpull", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ddhahn_Powershell_PasswordExpiryReport()
        {
            var downloadUrl = "https://github.com/ddhahn/Powershell-PasswordExpiryReport";
            TestFiles("ddhahn_Powershell-PasswordExpiryReport", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DamianZaremba_topaz()
        {
            var downloadUrl = "https://github.com/DamianZaremba/topaz";
            TestFiles("DamianZaremba_topaz", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vlele_AzureIaaSScripts()
        {
            var downloadUrl = "https://github.com/vlele/AzureIaaSScripts";
            TestFiles("vlele_AzureIaaSScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kmg90_toolkit()
        {
            var downloadUrl = "https://github.com/kmg90/toolkit";
            TestFiles("kmg90_toolkit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_DEMO_DeployingAD()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/DEMO-DeployingAD";
            TestFiles("WindowsAzure-TrainingKit_DEMO-DeployingAD", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Shaners_ShellScripting()
        {
            var downloadUrl = "https://github.com/Shaners/ShellScripting";
            TestFiles("Shaners_ShellScripting", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vederosoft_Vedero_API_Examples()
        {
            var downloadUrl = "https://github.com/vederosoft/Vedero.API.Examples";
            TestFiles("vederosoft_Vedero.API.Examples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tomconte_documents()
        {
            var downloadUrl = "https://github.com/tomconte/documents";
            TestFiles("tomconte_documents", downloadUrl);
        }

        [TestMethod]
        public void GitHub_itrond_testnode()
        {
            var downloadUrl = "https://github.com/itrond/testnode";
            TestFiles("itrond_testnode", downloadUrl);
        }

        [TestMethod]
        public void GitHub_marcote_environment()
        {
            var downloadUrl = "https://github.com/marcote/environment";
            TestFiles("marcote_environment", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Dreffed_scripts()
        {
            var downloadUrl = "https://github.com/Dreffed/scripts";
            TestFiles("Dreffed_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adminian_AzureSharePoint()
        {
            var downloadUrl = "https://github.com/adminian/AzureSharePoint";
            TestFiles("adminian_AzureSharePoint", downloadUrl);
        }


        [TestMethod]
        public void GitHub_BIAINC_pstddc()
        {
            var downloadUrl = "https://github.com/BIAINC/pstddc";
            TestFiles("BIAINC_pstddc", downloadUrl);
        }

        [TestMethod]
        public void GitHub_octopuscontrib_OctopusContrib_NewRelic()
        {
            var downloadUrl = "https://github.com/octopuscontrib/OctopusContrib.NewRelic";
            TestFiles("octopuscontrib_OctopusContrib.NewRelic", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mellibo_PowerShell_Modules()
        {
            var downloadUrl = "https://github.com/mellibo/PowerShell_Modules";
            TestFiles("mellibo_PowerShell_Modules", downloadUrl);
        }

        [TestMethod]
        public void GitHub_garignack_PS_Nessus_AccessDB()
        {
            var downloadUrl = "https://github.com/garignack/PS-Nessus-AccessDB";
            TestFiles("garignack_PS-Nessus-AccessDB", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ecwright3_NetMgmt()
        {
            var downloadUrl = "https://github.com/ecwright3/NetMgmt";
            TestFiles("ecwright3_NetMgmt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aaronnelson_PowershellStuff()
        {
            var downloadUrl = "https://github.com/aaronnelson/PowershellStuff";
            TestFiles("aaronnelson_PowershellStuff", downloadUrl);
        }

        [TestMethod]
        public void GitHub_isdaviddong_aspnet4WebFormsAuthAndGoogleoAuth()
        {
            var downloadUrl = "https://github.com/isdaviddong/aspnet4WebFormsAuthAndGoogleoAuth";
            TestFiles("isdaviddong_aspnet4WebFormsAuthAndGoogleoAuth", downloadUrl);
        }

        [TestMethod]
        public void GitHub_progre_nugetpackages()
        {
            var downloadUrl = "https://github.com/progre/nugetpackages";
            TestFiles("progre_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SqlSandwiches_SQLSandwiches()
        {
            var downloadUrl = "https://github.com/SqlSandwiches/SQLSandwiches";
            TestFiles("SqlSandwiches_SQLSandwiches", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adamdriscoll_fluentdwelling()
        {
            var downloadUrl = "https://github.com/adamdriscoll/fluentdwelling";
            TestFiles("adamdriscoll_fluentdwelling", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tanguy2m_LiveRsync()
        {
            var downloadUrl = "https://github.com/tanguy2m/LiveRsync";
            TestFiles("tanguy2m_LiveRsync", downloadUrl);
        }


        [TestMethod]
        public void GitHub_mikecole_MVVMSample()
        {
            var downloadUrl = "https://github.com/mikecole/MVVMSample";
            TestFiles("mikecole_MVVMSample", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Nurfballs_PowerShell()
        {
            var downloadUrl = "https://github.com/Nurfballs/PowerShell";
            TestFiles("Nurfballs_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nikolay_pshenichny_OctopusDeploy_PowerShell()
        {
            var downloadUrl = "https://github.com/nikolay-pshenichny/OctopusDeploy-PowerShell";
            TestFiles("nikolay-pshenichny_OctopusDeploy-PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_robmen_profile()
        {
            var downloadUrl = "https://github.com/robmen/profile";
            TestFiles("robmen_profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kulkarniankita09_Windows8Apps()
        {
            var downloadUrl = "https://github.com/kulkarniankita09/Windows8Apps";
            TestFiles("kulkarniankita09_Windows8Apps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adabei_dispenser()
        {
            var downloadUrl = "https://github.com/adabei/dispenser";
            TestFiles("adabei_dispenser", downloadUrl);
        }

        [TestMethod]
        public void GitHub_amatashkin_export_infobase()
        {
            var downloadUrl = "https://github.com/amatashkin/export-infobase";
            TestFiles("amatashkin_export-infobase", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DanielSiva_powershell_scripts()
        {
            var downloadUrl = "https://github.com/DanielSiva/powershell-scripts";
            TestFiles("DanielSiva_powershell-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mmitev_DevOps()
        {
            var downloadUrl = "https://github.com/mmitev/DevOps";
            TestFiles("mmitev_DevOps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dancastellani_farofa()
        {
            var downloadUrl = "https://github.com/dancastellani/farofa";
            TestFiles("dancastellani_farofa", downloadUrl);
        }

        [TestMethod]
        public void GitHub_carlioth_FishingApp()
        {
            var downloadUrl = "https://github.com/carlioth/FishingApp";
            TestFiles("carlioth_FishingApp", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pbolduc_Agrius()
        {
            var downloadUrl = "https://github.com/pbolduc/Agrius";
            TestFiles("pbolduc_Agrius", downloadUrl);
        }

        [TestMethod]
        public void GitHub_shin820_ProgrammingEF()
        {
            var downloadUrl = "https://github.com/shin820/ProgrammingEF";
            TestFiles("shin820_ProgrammingEF", downloadUrl);
        }

        [TestMethod]
        public void GitHub_arbesfeld_PowerShell()
        {
            var downloadUrl = "https://github.com/arbesfeld/PowerShell";
            TestFiles("arbesfeld_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_opentable_PowerNagios()
        {
            var downloadUrl = "https://github.com/opentable/PowerNagios";
            TestFiles("opentable_PowerNagios", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cyragon_CodeStock2013()
        {
            var downloadUrl = "https://github.com/cyragon/CodeStock2013";
            TestFiles("cyragon_CodeStock2013", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AWaterFountain_automation()
        {
            var downloadUrl = "https://github.com/AWaterFountain/automation";
            TestFiles("AWaterFountain_automation", downloadUrl);
        }

        [TestMethod]
        public void GitHub_e82eric_Azure_SharedKey_Powershell()
        {
            var downloadUrl = "https://github.com/e82eric/Azure-SharedKey-Powershell";
            TestFiles("e82eric_Azure-SharedKey-Powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_adlermedrado_my_powershell_tools()
        {
            var downloadUrl = "https://github.com/adlermedrado/my-powershell-tools";
            TestFiles("adlermedrado_my-powershell-tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sillvan_powershell()
        {
            var downloadUrl = "https://github.com/sillvan/powershell";
            TestFiles("sillvan_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_esoterydactyl_PowershellSnippets()
        {
            var downloadUrl = "https://github.com/esoterydactyl/PowershellSnippets";
            TestFiles("esoterydactyl_PowershellSnippets", downloadUrl);
        }

        [TestMethod]
        public void GitHub_victorwoo_verycd_extension()
        {
            var downloadUrl = "https://github.com/victorwoo/verycd-extension";
            TestFiles("victorwoo_verycd-extension", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jeffblankenburg_BowlingStatsPro()
        {
            var downloadUrl = "https://github.com/jeffblankenburg/BowlingStatsPro";
            TestFiles("jeffblankenburg_BowlingStatsPro", downloadUrl);
        }

        [TestMethod]
        public void GitHub_codeplanner_CodePlanner()
        {
            var downloadUrl = "https://github.com/codeplanner/CodePlanner";
            TestFiles("codeplanner_CodePlanner", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yangjeewoong_WindowsOS()
        {
            var downloadUrl = "https://github.com/yangjeewoong/WindowsOS";
            TestFiles("yangjeewoong_WindowsOS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dlewis3713_PowerShell_Personal()
        {
            var downloadUrl = "https://github.com/dlewis3713/PowerShell-Personal";
            TestFiles("dlewis3713_PowerShell-Personal", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pdxcat_Get_Logon()
        {
            var downloadUrl = "https://github.com/pdxcat/Get-Logon";
            TestFiles("pdxcat_Get-Logon", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lukesampson_cowsay_psh()
        {
            var downloadUrl = "https://github.com/lukesampson/cowsay-psh";
            TestFiles("lukesampson_cowsay-psh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hikaruyh88_Projects()
        {
            var downloadUrl = "https://github.com/hikaruyh88/Projects";
            TestFiles("hikaruyh88_Projects", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pdxcat_Get_LogonHistory()
        {
            var downloadUrl = "https://github.com/pdxcat/Get-LogonHistory";
            TestFiles("pdxcat_Get-LogonHistory", downloadUrl);
        }

        [TestMethod]
        public void GitHub_brianaddicks_prtgshell()
        {
            var downloadUrl = "https://github.com/brianaddicks/prtgshell";
            TestFiles("brianaddicks_prtgshell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrisrpatterson_dotfiles()
        {
            var downloadUrl = "https://github.com/chrisrpatterson/dotfiles";
            TestFiles("chrisrpatterson_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_brenopolanski_app_win8_gameTicTacToePaper()
        {
            var downloadUrl = "https://github.com/brenopolanski/app-win8-gameTicTacToePaper";
            TestFiles("brenopolanski_app-win8-gameTicTacToePaper", downloadUrl);
        }

        [TestMethod]
        public void GitHub_GiscardBiamby_ChocolateyPackages()
        {
            var downloadUrl = "https://github.com/GiscardBiamby/ChocolateyPackages";
            TestFiles("GiscardBiamby_ChocolateyPackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_malichite_VMWare()
        {
            var downloadUrl = "https://github.com/malichite/VMWare";
            TestFiles("malichite_VMWare", downloadUrl);
        }

        [TestMethod]
        public void GitHub_krispharper_Powershell_Scripts()
        {
            var downloadUrl = "https://github.com/krispharper/Powershell-Scripts";
            TestFiles("krispharper_Powershell-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yster_createuser()
        {
            var downloadUrl = "https://github.com/yster/createuser";
            TestFiles("yster_createuser", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Ponnuki_PowerShell()
        {
            var downloadUrl = "https://github.com/Ponnuki/PowerShell";
            TestFiles("Ponnuki_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lubson_domIS()
        {
            var downloadUrl = "https://github.com/lubson/domIS";
            TestFiles("lubson_domIS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_llstrk_Test()
        {
            var downloadUrl = "https://github.com/llstrk/Test";
            TestFiles("llstrk_Test", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TomOne_various()
        {
            var downloadUrl = "https://github.com/TomOne/various";
            TestFiles("TomOne_various", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JamesSeiters_Inventory_Console()
        {
            var downloadUrl = "https://github.com/JamesSeiters/Inventory-Console";
            TestFiles("JamesSeiters_Inventory-Console", downloadUrl);
        }

        [TestMethod]
        public void GitHub_blachniet_blachniet_psutils()
        {
            var downloadUrl = "https://github.com/blachniet/blachniet-psutils";
            TestFiles("blachniet_blachniet-psutils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sammcgeown_Change_HostPasswords()
        {
            var downloadUrl = "https://github.com/sammcgeown/Change-HostPasswords";
            TestFiles("sammcgeown_Change-HostPasswords", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Midacts_DisableInactiveUsers()
        {
            var downloadUrl = "https://github.com/Midacts/DisableInactiveUsers";
            TestFiles("Midacts_DisableInactiveUsers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pemo11_PSGit()
        {
            var downloadUrl = "https://github.com/pemo11/PSGit";
            TestFiles("pemo11_PSGit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_CameronAM_posh()
        {
            var downloadUrl = "https://github.com/CameronAM/posh";
            TestFiles("CameronAM_posh", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bmontgomery_SharePointSolutionDeployer()
        {
            var downloadUrl = "https://github.com/bmontgomery/SharePointSolutionDeployer";
            TestFiles("bmontgomery_SharePointSolutionDeployer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_caloggins_PowerShellScripts()
        {
            var downloadUrl = "https://github.com/caloggins/PowerShellScripts";
            TestFiles("caloggins_PowerShellScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kristinn_Stefansson_krschocolateypackages()
        {
            var downloadUrl = "https://github.com/Kristinn-Stefansson/krschocolateypackages";
            TestFiles("Kristinn-Stefansson_krschocolateypackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dustyburwell_homedir()
        {
            var downloadUrl = "https://github.com/dustyburwell/homedir";
            TestFiles("dustyburwell_homedir", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thaiphan_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/thaiphan/chocolatey-packages";
            TestFiles("thaiphan_chocolatey-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Kartones_PowerShellAssorted()
        {
            var downloadUrl = "https://github.com/Kartones/PowerShellAssorted";
            TestFiles("Kartones_PowerShellAssorted", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kmcginnes_BoxStarter()
        {
            var downloadUrl = "https://github.com/kmcginnes/BoxStarter";
            TestFiles("kmcginnes_BoxStarter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_elmundio87_RingfencedFileAlert()
        {
            var downloadUrl = "https://github.com/elmundio87/RingfencedFileAlert";
            TestFiles("elmundio87_RingfencedFileAlert", downloadUrl);
        }

        [TestMethod]
        public void GitHub_anant_pushkar_utk()
        {
            var downloadUrl = "https://github.com/anant-pushkar/utk";
            TestFiles("anant-pushkar_utk", downloadUrl);
        }

        [TestMethod]
        public void GitHub_coopdev_uhmessages()
        {
            var downloadUrl = "https://github.com/coopdev/uhmessages";
            TestFiles("coopdev_uhmessages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_glennlarson_Meal_planner()
        {
            var downloadUrl = "https://github.com/glennlarson/Meal-planner";
            TestFiles("glennlarson_Meal-planner", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WSCIUser_PSTest()
        {
            var downloadUrl = "https://github.com/WSCIUser/PSTest";
            TestFiles("WSCIUser_PSTest", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cardwookie_DataProtector()
        {
            var downloadUrl = "https://github.com/cardwookie/DataProtector";
            TestFiles("cardwookie_DataProtector", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Sergievskiy_HL7Service()
        {
            var downloadUrl = "https://github.com/Sergievskiy/HL7Service";
            TestFiles("Sergievskiy_HL7Service", downloadUrl);
        }

        [TestMethod]
        public void GitHub_urn42_Powershell_Experiments()
        {
            var downloadUrl = "https://github.com/urn42/Powershell-Experiments";
            TestFiles("urn42_Powershell-Experiments", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chuckstaburnt_fusibleplug()
        {
            var downloadUrl = "https://github.com/chuckstaburnt/fusibleplug";
            TestFiles("chuckstaburnt_fusibleplug", downloadUrl);
        }

        [TestMethod]
        public void GitHub_newrelic_nuget_agent_api()
        {
            var downloadUrl = "https://github.com/newrelic/nuget-agent-api";
            TestFiles("newrelic_nuget-agent-api", downloadUrl);
        }

        [TestMethod]
        public void GitHub_SolidusSnake_Tools()
        {
            var downloadUrl = "https://github.com/SolidusSnake/Tools";
            TestFiles("SolidusSnake_Tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vgrigoriu_scripts()
        {
            var downloadUrl = "https://github.com/vgrigoriu/scripts";
            TestFiles("vgrigoriu_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_CraigI_Exchange2007ExportMailboxes()
        {
            var downloadUrl = "https://github.com/CraigI/Exchange2007ExportMailboxes";
            TestFiles("CraigI_Exchange2007ExportMailboxes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cloudbase_adk_tools()
        {
            var downloadUrl = "https://github.com/cloudbase/adk-tools";
            TestFiles("cloudbase_adk-tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DavorJ_PS_Backup()
        {
            var downloadUrl = "https://github.com/DavorJ/PS-Backup";
            TestFiles("DavorJ_PS-Backup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_joerod_powershell()
        {
            var downloadUrl = "https://github.com/joerod/powershell";
            TestFiles("joerod_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AndyHale_RoomBooker()
        {
            var downloadUrl = "https://github.com/AndyHale/RoomBooker";
            TestFiles("AndyHale_RoomBooker", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nconrads_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/nconrads/chocolatey_packages";
            TestFiles("nconrads_chocolatey_packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_WindowsAzure_TrainingKit_DEMO_ConnectingCloudServices()
        {
            var downloadUrl = "https://github.com/WindowsAzure-TrainingKit/DEMO-ConnectingCloudServices";
            TestFiles("WindowsAzure-TrainingKit_DEMO-ConnectingCloudServices", downloadUrl);
        }

        [TestMethod]
        public void GitHub_vkorppi_PowerShellScript_to_unify_AccessRights_of_mailboxes()
        {
            var downloadUrl = "https://github.com/vkorppi/PowerShellScript-to-unify-AccessRights-of-mailboxes";
            TestFiles("vkorppi_PowerShellScript-to-unify-AccessRights-of-mailboxes", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smattoo_ReceiptPrinter()
        {
            var downloadUrl = "https://github.com/smattoo/ReceiptPrinter";
            TestFiles("smattoo_ReceiptPrinter", downloadUrl);
        }

        [TestMethod]
        public void GitHub_areteinc_gitprocess()
        {
            var downloadUrl = "https://github.com/areteinc/gitprocess";
            TestFiles("areteinc_gitprocess", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rmorrin_ps_profile()
        {
            var downloadUrl = "https://github.com/rmorrin/ps-profile";
            TestFiles("rmorrin_ps-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_poolebc_WindowsProxySetup()
        {
            var downloadUrl = "https://github.com/poolebc/WindowsProxySetup";
            TestFiles("poolebc_WindowsProxySetup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pdxcat_PrepDeploy()
        {
            var downloadUrl = "https://github.com/pdxcat/PrepDeploy";
            TestFiles("pdxcat_PrepDeploy", downloadUrl);
        }

        [TestMethod]
        public void GitHub_knutkj_sockettoolkit()
        {
            var downloadUrl = "https://github.com/knutkj/sockettoolkit";
            TestFiles("knutkj_sockettoolkit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ryo_murai_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/ryo-murai/WindowsPowerShell";
            TestFiles("ryo-murai_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_soulery_test()
        {
            var downloadUrl = "https://github.com/soulery/test";
            TestFiles("soulery_test", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JaminQuimby_jqPower()
        {
            var downloadUrl = "https://github.com/JaminQuimby/jqPower";
            TestFiles("JaminQuimby_jqPower", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dteverett_SickScripts()
        {
            var downloadUrl = "https://github.com/dteverett/SickScripts";
            TestFiles("dteverett_SickScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_daveshah_dotfiles()
        {
            var downloadUrl = "https://github.com/daveshah/dotfiles";
            TestFiles("daveshah_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jsakamoto_nupkg_selenium_webdriver_iedriver()
        {
            var downloadUrl = "https://github.com/jsakamoto/nupkg-selenium-webdriver-iedriver";
            TestFiles("jsakamoto_nupkg-selenium-webdriver-iedriver", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dcjulian29_WindowsPowerShell()
        {
            var downloadUrl = "https://github.com/dcjulian29/WindowsPowerShell";
            TestFiles("dcjulian29_WindowsPowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jeffreypalermo_onion_architecture_distributed()
        {
            var downloadUrl = "https://github.com/jeffreypalermo/onion-architecture-distributed";
            TestFiles("jeffreypalermo_onion-architecture-distributed", downloadUrl);
        }

        [TestMethod]
        public void GitHub_michelr_dotfiles()
        {
            var downloadUrl = "https://github.com/michelr/dotfiles";
            TestFiles("michelr_dotfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lukesampson_scoop_extras()
        {
            var downloadUrl = "https://github.com/lukesampson/scoop-extras";
            TestFiles("lukesampson_scoop-extras", downloadUrl);
        }

        [TestMethod]
        public void GitHub_guadacasuso_WAPowerShellScripts()
        {
            var downloadUrl = "https://github.com/guadacasuso/WAPowerShellScripts";
            TestFiles("guadacasuso_WAPowerShellScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_CraigI_DeprovisionDisabledUsers()
        {
            var downloadUrl = "https://github.com/CraigI/DeprovisionDisabledUsers";
            TestFiles("CraigI_DeprovisionDisabledUsers", downloadUrl);
        }

        [TestMethod]
        public void GitHub_eplouhinec_chocolatey_packages()
        {
            var downloadUrl = "https://github.com/eplouhinec/chocolatey-packages";
            TestFiles("eplouhinec_chocolatey-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_esacteksab_PowerShell()
        {
            var downloadUrl = "https://github.com/esacteksab/PowerShell";
            TestFiles("esacteksab_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_qinxij_install_remove_software()
        {
            var downloadUrl = "https://github.com/qinxij/install_remove_software";
            TestFiles("qinxij_install_remove_software", downloadUrl);
        }

        [TestMethod]
        public void GitHub_uniquelau_vdb_Common_Project()
        {
            var downloadUrl = "https://github.com/uniquelau/vdb.Common.Project";
            TestFiles("uniquelau_vdb.Common.Project", downloadUrl);
        }

        [TestMethod]
        public void GitHub_tbedi_iTOLEDO()
        {
            var downloadUrl = "https://github.com/tbedi/iTOLEDO";
            TestFiles("tbedi_iTOLEDO", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rakheshster_PS_AppMgmt()
        {
            var downloadUrl = "https://github.com/rakheshster/PS-AppMgmt";
            TestFiles("rakheshster_PS-AppMgmt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Ercenk_azurevm_ps_samples()
        {
            var downloadUrl = "https://github.com/Ercenk/azurevm-ps-samples";
            TestFiles("Ercenk_azurevm-ps-samples", downloadUrl);
        }

        [TestMethod]
        public void GitHub_RaveMaker_VMware_VM_Cloner()
        {
            var downloadUrl = "https://github.com/RaveMaker/VMware-VM-Cloner";
            TestFiles("RaveMaker_VMware-VM-Cloner", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ScottWeinstein_RequireJS_Nuget()
        {
            var downloadUrl = "https://github.com/ScottWeinstein/RequireJS-Nuget";
            TestFiles("ScottWeinstein_RequireJS-Nuget", downloadUrl);
        }

        [TestMethod]
        public void GitHub_khanfx_resume()
        {
            var downloadUrl = "https://github.com/khanfx/resume";
            TestFiles("khanfx_resume", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ComFreek_IcoHolder()
        {
            var downloadUrl = "https://github.com/ComFreek/IcoHolder";
            TestFiles("ComFreek_IcoHolder", downloadUrl);
        }

        [TestMethod]
        public void GitHub_deanet_Powershell_rsync()
        {
            var downloadUrl = "https://github.com/deanet/Powershell-rsync";
            TestFiles("deanet_Powershell-rsync", downloadUrl);
        }

        [TestMethod]
        public void GitHub_BlueBasher_EFNinject()
        {
            var downloadUrl = "https://github.com/BlueBasher/EFNinject";
            TestFiles("BlueBasher_EFNinject", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrismckelt_BuildScripts()
        {
            var downloadUrl = "https://github.com/chrismckelt/BuildScripts";
            TestFiles("chrismckelt_BuildScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_piers7_pink()
        {
            var downloadUrl = "https://github.com/piers7/pink";
            TestFiles("piers7_pink", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Phil_Factor_CentralManagementServerScripts()
        {
            var downloadUrl = "https://github.com/Phil-Factor/CentralManagementServerScripts";
            TestFiles("Phil-Factor_CentralManagementServerScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Inlogik_Squawkings()
        {
            var downloadUrl = "https://github.com/Inlogik/Squawkings";
            TestFiles("Inlogik_Squawkings", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Polonius19_PoSH()
        {
            var downloadUrl = "https://github.com/Polonius19/PoSH";
            TestFiles("Polonius19_PoSH", downloadUrl);
        }

        [TestMethod]
        public void GitHub_luislee818_TFS_CherryPicky()
        {
            var downloadUrl = "https://github.com/luislee818/TFS_CherryPicky";
            TestFiles("luislee818_TFS_CherryPicky", downloadUrl);
        }

        [TestMethod]
        public void GitHub_PaulMilbank_VMMScripts()
        {
            var downloadUrl = "https://github.com/PaulMilbank/VMMScripts";
            TestFiles("PaulMilbank_VMMScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_seizethemoment12_OrganizeMusic()
        {
            var downloadUrl = "https://github.com/seizethemoment12/OrganizeMusic";
            TestFiles("seizethemoment12_OrganizeMusic", downloadUrl);
        }

        [TestMethod]
        public void GitHub_smashdevcode_CalorieCounterDataLayer()
        {
            var downloadUrl = "https://github.com/smashdevcode/CalorieCounterDataLayer";
            TestFiles("smashdevcode_CalorieCounterDataLayer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_SvcHostManagement()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.SvcHostManagement";
            TestFiles("sergey-s-betke_ITG.SvcHostManagement", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_WinAPI()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.WinAPI";
            TestFiles("sergey-s-betke_ITG.WinAPI", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zachbonham_PsMonkeyPatch()
        {
            var downloadUrl = "https://github.com/zachbonham/PsMonkeyPatch";
            TestFiles("zachbonham_PsMonkeyPatch", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sergey_s_betke_ITG_RegExps()
        {
            var downloadUrl = "https://github.com/sergey-s-betke/ITG.RegExps";
            TestFiles("sergey-s-betke_ITG.RegExps", downloadUrl);
        }

        [TestMethod]
        public void GitHub_borigas_PowershellScripts()
        {
            var downloadUrl = "https://github.com/borigas/PowershellScripts";
            TestFiles("borigas_PowershellScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wheelert_TekTools()
        {
            var downloadUrl = "https://github.com/wheelert/TekTools";
            TestFiles("wheelert_TekTools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ronanmoynihan_MongoSpringDevSetupScript()
        {
            var downloadUrl = "https://github.com/ronanmoynihan/MongoSpringDevSetupScript";
            TestFiles("ronanmoynihan_MongoSpringDevSetupScript", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JohanCyprich_DFS()
        {
            var downloadUrl = "https://github.com/JohanCyprich/DFS";
            TestFiles("JohanCyprich_DFS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_MartinBjornebye_Crammer()
        {
            var downloadUrl = "https://github.com/MartinBjornebye/Crammer";
            TestFiles("MartinBjornebye_Crammer", downloadUrl);
        }

        [TestMethod]
        public void GitHub_elpikel_Publisher()
        {
            var downloadUrl = "https://github.com/elpikel/Publisher";
            TestFiles("elpikel_Publisher", downloadUrl);
        }

        [TestMethod]
        public void GitHub_writeameer_scriptrepo()
        {
            var downloadUrl = "https://github.com/writeameer/scriptrepo";
            TestFiles("writeameer_scriptrepo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_lenchevsky_scripts()
        {
            var downloadUrl = "https://github.com/lenchevsky/scripts";
            TestFiles("lenchevsky_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jackiesingh_WindowsLaptopLocatorScript()
        {
            var downloadUrl = "https://github.com/jackiesingh/WindowsLaptopLocatorScript";
            TestFiles("jackiesingh_WindowsLaptopLocatorScript", downloadUrl);
        }

        [TestMethod]
        public void GitHub_flok2lok_dontlookmvcmagazine()
        {
            var downloadUrl = "https://github.com/flok2lok/dontlookmvcmagazine";
            TestFiles("flok2lok_dontlookmvcmagazine", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kyoji_y_PSUtils()
        {
            var downloadUrl = "https://github.com/kyoji-y/PSUtils";
            TestFiles("kyoji-y_PSUtils", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jhpaterson_MappingExampleEF5()
        {
            var downloadUrl = "https://github.com/jhpaterson/MappingExampleEF5";
            TestFiles("jhpaterson_MappingExampleEF5", downloadUrl);
        }

        [TestMethod]
        public void GitHub_giggio_poshfiles()
        {
            var downloadUrl = "https://github.com/giggio/poshfiles";
            TestFiles("giggio_poshfiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_koolala_azure_usage_monitoring()
        {
            var downloadUrl = "https://github.com/koolala/azure-usage-monitoring";
            TestFiles("koolala_azure-usage-monitoring", downloadUrl);
        }

        [TestMethod]
        public void GitHub_sreal_ducking_bear_tools()
        {
            var downloadUrl = "https://github.com/sreal/ducking-bear-tools";
            TestFiles("sreal_ducking-bear-tools", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ottoo_ProjectPartner()
        {
            var downloadUrl = "https://github.com/ottoo/ProjectPartner";
            TestFiles("ottoo_ProjectPartner", downloadUrl);
        }

        [TestMethod]
        public void GitHub_StealFocus_EventStoreExtensions()
        {
            var downloadUrl = "https://github.com/StealFocus/EventStoreExtensions";
            TestFiles("StealFocus_EventStoreExtensions", downloadUrl);
        }

        [TestMethod]
        public void GitHub_StealFocus_NServiceBusExtensions()
        {
            var downloadUrl = "https://github.com/StealFocus/NServiceBusExtensions";
            TestFiles("StealFocus_NServiceBusExtensions", downloadUrl);
        }

        [TestMethod]
        public void GitHub_illearth_powershell_taglib()
        {
            var downloadUrl = "https://github.com/illearth/powershell-taglib";
            TestFiles("illearth_powershell-taglib", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chromigo_BookLibraryWPF()
        {
            var downloadUrl = "https://github.com/chromigo/BookLibraryWPF";
            TestFiles("chromigo_BookLibraryWPF", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jpuskar_JP_Public_Repo()
        {
            var downloadUrl = "https://github.com/jpuskar/JP-Public-Repo";
            TestFiles("jpuskar_JP-Public-Repo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_masterots_scripts()
        {
            var downloadUrl = "https://github.com/masterots/scripts";
            TestFiles("masterots_scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Paco112_2008R2Setup()
        {
            var downloadUrl = "https://github.com/Paco112/2008R2Setup";
            TestFiles("Paco112_2008R2Setup", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rmoorehe_powershell_snippets()
        {
            var downloadUrl = "https://github.com/rmoorehe/powershell-snippets";
            TestFiles("rmoorehe_powershell-snippets", downloadUrl);
        }

        [TestMethod]
        public void GitHub_JMayrbaeurl_GotoZurich2013JavaOnAzureSample()
        {
            var downloadUrl = "https://github.com/JMayrbaeurl/GotoZurich2013JavaOnAzureSample";
            TestFiles("JMayrbaeurl_GotoZurich2013JavaOnAzureSample", downloadUrl);
        }

        [TestMethod]
        public void GitHub_rcjames1004_PowerShell()
        {
            var downloadUrl = "https://github.com/rcjames1004/PowerShell";
            TestFiles("rcjames1004_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ptoth_countPicturesAndFiles()
        {
            var downloadUrl = "https://github.com/ptoth/countPicturesAndFiles";
            TestFiles("ptoth_countPicturesAndFiles", downloadUrl);
        }

        [TestMethod]
        public void GitHub_michaelsalisbury_vbox_win_scripts()
        {
            var downloadUrl = "https://github.com/michaelsalisbury/vbox-win-scripts";
            TestFiles("michaelsalisbury_vbox-win-scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kyanro_mytool()
        {
            var downloadUrl = "https://github.com/kyanro/mytool";
            TestFiles("kyanro_mytool", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ViktorL_FirstApp()
        {
            var downloadUrl = "https://github.com/ViktorL/FirstApp";
            TestFiles("ViktorL_FirstApp", downloadUrl);
        }

        [TestMethod]
        public void GitHub_camiloamora_pagosin()
        {
            var downloadUrl = "https://github.com/camiloamora/pagosin";
            TestFiles("camiloamora_pagosin", downloadUrl);
        }

        [TestMethod]
        public void GitHub_VictorGubin_Mailbox_Move()
        {
            var downloadUrl = "https://github.com/VictorGubin/Mailbox-Move";
            TestFiles("VictorGubin_Mailbox-Move", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gswallow_vmware_powershell()
        {
            var downloadUrl = "https://github.com/gswallow/vmware-powershell";
            TestFiles("gswallow_vmware-powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_hcavalle_powershell()
        {
            var downloadUrl = "https://github.com/hcavalle/powershell";
            TestFiles("hcavalle_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_aleksey_berezan_psini()
        {
            var downloadUrl = "https://github.com/aleksey-berezan/psini";
            TestFiles("aleksey-berezan_psini", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yngvebn_Novanet_CQRS()
        {
            var downloadUrl = "https://github.com/yngvebn/Novanet.CQRS";
            TestFiles("yngvebn_Novanet.CQRS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jwstl_SPPowerShellScripts()
        {
            var downloadUrl = "https://github.com/jwstl/SPPowerShellScripts";
            TestFiles("jwstl_SPPowerShellScripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_glasnt_nsclient_checks()
        {
            var downloadUrl = "https://github.com/glasnt/nsclient-checks";
            TestFiles("glasnt_nsclient-checks", downloadUrl);
        }

        [TestMethod]
        public void GitHub_kjacobsen_PSBCrypt()
        {
            var downloadUrl = "https://github.com/kjacobsen/PSBCrypt";
            TestFiles("kjacobsen_PSBCrypt", downloadUrl);
        }

        [TestMethod]
        public void GitHub_dvansant_gnops()
        {
            var downloadUrl = "https://github.com/dvansant/gnops";
            TestFiles("dvansant_gnops", downloadUrl);
        }

        [TestMethod]
        public void GitHub_seniorOtaka_MedicalIndex()
        {
            var downloadUrl = "https://github.com/seniorOtaka/MedicalIndex";
            TestFiles("seniorOtaka_MedicalIndex", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jamesfoster_nuget_packages()
        {
            var downloadUrl = "https://github.com/jamesfoster/nuget-packages";
            TestFiles("jamesfoster_nuget-packages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_pik4ez_envy()
        {
            var downloadUrl = "https://github.com/pik4ez/envy";
            TestFiles("pik4ez_envy", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jhpaterson_NDBT_lab3()
        {
            var downloadUrl = "https://github.com/jhpaterson/NDBT_lab3";
            TestFiles("jhpaterson_NDBT_lab3", downloadUrl);
        }

        [TestMethod]
        public void GitHub_GingaNinja_nugetpackages()
        {
            var downloadUrl = "https://github.com/GingaNinja/nugetpackages";
            TestFiles("GingaNinja_nugetpackages", downloadUrl);
        }

        [TestMethod]
        public void GitHub_savpek_Powershell_Scripts()
        {
            var downloadUrl = "https://github.com/savpek/Powershell-Scripts";
            TestFiles("savpek_Powershell-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_donhector_WifiHotspot()
        {
            var downloadUrl = "https://github.com/donhector/WifiHotspot";
            TestFiles("donhector_WifiHotspot", downloadUrl);
        }

        [TestMethod]
        public void GitHub_zjkyz8_PS()
        {
            var downloadUrl = "https://github.com/zjkyz8/PS";
            TestFiles("zjkyz8_PS", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bjourne_TfsHandy()
        {
            var downloadUrl = "https://github.com/bjourne/TfsHandy";
            TestFiles("bjourne_TfsHandy", downloadUrl);
        }

        [TestMethod]
        public void GitHub_quicksolutions_azure_cloud_demo()
        {
            var downloadUrl = "https://github.com/quicksolutions/azure-cloud-demo";
            TestFiles("quicksolutions_azure-cloud-demo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_McSquibbly_disky()
        {
            var downloadUrl = "https://github.com/McSquibbly/disky";
            TestFiles("McSquibbly_disky", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Zomgrei_powershell_ftp_upload()
        {
            var downloadUrl = "https://github.com/Zomgrei/powershell-ftp-upload";
            TestFiles("Zomgrei_powershell-ftp-upload", downloadUrl);
        }

        [TestMethod]
        public void GitHub_romaklimenko_dbstate()
        {
            var downloadUrl = "https://github.com/romaklimenko/dbstate";
            TestFiles("romaklimenko_dbstate", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jhpaterson_MappingExampleEF5Modeling_Part2()
        {
            var downloadUrl = "https://github.com/jhpaterson/MappingExampleEF5Modeling_Part2";
            TestFiles("jhpaterson_MappingExampleEF5Modeling_Part2", downloadUrl);
        }

        [TestMethod]
        public void GitHub_geoffreysamper_javascript_teamcity_integration()
        {
            var downloadUrl = "https://github.com/geoffreysamper/javascript-teamcity-integration";
            TestFiles("geoffreysamper_javascript-teamcity-integration", downloadUrl);
        }

        [TestMethod]
        public void GitHub_GingaNinja_DevInstall()
        {
            var downloadUrl = "https://github.com/GingaNinja/DevInstall";
            TestFiles("GingaNinja_DevInstall", downloadUrl);
        }

        [TestMethod]
        public void GitHub_thetoast_powershell()
        {
            var downloadUrl = "https://github.com/thetoast/powershell";
            TestFiles("thetoast_powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_TheAngryByrd_WACKPowershell()
        {
            var downloadUrl = "https://github.com/TheAngryByrd/WACKPowershell";
            TestFiles("TheAngryByrd_WACKPowershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_FesSpinosa_Preisanpassungen()
        {
            var downloadUrl = "https://github.com/FesSpinosa/Preisanpassungen";
            TestFiles("FesSpinosa_Preisanpassungen", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mossywell_PS3_xbmc_screen_reset()
        {
            var downloadUrl = "https://github.com/mossywell/PS3-xbmc-screen-reset";
            TestFiles("mossywell_PS3-xbmc-screen-reset", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chall32_VMBuild()
        {
            var downloadUrl = "https://github.com/chall32/VMBuild";
            TestFiles("chall32_VMBuild", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DRCOG_PowerShell_Scripts()
        {
            var downloadUrl = "https://github.com/DRCOG/PowerShell-Scripts";
            TestFiles("DRCOG_PowerShell-Scripts", downloadUrl);
        }

        [TestMethod]
        public void GitHub_ajaydivakaran_PowerShell()
        {
            var downloadUrl = "https://github.com/ajaydivakaran/PowerShell";
            TestFiles("ajaydivakaran_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_gooooloo_lovingRenju1()
        {
            var downloadUrl = "https://github.com/gooooloo/lovingRenju1";
            TestFiles("gooooloo_lovingRenju1", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Bonuspunkt_wnave()
        {
            var downloadUrl = "https://github.com/Bonuspunkt/wnave";
            TestFiles("Bonuspunkt_wnave", downloadUrl);
        }

        [TestMethod]
        public void GitHub_diegopol_dotseven()
        {
            var downloadUrl = "https://github.com/diegopol/dotseven";
            TestFiles("diegopol_dotseven", downloadUrl);
        }

        [TestMethod]
        public void GitHub_fuhoi_ps_sql_exe()
        {
            var downloadUrl = "https://github.com/fuhoi/ps-sql-exe";
            TestFiles("fuhoi_ps-sql-exe", downloadUrl);
        }

        [TestMethod]
        public void GitHub_chrisdostert_CM_Notification()
        {
            var downloadUrl = "https://github.com/chrisdostert/CM.Notification";
            TestFiles("chrisdostert_CM.Notification", downloadUrl);
        }

        [TestMethod]
        public void GitHub_mar614_testRepository()
        {
            var downloadUrl = "https://github.com/mar614/testRepository";
            TestFiles("mar614_testRepository", downloadUrl);
        }

        [TestMethod]
        public void GitHub_buzzlight_schoolkit()
        {
            var downloadUrl = "https://github.com/buzzlight/schoolkit";
            TestFiles("buzzlight_schoolkit", downloadUrl);
        }

        [TestMethod]
        public void GitHub_brunomlopes_pap_2013_05_25_powershell()
        {
            var downloadUrl = "https://github.com/brunomlopes/pap-2013-05-25-powershell";
            TestFiles("brunomlopes_pap-2013-05-25-powershell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_philbritton_polkadots()
        {
            var downloadUrl = "https://github.com/philbritton/polkadots";
            TestFiles("philbritton_polkadots", downloadUrl);
        }

        [TestMethod]
        public void GitHub_UCL_ActiveDirectory_CertificateAuthority()
        {
            var downloadUrl = "https://github.com/UCL/ActiveDirectory-CertificateAuthority";
            TestFiles("UCL_ActiveDirectory-CertificateAuthority", downloadUrl);
        }

        [TestMethod]
        public void GitHub_DonTomato_OrmTest()
        {
            var downloadUrl = "https://github.com/DonTomato/OrmTest";
            TestFiles("DonTomato_OrmTest", downloadUrl);
        }

        [TestMethod]
        public void GitHub_craibuc_PsCrystal()
        {
            var downloadUrl = "https://github.com/craibuc/PsCrystal";
            TestFiles("craibuc_PsCrystal", downloadUrl);
        }

        [TestMethod]
        public void GitHub_wrideout_PowerShell()
        {
            var downloadUrl = "https://github.com/wrideout/PowerShell";
            TestFiles("wrideout_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_diasfulvio_Repository()
        {
            var downloadUrl = "https://github.com/diasfulvio/Repository";
            TestFiles("diasfulvio_Repository", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Iristyle_AnalysisRules()
        {
            var downloadUrl = "https://github.com/Iristyle/AnalysisRules";
            TestFiles("Iristyle_AnalysisRules", downloadUrl);
        }

        [TestMethod]
        public void GitHub_bj_colley_BGinfo()
        {
            var downloadUrl = "https://github.com/bj-colley/BGinfo";
            TestFiles("bj-colley_BGinfo", downloadUrl);
        }

        [TestMethod]
        public void GitHub_jttuboi_Mp3Tag_Manager()
        {
            var downloadUrl = "https://github.com/jttuboi/Mp3Tag-Manager";
            TestFiles("jttuboi_Mp3Tag-Manager", downloadUrl);
        }

        [TestMethod]
        public void GitHub_AdamKorczynski_Scripting_Games()
        {
            var downloadUrl = "https://github.com/AdamKorczynski/Scripting-Games";
            TestFiles("AdamKorczynski_Scripting-Games", downloadUrl);
        }

        [TestMethod]
        public void GitHub_yuwei_wang_PowerShell()
        {
            var downloadUrl = "https://github.com/yuwei-wang/PowerShell";
            TestFiles("yuwei-wang_PowerShell", downloadUrl);
        }

        [TestMethod]
        public void GitHub_erikojebo_msbuild_example()
        {
            var downloadUrl = "https://github.com/erikojebo/msbuild-example";
            TestFiles("erikojebo_msbuild-example", downloadUrl);
        }

        [TestMethod]
        public void GitHub_xingmin_stayhome()
        {
            var downloadUrl = "https://github.com/xingmin/stayhome";
            TestFiles("xingmin_stayhome", downloadUrl);
        }

        [TestMethod]
        public void GitHub_Andrey4623_GameForCats()
        {
            var downloadUrl = "https://github.com/Andrey4623/GameForCats";
            TestFiles("Andrey4623_GameForCats", downloadUrl);
        }

        [TestMethod]
        public void GitHub_cbadke_powershell_profile()
        {
            var downloadUrl = "https://github.com/cbadke/powershell-profile";
            TestFiles("cbadke_powershell-profile", downloadUrl);
        }

        [TestMethod]
        public void GitHub_nslowes_chocolatey_chef_client()
        {
            var downloadUrl = "https://github.com/nslowes/chocolatey-chef-client";
            TestFiles("nslowes_chocolatey-chef-client", downloadUrl);
        }

        [TestMethod]
        public void GitHub_guitarrapc_valentia()
        {
            var downloadUrl = "https://github.com/guitarrapc/valentia";
            TestFiles("guitarrapc_valentia", downloadUrl);
        }

        
        #endregion


        private const string BasePath = @"..\..\Scripts\GitHub";
        private void TestFiles(string directoryName, string downloadUrl)
        {
            var diffLaunchBatPath = Utility.TestFiles(BasePath, directoryName, downloadUrl);

            //Append Result Diff bat file
            TestContext.AddResultFile(diffLaunchBatPath);
        }
    }
}
