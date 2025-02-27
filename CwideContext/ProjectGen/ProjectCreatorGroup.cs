﻿using ProjectManager.Projects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CwideContext
{
    class ProjectCreatorGroup : FileUtils
    {

       // private  string sTab = "";
       // StreamWriter writer;
        Project oProject;

        public ProjectCreatorGroup(Project _oProject ,string _sGroupList, string _sProjectName,  string _sOutputDir, string _sOutBranch, List<string> _aFileList, List<string> _aIncludeDir, string _sPlatform, string _sOpLibList)
        {
			oProject = _oProject;
			
			
            
            string _sPrjFile = _sOutputDir + _sOutBranch + "Prj_"+ _sProjectName + "Group.cbp";
            //CompileCpp.fCreateDirectoryRecursively(Path.GetDirectoryName(_sPrjFile));

			fIniFile(_sPrjFile);


            //this code segment write data to file.
           // FileStream fs1 = new FileStream(_sPrjFile, FileMode.OpenOrCreate, FileAccess.Write);
           // writer = new StreamWriter(fs1);


            fAdd("<?xml version='1.0' encoding='UTF-8' standalone='yes' ?>");
            fAdd("<CodeBlocks_project_file>");
            fAddTab();

            fAdd("<FileVersion major='1' minor='6' />");
            fAdd("<Project>");
                fAddTab();

                fAdd("<Option title='" + _sProjectName + "' />");
                fAdd("<Option pch_mode='2' />");
                fAdd("<Option compiler='gcc' />");
         

                fAdd("<Build>");
                fAddTab();

                    fAdd("<Target title='default'>");
                      fAddTab();
                         fAdd("<Option output='bin/" + _sProjectName  + "' prefix_auto='1' extension_auto='1' />");
						fAdd("<Option working_dir='bin' />");
                         fAdd("<Option type = '1' />");
                        fAdd("<Option compiler='gcc' />");
                        fAdd("<Option use_console_runner='0' />");

                        fSubTab();
                    fAdd("</Target>");

               fSubTab();
                fAdd("</Build>");


                fAdd("<Compiler>");
                    fAddTab();
/*
					string[] _aCompilerArg = CompileCpp.sCompilerFlag.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries);
					foreach(string _sArg in _aCompilerArg) {	
						  fAdd("<Add option = '-" + _sArg + "' />");
					}
*/
/*
                    fAdd("<Add option = '-march=pentium4' />");
                    fAdd("<Add option = '-std=c++11' />");
					fAdd("<Add option = '-g' />");
					fAdd("<Add option = '-x c++' />");
                    fAdd("<Add option = '-Wreturn-type' />");
					fAdd("<Add option = '-fno-exceptions' />");
                    fAdd("<Add option = '-DGZ_tNo_FreeType' />");
                    fAdd("<Add option = '-DGZ_t" + _sPlatform + "' />");
                    fAdd("<Add option = '-DGZ_tOverplace=\\\"[" + _sOpLibList + "]\\\"' />");
                    fAdd("<Add option = '-DGZ_tTakeEmbedRcOnDrive' />");
                    fAdd("<Add option = '-DGZ_tMonothread' />");
                    fAdd("<Add option = '-DGZ_tDebug' />");
				//	fAdd("<Add option = '-DSTBI_NO_STDIO' />");
*/
           


            //  _sSend += "-std=c++11 -" + sBitType + " -g -Wreturn-type -fno-exceptions ";
            //  _sSend += "-DGZ_t" + sPlatform + " ";
            //   _sSend += "-DGZ_tNo_FreeType -DGZ_tTakeEmbedRcOnDrive -DGZ_tMonothread -DGZ_tOverplace=\\\"[" + sOpLibList + "]\\\" ";

            fAdd("<Add directory = '../ExportCpp/' />");
            foreach (string _sDir in _aIncludeDir)
                    {
                        fAdd("<Add directory = '" + _sDir + "' />");
                    }

                    /*
                    fAdd("<Add directory = '../../../_Lib/Lib_GZE' />");
                    fAdd("< Add directory = '../../../_Lib/Lib_GZE/System/Windows' />");
                    fAdd("< Add directory = '../../../_Lib/Lib_GZE/System/OpenGL' />");
                    fAdd("< Add directory = '../../_Src' />");*/

                    fSubTab();
                fAdd("</Compiler>");

				fAdd("<Linker>");
				fAddTab();
/*
					string[] _aLinkerArg = CompileCpp.sLinkerFlag.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries);
					foreach(string _sArg in _aLinkerArg) {
						  fAdd("<Add option = '-" + _sArg + "' />");
					}
*/
				fSubTab();
				fAdd("</Linker>");



				string[] _aGroupList = _sGroupList.Split('?');
				foreach (string _sCompileGroup in _aGroupList)  {
					if (_sCompileGroup != "") {
					   fAdd("<Unit filename='" + _sCompileGroup + "' >");
						fAddTab();
							 fAdd("<Option compile='1' /> ");
							 fAdd("<Option link='1' /> ");
						fSubTab();
					  fAdd("</Unit>");
					}
				}
				
				
				

			/*
				foreach(Nx2LibGroup _oGroup in oProject.aLib) {
					foreach(Nx2Lib _oLib in _oGroup.aLib) {
						if(!_oLib.bReadOnly) {
						  fAdd("<Unit filename='" + _oLib.sFullWritePath + "_CwCompileList.cpp' />");
						}
//fAdd(_oGroup.sName);
//fAdd(_oGroup.sWritePath);
					}
				}*/



/*
                foreach (string _sFile in _aFileList)
                {
                    fAdd("<Unit filename='" + _sFile + ".cpp' />");
                    fAdd("<Unit filename='" + _sFile + ".h' />");
                }
*/

			

            fAdd("</Project>");
            fSubTab();
            fAdd("</CodeBlocks_project_file>");
           // writer.Close();
			fClose();
        }

/*
        public void fSubTab() {
            sTab = sTab.Substring(0, sTab.Length - 1);
        }
        public void fAddTab()  {
            sTab += '\t';
        }

        public void fAdd(string _sLine){
            writer.WriteLine(sTab + _sLine );
        } */

    }
}
