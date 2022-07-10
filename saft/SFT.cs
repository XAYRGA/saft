using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Be.IO;
using System.Diagnostics;

namespace saft
{
    public class SFTEntry
    {
        public string name;
        public int size;
        public int sampleCount;
        public short sampleRate; 
        public short format;
        // 0 
        public short frameRate;
        public bool loop;
        public int loopStart;
        public void readStream(BeBinaryReader read, bool noName = false)
        {
            if (!noName)
                name = Encoding.ASCII.GetString(read.ReadBytes(16)).Replace("\x00",string.Empty);
            size = read.ReadInt32();
            Debug.WriteLine(size);
            sampleCount = read.ReadInt32();
            Debug.WriteLine(sampleCount);

            sampleRate = read.ReadInt16();
            Debug.WriteLine(sampleRate);

            format = read.ReadInt16();
            Debug.WriteLine(format);

            read.ReadUInt16(); // unused short. 
            
            frameRate = read.ReadInt16();
            Debug.WriteLine(frameRate);
            loop = read.ReadInt32() == 1 ? true : false;
            Debug.WriteLine(loop);
            loopStart = read.ReadInt32();
            Debug.WriteLine(loopStart);
            read.ReadInt64();
            Debug.Write($"0x{read.BaseStream.Position:X}");
        }

        public void writeStream(BeBinaryWriter writer)
        {
            var w = Encoding.ASCII.GetBytes(name);
            for (int i = 0; i < 16; i++)
                if (i < w.Length)
                    writer.Write(w[i]);
                else
                    writer.Write((byte)0);
            writer.Write(size);
            writer.Write(sampleCount);
            writer.Write(sampleRate);
            writer.Write(format);
            writer.Write((short)0);
            writer.Write(frameRate);
            writer.Write(loop ? 1 : 0);
            writer.Write(loopStart);
            writer.Write(0l);
        }
    }

    public class SFT
    {
        public int count;
        public SFTEntry[] entries;

        public void readStream(BeBinaryReader read)
        {
            // I don't love you any more. 
            count = (int)(read.BaseStream.Length - 0x10) / 0x30; // read.ReadInt32(); well, technically this is count, but nintendo doesn't seem to use it. Thanks nintendo. 
            read.ReadUInt32(); // skip bytes. 
            read.ReadUInt64();
            read.ReadUInt32(); // skip bytes. 
            Debug.WriteLine($"Start read at 0x{read.BaseStream.Position:X}");
            entries = new SFTEntry[count];
            for (int i = 0; i < count; i++)
                (entries[i] = new SFTEntry()).readStream(read);
            

        }

        public void writeStream(BeBinaryWriter writer)
        {
            writer.Write(entries.Length);
            writer.Write(0l);
            writer.Write(0);
            for (int i = 0; i < entries.Length; i++)
                entries[i].writeStream(writer);
            writer.Write(0l);
            writer.Write(0l);
        }
    }

}
