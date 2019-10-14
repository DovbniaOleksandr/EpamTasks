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
            Succeed = false;
            _ui = ui;
            Errors = new List<string>();
        }

        public bool Succeed { get; private set; }

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
                Succeed = false;
            }
            catch(DirectoryNotFoundException e)
            {
                Errors.Add(e.Message);
                Succeed = false;
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
                Succeed = false;
            }

            try
            {
                DirectoryVisualizer.FindTxtFileByPartialName(@"D:\Matlab", "t", new ConsoleUserInterface());
            }
            catch (ArgumentException e)
            {
                Errors.Add(e.Message);
                Succeed = false;
            }
        }
    }
}
