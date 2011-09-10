echo off

if not exist cs.lib goto NOSMALLLIB
echo Patching small library...
tlib cs.lib -vnewf.obj -vnewvf.obj
ren vnewf.obs vnewf.obj
ren vnewvf.obs vnewvf.obj
tlib cs.lib +vnewf.obj +vnewvf.obj
del vnewf.obj
del vnewvf.obj
cls
if errorlevel 1 goto ERROR_NOTLIB
goto MEDIUM
:NOSMALLLIB
echo Cannot find CS.LIB to patch small library.

:MEDIUM
if not exist %1cm.lib goto NOMEDLIB
echo Patching medium library...
tlib cm.lib -vnewf.obj -vnewvf.obj
ren vnewf.obm vnewf.obj
ren vnewvf.obm vnewvf.obj
tlib cm.lib +vnewf.obj +vnewvf.obj
del vnewf.obj
del vnewvf.obj
cls
goto COMPACT
:NOMEDLIB
echo Cannot find CM.LIB to patch medium library.

:COMPACT
if not exist %1cc.lib goto NOCOMPACTLIB
echo Patching compact library...
tlib cc.lib -vnewf.obj -vnewvf.obj
ren vnewf.obc vnewf.obj
ren vnewvf.obc vnewvf.obj
tlib cc.lib +vnewf.obj +vnewvf.obj
del vnewf.obj
del vnewvf.obj
cls
goto LARGE
:NOCOMPACTLIB
echo Cannot find CC.LIB to patch compact library.

:LARGE
if not exist %1cl.lib goto NOLARGELIB
echo Patching large library...
tlib cl.lib -vnewf.obj -vnewvf.obj
ren vnewf.obl vnewf.obj
ren vnewvf.obl vnewvf.obj
tlib cl.lib +vnewf.obj +vnewvf.obj
del vnewf.obj
del vnewvf.obj
cls
goto HUGE
:NOLARGELIB
echo Cannot find CL.LIB to patch large library.

:HUGE
if not exist %1ch.lib goto NOHUGELIB
echo Patching huge library...
tlib ch.lib -vnewf.obj -vnewvf.obj
ren vnewf.obh vnewf.obj
ren vnewvf.obh vnewvf.obj
tlib ch.lib +vnewf.obj +vnewvf.obj
del vnewf.obj
del vnewvf.obj
cls
goto DONE
:NOHUGELIB
echo Cannot find CH.LIB to patch huge library.
goto DONE

:ERROR_NOOBJ
echo An patch object module is not in the current directory.  Please use
echo unzip on bc31p1.zip and try to patch again.
goto DONE

:ERROR_NOTLIB
echo A problem was encountered executing TLIB.  Either the Turbo Librarian
echo cannot be located along your DOS path, or an error occurred.  Consult
echo your Borland C++ Users Guide for more information on why TLIB might
not echo be operating correctly.

:DONE
cls
echo Done.
echo Two object modules named VNEWF.OBJ, VNEWVF.OBJ, have been removed for
echo each of the libraries for each of the five memory models small, medium,
echo compact, large, and huge.  These modules have been replaced by the
echo updated version of NEW in their respective libraries.

