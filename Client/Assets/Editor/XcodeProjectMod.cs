using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode; //XcodeAPI
using System.Collections;
using System.IO;
using System;

public class XcodeProjectMod : MonoBehaviour
{

	//
	internal static bool DeleteDir(string strPath)
	{
		try
		{
			strPath = @strPath.Trim().ToString();// 清除空格
			if (System.IO.Directory.Exists(strPath))// 判断文件夹是否存在
			{
				string[] strDirs = System.IO.Directory.GetDirectories(strPath);// 获得文件夹数组
				string[] strFiles = System.IO.Directory.GetFiles(strPath);// 获得文件数组
				foreach (string strFile in strFiles)// 遍历所有子文件夹
				{
					System.IO.File.Delete(strFile);// 删除文件夹
				}
				foreach (string strdir in strDirs)// 遍历所有文件
				{
					System.IO.Directory.Delete(strdir, true);// 删除文件
				}
			}
			return true;// 成功
		}
		catch (Exception Exp) // 异常处理
		{
			System.Diagnostics.Debug.Write(Exp.Message.ToString());// 异常信息
			return false;// 失败
		}
	}

	//文件夹替换
	internal static void CopyAndReplaceDirectory(string srcPath, string dstPath)
	{
		if (Directory.Exists(dstPath))
			Directory.Delete(dstPath);
		if (File.Exists(dstPath))
			File.Delete(dstPath);

		Directory.CreateDirectory(dstPath);

		foreach (var file in Directory.GetFiles(srcPath))
			File.Copy(file, Path.Combine(dstPath, Path.GetFileName(file)));

		foreach (var dir in Directory.GetDirectories(srcPath))
			CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
	}


	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
	{
		
		if (buildTarget == BuildTarget.iOS) {
			string pbxPath = PBXProject.GetPBXProjectPath (path);
		
			PBXProject pbxProj = new PBXProject ();
			pbxProj.ReadFromString (File.ReadAllText (pbxPath));
			string targetName = PBXProject.GetUnityTargetName ();
			string targetGuid = pbxProj.TargetGuidByName (targetName);

			//required framworks
			string[] frameworksRequired = {
				"SystemConfiguration.framework", //bugly
				"Security.framework", //bugly
				"libz.tbd", //bugly
				"libc++.tbd", //bugly
			};
			foreach (string framwork in frameworksRequired) {
				pbxProj.AddFrameworkToProject (targetGuid, framwork, false);
			}

			//optional frameworks
			string[] frameworksOptional = {
				"JavaScriptCore.framework", //bugly
			};
			foreach (string framework in frameworksOptional) {
				pbxProj.AddFrameworkToProject (targetGuid, framework, true);
			}

			//3rd frameworks
			string[] frameworks3rdParty = {
				"Bugly.framework",
				"UMAnalytics.framework",
			};

			string rootDir = "Frameworks";
			string destDir;
			DeleteDir (Path.Combine (path, rootDir));
			foreach (string framework in frameworks3rdParty) {
				CopyAndReplaceDirectory ("/Users/5th/Documents/Frameworks", path + "/" + rootDir + "/" + framework);
				pbxProj.AddFileToBuild (targetGuid, pbxProj.AddFile (rootDir + "/" + framework, "Frameworks/" + framework, PBXSourceTree.Source));
			}

			pbxProj.SetBuildProperty (targetGuid, "ENABLE_BITCODE", "NO");
			/*
			pbxProj.SetBuildProperty(targetGuid, "FRAMEWORK_SEARCH_PATHS", "$(inherited)");
			pbxProj.AddBuildProperty(targetGuid, "FRAMEWORK_SEARCH_PATHS", "$(pbxProjECT_DIR)/Frameworks");
			*/
			//保存所做的修改
			File.WriteAllText (pbxPath, pbxProj.WriteToString ());

			//修改plist
			string plistPath = Path.Combine (path, "Info.plist");
			string plistText = File.ReadAllText (plistPath);
			PlistDocument plistDoc = new PlistDocument ();
			plistDoc.ReadFromString (plistText);
			PlistElementDict plistDict = plistDoc.root;


			//plistDict.SetString("CFBundleDevelopmentRegion", "zh_CN");
			//plistDict.SetString("CFBundleDevelopmentRegion", "en");
			// 一些权限声明
			//plistDict.SetString("NSContactsUsageDescription", "是否允许此游戏使用联系人？");
			//plistDict.SetString("NSCameraUsageDescription", "我们需要使用摄像头权限");
			//plistDict.SetString("NSLocationWhenInUseUsageDescription", "我们需要使用定位权限");
			plistDict.SetString ("NSMicrophoneUsageDescription", "语音聊天时需要使用麦克风权限");
			//plistDict.SetString ("NSPhotoLibraryUsageDescription", "我们需要使用相册权限");

			// add url scheme
			//PlistElementArray urlTypes = rootDict.CreateArray("CFBundleURLTypes");
			//PlistElementArray wxUrlScheme = wxUrl.CreateArray("CFBundleURLSchemes");

			File.WriteAllText (plistPath, plistDoc.WriteToString ());
		}
	}
}