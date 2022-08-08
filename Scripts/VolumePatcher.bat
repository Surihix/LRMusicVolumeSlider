@echo off

cd /d "%~dp0..\UserSettings\"

if not exist mode.txt goto NOMODE

set /p gamemode=<mode.txt

if %gamemode%==Packed goto PACKEDPATCH
if %gamemode%==Nova goto NOVAPATCH


:PACKEDPATCH
if not exist language.txt goto NOLANG

set /p lrpath=<LRPath.txt

cd /d "%lrpath%\"
if not exist LRFF13.exe goto INVALIDPATH

cd /d "%~dp0..\UserSettings\"

set /p lang=<language.txt

if %lang%==English goto ENVO
if %lang%==Japanese goto JPVO


:ENVO
echo.
echo English VO is set. Proceeding....
echo.

cd /d "%~dp0\"
call PackedENVolume.bat
goto END


:JPVO
echo.
echo Japanese VO is set. Proceeding....
echo.

cd /d "%~dp0\"
call PackedJPVolume.bat
goto END


:NOVAPATCH
cd /d "%~dp0..\UserSettings\"
set /p lrpath=<LRPath.txt

cd /d "%lrpath%weiss_data\"
if not exist db\resident\wdbpack.bin goto NOTUNPACKED

cd /d "%~dp0\"
call NovaVolume.bat
goto END


:NOMODE
cls
cd /d "%~dp0..\Scripts\"
echo.
echo FileSystem settings not set....
echo MSGBOX "The FileSystem settings is not specified." ^& vbCrLf ^& "Please set the correct FileSystem setting in the app and then try setting the volume.", 16, "Error" > msgbox.vbs
call msgbox.vbs
goto END


:NOLANG
cls
cd /d "%~dp0..\Scripts\"
echo.
echo Voice Over settings not set....
echo MSGBOX "The Voice Over language is not sepecified." ^& vbCrLf ^& "Please set the Voice Over language in the app and then set the volume.", 16, "Error" > msgbox.vbs
call msgbox.vbs
goto END


:NOTUNPACKED
echo.
echo Game data not unpacked....
cd /d "%~dp0..\Scripts\"  
echo MSGBOX "Game data is not unpacked for Nova FileSystem setting." ^& vbCrLf ^& "Please unpack the game data with Nova Chrysalia mod manager and then set the volume.", 16, "Error" > msgbox.vbs
call msgbox.vbs
goto END


:INVALIDPATH
cd /d "%~dp0..\Scripts\"
echo.
echo Unable to find the executable file....
echo MSGBOX "Unable to find the executable file." ^& vbCrLf ^& "Please set the correct location of the LRFF13.exe file and then try setting the volume.", 16, "Error" > msgbox.vbs
call msgbox.vbs


:END
cd /d "%~dp0..\Scripts\"
if exist msgbox.vbs del msgbox.vbs