namespace DictIt.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Commands;
    using Common;
    using Data;
    using Model;

    public class DictionaryViewModel : BaseViewModel
    {
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        private RelayCommand editCommand;
        private RelayCommand voiceCommand;
        
        private IDictionary<string, string> terms;
        private ObservableCollection<string> namesList;

        private string searchSample;

        private string contentAddBtn = "Add";
        private bool isAddVisible = false;

        private string selectedItemDescription;
        private string selectedItem;

        private string labelName = null;

        private string termToAdd = null;
        private string descriptionToAdd = null;


        //================================================================

        public DictionaryViewModel() : this(new SortedDictionary<string, string>(), new List<string>())
        {
        }

        public DictionaryViewModel(IDictionary<string, string> terms, IList<string> names)
        {
            this.Terms = DataProvider.TakeTermsFromXml(Const.PathToTerms);
            this.Names = DataProvider.TakeNamesFromXml(Const.PathToTerms);
        }

        //================================================================

        public string TermToAdd
        {
            get
            {
                return this.termToAdd;
            }
            set
            {
                this.termToAdd = value;
                OnPropertyChanged("TermToAdd");
            }
        }
        public string DescriptionToAdd
        {
            get
            {
                return this.descriptionToAdd;
            }
            set
            {
                this.descriptionToAdd = value;
                OnPropertyChanged("DescriptionToAdd");
            }
        }


        public string SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                if (value != null)
                {
                    this.labelName = value;
                }
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("LabelName");
            }
        }
        public string SelectedItemDescription
        {
            get
            {
                return this.selectedItemDescription;
            }
            set
            {
                this.selectedItemDescription = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public string LabelName
        {
            get
            {
                return this.labelName;
            }
            set
            {
                this.labelName = value;
                OnPropertyChanged("LabelName");
                if (value != null)
                {
                    this.selectedItemDescription = this.Terms[value];
                    OnPropertyChanged("SelectedItemDescription");
                }
            }
        }

        public string SearchSample
        {
            get
            {
                return this.searchSample;
            }
            set
            {
                this.searchSample = value;
                OnPropertyChanged("SearchSample");
            }
        }

        public string ContentAddBtn
        {
            get
            {
                return this.contentAddBtn;
            }
            set
            {
                this.contentAddBtn = value;
                OnPropertyChanged("ContentAddBtn");
            }
        }

        public bool IsAddVisible
        {
            get
            {
                return this.isAddVisible;
            }
            set
            {
                if (this.isAddVisible != value)
                {
                    this.isAddVisible = value;
                    OnPropertyChanged("IsAddVisible");
                }
            }
        }

        public ObservableCollection<string> Names
        {
            get
            {
                return this.namesList;
            }
            set
            {
                this.namesList = value;
                OnPropertyChanged("Names");
            }
        }

        public IDictionary<string, string> Terms
        {
            get
            {
                return this.terms;
            }
            set
            {
                this.terms = value;
                OnPropertyChanged("Terms");
            }
        }

        //================================================================

        public ICommand AddCommand
        {
            get { return this.addCommand ?? (this.addCommand = new RelayCommand(this.HandleAddCommand)); }
        }
        private void HandleAddCommand(object obj)
        {
            if (!this.IsAddVisible)
            {
                this.ContentAddBtn = "Save";
            }
            else
            {
                var term = new Term(this.TermToAdd, this.DescriptionToAdd);

                if (this.TermToAdd != null)
                {
                    DataProvider.AddToXml(Const.PathToTerms, term);
                    if (!this.Names.Contains(this.TermToAdd))
                    {
                        this.Names.Add(this.TermToAdd);
                        this.Names = new ObservableCollection<string>(this.Names.OrderBy(i => i));
                        this.Terms.Add(this.TermToAdd, this.DescriptionToAdd);
                    }
                    else
                    {
                        this.Terms[this.TermToAdd] = this.DescriptionToAdd;
                    }
                    MessageBox.Show(Logger.ItemSaved(this.TermToAdd));
                }
                this.ContentAddBtn = "Add";
            }
            this.IsAddVisible = !this.IsAddVisible;
        }

        public ICommand DeleteCommand
        {
            get { return this.deleteCommand ?? (this.deleteCommand = new RelayCommand(this.HandleDeleteCommand)); }
        }
        private void HandleDeleteCommand(object obj)
        {
            MessageBox.Show("Not implemented");
        }

        public ICommand EditCommand
        {
            get { return this.editCommand ?? (this.editCommand = new RelayCommand(this.HandleEditCommand)); }
        }
        private void HandleEditCommand(object obj)
        {
            MessageBox.Show("Not implemented");
        }

        public ICommand VoiceCommand
        {
            get { return this.voiceCommand ?? (this.voiceCommand = new RelayCommand(this.HandleVoiceCommand)); }
        }
        private void HandleVoiceCommand(object obj)
        {
            TextManager.SpeakTextFemale(this.LabelName + ", " + this.SelectedItemDescription);
        }
    }
}
