using System;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;

namespace speech
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Output information about all of the installed voices. 
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    string AudioFormats = "";
                    foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
                    {
                        AudioFormats += String.Format("{0}\n",
                        fmt.EncodingFormat.ToString());
                    }

                    Console.WriteLine(" Name:          " + info.Name);
                    Console.WriteLine(" Culture:       " + info.Culture);
                    Console.WriteLine(" Age:           " + info.Age);
                    Console.WriteLine(" Gender:        " + info.Gender);
                    Console.WriteLine(" Description:   " + info.Description);
                    Console.WriteLine(" ID:            " + info.Id);
                    Console.WriteLine(" Enabled:       " + voice.Enabled);
                    if (info.SupportedAudioFormats.Count != 0)
                    {
                        Console.WriteLine(" Audio formats: " + AudioFormats);
                    }
                    else
                    {
                        Console.WriteLine(" No supported audio formats found");
                    }

                    string AdditionalInfo = "";
                    foreach (string key in info.AdditionalInfo.Keys)
                    {
                        AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
                    }

                    Console.WriteLine(" Additional Info - " + AdditionalInfo);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            SpeechSynthesizer synth2 = new SpeechSynthesizer();
            synth2.SelectVoice("Microsoft Helena Desktop");
            //synth2.SelectVoice("Microsoft Zira Desktop");
            while (true)
            {
                Console.WriteLine("Escriba el texto a pronunciar: ");
                string texto = Console.ReadLine();
                synth2.Speak(texto);
            }
            synth2.Speak("Hola, esto es una prueba");
            synth2.SelectVoice("Microsoft Sabina Desktop");
            //synth2.Speak("esta será la voz seleccionada como el asistente de Gabo");
        }
    }
}
