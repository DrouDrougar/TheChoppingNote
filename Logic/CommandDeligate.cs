using System.Windows.Input;

namespace TheChoppingNote.Logic
{
    public class CommandDeligate : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Func<object?, bool?> canExecute;

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExicuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public CommandDeligate(Action<object?> execute, Func<object?, bool?>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return (bool)canExecute(parameter);
            };

        }

        public void Execute(object? parameter) => execute(parameter);
    }
}
