using System.IO;
using LRMusicVolumeSlider.WhiteBinTools.FilelistClasses;
using LRMusicVolumeSlider.WhiteBinTools.SupportClasses;
using static LRMusicVolumeSlider.WhiteBinTools.SupportClasses.CmnEnums;

namespace LRMusicVolumeSlider.WhiteBinTools.UnpackClasses
{
    public class UnpackTypeArchive
    {
        public static void UnpackSingle(GameCodes gameCode, string filelistFile, string whiteBinFile, string whiteFilePath)
        {
            var filelistVariables = new FilelistVariables();
            var unpackVariables = new UnpackVariables();

            FilelistProcesses.PrepareFilelistVars(filelistVariables, filelistFile);
            UnpackProcess.PrepareBinVars(whiteBinFile, unpackVariables);

            filelistVariables.DefaultChunksExtDir = Path.Combine(unpackVariables.ExtractDir, "_chunks");
            filelistVariables.ChunkFile = Path.Combine(filelistVariables.DefaultChunksExtDir, "chunk_");


            if (!Directory.Exists(unpackVariables.ExtractDir))
            {
                Directory.CreateDirectory(unpackVariables.ExtractDir);
            }

            filelistVariables.DefaultChunksExtDir.IfDirExistsDel();
            Directory.CreateDirectory(filelistVariables.DefaultChunksExtDir);


            FilelistProcesses.DecryptProcess(gameCode, filelistVariables);

            using (var filelistStream = new FileStream(filelistVariables.MainFilelistFile, FileMode.Open, FileAccess.Read))
            {
                using (var filelistReader = new BinaryReader(filelistStream))
                {
                    FilelistChunksPrep.GetFilelistOffsets(filelistReader, filelistVariables);
                    FilelistChunksPrep.UnpackChunks(filelistStream, filelistVariables.ChunkFile, filelistVariables);
                }
            }

            if (filelistVariables.IsEncrypted)
            {
                CmnMethods.IfFileExistsDel(filelistVariables.TmpDcryptFilelistFile);
                filelistVariables.MainFilelistFile = filelistFile;
            }


            // Extracting a single file section 
            filelistVariables.ChunkFNameCount = 0;
            unpackVariables.CountDuplicates = 0;
            var hasExtracted = false;
            for (int ch = 0; ch < filelistVariables.TotalChunks; ch++)
            {
                var filesInChunkCount = FilelistProcesses.GetFilesInChunkCount(filelistVariables.ChunkFile + filelistVariables.ChunkFNameCount);

                // Open a chunk file for reading
                using (var currentChunkStream = new FileStream(filelistVariables.ChunkFile + filelistVariables.ChunkFNameCount, FileMode.Open, FileAccess.Read))
                {
                    using (var chunkStringReader = new BinaryReader(currentChunkStream))
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
                            if (filelistVariables.MainPath == whiteFilePath)
                            {
                                using (var whiteBinStream = new FileStream(whiteBinFile, FileMode.Open, FileAccess.Read))
                                {
                                    if (!Directory.Exists(Path.Combine(unpackVariables.ExtractDir, filelistVariables.DirectoryPath)))
                                    {
                                        Directory.CreateDirectory(Path.Combine(unpackVariables.ExtractDir, filelistVariables.DirectoryPath));
                                    }
                                    if (File.Exists(filelistVariables.FullFilePath))
                                    {
                                        File.Delete(filelistVariables.FullFilePath);
                                        unpackVariables.CountDuplicates++;
                                    }

                                    UnpackProcess.UnpackFile(filelistVariables, whiteBinStream, unpackVariables);
                                }

                                hasExtracted = true;
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