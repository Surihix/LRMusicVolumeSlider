﻿using System;
using System.IO;

namespace LRMusicVolumeSlider
{
    internal class AdjustVolume
    {
        public static void SCD(BinaryWriter writerNameVar, uint writerPosVar, string scdFileNameVar, int sliderValVar)
        {
            foreach (var scd in SCDlist.LRmusicList)
            {
                var defaultScd = scd.Split(':');
                var defaultScdVol = Convert.ToSingle(defaultScd[0]);
                var defaultScdName = defaultScd[1];

                if (scdFileNameVar.Equals(defaultScdName))
                {
                    float volLvlToScale = 0;
                    float newVolLvl = 0;

                    switch (sliderValVar)
                    {
                        case 0:
                            break;

                        case 1:
                            volLvlToScale = Convert.ToSingle(0.40);
                            newVolLvl = defaultScdVol - volLvlToScale;
                            ClampValue("low", ref newVolLvl);
                            break;

                        case 2:
                            volLvlToScale = Convert.ToSingle(0.30);
                            newVolLvl = defaultScdVol - volLvlToScale;
                            ClampValue("low", ref newVolLvl);
                            break;

                        case 3:
                            volLvlToScale = Convert.ToSingle(0.20);
                            newVolLvl = defaultScdVol - volLvlToScale;
                            ClampValue("low", ref newVolLvl);
                            break;

                        case 4:
                            volLvlToScale = Convert.ToSingle(0.10);
                            newVolLvl = defaultScdVol - volLvlToScale;
                            ClampValue("low", ref newVolLvl);
                            break;

                        case 5:
                            newVolLvl = defaultScdVol;
                            break;

                        case 6:
                            volLvlToScale = Convert.ToSingle(0.05);
                            newVolLvl = defaultScdVol + volLvlToScale;
                            ClampValue("high", ref newVolLvl);
                            break;

                        case 7:
                            volLvlToScale = Convert.ToSingle(0.10);
                            newVolLvl = defaultScdVol + volLvlToScale;
                            ClampValue("high", ref newVolLvl);
                            break;

                        case 8:
                            volLvlToScale = Convert.ToSingle(0.15);
                            newVolLvl = defaultScdVol + volLvlToScale;
                            ClampValue("high", ref newVolLvl);
                            break;

                        case 9:
                            volLvlToScale = Convert.ToSingle(0.20);
                            newVolLvl = defaultScdVol + volLvlToScale;
                            ClampValue("high", ref newVolLvl);
                            break;

                        case 10:
                            newVolLvl = 2;
                            break;
                    }

                    writerNameVar.BaseStream.Position = writerPosVar;
                    writerNameVar.Write((Single)newVolLvl);
                }
            }
        }
        
        public static void ClampValue(string clampType, ref float newVolVar)
        {
            switch (clampType)
            {
                case "low":
                    if (newVolVar < 0 || newVolVar.Equals(0))
                    {
                        newVolVar = Convert.ToSingle(0.10);
                    }
                    break;

                case "high":
                    if (newVolVar > 2 || newVolVar.Equals(2))
                    {
                        newVolVar = Convert.ToSingle(1.10);
                    }
                    break;
            }
        }
    }
}