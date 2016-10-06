namespace RTFEditor
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.IO;
    using ColorPicker;

	public partial class RtfBox 
    {
        public RtfBox()
        {
            InitializeComponent();            
        }
          
	    public bool DataChanged; 
	    public string Text
        {
            get
            {
                var range = new TextRange(RichTextControl
                    .Document.ContentStart, RichTextControl.Document.ContentEnd);
                return range.Text;
            }
        }   
        private void RTFEditor_Loaded(object sender, RoutedEventArgs e)
        {
            var range = new TextRange(RichTextControl.Selection.Start, RichTextControl.Selection.End);
            Fonttype.SelectedValue = range.GetPropertyValue(FlowDocument.FontFamilyProperty).ToString();
            Fontheight.SelectedValue = range.GetPropertyValue(FlowDocument.FontSizeProperty).ToString();

            RichTextControl.Focus();
        }

        #region private ToolBarHandler
		private void ToolStripButtonPrint_Click(object sender, RoutedEventArgs e)
		{
		    var dlg = new PrintDialog 
            { PageRangeSelection = PageRangeSelection.AllPages, UserPageRangeEnabled = true };

            if (dlg.ShowDialog() == true)
            {
                dlg.PrintDocument((((IDocumentPaginatorSource)RichTextControl.Document).DocumentPaginator), "printing as paginator");
            }
		}

        private void ToolStripButtonStrikeout_Click(object sender, RoutedEventArgs e)
        {
            var range = new TextRange(RichTextControl.Selection.Start, RichTextControl.Selection.End);

            var tdc = (TextDecorationCollection)RichTextControl.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            if (tdc == null || !tdc.Equals(TextDecorations.Strikethrough))
            {
                tdc = TextDecorations.Strikethrough;

            }
            else
            {
                tdc = new TextDecorationCollection();
            }
            range.ApplyPropertyValue(Inline.TextDecorationsProperty, tdc);
        }

        //
        // ToolStripButton Textcolor 
        //
        private void ToolStripButtonTextcolor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new ColorDialog();
            var showDialog = colorDialog.ShowDialog();
            if (showDialog == null || !(bool)showDialog) return;
            var range = new TextRange(RichTextControl.Selection.Start, RichTextControl.Selection.End);

            range.ApplyPropertyValue(FlowDocument.ForegroundProperty, new SolidColorBrush(colorDialog.SelectedColor));
        }

        //
        // ToolStripButton Backgroundcolor 
        //
        private void ToolStripButtonBackcolor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new ColorDialog();
            var showDialog = colorDialog.ShowDialog();
            if (showDialog == null || !(bool)showDialog) return;
            var range = new TextRange(RichTextControl.Selection.Start, RichTextControl.Selection.End);

            range.ApplyPropertyValue(FlowDocument.BackgroundProperty, new SolidColorBrush(colorDialog.SelectedColor));
        }

        // ToolStripButton Subscript
        // http://msdn.microsoft.com/en-us/library/ms745109.aspx#variants
        private void ToolStripButtonSubscript_Click(object sender, RoutedEventArgs e)
        {
            var currentAlignment = RichTextControl.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);

            var newAlignment = ((BaselineAlignment)currentAlignment == BaselineAlignment.Subscript) ? BaselineAlignment.Baseline : BaselineAlignment.Subscript;
            RichTextControl.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
        }

        private void ToolStripButtonSuperscript_Click(object sender, RoutedEventArgs e)
        { 
	        var currentAlignment = RichTextControl.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);
    	 
	        var newAlignment = ((BaselineAlignment)currentAlignment == BaselineAlignment.Superscript) ? BaselineAlignment.Baseline : BaselineAlignment.Superscript;
	        RichTextControl.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
        }

        private void Fontheight_DropDownClosed(object sender, EventArgs e)
        {
            var fontHeight = (string)Fontheight.SelectedItem;

            if (fontHeight == null) return;
            RichTextControl.Selection.ApplyPropertyValue(FontSizeProperty, fontHeight);
            RichTextControl.Focus();
        }

        private void Fonttype_DropDownClosed(object sender, EventArgs e)
        {            
            var fontName = (string)Fonttype.SelectedItem;

            if (fontName == null) return;
            RichTextControl.Selection.ApplyPropertyValue(FontFamilyProperty, fontName);
            RichTextControl.Focus();
        }

        private void ToolStripButtonAlignLeft_Click(object sender, RoutedEventArgs e)
        {
            if (ToolStripButtonAlignLeft.IsChecked != true) return;
            ToolStripButtonAlignCenter.IsChecked = false;
            ToolStripButtonAlignRight.IsChecked = false;
        }

        //
        // Alignment status
        //
        private void ToolStripButtonAlignCenter_Click(object sender, RoutedEventArgs e)
        {
            if (ToolStripButtonAlignCenter.IsChecked != true) return;
            ToolStripButtonAlignLeft.IsChecked = false;
            ToolStripButtonAlignRight.IsChecked = false;
        }

        //
        // Alignment status 
        //
        private void ToolStripButtonAlignRight_Click(object sender, RoutedEventArgs e)
        {
            if (ToolStripButtonAlignRight.IsChecked != true) return;
            ToolStripButtonAlignCenter.IsChecked = false;
            ToolStripButtonAlignLeft.IsChecked = false;
        }

        #endregion private ToolBarHandler
        
        #region private RichTextBoxHandler
        
        //
        // Formating
        //
        private void RichTextControl_SelectionChanged(object sender, RoutedEventArgs e)
        {     
            var selectionRange = new TextRange(RichTextControl.Selection.Start, RichTextControl.Selection.End);
            
            
            ToolStripButtonBold.IsChecked = selectionRange.GetPropertyValue(FontWeightProperty).ToString() == "Bold";

            ToolStripButtonItalic.IsChecked = selectionRange.GetPropertyValue(FontStyleProperty).ToString() == "Italic";

            ToolStripButtonUnderline.IsChecked = Equals(selectionRange.GetPropertyValue(Inline.TextDecorationsProperty), TextDecorations.Underline);

            ToolStripButtonStrikeout.IsChecked = Equals(selectionRange.GetPropertyValue(Inline.TextDecorationsProperty), TextDecorations.Strikethrough); 

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Left")
            {
                ToolStripButtonAlignLeft.IsChecked = true;
            }

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Center")
            {
                ToolStripButtonAlignCenter.IsChecked = true;
            }

            if (selectionRange.GetPropertyValue(FlowDocument.TextAlignmentProperty).ToString() == "Right")
            {
                ToolStripButtonAlignRight.IsChecked = true;
            }
            
            // Sub-, Superscript Buttons
            try
            {                
                switch ((BaselineAlignment)selectionRange.GetPropertyValue(Inline.BaselineAlignmentProperty))
                {
                    case BaselineAlignment.Subscript:
                        ToolStripButtonSubscript.IsChecked = true;
                        ToolStripButtonSuperscript.IsChecked = false;
                        break;

                    case BaselineAlignment.Superscript:
                        ToolStripButtonSubscript.IsChecked = false;
                        ToolStripButtonSuperscript.IsChecked = true;
                        break;

                    default:
                        ToolStripButtonSubscript.IsChecked = false;
                        ToolStripButtonSuperscript.IsChecked = false;
                        break;
                }
            }
            catch (Exception) 
            {
                ToolStripButtonSubscript.IsChecked = false;
                ToolStripButtonSuperscript.IsChecked = false;
            }                    

            // Get selected font and height and update selection in ComboBoxes
            Fonttype.SelectedValue = selectionRange.GetPropertyValue(FlowDocument.FontFamilyProperty).ToString();
            Fontheight.SelectedValue = selectionRange.GetPropertyValue(FlowDocument.FontSizeProperty).ToString();

        }              

        private void RichTextControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataChanged = true;
        }

        //
        //  Font
        //
        private void RichTextControl_KeyDown(object sender, KeyEventArgs e)
        {
            DataChanged = true;

            var fontName = (string)Fonttype.SelectedValue;
            var fontHeight = (string)Fontheight.SelectedValue;
            var range = new TextRange(RichTextControl.Selection.Start, RichTextControl.Selection.End);

            range.ApplyPropertyValue(TextElement.FontFamilyProperty, fontName);
            range.ApplyPropertyValue(TextElement.FontSizeProperty, fontHeight);
        }

        private void RichTextControl_KeyUp(object sender, KeyEventArgs e)
        {
            // Ctrl + B
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.B))
            {
                ToolStripButtonBold.IsChecked = ToolStripButtonBold.IsChecked != true;
            }

            // Ctrl + I
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.I))
            {
                ToolStripButtonItalic.IsChecked = ToolStripButtonItalic.IsChecked != true;
            }

            // Ctrl + U
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.U))
            {
                ToolStripButtonUnderline.IsChecked = ToolStripButtonUnderline.IsChecked != true;
            }

            // Ctrl + O
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
            {
                ToolStripButtonOpen_Click(sender, e);
            }
        }

        #endregion private RichTextBoxHandler






        # region functionality
        private void ToolStripButtonOpen_Click(object sender, RoutedEventArgs e)
        {

            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = string.Empty,
                DefaultExt = ".rtf",
                Filter = "RichText documents (.rtf)|*.rtf|Text documents (.txt)|*.txt"
            };

            // Show open file dialog box
            var result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result != true) return;
            var path = dlg.FileName;

            SetRtf(path);

            // Open document
            if (!File.Exists(path)) return;
            var range = new TextRange(RichTextControl.Document.ContentStart, RichTextControl.Document.ContentEnd);
            var fStream = new FileStream(path, FileMode.OpenOrCreate);
            range.Load(fStream, DataFormats.Rtf);
            fStream.Close();
        }

        public void Clear()
        {            
            DataChanged = false;            
            RichTextControl.Document.Blocks.Clear();            
        }

        public void SetRtf(string rtf)
        {
            var range = new TextRange(RichTextControl.Document.ContentStart, RichTextControl.Document.ContentEnd);

            try
            {
                using (var rtfMemoryStream = new MemoryStream())
                {
                    using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                    {
                        rtfStreamWriter.Write(rtf);
                        rtfStreamWriter.Flush();
                        rtfMemoryStream.Seek(0, SeekOrigin.Begin);

                        range.Load(rtfMemoryStream, DataFormats.Rtf);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        #endregion functionality
    }
}