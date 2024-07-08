using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CommonLib.Controls
{
    public partial class PilotMessageBox
    {
        private MessageBoxResult _result = MessageBoxResult.None;

        private static ImageSource _iconSource;


        public PilotMessageBox()
        {
            InitializeComponent();
        }

        void AddButtons(MessageBoxButton buttons)
        {
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    AddButton("OK", MessageBoxResult.OK, isDefault: true);
                    break;

                case MessageBoxButton.OKCancel:
                    AddButton("OK", MessageBoxResult.OK, isDefault: true);
                    AddButton("Отмена", MessageBoxResult.Cancel, isCancel: true);
                    break;

                case MessageBoxButton.YesNo:
                    AddButton("Да", MessageBoxResult.Yes, isDefault: true);
                    AddButton("Нет", MessageBoxResult.No);
                    break;

                case MessageBoxButton.YesNoCancel:
                    AddButton("Да", MessageBoxResult.Yes, isDefault: true);
                    AddButton("Нет", MessageBoxResult.No);
                    AddButton("Отмена", MessageBoxResult.Cancel, isCancel: true);
                    break;
                default:
                    throw new ArgumentException("Unknown button value", "buttons");
            }
        }

        void AddButton(string text, MessageBoxResult result, bool isCancel = false, bool isDefault = false)
        {
            var button = new Button()
            {
                Content = text,
                IsCancel = isCancel,
                IsDefault = isDefault
            };

            button.Click += (o, args) =>
            { 
                _result = result;
                DialogResult = true;
            };
            
            ButtonContainer.Children.Add(button);
        }


        public static MessageBoxResult Show(string message,
                                            string caption,
                                            MessageBoxButton buttons
                                            )
        {

            var dialog = new PilotMessageBox();

            if (!string.IsNullOrWhiteSpace(caption))
            {
                dialog.Title = caption;
            }

            dialog.MessageContainer.Text = message;
            dialog.AddButtons(buttons);

            if (_iconSource != null)
            {
                dialog.Icon.Source = _iconSource;
                dialog.Icon.Visibility = Visibility.Visible;
            }

            dialog.ShowDialog();

            return dialog._result;
        }


        public static MessageBoxResult Show(string message,
                                            string caption = null,
                                            MessageBoxButton buttons = MessageBoxButton.OK,
                                            MessageBoxImage image = MessageBoxImage.None
                                            )
        {
            Icon icon = null;

            switch (image)
            {
                case MessageBoxImage.None:
                    break;

                case MessageBoxImage.Hand:
                    icon = SystemIcons.Hand;
                    break;
                
                case MessageBoxImage.Question:
                    icon = SystemIcons.Question;
                    break;

                case MessageBoxImage.Warning:
                    icon = SystemIcons.Warning;
                    break;

                case MessageBoxImage.Information:
                    icon = SystemIcons.Information;
                    //icon = SystemIcons.N;
                    break;

                //default: break;
            };

            if (icon != null)
            {
                _iconSource = Imaging.CreateBitmapSourceFromHIcon(
                        icon.Handle,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
            }


            return Show(message,
                        caption,
                        buttons);
        }
    }
}