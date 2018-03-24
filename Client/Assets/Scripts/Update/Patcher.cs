using System.Runtime.InteropServices;

public class Patcher{

#if UNITY_IPHONE || UNITY_XBOX360
    const string IMPORT_NAME = "__Internal";
#else
    const string IMPORT_NAME = "AngelicaMobile";
#endif


    [DllImport(IMPORT_NAME, CallingConvention = CallingConvention.Winapi)]
    static extern void Patcher_init(SPatcherConfig config);

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SVersionInfo
    {
        public readonly int Ver0; //负值表示无效
        public readonly int Ver1;
        public readonly int Ver2;

        public SVersionInfo(int iVer0, int iVer1, int iVer2)
        {
            Ver0 = iVer0;
            Ver1 = iVer1;
            Ver2 = iVer2;
        }

        /// <summary>
        /// 创建一个无效的 SVersionInfo
        /// </summary>
        public static SVersionInfo MakeInvalid()
        {
            return new SVersionInfo(-1, 0, 0);
        }

        public static bool operator <(SVersionInfo left, SVersionInfo right)
        {
            return left.Ver0 < right.Ver0 || left.Ver0 == right.Ver0 && (left.Ver1 < right.Ver1 || left.Ver1 == right.Ver1 && left.Ver2 < right.Ver2);
        }

        public bool IsValid()
        {
            return Ver0 >= 0 && Ver1 >= 0 && Ver2 >= 0;
        }

        public static bool operator >(SVersionInfo left, SVersionInfo right)
        {
            return left.Ver0 > right.Ver0 || left.Ver0 == right.Ver0 && (left.Ver1 > right.Ver1 || left.Ver1 == right.Ver1 && left.Ver2 > right.Ver2);
        }

        public override string ToString()
        {
            return IsValid() ? string.Format("{0}.{1}.{2}", Ver0, Ver1, Ver2) : "--";
        }

        public static SVersionInfo FromString(string strVerString)
        {
            var aToks = strVerString.Split('.');
            int ver0, ver1, ver2;
            return (aToks.Length == 3 && int.TryParse(aToks[0], out ver0) && int.TryParse(aToks[1], out ver1) && int.TryParse(aToks[2], out ver2)) ? new SVersionInfo(ver0, ver1, ver2) : MakeInvalid();
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SPatcherConfig
    {
        public SVersionInfo MinVersion;         //可进入游戏的最低版本号
        public SVersionInfo ResBaseVer;         //安装程序附带的初始资源版本
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ResBasePath;              //初始资源目录
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ResourcePath;             //末尾不含分隔符
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string StrTabContent;	        //content of stringTablePath
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string PackExt;	                //patcher.cfg, PackFile.ext
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Project;	                //patcher.cfg, Game.project
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Addr;	                    //serverlist.cfg, address
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ImportantList;	        //serverlist.cfg, importantlist
        
        [MarshalAs(UnmanagedType.LPWStr)]
        public string PackDownloadUrl;	        //serverlist.cfg, packdownloadurl
    }


    private Patcher()
    {

    }

    private static Patcher _instance;
    public static Patcher Instance
    {
        get{
            if (_instance == null)
                _instance = new Patcher();
            return _instance;
        }
    }


}
