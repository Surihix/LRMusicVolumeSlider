@echo off

cd /d "%~dp0..\UserSettings\"

set /p sliderVal=<SliderValue.txt

echo.
echo Setting Volume....
echo.

if %sliderVal%==0 goto SLIDE0
if %sliderVal%==1 goto SLIDE1
if %sliderVal%==2 goto SLIDE2
if %sliderVal%==3 goto SLIDE3
if %sliderVal%==4 goto SLIDE4
if %sliderVal%==5 goto SLIDE5


:SLIDE0
echo.
echo Muting music volume....
echo.
cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 000 000 000 000

del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

echo Patched wdbpack file

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\sound\pack\8000\*.* > nul

cd /d "%lrpath%weiss_data\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 000 000 000 000

del LRVolumePatchTool.exe > nul

echo.
echo Patched music file

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music has been Muted", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE1
echo.
echo Setting music volume to level 1....
echo.
cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 015 092 041

del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

echo Patched wdbpack file

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\sound\pack\8000\*.* > nul

cd /d "%lrpath%weiss_data\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 041 092 015 063

del LRVolumePatchTool.exe > nul

echo.
echo Patched music file

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 1", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE2
echo.
echo Setting music volume to level 2....
echo.
cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 040 245 195

del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

echo Patched wdbpack file

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\sound\pack\8000\*.* > nul

cd /d "%lrpath%weiss_data\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 195 245 040 063

del LRVolumePatchTool.exe > nul

echo.
echo Patched music file

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 2", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE3
echo.
echo Setting music volume to level 3....
echo.
cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 066 143 092

del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

echo Patched wdbpack file

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\sound\pack\8000\*.* > nul

cd /d "%lrpath%weiss_data\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 092 143 066 063

del LRVolumePatchTool.exe > nul

echo.
echo Patched music file

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 3", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE4
echo.
echo Setting music volume to level 4....
echo.
cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 092 040 246

del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

echo Patched wdbpack file

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\sound\pack\8000\*.* > nul

cd /d "%lrpath%weiss_data\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 205 204 076 063

del LRVolumePatchTool.exe > nul

echo.
echo Patched music file

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 4", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE5
echo.
echo Setting music volume to level 5....
echo.
cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 128 000 000

del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\db\resident\"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

echo Patched wdbpack file

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\sound\pack\8000\*.* > nul

cd /d "%lrpath%weiss_data\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 246 040 092 063

del LRVolumePatchTool.exe > nul

echo.
echo Patched music file

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 5", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:END