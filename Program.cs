
using Newtonsoft.Json;
using System.Diagnostics;

namespace MF_RvmatCreator
{
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
        public static string m_JsonPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\MF_RvmatCreateor";
        public static string m_JsonFileName = "\\Rvmats.json";
        public static string m_JsonSettings = "\\Setings.json";

        public static string m_DamagePath = "dz\\characters\\data\\generic_damage_mc.paa";
        public static string m_DestructPath = "dz\\characters\\data\\generic_destruct_mc.paa";


        public static RvmatConfig m_RvmatJson = new RvmatConfig();
        public static RvmatCreatorSettings m_settings = new RvmatCreatorSettings();

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
            RvmatConfig config = new RvmatConfig();
            config.m_RVMAT.Add("Iron", "ambient[] = { 1, 1, 1, 1 };\r\ndiffuse[] = { 1, 1, 1, 1 };\r\nforcedDiffuse[] = { 0, 0, 0, 1 };\r\nemmisive[] = { 0, 0, 0, 1 };\r\nspecular[] = { 0.4, 0.38, 0.36, 1 };\r\nspecularPower = 32;\r\nPixelShaderID = \"Super\";\r\nVertexShaderID = \"Super\";\r\nclass Stage1 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage2 {\r\n\ttexture = \"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 1, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage3 {\r\n\ttexture = \"#(argb,8,8,3)color(0,0,0,0,MC)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage4 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 1 };\r\n\t};\r\n};\r\nclass Stage5 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage6 {\r\n\ttexture = \"#(ai,64,64,1)fresnel(3.12,3.87)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage7 {\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuseWorldEnvMap = \"true\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\n");
            config.m_RVMAT.Add("Wood", "ambient[] = { 1, 1, 1, 1 };\r\ndiffuse[] = { 1, 1, 1, 1 };\r\nforcedDiffuse[] = { 0, 0, 0, 1 };\r\nemmisive[] = { 0, 0, 0, 1 };\r\nspecular[] = { 0.16, 0.16, 0.16, 1 };\r\nspecularPower = 45;\r\nPixelShaderID = \"Super\";\r\nVertexShaderID = \"Super\";\r\nclass Stage1 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage2 {\r\n\ttexture = \"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 1, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage3 {\r\n\ttexture = \"#(argb,8,8,3)color(0,0,0,0,MC)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage4 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 1 };\r\n\t};\r\n};\r\nclass Stage5 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage6 {\r\n\ttexture = \"#(ai,64,64,1)fresnel(1.5,0.45)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage7 {\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuseWorldEnvMap = \"true\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\n");
            return config;
        }
    
        //Getters

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
            if(m_RvmatJson != null)
            {
                RVMAT = m_RvmatJson.m_RVMAT[type];
            }
            if(RVMAT == null)
            {
                RVMAT = String.Empty;
            }
            return RVMAT;
         }

        public static List<string> GetRvmatTypes()
        {
            return new List<string>(m_RvmatJson.m_RVMAT.Keys);
        }

         //Functions

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
        public RvmatCreatorSettings()
        {
            m_DefultPath = "Path";
            m_DefultPathExampleRVMAT = "Path";
        }
    }
}