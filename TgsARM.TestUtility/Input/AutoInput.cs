using WindowsInput;
using WindowsInput.Native;
using System.Linq;
using Aquality.Selenium.Core.Logging;
using TgsARM.TestUtility.Configuration;

namespace TgsARM.TestUtility.Input
{

    public static class AutoInput
    {
        private const string configFilePath = @"Input\inputsimcfg.json";        

        private static InputSimulator sim = new InputSimulator();

        private static InputSimConfig simConfig;

        private static InputSimConfig SimConfig
        {
            get
            {
                if (simConfig is null)
                {
                    simConfig = ConfigManager.LoadConfig<InputSimConfig>(configFilePath);
                }

                return simConfig;
            }
        }

        public static void SimulateFileUpload(string fileAbsolutePath)
        {
            const int tabPressesToDirPath = 6;
            const int tabPressesToFileName = 6;
            
            Logger.Instance.Info($"Simulating file upload. File path: {fileAbsolutePath}.");
         
            if (fileAbsolutePath.Last() == '\\')
            {
                fileAbsolutePath = fileAbsolutePath.Substring(0, fileAbsolutePath.Length - 1);
            }

            var lastSlashIndex = fileAbsolutePath.LastIndexOf('\\');
            var dirPath = new string(fileAbsolutePath.Take(lastSlashIndex).ToArray());
            var fileName = new string(fileAbsolutePath.Skip(lastSlashIndex + 1).ToArray());

            PressKey(VirtualKeyCode.TAB, tabPressesToDirPath, SimConfig.ShortSleepTime);
            SelectFieldAndEnterText(dirPath);
            PressKey(VirtualKeyCode.TAB, tabPressesToFileName, SimConfig.ShortSleepTime);
            SelectFieldAndEnterText(fileName);
        }

        private static void SelectFieldAndEnterText(string text)
        {
            sim.Keyboard
                .KeyPress(VirtualKeyCode.RETURN)
                .Sleep(SimConfig.ShortSleepTime)
                .TextEntry(text)
                .KeyPress(VirtualKeyCode.RETURN)
                .Sleep(SimConfig.LongSleepTime);
        }

        private static void PressKey(VirtualKeyCode key, int pressCount, int pressIntervalInMillseconds)
        {
            for (int i = 0; i < pressCount; i++)
            {
                sim.Keyboard.KeyPress(key).Sleep(pressIntervalInMillseconds);
            }
        }
    }

}
