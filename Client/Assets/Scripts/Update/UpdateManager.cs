using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
//using System.Text;
using UnityEngine;
using System.Runtime.InteropServices;


public struct VersionProgram
{
    public readonly Int32 version;
    public readonly String descriptionName;
    public readonly String descriptionContent;

    public VersionProgram(Int32 version, String desc, String showContent)
    {
        this.version = version;
        this.descriptionName = desc;
        this.descriptionContent = showContent;
    }
}

public struct VersionCompatible
{
    public readonly Int32 newProgVersion;
    public readonly Int32 minProgVersion;
    public readonly String newProgDescribe;
    public readonly String minResVersion;
    public readonly String updateMethod;
    public readonly String updateUrl;

    public VersionCompatible(Int32 newProgVersion, String newProgDescribe,Int32 minProgVersion,String minResVersion, String updateMethod, String updateUrl)
    {
        this.newProgVersion = newProgVersion;
        this.newProgDescribe = newProgDescribe;
        this.minProgVersion = minProgVersion;
        this.minResVersion = minResVersion;
        this.updateMethod = updateMethod;
        this.updateUrl = updateUrl;
    }
}


public class UpdateManager : NormSingleton<UpdateManager>{
#if UNITY_IPHONE || UNITY_XBOX360
	private const string IMPORT_NAME = "__Internal";
#else
    private const string IMPORT_NAME = "AngelicaMobile";
#endif

    private UpdateManager()
    {
        
    }

    private Dictionary<String, String> _stringMap;
    private bool ReadStringTable()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("launcher/stringtable", typeof(TextAsset));
        if (textAsset != null)
        {
            _stringMap = new Dictionary<string, string>();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(textAsset.text);
                XmlNode focusNode = xmlDoc["stringtable"];
                if (focusNode == null) return false;

                foreach (XmlNode node in focusNode)
                {
                    var brief = node.Attributes["origin"];
                    var detail = node.Attributes["translation"];
                    if (brief != null && detail != null)
                        _stringMap[brief.Value] = detail.Value;
                }
            }
            catch (XmlException)
            {
                return false;
            }
        }

        return true;
    }

    public String GetString(string origin)
    {
        String result;
        if (_stringMap != null && _stringMap.TryGetValue(origin, out result))
            return result;
        return origin;
    }

    private Patcher.SVersionInfo m_minimumResourceVersion = Patcher.SVersionInfo.MakeInvalid();
    public Patcher.SVersionInfo MinimumResourceVersion
    { get { return m_minimumResourceVersion; } set { m_minimumResourceVersion = value; } }


    /*[DllImport(IMPORT_NAME)] //是否把内部资源拷贝到外部
    private extern static void exp_af_SetCopyBackupFilePackage(bool bCopy);*/


    public void Init()
    {
        ReadStringTable();
    }

    public IEnumerable UpdateCoroutine()
    {
        //exp_af_SetCopyBackupFilePackage(false);
        if(!Settings.skipProgramUpdate)
        {

        }

        Patcher.SPatcherConfig config;
        config.MinVersion = MinimumResourceVersion;
        config.ResourcePath = Settings.externalPath;

        TextAsset stringtableAsset = Resources.Load("patcher/stringtable", typeof(TextAsset)) as TextAsset;
        String stringTableContent = stringtableAsset ? stringtableAsset.text : "";
        if (stringTableContent.Length == 0 || stringTableContent[0] != 0xfeff)	//add bom utf-8 unnecessary 
            stringTableContent = '\xfeff' + stringTableContent;

        UIPanelUpdate updatePanel = UpdateUIManager.Instance.CreatePanel<UIPanelUpdate>("Panel_Update");

        ExpansionPackManager.Instance.Prepare(); // 保证在主线程中初始化


        yield return 1;
    }
}
