namespace DictIt.Commands
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly ExecuteDelegate execute;
        private readonly CanExecuteDelegate canExecute;

        public RelayCommand(ExecuteDelegate execute)
            : this(execute, null)
        {

        }
        public RelayCommand(ExecuteDelegate execute, CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
