using System;
using System.IO;
using System.Text;

namespace LRMusicVolumeSlider
{
    internal class UnpackBin
    {
        public static void UnpkAfile(string extractionDirVar, string filelistFile, string whiteBinFile, string whiteFilePath)
        {
            // Set directories and file paths for the filelist files and the white bin files
            var inFilelistFileDir = extractionDirVar;
            var inBinFileDir = extractionDirVar;

            var tmpDcryptFilelistFile = inFilelistFileDir + "\\filelist_tmp.bin";
            var extract_dir_Name = Path.GetFileNameWithoutExtension(whiteBinFile).Replace(".win32", "_win32");
            var extract_dir = inBinFileDir + "\\" + extract_dir_Name;
            var defaultChunksExtDir = extract_dir + "\\_chunks";
            var chunkFile = defaultChunksExtDir + "\\chunk_";


            // Check and delete backup filelist file if it exists
            CmnMethods.IfFileExistsDel(filelistFile + ".bak");


            // Check and create extracted directory if it does
            // not exist 
            if (!Directory.Exists(extract_dir))
            {
                Directory.CreateDirectory(extract_dir);
            }
            Directory.CreateDirectory(defaultChunksExtDir);


            // Check if the ffxiiicrypt tool is present in the filelist directory
            // and if it doesn't exist copy it to the directory from the app
            // directory if it doesn't exist            
            if (!File.Exists(inFilelistFileDir + "\\ffxiiicrypt.exe"))
            {
                if (File.Exists("ffxiiicrypt.exe"))
                {
                    if (!File.Exists(inFilelistFileDir + "\\ffxiiicrypt.exe"))
                    {
                        File.Copy("ffxiiicrypt.exe", inFilelistFileDir + "\\ffxiiicrypt.exe");
                    }
                }
            }


            // Decrypt and trim the filelist file for extraction
            CmnMethods.IfFileExistsDel(tmpDcryptFilelistFile);

            File.Copy(filelistFile, tmpDcryptFilelistFile);

            var CryptFilelistCode = " filelist";

            CmnMethods.FFXiiiCryptTool("\"" + inFilelistFileDir + "\"", " -d ", "\"" + tmpDcryptFilelistFile + "\"", ref CryptFilelistCode);

            File.Move(filelistFile, filelistFile + ".bak");

            using (FileStream toAdjust = new FileStream(tmpDcryptFilelistFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream adjusted = new FileStream(filelistFile, FileMode.OpenOrCreate,
                    FileAccess.Write))
                {
                    toAdjust.Seek(32, SeekOrigin.Begin);
                    toAdjust.CopyTo(adjusted);
                }
            }

            File.Delete(tmpDcryptFilelistFile);


            // Process File chunks section
            // Intialize the variables required for extraction
            var chunkFNameCount = (uint)0;
            var totalChunks = (uint)0;

            using (FileStream filelist = new FileStream(filelistFile, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader filelistReader = new BinaryReader(filelist))
                {
                    filelistReader.BaseStream.Position = 0;
                    var chunksInfoStartPos = filelistReader.ReadUInt32();
                    var chunksStartPos = filelistReader.ReadUInt32();

                    var chunkInfo_size = chunksStartPos - chunksInfoStartPos;
                    totalChunks = chunkInfo_size / 12;

                    // Make a memorystream for holding all Chunks info
                    using (MemoryStream chunkInfoStream = new MemoryStream())
                    {
                        filelist.Seek(chunksInfoStartPos, SeekOrigin.Begin);
                        byte[] chunkInfoBuffer = new byte[chunkInfo_size];
                        var chunkBytesRead = filelist.Read(chunkInfoBuffer, 0, chunkInfoBuffer.Length);
                        chunkInfoStream.Write(chunkInfoBuffer, 0, chunkBytesRead);

                        // Make memorystream for all Chunks compressed data
                        using (MemoryStream chunkStream = new MemoryStream())
                        {
                            filelist.Seek(chunksStartPos, SeekOrigin.Begin);
                            filelist.CopyTo(chunkStream);

                            // Open a binary reader and read each chunk's info and
                            // dump them as separate files
                            using (BinaryReader chunkInfoReader = new BinaryReader(chunkInfoStream))
                            {
                                var chunkInfoReadVal = (uint)0;
                                for (int c = 0; c < totalChunks; c++)
                                {
                                    chunkInfoReader.BaseStream.Position = chunkInfoReadVal + 4;
                                    var chunkCmpSize = chunkInfoReader.ReadUInt32();
                                    var chunkDataStart = chunkInfoReader.ReadUInt32();

                                    chunkStream.Seek(chunkDataStart, SeekOrigin.Begin);
                                    using (MemoryStream chunkToDcmp = new MemoryStream())
                                    {
                                        byte[] chunkBuffer = new byte[chunkCmpSize];
                                        var ReadCmpBytes = chunkStream.Read(chunkBuffer, 0, chunkBuffer.Length);
                                        chunkToDcmp.Write(chunkBuffer, 0, ReadCmpBytes);

                                        using (FileStream chunksOutStream = new FileStream(chunkFile + chunkFNameCount,
                                            FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            chunkToDcmp.Seek(0, SeekOrigin.Begin);
                                            ZlibLibrary.ZlibDecompress(chunkToDcmp, chunksOutStream);
                                        }
                                    }

                                    chunkInfoReadVal += 12;
                                    chunkFNameCount++;
                                }
                            }
                        }
                    }
                }
            }


            // Extracting files section 
            chunkFNameCount = 0;
            for (int ch = 0; ch < totalChunks; ch++)
            {
                // Get the total number of files in a chunk file by counting the number of times
                // an null character occurs in the chunk file
                var filesInChunkCount = (uint)0;
                using (StreamReader fileCountReader = new StreamReader(defaultChunksExtDir + "/chunk_" + chunkFNameCount))
                {
                    while (!fileCountReader.EndOfStream)
                    {
                        var currentNullChar = fileCountReader.Read();
                        if (currentNullChar == 0)
                        {
                            filesInChunkCount++;
                        }
                    }
                }

                // Open a chunk file for reading
                using (FileStream currentChunk = new FileStream(chunkFile + chunkFNameCount, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader chunkStringReader = new BinaryReader(currentChunk))
                    {
                        var chunkStringReaderPos = (uint)0;
                        for (int f = 0; f < filesInChunkCount; f++)
                        {
                            chunkStringReader.BaseStream.Position = chunkStringReaderPos;
                            var parsedString = new StringBuilder();
                            char getParsedString;
                            while ((getParsedString = chunkStringReader.ReadChar()) != default)
                            {
                                parsedString.Append(getParsedString);
                            }
                            var parsed = parsedString.ToString();

                            if (parsed.StartsWith("end"))
                            {
                                break;
                            }

                            string[] data = parsed.Split(':');
                            var filePos = Convert.ToUInt32(data[0], 16) * 2048;
                            var unCmpSize = Convert.ToUInt32(data[1], 16);
                            var cmpSize = Convert.ToUInt32(data[2], 16);
                            var mainPath = data[3].Replace("/", "\\");

                            var directoryPath = Path.GetDirectoryName(mainPath);
                            var fileName = Path.GetFileName(mainPath);
                            var fullFilePath = extract_dir + "\\" + directoryPath + "\\" + fileName;
                            var compressedState = false;

                            if (!unCmpSize.Equals(cmpSize))
                            {
                                compressedState = true;
                            }
                            else
                            {
                                compressedState = false;
                            }

                            // Extract a specific file
                            if (mainPath.Equals(whiteFilePath))
                            {
                                using (FileStream whiteBin = new FileStream(whiteBinFile, FileMode.Open, FileAccess.Read))
                                {
                                    if (!Directory.Exists(extract_dir + "\\" + directoryPath))
                                    {
                                        Directory.CreateDirectory(extract_dir + "\\" + directoryPath);
                                    }
                                    if (File.Exists(fullFilePath))
                                    {
                                        File.Delete(fullFilePath);
                                    }

                                    switch (compressedState)
                                    {
                                        case true:
                                            using (MemoryStream cmpData = new MemoryStream())
                                            {
                                                whiteBin.CopyTo(cmpData, filePos, cmpSize);

                                                using (FileStream OutFile = new FileStream(fullFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                                {
                                                    cmpData.Seek(0, SeekOrigin.Begin);
                                                    ZlibLibrary.ZlibDecompress(cmpData, OutFile);
                                                }
                                            }
                                            break;

                                        case false:
                                            using (FileStream outFile = new FileStream(fullFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                                            {
                                                outFile.Seek(0, SeekOrigin.Begin);
                                                whiteBin.CopyTo(outFile, filePos, unCmpSize);
                                            }
                                            break;
                                    }
                                }
                            }

                            chunkStringReaderPos = (uint)chunkStringReader.BaseStream.Position;
                        }
                    }
                }

                chunkFNameCount++;
            }

            Directory.Delete(defaultChunksExtDir, true);

            // Restore old filefile file
            File.Delete(filelistFile);
            File.Move(filelistFile + ".bak", filelistFile);
        }


        public static void UnpkAll(string extractionDirVar, string filelistFile, string whiteBinFile)
        {
            // Set directories and file paths for the filelist files and the white bin files
            var inFilelistFileDir = extractionDirVar;
            var inBinFileDir = extractionDirVar;

            var tmpDcryptFilelistFile = inFilelistFileDir + "\\filelist_tmp.bin";
            var extract_dir_Name = Path.GetFileNameWithoutExtension(whiteBinFile).Replace(".win32", "_win32");
            var extract_dir = inBinFileDir + "\\" + extract_dir_Name;
            var defaultChunksExtDir = extract_dir + "\\_chunks";
            var chunkFile = defaultChunksExtDir + "\\chunk_";


            // Check and delete backup filelist file if it exists
            CmnMethods.IfFileExistsDel(filelistFile + ".bak");


            // Check and create extracted directory if it does
            // not exist 
            if (!Directory.Exists(extract_dir))
            {
                Directory.CreateDirectory(extract_dir);
            }
            Directory.CreateDirectory(defaultChunksExtDir);


            // Check if the ffxiiicrypt tool is present in the filelist directory
            // and if it doesn't exist copy it to the directory from the app
            // directory if it doesn't exist            
            if (!File.Exists(inFilelistFileDir + "\\ffxiiicrypt.exe"))
            {
                if (File.Exists("ffxiiicrypt.exe"))
                {
                    if (!File.Exists(inFilelistFileDir + "\\ffxiiicrypt.exe"))
                    {
                        File.Copy("ffxiiicrypt.exe", inFilelistFileDir + "\\ffxiiicrypt.exe");
                    }
                }
            }


            // Decrypt and trim the filelist file for extraction
            CmnMethods.IfFileExistsDel(tmpDcryptFilelistFile);

            File.Copy(filelistFile, tmpDcryptFilelistFile);

            var CryptFilelistCode = " filelist";

            CmnMethods.FFXiiiCryptTool("\"" + inFilelistFileDir + "\"", " -d ", "\"" + tmpDcryptFilelistFile + "\"", ref CryptFilelistCode);

            File.Move(filelistFile, filelistFile + ".bak");

            using (FileStream toAdjust = new FileStream(tmpDcryptFilelistFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream adjusted = new FileStream(filelistFile, FileMode.OpenOrCreate,
                    FileAccess.Write))
                {
                    toAdjust.Seek(32, SeekOrigin.Begin);
                    toAdjust.CopyTo(adjusted);
                }
            }

            File.Delete(tmpDcryptFilelistFile);


            // Process File chunks section
            // Intialize the variables required for extraction
            var chunkFNameCount = (uint)0;
            var totalChunks = (uint)0;

            using (FileStream filelist = new FileStream(filelistFile, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader filelistReader = new BinaryReader(filelist))
                {
                    filelistReader.BaseStream.Position = 0;
                    var chunksInfoStartPos = filelistReader.ReadUInt32();
                    var chunksStartPos = filelistReader.ReadUInt32();

                    var chunkInfo_size = chunksStartPos - chunksInfoStartPos;
                    totalChunks = chunkInfo_size / 12;

                    // Make a memorystream for holding all Chunks info
                    using (MemoryStream chunkInfoStream = new MemoryStream())
                    {
                        filelist.Seek(chunksInfoStartPos, SeekOrigin.Begin);
                        byte[] chunkInfoBuffer = new byte[chunkInfo_size];
                        var chunkBytesRead = filelist.Read(chunkInfoBuffer, 0, chunkInfoBuffer.Length);
                        chunkInfoStream.Write(chunkInfoBuffer, 0, chunkBytesRead);

                        // Make memorystream for all Chunks compressed data
                        using (MemoryStream chunkStream = new MemoryStream())
                        {
                            filelist.Seek(chunksStartPos, SeekOrigin.Begin);
                            filelist.CopyTo(chunkStream);

                            // Open a binary reader and read each chunk's info and
                            // dump them as separate files
                            using (BinaryReader chunkInfoReader = new BinaryReader(chunkInfoStream))
                            {
                                var chunkInfoReadVal = (uint)0;
                                for (int c = 0; c < totalChunks; c++)
                                {
                                    chunkInfoReader.BaseStream.Position = chunkInfoReadVal + 4;
                                    var chunkCmpSize = chunkInfoReader.ReadUInt32();
                                    var chunkDataStart = chunkInfoReader.ReadUInt32();

                                    chunkStream.Seek(chunkDataStart, SeekOrigin.Begin);
                                    using (MemoryStream chunkToDcmp = new MemoryStream())
                                    {
                                        byte[] chunkBuffer = new byte[chunkCmpSize];
                                        var ReadCmpBytes = chunkStream.Read(chunkBuffer, 0, chunkBuffer.Length);
                                        chunkToDcmp.Write(chunkBuffer, 0, ReadCmpBytes);

                                        using (FileStream chunksOutStream = new FileStream(chunkFile + chunkFNameCount,
                                            FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            chunkToDcmp.Seek(0, SeekOrigin.Begin);
                                            ZlibLibrary.ZlibDecompress(chunkToDcmp, chunksOutStream);
                                        }
                                    }

                                    chunkInfoReadVal += 12;
                                    chunkFNameCount++;
                                }
                            }
                        }
                    }
                }
            }


            // Extracting files section 
            chunkFNameCount = 0;
            for (int ch = 0; ch < totalChunks; ch++)
            {
                // Get the total number of files in a chunk file by counting the number of times
                // an null character occurs in the chunk file
                var filesInChunkCount = (uint)0;
                using (StreamReader fileCountReader = new StreamReader(defaultChunksExtDir + "/chunk_" + chunkFNameCount))
                {
                    while (!fileCountReader.EndOfStream)
                    {
                        var currentNullChar = fileCountReader.Read();
                        if (currentNullChar == 0)
                        {
                            filesInChunkCount++;
                        }
                    }
                }

                // Open a chunk file for reading
                using (FileStream currentChunk = new FileStream(chunkFile + chunkFNameCount, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader chunkStringReader = new BinaryReader(currentChunk))
                    {
                        var chunkStringReaderPos = (uint)0;
                        for (int f = 0; f < filesInChunkCount; f++)
                        {
                            chunkStringReader.BaseStream.Position = chunkStringReaderPos;
                            var parsedString = new StringBuilder();
                            char getParsedString;
                            while ((getParsedString = chunkStringReader.ReadChar()) != default)
                            {
                                parsedString.Append(getParsedString);
                            }
                            var parsed = parsedString.ToString();

                            if (parsed.StartsWith("end"))
                            {
                                break;
                            }

                            string[] data = parsed.Split(':');
                            var filePos = Convert.ToUInt32(data[0], 16) * 2048;
                            var unCmpSize = Convert.ToUInt32(data[1], 16);
                            var cmpSize = Convert.ToUInt32(data[2], 16);
                            var mainPath = data[3].Replace("/", "\\");

                            var directoryPath = Path.GetDirectoryName(mainPath);
                            var fileName = Path.GetFileName(mainPath);
                            var fullFilePath = extract_dir + "\\" + directoryPath + "\\" + fileName;
                            var compressedState = false;

                            if (!unCmpSize.Equals(cmpSize))
                            {
                                compressedState = true;
                            }
                            else
                            {
                                compressedState = false;
                            }

                            using (FileStream whiteBin = new FileStream(whiteBinFile, FileMode.Open, FileAccess.Read))
                            {
                                if (!Directory.Exists(extract_dir + "\\" + directoryPath))
                                {
                                    Directory.CreateDirectory(extract_dir + "\\" + directoryPath);
                                }
                                if (File.Exists(fullFilePath))
                                {
                                    File.Delete(fullFilePath);
                                }

                                switch (compressedState)
                                {
                                    case true:
                                        using (MemoryStream cmpData = new MemoryStream())
                                        {
                                            whiteBin.CopyTo(cmpData, filePos, cmpSize);

                                            using (FileStream OutFile = new FileStream(fullFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                            {
                                                cmpData.Seek(0, SeekOrigin.Begin);
                                                ZlibLibrary.ZlibDecompress(cmpData, OutFile);
                                            }
                                        }
                                        break;

                                    case false:
                                        using (FileStream outFile = new FileStream(fullFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                                        {
                                            outFile.Seek(0, SeekOrigin.Begin);
                                            whiteBin.CopyTo(outFile, filePos, unCmpSize);
                                        }
                                        break;
                                }
                            }

                            chunkStringReaderPos = (uint)chunkStringReader.BaseStream.Position;
                        }
                    }
                }

                chunkFNameCount++;
            }

            Directory.Delete(defaultChunksExtDir, true);

            // Restore old filefile file
            File.Delete(filelistFile);
            File.Move(filelistFile + ".bak", filelistFile);
        }


        public static void UnpkFilePaths(string filelistFile)
        {
            // Set the filelist file names
            var filelistOutName = Path.GetFileNameWithoutExtension(filelistFile);

            // Set directories and file paths for the filelist file
            // and the extracted chunk files
            var inFilelistFilePath = Path.GetFullPath(filelistFile);
            var inFilelistFileDir = Path.GetDirectoryName(inFilelistFilePath);
            var tmpDcryptFilelistFile = inFilelistFileDir + "\\filelist_tmp.bin";

            var chunksExtDir = inFilelistFileDir + "\\" + "_chunks";
            var chunkFile = chunksExtDir + "\\chunk_";
            var outChunkTxtFile = inFilelistFileDir + "\\" + filelistOutName + ".txt";
            CmnMethods.IfFileExistsDel(outChunkTxtFile);


            // Check and delete backup filelist file, the chunk
            // files and extracted chunk file directory if it exists
            CmnMethods.IfFileExistsDel(filelistFile + ".bak");

            if (Directory.Exists(chunksExtDir))
            {
                Directory.Delete(chunksExtDir, true);
            }
            Directory.CreateDirectory(chunksExtDir);


            // Check if the ffxiiicrypt tool is present in the filelist directory
            // and if it doesn't exist copy it to the directory from the app
            // directory if it doesn't exist
            if (!File.Exists(inFilelistFileDir + "\\ffxiiicrypt.exe"))
            {
                if (File.Exists("ffxiiicrypt.exe"))
                {
                    if (!File.Exists(inFilelistFileDir + "\\ffxiiicrypt.exe"))
                    {
                        File.Copy("ffxiiicrypt.exe", inFilelistFileDir + "\\ffxiiicrypt.exe");
                    }
                }
            }


            // Decrypt and trim the filelist file for extraction
            CmnMethods.IfFileExistsDel(tmpDcryptFilelistFile);

            File.Copy(filelistFile, tmpDcryptFilelistFile);

            var cryptFilelistCode = " filelist";

            CmnMethods.FFXiiiCryptTool(inFilelistFileDir, " -d ", "\"" + tmpDcryptFilelistFile + "\"", ref cryptFilelistCode);

            File.Move(filelistFile, filelistFile + ".bak");

            using (FileStream toAdjust = new FileStream(tmpDcryptFilelistFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream adjusted = new FileStream(filelistFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    toAdjust.Seek(32, SeekOrigin.Begin);
                    toAdjust.CopyTo(adjusted);
                }
            }

            File.Delete(tmpDcryptFilelistFile);


            // Process File chunks section
            // Intialize the variables required for extraction
            var chunkFNameCount = (uint)0;
            var totalChunks = (uint)0;
            var totalFiles = (uint)0;

            using (FileStream filelist = new FileStream(filelistFile, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader filelistReader = new BinaryReader(filelist))
                {
                    filelistReader.BaseStream.Position = 0;
                    var chunksInfoStartPos = filelistReader.ReadUInt32();
                    var chunksStartPos = filelistReader.ReadUInt32();
                    totalFiles = filelistReader.ReadUInt32();

                    var chunkInfo_size = chunksStartPos - chunksInfoStartPos;
                    totalChunks = chunkInfo_size / 12;

                    // Make a memorystream for holding all Chunks info
                    using (MemoryStream chunkInfoStream = new MemoryStream())
                    {
                        filelist.Seek(chunksInfoStartPos, SeekOrigin.Begin);
                        byte[] chunkInfoBuffer = new byte[chunkInfo_size];
                        var chunkBytesRead = filelist.Read(chunkInfoBuffer, 0, chunkInfoBuffer.Length);
                        chunkInfoStream.Write(chunkInfoBuffer, 0, chunkBytesRead);

                        // Make memorystream for all Chunks compressed data
                        using (MemoryStream chunkStream = new MemoryStream())
                        {
                            filelist.Seek(chunksStartPos, SeekOrigin.Begin);
                            filelist.CopyTo(chunkStream);

                            // Open a binary reader and read each chunk's info and
                            // dump them as separate files
                            using (BinaryReader chunkInfoReader = new BinaryReader(chunkInfoStream))
                            {
                                var chunkInfoReadVal = (uint)0;
                                for (int c = 0; c < totalChunks; c++)
                                {
                                    chunkInfoReader.BaseStream.Position = chunkInfoReadVal + 4;
                                    var chunkCmpSize = chunkInfoReader.ReadUInt32();
                                    var chunkDataStart = chunkInfoReader.ReadUInt32();

                                    chunkStream.Seek(chunkDataStart, SeekOrigin.Begin);
                                    using (MemoryStream chunkToDcmp = new MemoryStream())
                                    {
                                        byte[] chunkBuffer = new byte[chunkCmpSize];
                                        var readCmpBytes = chunkStream.Read(chunkBuffer, 0, chunkBuffer.Length);
                                        chunkToDcmp.Write(chunkBuffer, 0, readCmpBytes);

                                        using (FileStream chunksOutStream = new FileStream(chunkFile + chunkFNameCount, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            chunkToDcmp.Seek(0, SeekOrigin.Begin);
                                            ZlibLibrary.ZlibDecompress(chunkToDcmp, chunksOutStream);
                                        }
                                    }

                                    chunkInfoReadVal += 12;
                                    chunkFNameCount++;
                                }
                            }
                        }
                    }
                }
            }


            // Write all file paths strings
            // to a text file
            chunkFNameCount = 0;
            for (int cf = 0; cf < totalChunks; cf++)
            {
                // Get the total number of entries in a chunk file by counting the number of times
                // an null character occurs in the chunk file
                var entriesInChunk = (uint)0;
                using (StreamReader fileCountReader = new StreamReader(chunksExtDir + "/chunk_" + chunkFNameCount))
                {
                    while (!fileCountReader.EndOfStream)
                    {
                        var currentNullChar = fileCountReader.Read();
                        if (currentNullChar == 0)
                        {
                            entriesInChunk++;
                        }
                    }
                }

                // Open a chunk file for reading
                using (FileStream currentChunk = new FileStream(chunkFile + chunkFNameCount, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream outChunk = new FileStream(outChunkTxtFile, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter entriesWriter = new StreamWriter(outChunk))
                        {
                            using (BinaryReader chunkStringReader = new BinaryReader(currentChunk))
                            {
                                var chunkStringReaderPos = (uint)0;
                                for (int e = 0; e < entriesInChunk; e++)
                                {
                                    chunkStringReader.BaseStream.Position = chunkStringReaderPos;
                                    var parsedString = new StringBuilder();
                                    char getParsedString;
                                    while ((getParsedString = chunkStringReader.ReadChar()) != default)
                                    {
                                        parsedString.Append(getParsedString);
                                    }
                                    var parsed = parsedString.ToString();

                                    entriesWriter.WriteLine(parsed);

                                    chunkStringReaderPos = (uint)chunkStringReader.BaseStream.Position;
                                }
                            }
                        }
                    }
                }

                File.Delete(chunkFile + chunkFNameCount);
                chunkFNameCount++;
            }

            Directory.Delete(chunksExtDir, true);

            // Restore old filefile file 
            File.Delete(filelistFile);
            File.Move(filelistFile + ".bak", filelistFile);
        }
    }
}