using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Pit_Engineer {
    /// <summary>
    /// Interaction logic for QuestionUC.xaml
    /// </summary>
    public partial class QuestionUC : UserControl {
        struct ButtonDataStruct {
            public int questionID;
            public string catName;
            public ButtonDataStruct(int quest, string category) {
                questionID = quest;
                catName = category;
            }
        }
        public QuestionUC() {
            InitializeComponent();
            GeneratePage("None", 0);
        }

        private void BackClick(object sender, RoutedEventArgs e) {
            FrameworkElement obj = sender as FrameworkElement;
            MainWindow main = App.Current.MainWindow as MainWindow;
            main.tsMain.SelectedIndex = 0;
        }
        private void AnswerClick(object sender, RoutedEventArgs e) {
            FrameworkElement obj = sender as FrameworkElement;
            MainWindow main = App.Current.MainWindow as MainWindow;
            Transitioner trans = main.tsMain;
            
            ButtonDataStruct btnData = (ButtonDataStruct)obj.Tag;
            if (btnData.questionID == 0 && btnData.catName == "") {
                trans.SelectedIndex = 0;
            }
            else if (btnData.catName != "") {
                GeneratePage(btnData.catName, btnData.questionID);
            }
            else {
                GeneratePage(lblCategory.Content.ToString(), btnData.questionID);
            }
        }

        public void GeneratePage(string category, int question) {
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load("PitEngineer_data.xml");
            }
            catch (System.IO.FileNotFoundException e) {
                tbDescription.Text = e.Message;
                return;
            }
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("tel", "http://tempuri.org/PitEngineer_Schema.xsd");
            XmlNode cat = doc.SelectSingleNode("//tel:Category[@Name='" + category + "']", nsmgr);
            if (cat == null) {
                lblCategory.Content = "Could not find category with name: " + category;
                return;
            }
            lblCategory.Content = category;
            XmlNode quest = cat.SelectSingleNode("tel:Question[@QuestionID='" + question + "']", nsmgr);
            if (quest == null) {
                tbDescription.Text = "Could not find question with ID: " + question;
                return;
            }

            tbDescription.Text = quest.FirstChild.InnerText;
            XmlNodeList answerNodes = quest.SelectNodes("tel:Answer", nsmgr);
            spAnswers.Children.Clear();
            foreach (XmlNode n in answerNodes) {
                Button btnN = new Button();
                if (!int.TryParse(n.Attributes["QuestionRef"].Value, out int questID)) { continue; }
                XmlNode catRef = n.SelectSingleNode("tel:CategoryRef", nsmgr);
                string catRefname = "";
                if (catRef != null) {
                    catRefname = catRef.InnerText;
                }
                btnN.Name = "btn" + questID;
                btnN.Tag = new ButtonDataStruct(questID, catRefname);
                btnN.Content = n.FirstChild.InnerText;
                btnN.FontSize = 18;
                btnN.Margin = new Thickness(0, 0, 0, 10);
                btnN.Click += new RoutedEventHandler(AnswerClick);
                spAnswers.Children.Add(btnN);
            }
            if (spAnswers.Children.Count == 0) {
                Label lab = new Label();
                lab.Name = "lblNoAnswers";
                lab.Content = "No answers found for this question.";
                lab.FontSize = 18;
                lab.VerticalAlignment = VerticalAlignment.Center;
                lab.HorizontalAlignment = HorizontalAlignment.Center;
                spAnswers.Children.Add(lab);
            }
        }
    }
}
