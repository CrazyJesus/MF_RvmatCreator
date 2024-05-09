
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MF_RvmatCreator
{
    public enum DamageType
    {
        None,
        Damage,
        Destruct
    }

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

  

        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            
            RvmatManager.Init();
            RvmatCreator m_RvmatCreator = new RvmatCreator();
            //RvmatManager manager = new RvmatManager();
            //manager.Init();
            Application.Run(m_RvmatCreator);
            
        }   
    }

    public static class RvmatManager
    {
        private static string m_JsonPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\MF_RvmatCreateor";
        private static string m_JsonFileName = "\\Rvmats.json";
        private static string m_JsonSettings = "\\Setings.json";

        public static string m_TempFile = m_JsonPath + "\\Temp.cs";

        private static readonly string m_DamagePath = "dz\\characters\\data\\generic_damage_mc.paa";
        private static string m_DestructPath = "dz\\characters\\data\\generic_destruct_mc.paa";

        public static string m_DefultAs = "#(argb,8,8,3)color(1,1,1,1,AS)";
        public static string m_DefultSmdi = "#(argb,8,8,3)color(1,1,1,1,SMDI)";
        public static string m_DefultNohq = "#(argb,8,8,3)color(0.5,0.5,1,1,NOHQ)";
        public static string m_DefultMc = "#(argb,8,8,3)color(0,0,0,0,MC)";

        public static string m_DamageTexture = "dz\\characters\\data\\generic_damage_mc.paa";
        public static string m_DestructTexture = "dz\\characters\\data\\generic_destruct_mc.paa";

        private static RvmatConfig m_RvmatJson = new();
        private static RvmatCreatorSettings m_settings = new();

        //Init

        public static void Init()
        {
            ReadRvmatJson();
            ReadSettingJson();
        }
        
        public static void ReadSettingJson()
        {
            string jsonPath = m_JsonPath + m_JsonSettings;
            if (!Directory.Exists(m_JsonPath))
            {
                Directory.CreateDirectory(m_JsonPath);
            }

            if (File.Exists(jsonPath))
            {
                string text = File.ReadAllText(jsonPath);
                if (text != null)
                {
                    m_settings = JsonConvert.DeserializeObject<RvmatCreatorSettings>(text);
                }

            }
            else
            {
                m_settings = new RvmatCreatorSettings();
                string json = JsonConvert.SerializeObject(m_settings, Formatting.Indented);

                System.IO.File.WriteAllText(jsonPath, json);
            }
        }

        public static void ReadRvmatJson()
        {
            string jsonPath = m_JsonPath + m_JsonFileName;
             if(!Directory.Exists(m_JsonPath)) {
                 Directory.CreateDirectory(m_JsonPath);
             }

            if (File.Exists(jsonPath))
            {
                string text = File.ReadAllText(jsonPath);
                if (text != null)
                {
                    m_RvmatJson = JsonConvert.DeserializeObject<RvmatConfig>(text);
                }
            }
            else
            {
                m_RvmatJson = GetDefultConfig();
                string json = JsonConvert.SerializeObject(m_RvmatJson, Formatting.Indented);

                System.IO.File.WriteAllText(jsonPath, json);
            }
        }

        public static RvmatConfig GetDefultConfig()
        {
            RvmatConfig config = new();
            config.m_RVMAT.Add("Iron", "ambient[] = { 1, 1, 1, 1 };\r\ndiffuse[] = { 1, 1, 1, 1 };\r\nforcedDiffuse[] = { 0, 0, 0, 1 };\r\nemmisive[] = { 0, 0, 0, 1 };\r\nspecular[] = { 0.4, 0.38, 0.36, 1 };\r\nspecularPower = 32;\r\nPixelShaderID = \"Super\";\r\nVertexShaderID = \"Super\";\r\nclass Stage1 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage2 {\r\n\ttexture = \"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 1, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage3 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage4 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 1 };\r\n\t};\r\n};\r\nclass Stage5 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage6 {\r\n\ttexture = \"#(ai,64,64,1)fresnel(3.12,3.87)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage7 {\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuseWorldEnvMap = \"true\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Wood", "ambient[] = { 1, 1, 1, 1 };\r\ndiffuse[] = { 1, 1, 1, 1 };\r\nforcedDiffuse[] = { 0, 0, 0, 1 };\r\nemmisive[] = { 0, 0, 0, 1 };\r\nspecular[] = { 0.16, 0.16, 0.16, 1 };\r\nspecularPower = 45;\r\nPixelShaderID = \"Super\";\r\nVertexShaderID = \"Super\";\r\nclass Stage1 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage2 {\r\n\ttexture = \"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 1, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage3 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage4 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 1 };\r\n\t};\r\n};\r\nclass Stage5 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage6 {\r\n\ttexture = \"#(ai,64,64,1)fresnel(1.5,0.45)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage7 {\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuseWorldEnvMap = \"true\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Gold", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[] = {0.3, 0.3, 0.3, 1 };\r\nspecularPower=320;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture = \"#(ai,64,64,1)fresnel(1.1,0.3)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Mate_Plactic", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.050000008,0.050000008,0.050000008,1};\r\nspecularPower=200;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,32,128,1)fresnel(0.67,0.04)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Meat_Raw", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.5,0.5,0.5,1};\r\nspecularPower=200;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(1,0.7)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Metal_Armor", "ambient[]={0.5,0.5,0.5,1};\r\ndiffuse[]={0.5,0.5,0.5,1};\r\nforcedDiffuse[]={0.5,0.5,0.5,1};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.32941177,0.32941177,0.32156864,1};\r\nspecularPower=90;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(1,0.7)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Plastic_Furniture", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[] = {0.3, 0.3, 0.3, 1 };\r\nspecularPower=320;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture = \"#(ai,64,64,1)fresnel(1.1,0.3)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Shine_leather", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={1,0.82800013,0.82800013,1};\r\nspecularPower=80;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"MF_Exo\\data\\proto\\MF_Exo_proto_nohq.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0,0,0,0,MC)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"MF_Exo\\data\\proto\\MF_Exo_proto_as.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"MF_Exo\\data\\proto\\MF_Exo_proto_smdi.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(1,0.43)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0,0,0,1,CO)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Shine_metal_soda_can", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={1,1,1,1};\r\nspecularPower=500;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(1.1,0.51)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Shine_regular_clothes", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.49411765,0.49411765,0.49411765,1};\r\nspecularPower=50;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(2.06,1.02)\";\r\n\tuvSource=\"none\";\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.1,0.1,0.1,1,CO)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Steel_Gun", "ambient[]={1,1,1,1};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.1,0.1,0.1,1};\r\nspecularPower=80;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,32,128,1)fresnel(0.7,0.8)\";\r\n\tuvSource=\"none\";\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_roughness_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Tired_rubber", "ambient[]={0.81960785,0.8509804,0.87058824,1};\r\ndiffuse[]={0.81960785,0.8509804,0.87058824,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.1,0.1,0.1,1};\r\nspecularPower=180;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(2.05,0.45)\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,0};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\nclass Stage7\r\n{\r\n\ttexture=\"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource=\"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[]={1,0,0};\r\n\t\tup[]={0,1,0};\r\n\t\tdir[]={0,0,1};\r\n\t\tpos[]={0,0,0};\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Zombie_creature_sharp", "ambient[]={2,2,2,2};\r\ndiffuse[]={1,1,1,1};\r\nforcedDiffuse[]={0,0,0,0};\r\nemmisive[]={0,0,0,1};\r\nspecular[]={0.34,0.34,0.04,1};\r\nspecularPower=80;\r\nPixelShaderID=\"Super\";\r\nVertexShaderID=\"Super\";\r\nclass Stage1\r\n{\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[] = {1,0,0};\r\n\t\tup[] = {0,1,0};\r\n\t\tdir[] = {0,0,0};\r\n\t\tpos[] = {0,0,0};\r\n\t};\r\n};\r\nclass Stage2\r\n{\r\n\ttexture=\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[] = {1,0,0};\r\n\t\tup[] = {0,1,0};\r\n\t\tdir[] = {0,0,0};\r\n\t\tpos[] = {0,0,0};\r\n\t};\r\n};\r\nclass Stage3\r\n{\r\n\ttexture=\"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[] = {1,0,0};\r\n\t\tup[] = {0,1,0};\r\n\t\tdir[] = {0,0,0};\r\n\t\tpos[] = {0,0,0};\r\n\t};\r\n};\r\nclass Stage4\r\n{\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[] = {1,0,0};\r\n\t\tup[] = {0,1,0};\r\n\t\tdir[] = {0,0,0};\r\n\t\tpos[] = {0,0,0};\r\n\t};\r\n};\r\nclass Stage5\r\n{\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[] = {1,0,0};\r\n\t\tup[] = {0,1,0};\r\n\t\tdir[] = {0,0,0};\r\n\t\tpos[] = {0,0,0};\r\n\t};\r\n};\r\nclass Stage6\r\n{\r\n\ttexture=\"#(ai,64,64,1)fresnel(1,0.7)\";\r\n\tuvSource=\"none\";\r\n};\r\nclass Stage7\r\n{\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform\r\n\t{\r\n\t\taside[] = {1,0,0};\r\n\t\tup[] = {0,1,0};\r\n\t\tdir[] = {0,0,0};\r\n\t\tpos[] = {0,0,0};\r\n\t};\r\n};\r\n");
            return config;
        }

        //Getters
        public static string GetVersion()
        {
            return "0.1.6";
        }

        static RvmatConfig GetConfig()
        {
            return m_RvmatJson;
        }

        static RvmatCreatorSettings GetSettings()
        { return m_settings; }

        public static string GetDefultPath()
        {
            string path = "Path...";
            if(m_settings !=  null)
            {
                path = m_settings.m_DefultPath;
            };

            return path;
        }

        public static string GetDefultExampleRvmatPath()
        {
            string path = "Path...";
            if (m_settings != null)
            {
                path = m_settings.m_DefultPathExampleRVMAT;
            }
            return path;
        }

        public static string GetRVMAT(string type)
        {
            string RVMAT = String.Empty;
            if(m_RvmatJson != null && m_RvmatJson.m_RVMAT.ContainsKey(type))
            {
                RVMAT = m_RvmatJson.m_RVMAT[type];
            }
            if(RVMAT == null)
            {
                RVMAT = String.Empty;
            }
            return RVMAT;
         }

        public static bool IsCreateDamage()
        {
            return m_settings.m_CreateDamage;
        }

        public static bool IsOrganizeFolder()
        {
            return m_settings.m_OrganizeFolder;
        }

        public static List<string> GetRvmatTypes()
        {
            return new List<string>(m_RvmatJson.m_RVMAT.Keys);
        }

        public static List<FileStream> GetFiles(string path)
        {
            List<FileStream> files = new List<FileStream>();
            foreach (var file in Directory.GetFiles(path))
            {
                using (FileStream fs = File.Open(file, FileMode.Open))
                {
                    string[] split = file.Split(".");
                    if (split[split.Length - 1] == "paa")
                    {
                        files.Add(fs);
                    }
                }
            }
            return files;
        }

        public static void GetTexturePaths(string path, out string? _nohq, out string? _as, out string? _smdi)
        {
            List<FileStream> files = GetFiles(path);
            _nohq = string.Empty;
            _as = string.Empty;
            _smdi = string.Empty;  
            foreach (FileStream file in files)
            {
                string name = file.Name;
                string[] temp = name.Split(":\\");
                name = temp[1];
                string[] split = name.Split('_');
                foreach (string s in split)
                {
                    split = s.Split('.');
                    if (split[split.Length - 1] == "paa")
                    {
                        if (split[0] == "nohq")
                        {
                            _nohq = name;
                        }
                        else if (split[0] == "smdi")
                        {
                            _smdi = name;
                        }
                        else if (split[0] == "as")
                        {
                            _as = name;
                        }
                    }
                }
            }

            if (_nohq == string.Empty)
            {
                _nohq = m_DefultNohq;
            }
            if (_as == string.Empty)
            {
                _as = m_DefultAs;
            }
            if( _smdi == string.Empty)
            {
                _smdi = m_DefultSmdi;
            }
        }

         //Functions
         public static void CreateRvmatFile(string filename, string rvmat, List<string> textures, DamageType damageType = DamageType.None )
        {
            string? _nohq = textures[0];
            string? _as = textures[1];
            string? _smdi = textures[2];
            string[] ar = rvmat.Split("class Stage");
            int count = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                string s = ar[i];
                if (count != 0)
                {
                    s = s.Insert(0, "class Stage");
                }
                if (count == 1)
                {
                    s = s.Replace("%Path%", _nohq);
                }
                else if (count == 4)
                {
                    s = s.Replace("%Path%", _as);
                }
                else if (count == 5)
                {
                    s = s.Replace("%Path%", _smdi);
                }

                if (damageType == DamageType.Damage && count == 3)
                {
                    s = s.Replace("%Path%", m_DamageTexture);
                }
                else if(damageType == DamageType.Destruct && count == 3)
                {
                    s = s.Replace("%Path%", m_DestructTexture);
                }
                else if(count == 3)
                {
                    s = s.Replace("%Path%", m_DefultMc);
                }

                ar[i] = s;
                count++;
            }

            rvmat = string.Empty;

            foreach (string s in ar)
            {
                rvmat += s;
            }

            using (FileStream fstream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(rvmat);
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        public static void Message(string msg)
        {
            RvmatMessageBox msgbox;
            msgbox = new RvmatMessageBox(msg);
            msgbox.Show();
        }

         public static void AddRvmat(string type, string path)
        {
            string content;
            if (GetRVMAT(type) == String.Empty)
            { 
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] dataRead = new byte[fileStream.Length];
                    fileStream.Read(dataRead, 0, dataRead.Length);
                    content = System.Text.Encoding.UTF8.GetString(dataRead);
                }
                m_RvmatJson.m_RVMAT.Add(type, content);
                SaveRvmat();
            }
            else
            {
                MessageBox.Show("Rvmat by type: " + type + " already exist");
            }
        }

        public static void RemoveRvmat(string type)
        {
            m_RvmatJson.m_RVMAT.Remove(type);
            SaveRvmat() ;
        }

        public static void ChangeDefultPath(string path)
        {
            m_settings.m_DefultPath = path;
            SaveSettings();
        }

        public static void ChangeDefultExampleRvmatPath(string path)
        {
            m_settings.m_DefultPathExampleRVMAT = path;
            SaveSettings();
        }

        public static void SetCreateDamage(bool state)
        {
            m_settings.m_CreateDamage = state;
            SaveSettings();
        }

        public static void SetOrganizeFoldere(bool state)
        {
            m_settings.m_OrganizeFolder = state;
            SaveSettings();
        }

        public static void ResetSettings()
        {
            m_settings = new RvmatCreatorSettings();
            SaveSettings();
        }

        public static void ResetRvmats()
        {
            m_RvmatJson = GetDefultConfig();
            SaveRvmat();
        }

         public static void SaveSettings()
         {
            string jsonPath = m_JsonPath + m_JsonSettings;
            if (m_settings != null)
            {
                string json = JsonConvert.SerializeObject(m_settings, Formatting.Indented);

                System.IO.File.WriteAllText(jsonPath, json);
            }
          }

        public static void SaveRvmat()
        {
            string jsonPath = m_JsonPath + m_JsonFileName;
            if (m_RvmatJson != null)
            {
                string json = JsonConvert.SerializeObject(m_RvmatJson, Formatting.Indented);

                System.IO.File.WriteAllText(jsonPath, json);
            }
         }
    }

    public class RvmatConfig
    {
        public Dictionary<string, string> m_RVMAT { get; set; } = new Dictionary<string, string>();
        public RvmatConfig()
        {
        }
    }

    public class RVMAT
    {
        public string m_type { get; set; }
        public string m_rvmat { get; set; }

        public RVMAT()
        {
            m_type = "";
            m_rvmat = "";
        }
    }

    public class RvmatCreatorSettings
    {
        public string m_DefultPath {  get; set; }
        public string m_DefultPathExampleRVMAT { get; set; }
        public bool m_CreateDamage { get; set; }
        public bool m_OrganizeFolder { get; set; }
        public RvmatCreatorSettings()
        {
            m_DefultPath = "Path";
            m_DefultPathExampleRVMAT = "Path";
            m_OrganizeFolder = false;
            m_CreateDamage = false;
        }
    }
}