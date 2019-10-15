using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UI;

namespace IO
{
    public class DirectoriesRunner:IRunner
    {
        public DirectoriesRunner(UserInterface ui)
        {
            _ui = ui;
            Errors = new List<string>();
        }

        public IList<string> Errors { get; private set; }

        public UserInterface _ui { get; private set; }

        public void Run()
        {

            try
            {
                DirectoryVisualizer.GetContentFromDirectory(@"D:\Vikings.(S02).1080p.NewStudio", new ConsoleUserInterface(), 0);
            }
            catch (ArgumentException e)
            {
                Errors.Add(e.Message);
            }
            catch(DirectoryNotFoundException e)
            {
                Errors.Add(e.Message);          
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }

            try
            {
                DirectoryVisualizer.FindTxtFileByPartialName(@"D:\Matlab", "t", new ConsoleUserInterface());
            }
            catch (ArgumentException e)
            {
                Errors.Add(e.Message);
            }
        }
    }
}
