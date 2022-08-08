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

cd /d "%lrpath%\weiss_data\"
if not exist dir-1 md dir-1
if not exist dir-1\dir-2\dir-3 md dir-1\dir-2\dir-3

if not exist zone-dir1 md zone-dir1
if not exist zone-dir1\zone-dir2 md zone-dir1\zone-dir2

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul

cd /d "%lrpath%weiss_data\sys"
move "%lrpath%weiss_data\sys\filelist2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\sys\white_img2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3"
ff13tool -x -ff133 filelist2a.win32.bin white_img2a.win32.bin

cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 000 000 000 000
del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

cls
echo.
echo Patched wdbpack file
echo.

move "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" > nul
move "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" > nul

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -x -ff133 filelist_z0120a.win32.bin white_z0120a_img.win32.bin

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\*.*" > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 000 000 000 000
del LRVolumePatchTool.exe > nul

echo.
echo Patched music file
echo. 

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -c -ff133 filelist_z0120a.win32.bin white_z0120a_img 

cls
echo.
echo Packed z0120a bin file
echo.

move "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\"
ff13tool -c -ff133 filelist2a.win32.bin white_img2a

cls
echo.
echo Packed img2a bin file
echo.

move "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" "%lrpath%weiss_data\sys\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" "%lrpath%weiss_data\sys\white_img2a.win32.bin" > nul
move "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" > nul

echo Moved patched bin files

cd /d "%lrpath%weiss_data\"
if exist dir-1 rd /s /q dir-1 > nul
if exist dir-1 rd /s /q dir-1 > nul

if exist zone-dir1 rd/ s /q zone-dir1 > nul
if exist zone-dir1 rd/ s /q zone-dir1 > nul

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music has been Muted", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE1
echo.
echo Setting music volume to level 1....
echo.

cd /d "%lrpath%\weiss_data\"
if not exist dir-1 md dir-1
if not exist dir-1\dir-2\dir-3 md dir-1\dir-2\dir-3

if not exist zone-dir1 md zone-dir1
if not exist zone-dir1\zone-dir2 md zone-dir1\zone-dir2

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul

cd /d "%lrpath%weiss_data\sys"
move "%lrpath%weiss_data\sys\filelist2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\sys\white_img2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3"
ff13tool -x -ff133 filelist2a.win32.bin white_img2a.win32.bin

cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 015 092 041
del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

cls
echo.
echo Patched wdbpack file
echo.

move "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" > nul
move "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" > nul

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -x -ff133 filelist_z0120a.win32.bin white_z0120a_img.win32.bin

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\*.*" > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 041 092 015 063
del LRVolumePatchTool.exe > nul

echo.
echo Patched music file
echo. 

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -c -ff133 filelist_z0120a.win32.bin white_z0120a_img 

cls
echo.
echo Packed z0120a bin file
echo.

move "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\"
ff13tool -c -ff133 filelist2a.win32.bin white_img2a

cls
echo.
echo Packed img2a bin file
echo.

move "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" "%lrpath%weiss_data\sys\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" "%lrpath%weiss_data\sys\white_img2a.win32.bin" > nul
move "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" > nul

echo Moved patched bin files

cd /d "%lrpath%weiss_data\"
if exist dir-1 rd /s /q dir-1 > nul
if exist dir-1 rd /s /q dir-1 > nul

if exist zone-dir1 rd/ s /q zone-dir1 > nul
if exist zone-dir1 rd/ s /q zone-dir1 > nul

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 1", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE2
echo.
echo Setting music volume to level 2....
echo.

cd /d "%lrpath%\weiss_data\"
if not exist dir-1 md dir-1
if not exist dir-1\dir-2\dir-3 md dir-1\dir-2\dir-3

if not exist zone-dir1 md zone-dir1
if not exist zone-dir1\zone-dir2 md zone-dir1\zone-dir2

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul

cd /d "%lrpath%weiss_data\sys"
move "%lrpath%weiss_data\sys\filelist2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\sys\white_img2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3"
ff13tool -x -ff133 filelist2a.win32.bin white_img2a.win32.bin

cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 040 245 195
del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

cls
echo.
echo Patched wdbpack file
echo.

move "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" > nul
move "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" > nul

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -x -ff133 filelist_z0120a.win32.bin white_z0120a_img.win32.bin

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\*.*" > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 195 245 040 063
del LRVolumePatchTool.exe > nul

echo.
echo Patched music file
echo. 

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -c -ff133 filelist_z0120a.win32.bin white_z0120a_img 

cls
echo.
echo Packed z0120a bin file
echo.

move "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\"
ff13tool -c -ff133 filelist2a.win32.bin white_img2a

cls
echo.
echo Packed img2a bin file
echo.

move "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" "%lrpath%weiss_data\sys\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" "%lrpath%weiss_data\sys\white_img2a.win32.bin" > nul
move "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" > nul

echo Moved patched bin files

cd /d "%lrpath%weiss_data\"
if exist dir-1 rd /s /q dir-1 > nul
if exist dir-1 rd /s /q dir-1 > nul

if exist zone-dir1 rd/ s /q zone-dir1 > nul
if exist zone-dir1 rd/ s /q zone-dir1 > nul

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 2", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE3
echo.
echo Setting music volume to level 3....
echo.

cd /d "%lrpath%\weiss_data\"
if not exist dir-1 md dir-1
if not exist dir-1\dir-2\dir-3 md dir-1\dir-2\dir-3

if not exist zone-dir1 md zone-dir1
if not exist zone-dir1\zone-dir2 md zone-dir1\zone-dir2

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul

cd /d "%lrpath%weiss_data\sys"
move "%lrpath%weiss_data\sys\filelist2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\sys\white_img2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3"
ff13tool -x -ff133 filelist2a.win32.bin white_img2a.win32.bin

cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 066 143 092
del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

cls
echo.
echo Patched wdbpack file
echo.

move "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" > nul
move "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" > nul

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -x -ff133 filelist_z0120a.win32.bin white_z0120a_img.win32.bin

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\*.*" > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 092 143 066 063
del LRVolumePatchTool.exe > nul

echo.
echo Patched music file
echo. 

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -c -ff133 filelist_z0120a.win32.bin white_z0120a_img 

cls
echo.
echo Packed z0120a bin file
echo.

move "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\"
ff13tool -c -ff133 filelist2a.win32.bin white_img2a

cls
echo.
echo Packed img2a bin file
echo.

move "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" "%lrpath%weiss_data\sys\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" "%lrpath%weiss_data\sys\white_img2a.win32.bin" > nul
move "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" > nul

echo Moved patched bin files

cd /d "%lrpath%weiss_data\"
if exist dir-1 rd /s /q dir-1 > nul
if exist dir-1 rd /s /q dir-1 > nul

if exist zone-dir1 rd/ s /q zone-dir1 > nul
if exist zone-dir1 rd/ s /q zone-dir1 > nul

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 3", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE4
echo.
echo Setting music volume to level 4....
echo.

cd /d "%lrpath%\weiss_data\"
if not exist dir-1 md dir-1
if not exist dir-1\dir-2\dir-3 md dir-1\dir-2\dir-3

if not exist zone-dir1 md zone-dir1
if not exist zone-dir1\zone-dir2 md zone-dir1\zone-dir2

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul

cd /d "%lrpath%weiss_data\sys"
move "%lrpath%weiss_data\sys\filelist2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\sys\white_img2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3"
ff13tool -x -ff133 filelist2a.win32.bin white_img2a.win32.bin

cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 092 040 246
del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

cls
echo.
echo Patched wdbpack file
echo.

move "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" > nul
move "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" > nul

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -x -ff133 filelist_z0120a.win32.bin white_z0120a_img.win32.bin

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\*.*" > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 205 204 076 063
del LRVolumePatchTool.exe > nul

echo.
echo Patched music file
echo. 

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -c -ff133 filelist_z0120a.win32.bin white_z0120a_img 

cls
echo.
echo Packed z0120a bin file
echo.

move "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\"
ff13tool -c -ff133 filelist2a.win32.bin white_img2a

cls
echo.
echo Packed img2a bin file
echo.

move "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" "%lrpath%weiss_data\sys\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" "%lrpath%weiss_data\sys\white_img2a.win32.bin" > nul
move "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" > nul

echo Moved patched bin files

cd /d "%lrpath%weiss_data\"
if exist dir-1 rd /s /q dir-1 > nul
if exist dir-1 rd /s /q dir-1 > nul

if exist zone-dir1 rd/ s /q zone-dir1 > nul
if exist zone-dir1 rd/ s /q zone-dir1 > nul

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 4", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END


:SLIDE5
echo.
echo Setting music volume to level 5....
echo.

cd /d "%lrpath%\weiss_data\"
if not exist dir-1 md dir-1
if not exist dir-1\dir-2\dir-3 md dir-1\dir-2\dir-3

if not exist zone-dir1 md zone-dir1
if not exist zone-dir1\zone-dir2 md zone-dir1\zone-dir2

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\*.* > nul

cd /d "%lrpath%weiss_data\sys"
move "%lrpath%weiss_data\sys\filelist2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\sys\white_img2a.win32.bin" "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3"
ff13tool -x -ff133 filelist2a.win32.bin white_img2a.win32.bin

cd /d "%~dp0..\PatchTools\"
copy WPDPack.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -U wdbpack.bin > nul

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%"weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\*.* > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident\wdbpack\"
LRVolumePatchTool.exe r_white.wdb 9764 063 128 000 000
del LRVolumePatchTool.exe > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a\db\resident"
WPDPack.exe -P wdbpack.bin > nul

del wdbpack.bin > nul
del WPDPack.exe > nul
ren wdbpack.bin.NEW wdbpack.bin

if exist wdbpack rd /s /q wdbpack > nul
if exist wdbpack rd /s /q wdbpack > nul

cls
echo.
echo Patched wdbpack file
echo.

move "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" > nul
move "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" > nul

cd /d "%~dp0..\PatchTools\"
copy ff13tool.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul
copy ffxiiicrypt.exe "%lrpath%"weiss_data\zone-dir1\zone-dir2\*.* > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -x -ff133 filelist_z0120a.win32.bin white_z0120a_img.win32.bin

cd /d "%~dp0..\PatchTools\"
copy LRVolumePatchTool.exe "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\*.*" > nul

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img\sound\pack\8000\"
LRVolumePatchTool.exe music_W_title4.win32.scd 296 246 040 092 063
del LRVolumePatchTool.exe > nul

echo.
echo Patched music file
echo. 

cd /d "%lrpath%weiss_data\zone-dir1\zone-dir2\"
ff13tool -c -ff133 filelist_z0120a.win32.bin white_z0120a_img 

cls
echo.
echo Packed z0120a bin file
echo.

move "%lrpath%weiss_data\zone-dir1\zone-dir2\filelist_z0120a.win32.bin" "%lrpath%weiss_data\dir-1\zone\filelist_z0120a.win32.bin" > nul

cd /d "%lrpath%weiss_data\dir-1\dir-2\dir-3\"
ff13tool -c -ff133 filelist2a.win32.bin white_img2a

cls
echo.
echo Packed img2a bin file
echo.

move "%lrpath%weiss_data\dir-1\dir-2\dir-3\filelist2a.win32.bin" "%lrpath%weiss_data\sys\filelist2a.win32.bin" > nul
move "%lrpath%weiss_data\dir-1\dir-2\dir-3\white_img2a.win32.bin" "%lrpath%weiss_data\sys\white_img2a.win32.bin" > nul
move "%lrpath%weiss_data\zone-dir1\zone-dir2\white_z0120a_img.win32.bin" "%lrpath%weiss_data\zone\white_z0120a_img.win32.bin" > nul

echo Moved patched bin files

cd /d "%lrpath%weiss_data\"
if exist dir-1 rd /s /q dir-1 > nul
if exist dir-1 rd /s /q dir-1 > nul

if exist zone-dir1 rd/ s /q zone-dir1 > nul
if exist zone-dir1 rd/ s /q zone-dir1 > nul

cd /d "%~dp0..\Scripts\" 
echo MSGBOX "Music volume is set to level 5", 64, "Volume slider" > msgbox.vbs
call msgbox.vbs
goto END

:END