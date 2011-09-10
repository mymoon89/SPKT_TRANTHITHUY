echo OFF
echo This batch file will fix the problem with TBROWSER.DLL
echo You must be on the directory where TBROWSER.DLL resides in order to
echo run this batch file successfully.  The PATCH.COM file provided with
echo this patch package should also reside on this directory.
pause

if not exist patch.com goto HELP0
:dllstart
if not exist TBROWSER.DLL goto HELP1
patch -u bc31p3.pch tbrowser.dll > nul
if ERRORLEVEL 1 goto dllerror
echo Patch successfully installed.
goto DONE:
:dllerror
echo TBROWSER.DLL is incorrect version or is already patched
goto DONE:


:HELP0
echo  
echo ERROR:  unable to find PATCH.COM.  Aborting batch file!
echo
goto DONE:

:HELP1
echo
echo WARNING:  unable to find TBROWSER.DLL
echo
goto DONE:


:DONE
