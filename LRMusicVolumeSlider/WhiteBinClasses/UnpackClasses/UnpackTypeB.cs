using LRMusicVolumeSlider.WhiteBinClasses.FilelistClasses;
using LRMusicVolumeSlider.WhiteBinClasses.SupportClasses;
using System.IO;

namespace LRMusicVolumeSlider.WhiteBinClasses.UnpackClasses
{
    public class UnpackTypeB
    {
        public static void UnpackSingle(CmnEnums.GameCodes gameCodeVar, string filelistFileVar, string whiteBinFileVar, string whiteFilePathVar)
        {
            var filelistVariables = new FilelistProcesses();
            var unpackVariables = new UnpackProcess();

            FilelistProcesses.PrepareFilelistVars(filelistVariables, filelistFileVar);
            UnpackProcess.PrepareBinVars(whiteBinFileVar, unpackVariables);

            filelistVariables.DefaultChunksExtDir = unpackVariables.ExtractDir + "\\_chunks";
            filelistVariables.ChunkFile = filelistVariables.DefaultChunksExtDir + "\\chunk_";


            if (!Directory.Exists(unpackVariables.ExtractDir))
            {
                Directory.CreateDirectory(unpackVariables.ExtractDir);
            }

            CmnMethods.IfDirExistsDel(filelistVariables.DefaultChunksExtDir);
            Directory.CreateDirectory(filelistVariables.DefaultChunksExtDir);


            FilelistProcesses.DecryptProcess(gameCodeVar, filelistVariables);

            using (var filelist = new FileStream(filelistVariables.MainFilelistFile, FileMode.Open, FileAccess.Read))
            {
                using (var filelistReader = new BinaryReader(filelist))
                {
                    FilelistProcesses.GetFilelistOffsets(filelistReader, filelistVariables);
                    FilelistProcesses.UnpackChunks(filelist, filelistVariables.ChunkFile, filelistVariables);
                }
            }

            if (filelistVariables.IsEncrypted.Equals(true))
            {
                CmnMethods.IfFileExistsDel(filelistVariables.TmpDcryptFilelistFile);
                filelistVariables.MainFilelistFile = filelistFileVar;
            }


            // Extracting a single file section 
            filelistVariables.ChunkFNameCount = 0;
            unpackVariables.CountDuplicates = 0;
            for (int ch = 0; ch < filelistVariables.TotalChunks; ch++)
            {
                var filesInChunkCount = FilelistProcesses.GetFilesInChunkCount(filelistVariables.ChunkFile + filelistVariables.ChunkFNameCount);

                // Open a chunk file for reading
                using (var currentChunk = new FileStream(filelistVariables.ChunkFile + filelistVariables.ChunkFNameCount, FileMode.Open, FileAccess.Read))
                {
                    using (var chunkStringReader = new BinaryReader(currentChunk))
                    {
                        var chunkStringReaderPos = (uint)0;
                        for (int f = 0; f < filesInChunkCount; f++)
                        {
                            var convertedString = chunkStringReader.BinaryToString(chunkStringReaderPos);

                            if (convertedString.StartsWith("end"))
                            {
                                break;
                            }

                            UnpackProcess.PrepareExtraction(convertedString, filelistVariables, unpackVariables.ExtractDir);

                            // Extract a specific file
                            if (filelistVariables.MainPath.Equals(whiteFilePathVar))
                            {
                                using (var whiteBin = new FileStream(whiteBinFileVar, FileMode.Open, FileAccess.Read))
                                {
                                    if (!Directory.Exists(unpackVariables.ExtractDir + "\\" + filelistVariables.DirectoryPath))
                                    {
                                        Directory.CreateDirectory(unpackVariables.ExtractDir + "\\" + filelistVariables.DirectoryPath);
                                    }
                                    if (File.Exists(filelistVariables.FullFilePath))
                                    {
                                        File.Delete(filelistVariables.FullFilePath);
                                        unpackVariables.CountDuplicates++;
                                    }

                                    UnpackProcess.UnpackFile(filelistVariables, whiteBin, unpackVariables);
                                }
                            }

                            chunkStringReaderPos = (uint)chunkStringReader.BaseStream.Position;
                        }
                    }
                }

                filelistVariables.ChunkFNameCount++;
            }

            Directory.Delete(filelistVariables.DefaultChunksExtDir, true);
        }
    }
}