using NAudio.Wave;

namespace Exsperian
{
    public class Beat1 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Beat1()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound; // Alterna para o próximo som na próxima leitura

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(2 * (t >> 5 & t) - (t >> 5) + t * (t >> 14 & 14));
        }

        private byte GenerateBytebeatWeak(int t)
        {
            // Implementação de um som diferente para alternar
            return (byte)(2 * (t >> 5 & t) - (t >> 5) + t * (t >> 14 & 14));
        }
    }

    public class Beat2 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Beat2()
        {
            this.SetWaveFormat(10000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound; // Alterna para o próximo som na próxima leitura

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(t / 8 >> (t >> 9) * t / ((t >> 14 & 3) + 4));
        }

        private byte GenerateBytebeatWeak(int t)
        {
            // Implementação de um som diferente para alternar
            return (byte)(t / 8 >> (t >> 9) * t / ((t >> 14 & 3) + 4));
        }
    }

    public class Beat3 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Beat3()
        {
            this.SetWaveFormat(7000, 2); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound; // Alterna para o próximo som na próxima leitura

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)((t & t + t / 256) - t * (t >> 15) & 64);
        }

        private byte GenerateBytebeatWeak(int t)
        {
            // Implementação de um som diferente para alternar
            return (byte)((t & t + t / 256) - t * (t >> 15) & 64);
        }
    }

    public class Beat4 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Beat4()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound; // Alterna para o próximo som na próxima leitura

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)((t & t + t / 256) - t * (t >> 15) & 64);
        }

        private byte GenerateBytebeatWeak(int t)
        {
            // Implementação de um som diferente para alternar
            return (byte)((t & t + t / 256) - t * (t >> 15) & 64);
        }
    }
}
