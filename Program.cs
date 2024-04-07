using System.Diagnostics;
using System.Text.Json;

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Text.RegularExpressions;
using System.Text;

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
            RvmatCreator m_RvmatCreator = new RvmatCreator();
            RvmatManager manager = new RvmatManager();
            manager.Init();
            Application.Run(m_RvmatCreator);
            
        }

       
    }

    public class RvmatManager()
    {
        public string m_JsonPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\MF_RvmatCreateor";
        public string m_JsonFileName = "\\Rvmats.json";

        public string m_DamagePath = "dz\\characters\\data\\generic_damage_mc.paa";
        public string m_DestructPath = "dz\\characters\\data\\generic_destruct_mc.paa";

        public RvmatConfig m_RvmatJson = new RvmatConfig();

        public Dictionary<string, string> m_RegisteredRMAT = new Dictionary<string, string>();
        public void Init()
        {
            ReadJsonFile();
        }

        public void ReadJsonFile()
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

        public RvmatConfig GetDefultConfig()
        {
            RvmatConfig config = new RvmatConfig();
            //RVMAT rvmat;
            //rvmat = new RVMAT();
            config.m_RVMAT.Add("Iron", "ambient[] = { 1, 1, 1, 1 };\r\ndiffuse[] = { 1, 1, 1, 1 };\r\nforcedDiffuse[] = { 0, 0, 0, 1 };\r\nemmisive[] = { 0, 0, 0, 1 };\r\nspecular[] = { 0.4, 0.38, 0.36, 1 };\r\nspecularPower = 32;\r\nPixelShaderID = \"Super\";\r\nVertexShaderID = \"Super\";\r\nclass Stage1 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage2 {\r\n\ttexture = \"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 1, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage3 {\r\n\ttexture = \"#(argb,8,8,3)color(0,0,0,0,MC)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage4 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 1 };\r\n\t};\r\n};\r\nclass Stage5 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage6 {\r\n\ttexture = \"#(ai,64,64,1)fresnel(3.12,3.87)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage7 {\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuseWorldEnvMap = \"true\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\n");
            //rvmat = new RVMAT();
            config.m_RVMAT.Add("Wood", "ambient[] = { 1, 1, 1, 1 };\r\ndiffuse[] = { 1, 1, 1, 1 };\r\nforcedDiffuse[] = { 0, 0, 0, 1 };\r\nemmisive[] = { 0, 0, 0, 1 };\r\nspecular[] = { 0.16, 0.16, 0.16, 1 };\r\nspecularPower = 45;\r\nPixelShaderID = \"Super\";\r\nVertexShaderID = \"Super\";\r\nclass Stage1 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage2 {\r\n\ttexture = \"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 1, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage3 {\r\n\ttexture = \"#(argb,8,8,3)color(0,0,0,0,MC)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage4 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 1 };\r\n\t};\r\n};\r\nclass Stage5 {\r\n\ttexture = \"%Path%\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 0 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage6 {\r\n\ttexture = \"#(ai,64,64,1)fresnel(1.5,0.45)\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\nclass Stage7 {\r\n\ttexture = \"dz\\data\\data\\env_land_co.paa\";\r\n\tuseWorldEnvMap = \"true\";\r\n\tuvSource = \"tex\";\r\n\tclass uvTransform {\r\n\t\taside[] = { 1, 0, 0 };\r\n\t\tup[] = { 0, 1, 0 };\r\n\t\tdir[] = { 0, 0, 1 };\r\n\t\tpos[] = { 0, 0, 0 };\r\n\t};\r\n};\r\n");
            return config;
        }
    }

    public class RvmatConfig
    {
        public Dictionary<string, string> m_RVMAT { get; set; } = new Dictionary<string, string>();
        //public List<RVMAT> RVMATs { get; set; }
      //  public string m_type { get; set; }
    //    public string m_rvmat {  get; set; }
        public RvmatConfig()
        {
       //     m_type = "Iron";
    //        m_rvmat = "\"Iron\", \"ambient[] = { 1, 1, 1, 1 };\\r\\ndiffuse[] = { 1, 1, 1, 1 };\\r\\nforcedDiffuse[] = { 0, 0, 0, 1 };\\r\\nemmisive[] = { 0, 0, 0, 1 };\\r\\nspecular[] = { 0.4, 0.38, 0.36, 1 };\\r\\nspecularPower = 32;\\r\\nPixelShaderID = \\\"Super\\\";\\r\\nVertexShaderID = \\\"Super\\\";\\r\\nclass Stage1 {\\r\\n\\ttexture = \\\"%Path%\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 0, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 0 };\\r\\n\\t\\tpos[] = { 0, 0, 0 };\\r\\n\\t};\\r\\n};\\r\\nclass Stage2 {\\r\\n\\ttexture = \\\"#(argb,8,8,3)color(0.5,0.5,0.5,1,DT)\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 1, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 0 };\\r\\n\\t\\tpos[] = { 0, 0, 0 };\\r\\n\\t};\\r\\n};\\r\\nclass Stage3 {\\r\\n\\ttexture = \\\"#(argb,8,8,3)color(0,0,0,0,MC)\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 0, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 0 };\\r\\n\\t\\tpos[] = { 0, 0, 0 };\\r\\n\\t};\\r\\n};\\r\\nclass Stage4 {\\r\\n\\ttexture = \\\"%Path%\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 0, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 1 };\\r\\n\\t\\tpos[] = { 0, 0, 1 };\\r\\n\\t};\\r\\n};\\r\\nclass Stage5 {\\r\\n\\ttexture = \\\"%Path%\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 0, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 0 };\\r\\n\\t\\tpos[] = { 0, 0, 0 };\\r\\n\\t};\\r\\n};\\r\\nclass Stage6 {\\r\\n\\ttexture = \\\"#(ai,64,64,1)fresnel(3.12,3.87)\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 0, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 1 };\\r\\n\\t\\tpos[] = { 0, 0, 0 };\\r\\n\\t};\\r\\n};\\r\\nclass Stage7 {\\r\\n\\ttexture = \\\"dz\\\\data\\\\data\\\\env_land_co.paa\\\";\\r\\n\\tuseWorldEnvMap = \\\"true\\\";\\r\\n\\tuvSource = \\\"tex\\\";\\r\\n\\tclass uvTransform {\\r\\n\\t\\taside[] = { 1, 0, 0 };\\r\\n\\t\\tup[] = { 0, 1, 0 };\\r\\n\\t\\tdir[] = { 0, 0, 1 };\\r\\n\\t\\tpos[] = { 0, 0, 0 };\\r\\n\\t};\\r\\n};\\r\\n\"";
        }
       
    }

    public class RVMAT
    {
        public string m_type { get; set; }
        public string m_rvmat { get; set; }

        public RVMAT()
        { }
        public RVMAT(string type, string rvmat)
        {
            m_type = type;
            m_rvmat = rvmat;
        }
    }
}