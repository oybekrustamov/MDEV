using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MDEV.Model;
using System.IO;

namespace MDEV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        List<Test> tests;
        int[,] VariantArray;

        int step = 0;

        int Score=0;
        
        public TestPage()
        {
            InitializeComponent();
            BeginTests();
            NextQuestion();
            Rate.Text = "[0 балл]";
        }
        private void BeginTests()
        {
            tests = new List<Test>();
            tests = Service.ServiceTest.GetTests();
            VariantArray = new int[30, 4];
            int i = 0;
            foreach (Test test in tests)
            {
                Random rand = new Random();
                int r = rand.Next(1, 4);
                string k = test.Answers[0];
                test.Answers[0] = test.Answers[r];
                test.Answers[r] = k;
                VariantArray[i++, r] = 1;
            }
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Answers.CheckedItem.IsChecked ?? true)
                {
                    if (Answer_A.IsChecked ?? true)
                    {
                        Answer_A.IsChecked = false;
                        if (VariantArray[step, 0] == 1)
                        {
                            Score++;
                        }
                    }
                    else if (Answer_B.IsChecked ?? true)
                    {
                        Answer_B.IsChecked = false;
                        if (VariantArray[step, 1] == 1)
                        {
                            Score++;
                        }
                    }
                    else if (Answer_C.IsChecked ?? true)
                    {
                        Answer_C.IsChecked = false;
                        if (VariantArray[step, 2] == 1)
                        {
                            Score++;
                        }
                    }
                    else if (Answer_D.IsChecked ?? true)
                    {
                        Answer_D.IsChecked = false;
                        if (VariantArray[step, 3] == 1)
                        {
                            Score++;
                        }
                    }
                    Rate.Text = "["+Score+" балл]";
                    step++;
                    CheckQuestions();
                    NextQuestion();
                }
            }
            catch
            {

            }
        }
        private void NextQuestion()
        {
            if(tests.Count > 0)
            {
                Test test = tests.First();
                Question.Text = test.Question;
                Answer_A.Text = "A: "+test.Answers[0];
                Answer_B.Text = "B: "+test.Answers[1];
                Answer_C.Text = "C: "+test.Answers[2];
                Answer_D.Text = "D: "+test.Answers[3];
                tests.RemoveAt(0);
            }  
        }
        private void CheckQuestions()
        {
            if(tests.Count == 0)
            {
                Navigation.PopToRootAsync();
            } 
        }

        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        protected override bool OnBackButtonPressed()
        {
            try
            {
                StreamWriter write = new StreamWriter(folderPath+"/mdev_score");
                write.WriteLine(Score.ToString());
                write.Close();
            }
            catch(Exception ex)
            {

            }

            return base.OnBackButtonPressed();
        }
    }
}