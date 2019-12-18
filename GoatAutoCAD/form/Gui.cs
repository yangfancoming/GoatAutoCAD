using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfWindow = System.Windows.Window;
using AcadApplication = Autodesk.AutoCAD.ApplicationServices.Application;
using GoatAutoCAD.baseutil;


namespace GoatAutoCAD.form {

    public static class Gui {

        /// <summary>
        /// Shows a GetChoices window.
        /// </summary>
        /// <param name="tip">The tip.</param>
        /// <param name="choices">The choices.</param>
        /// <returns>The final choices.</returns>
        public static string[] GetChoices(string tip, string[] choices)
        {
            var window = new WpfWindow
            {
                Width = 300,
                SizeToContent = SizeToContent.Height,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowInTaskbar = false,
                WindowStyle = WindowStyle.ToolWindow,
                Title = "Choices"
            };

            var stackPanel = new StackPanel
            {
                Margin = new Thickness(10)
            };

            var textBlock = new TextBlock
            {
                Text = (tip == string.Empty ? "Please check items..." : tip),
                TextWrapping = TextWrapping.Wrap
            };

            var listBox = new ListBox
            {
                Height = 200
            };

            choices.ForEach(choice => listBox.Items.Add(new CheckBox
            {
                Content = choice
            }));

            var okButton = new Button
            {
                Content = "OK",
                Margin = new Thickness(5)
            };

            okButton.Click += (s, args) => window.DialogResult = true;
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(listBox);
            stackPanel.Children.Add(okButton);
            window.Content = stackPanel;

            AcadApplication.ShowModalWindow(window);
            return listBox.Items
                .Cast<CheckBox>()
                .Where(checkBox => checkBox.IsChecked == true)
                .Select(checkBox => checkBox.Content.ToString())
                .ToArray();
        }
    }
}